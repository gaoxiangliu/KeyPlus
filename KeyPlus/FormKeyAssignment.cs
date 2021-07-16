using System;
using System.Linq;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormKeyAssignment : Form
    {
        /// <summary>
        /// this form is singleton, variable open record whether the this window is opened or not
        /// </summary>
        public static bool open;

        private string comboKeyString;
        private bool boolHotKeyFlag = true;

        public static string[] assignmentType;

        public FormKeyAssignment()
        {
            InitializeComponent();
        }

        private void FormKeyAssignment_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo64;
            this.Height = Configure.keyAssignmentFormHeight;
            ArrangeComponentsLocationByFormHeight();
            assignmentType = new string[] {
                Language.GetText("display_main"),
                Language.GetText("volume_up"),
                Language.GetText("volume_down"),
                Language.GetText("mute"),
                Language.GetText("execute_program") };
            LoadLanguage();
            InitializeList();
            RefreshList();
            InitializeComboAssignment();
            groupBox.Enabled = false;
            btnDelete.Enabled = false;
    }

        private void LoadLanguage()
        {
            this.Text = Language.GetText("menu_key_assignment");
            lblAssignment.Text = Language.GetText("assignment");
            lblHotKey.Text = Language.GetText("hot_key");
            lblIndex.Text = Language.GetText("index");
            lblPath.Text = Language.GetText("path");
            btnClose.Text = Language.GetText("close");
            btnDelete.Text = Language.GetText("delete");
            btnNew.Text = Language.GetText("new");
            groupBox.Text = Language.GetText("add_new_assignment");
            btnBrowse.Text = Language.GetText("browse");
            btnSave.Text = Language.GetText("save");
        }

        public void InitializeList()
        {
            listView.Clear();
            listView.Columns.Add(Language.GetText("index"), -1, HorizontalAlignment.Left);
            listView.Columns.Add(Language.GetText("hot_key"), -1, HorizontalAlignment.Left);
            listView.Columns.Add(Language.GetText("assignment"), -1, HorizontalAlignment.Left);
            listView.Columns.Add(Language.GetText("path"), -1, HorizontalAlignment.Left);
        }

        private void InitializeComboAssignment()
        {
            comboBoxAssignment.Items.Clear();
            comboBoxAssignment.Items.AddRange(assignmentType);
        }

        public void RefreshList()
        {
            listView.Items.Clear();
            ListViewItem[] items = new ListViewItem[KeyAssignment.combinationKey.Count];
            for (int i = 0; i < KeyAssignment.combinationKey.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString(), 0);
                item.SubItems.Add(KeyAssignment.ConvertComboStringToNormalString(KeyAssignment.combinationKey.ElementAt(i).Key));
                item.SubItems.Add(KeyAssignment.GetAssignmentType(KeyAssignment.combinationKey.ElementAt(i).Value));
                item.SubItems.Add(KeyAssignment.GetProgramPath(KeyAssignment.combinationKey.ElementAt(i).Value));
                items[i] = item;
            }
            listView.Items.AddRange(items);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKeyAssignment.open = false;
        }

        private void FormKeyAssignment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                FormKeyAssignment.open = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
                txtPath.Text = openFileDialog1.FileName;
        }

        private void txtHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyAssignment.IsFunctionKey(e.KeyValue))
            {
                txtHotKey.Text = KeyAssignment.GetFunctionKeyString();
                boolHotKeyFlag = true;
            }
            else
            {
                if (txtHotKey.Text.Length > 0 && boolHotKeyFlag)
                {
                    txtHotKey.Text += ("+" + Keyboard.keyChar[e.KeyValue]);
                }
                else if ((txtHotKey.Text.Length > 0 && !boolHotKeyFlag) || txtHotKey.Text.Length == 0)
                {
                    txtHotKey.Text = Keyboard.keyChar[e.KeyValue];
                }
                comboKeyString = KeyAssignment.GetCombinationKeyString(e.KeyValue);
                boolHotKeyFlag = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            groupBox.Visible = true;
            groupBox.Enabled = true;
            comboKeyString = "";
            boolHotKeyFlag = true;
            lblTextIndex.Text = "";
            txtHotKey.Text = "";
            txtPath.Text = "";
            txtPath.Enabled = false;
            btnBrowse.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void comboBoxAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAssignment.SelectedIndex == 4)
            {
                // execute a program
                txtPath.Enabled = true;
                btnBrowse.Enabled = true;
            }
            else
            {
                txtPath.Enabled = false;
                btnBrowse.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // verify
            if (comboKeyString.Length == 0)
            {
                MessageBox.Show(Language.GetText("hot_key_warn"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (KeyAssignment.IsComboExist(comboKeyString))
            {
                MessageBox.Show(Language.GetText("hot_key_duplicated"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAssignment.SelectedIndex < 0)
            {
                MessageBox.Show(Language.GetText("assignment_type_warn"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAssignment.SelectedIndex == 4 && txtPath.Text.Length == 0)
            {
                MessageBox.Show(Language.GetText("path_warn"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // make command string
            string cmd = "";
            switch (comboBoxAssignment.SelectedIndex)
            {
                case 0:
                    cmd = "restore";
                    break;
                case 1:
                    cmd = "vup";
                    break;
                case 2:
                    cmd = "vdown";
                    break;
                case 3:
                    cmd = "vmute";
                    break;
                case 4:
                    cmd = "exe " + txtPath.Text;
                    break;
                default:
                    MessageBox.Show(Language.GetText("unknown_error"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            KeyAssignment.combinationKey.Add(comboKeyString, cmd);
            MessageBox.Show(Language.GetText("success"), Language.GetText("info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            groupBox.Enabled = false;
            comboKeyString = "";
            lblTextIndex.Text = "";
            txtHotKey.Text = "";
            txtPath.Text = "";
            RefreshList();
            Storage.WriteKeyAssignmentToFile();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = -1;
            try
            {
                // item selected
                index = listView.SelectedItems[0].Index;
                btnDelete.Enabled = true;
                groupBox.Enabled = false;
                lblTextIndex.Text = (index + 1).ToString();
                comboBoxAssignment.Select(KeyAssignment.GetAssignmentCode(KeyAssignment.combinationKey.ElementAt(index).Value), 1);
                txtHotKey.Text = KeyAssignment.ConvertComboStringToNormalString(KeyAssignment.combinationKey.ElementAt(index).Key);
                txtPath.Text = KeyAssignment.GetProgramPath(KeyAssignment.combinationKey.ElementAt(index).Value);
            }
            catch
            {
                // click blank area of the list, no item selected
                btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listView.SelectedItems[0].Index;
                var result = MessageBox.Show(Language.GetText("delete_assignment_alert"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    KeyAssignment.combinationKey.Remove(KeyAssignment.combinationKey.ElementAt(index).Key);
                    MessageBox.Show(Language.GetText("success"), Language.GetText("info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshList();
                    Storage.WriteKeyAssignmentToFile();
                    comboKeyString = "";
                    lblTextIndex.Text = "";
                    txtHotKey.Text = "";
                    txtPath.Text = "";
                }
            }
            catch 
            {
                MessageBox.Show(Language.GetText("unknown_error"), Language.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArrangeComponentsLocationByFormHeight()
        {
            listView.Height = this.Height - 199;
            btnClose.Top = this.Height - 180;
            btnNew.Top = this.Height - 180;
            btnDelete.Top = this.Height - 180;
            groupBox.Top = this.Height - 151;
        }

        private void FormKeyAssignment_Resize(object sender, EventArgs e)
        {
            ArrangeComponentsLocationByFormHeight();
            Configure.keyAssignmentFormHeight = this.Height;
            Storage.WriteConfigurationToFile();
        }
    }
}
