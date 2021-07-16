using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class FormStatisticsList : Form
    {
        /// <summary>
        /// this form is singleton, variable open record whether the this window is opened or not
        /// </summary>
        public static bool open;

        List<RowItem> rawList = new List<RowItem>();

        public FormStatisticsList()
        {
            InitializeComponent();
        }

        private void FormStatisticsList_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.logo64;

            // load language
            LoadLanguage();

            // arrange components
            if (Configure.stayOnTopStatistics == 1)
            {
                checkBoxTop.Checked = true;
                this.TopMost = true;
            }
            this.Height = Configure.statisticsFormHeight;
            ArrangeComponentsLocationByFormHeight();

            // fill in the table
            InitializeStatisticsList();
            RefreshStatisticsList();
        }

        public void LoadLanguage()
        {
            this.Text = Language.GetText("statistics_list");
            btnClose.Text = Language.GetText("close");
            btnRefresh.Text = Language.GetText("refresh");
            btnExport.Text = Language.GetText("export");
            checkBoxTop.Text = Language.GetText("stay_on_top");
        }

        public void InitializeStatisticsList() {
            string orderLabel = "";
            if (Configure.statisticsOrderMethod == 0)
                orderLabel = "▲";   //ascending
            else if (Configure.statisticsOrderMethod == 1)
                orderLabel = "▼";    //descending
            string column0 = Language.GetText("key_code");
            string column1 = Language.GetText("key_char");
            string column2 = Language.GetText("key_name");
            string column3 = Language.GetText("mode_current");
            string column4 = Language.GetText("mode_total");
            switch (Configure.statisticsOrderColumn)
            {
                case 0:
                    column0 += orderLabel;
                    break;
                case 1:
                    column1 += orderLabel;
                    break;
                case 2:
                    column2 += orderLabel;
                    break;
                case 3:
                    column3 += orderLabel;
                    break;
                case 4:
                    column4 += orderLabel;
                    break;
                default:
                    break;
            }
            listViewStatistics.Clear();
            listViewStatistics.Columns.Add(column0, -1, HorizontalAlignment.Left);
            listViewStatistics.Columns.Add(column1, -1, HorizontalAlignment.Left);
            listViewStatistics.Columns.Add(column2, -1, HorizontalAlignment.Left);
            listViewStatistics.Columns.Add(column3, -1, HorizontalAlignment.Left);
            listViewStatistics.Columns.Add(column4, -1, HorizontalAlignment.Left);
        }

        public void InitializeRawList()
        {
            // add data
            rawList.Clear();
            for (int i = 0; i < Keyboard.keyChar.Count; i++)
            {
                RowItem rowItem = new RowItem();
                rowItem.KeyCode = Keyboard.keyChar.ElementAt(i).Key;
                rowItem.KeyChar = Keyboard.keyChar.ElementAt(i).Value;
                rowItem.KeyName = Keyboard.keyName.ElementAt(i).Value;
                rowItem.Current = Keyboard.keyCountCurrent.ElementAt(i).Value;
                rowItem.Total = Keyboard.keyCount.ElementAt(i).Value;
                rawList.Add(rowItem);
            }

            // sort
            switch (Configure.statisticsOrderColumn)
            {
                case 0:
                    if (Configure.statisticsOrderMethod == 0)
                        rawList = rawList.OrderBy(o => o.KeyCode).ToList();
                    else if (Configure.statisticsOrderMethod == 1)
                        rawList = rawList.OrderByDescending(o => o.KeyCode).ToList();
                    break;
                case 1:
                    if (Configure.statisticsOrderMethod == 0)
                        rawList = rawList.OrderBy(o => o.KeyChar).ToList();
                    else if (Configure.statisticsOrderMethod == 1)
                        rawList = rawList.OrderByDescending(o => o.KeyChar).ToList();
                    break;
                case 2:
                    if (Configure.statisticsOrderMethod == 0)
                        rawList = rawList.OrderBy(o => o.KeyName).ToList();
                    else if (Configure.statisticsOrderMethod == 1)
                        rawList = rawList.OrderByDescending(o => o.KeyName).ToList();
                    break;
                case 3:
                    if (Configure.statisticsOrderMethod == 0)
                        rawList = rawList.OrderBy(o => o.Current).ToList();
                    else if (Configure.statisticsOrderMethod == 1)
                        rawList = rawList.OrderByDescending(o => o.Current).ToList();
                    break;
                case 4:
                    if (Configure.statisticsOrderMethod == 0)
                        rawList = rawList.OrderBy(o => o.Total).ToList();
                    else if (Configure.statisticsOrderMethod == 1)
                        rawList = rawList.OrderByDescending(o => o.Total).ToList();
                    break;
                default:
                    break;
            }

        }

        //public void RefreshStatisticsList()
        //{
        //    listViewStatistics.Items.Clear();
        //    ListViewItem[] items = new ListViewItem[Keyboard.keyChar.Count];
        //    for (int i = 0; i < Keyboard.keyChar.Count; i++)
        //    {
        //        ListViewItem item = new ListViewItem(Keyboard.keyChar.ElementAt(i).Key.ToString(), 0);  // key code
        //        item.SubItems.Add(Keyboard.keyChar.ElementAt(i).Value);                                 // key char
        //        item.SubItems.Add(Keyboard.keyName.ElementAt(i).Value);                                 // key name
        //        item.SubItems.Add(Keyboard.keyCountCurrent.ElementAt(i).Value.ToString());
        //        item.SubItems.Add(Keyboard.keyCount.ElementAt(i).Value.ToString());
        //        items[i] = item;
        //    }
        //    listViewStatistics.Items.AddRange(items);
        //    listViewStatistics.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    listViewStatistics.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //}

        public void RefreshStatisticsList()
        {
            InitializeStatisticsList();
            listViewStatistics.Items.Clear();
            InitializeRawList();
            ListViewItem[] items = new ListViewItem[Keyboard.keyChar.Count];
            int i = 0;
            foreach (RowItem row in rawList)
            {
                ListViewItem item = new ListViewItem(row.KeyCode.ToString(), 0);
                item.SubItems.Add(row.KeyChar);
                item.SubItems.Add(row.KeyName);
                item.SubItems.Add(row.Current.ToString());
                item.SubItems.Add(row.Total.ToString());
                items[i] = item;
                ++i;
            }
            listViewStatistics.Items.AddRange(items);
            listViewStatistics.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewStatistics.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStatisticsList.open = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshStatisticsList();
        }

        private void FormStatisticsList_Resize(object sender, EventArgs e)
        {
            Configure.statisticsFormHeight = this.Height;
            ArrangeComponentsLocationByFormHeight();
            Storage.WriteConfigurationToFile();
        }
        private void ArrangeComponentsLocationByFormHeight()
        {
            int height = this.Height;
            listViewStatistics.Height = height - 74;
            checkBoxTop.Location = new Point(checkBoxTop.Location.X, height - 74 + 10);
            btnClose.Location = new Point(btnClose.Location.X, height - 74 + 6);
            btnRefresh.Location = new Point(btnRefresh.Location.X, height - 74 + 6);
            btnExport.Location = new Point(btnExport.Location.X, height - 74 + 6);
        }

        private void checkBoxTop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTop.Checked)
            {
                this.TopMost = true;
                Configure.stayOnTopStatistics = 1;
            }
            else
            {
                this.TopMost = false;
                Configure.stayOnTopStatistics = 0;
            }
            Storage.WriteConfigurationToFile();
        }

        private void FormStatisticsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                FormStatisticsList.open = false;
            }
        }

        private void listViewStatistics_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (Configure.statisticsOrderColumn == e.Column)
            {
                if (Configure.statisticsOrderMethod == 0)
                    Configure.statisticsOrderMethod = 1;
                else
                    Configure.statisticsOrderMethod = 0;
            }
            else
            {
                Configure.statisticsOrderColumn = e.Column;
                Configure.statisticsOrderMethod = 0;
            }
            RefreshStatisticsList();
            Storage.WriteConfigurationToFile();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            RefreshStatisticsList();
            saveFileDialog1.Filter = Language.GetText("txt_filter");
            saveFileDialog1.FileName = DateTime.Now.ToString("MM-dd-yyyy--HH_MM_ss");
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName))
                {
                    string column0 = Language.GetText("key_code");
                    string column1 = Language.GetText("key_char");
                    string column2 = Language.GetText("key_name");
                    string column3 = Language.GetText("mode_current");
                    string column4 = Language.GetText("mode_total");
                    if (Configure.language == 0)
                    {
                        sw.WriteLine(
                            string.Format("{0, -15}", column0) +
                            string.Format("{0, -15}", column1) +
                            string.Format("{0, -20}", column2) +
                            string.Format("{0, -20}", column3) +
                            string.Format("{0, -20}", column4));
                    }
                    else if (Configure.language == 1)
                    {
                        sw.WriteLine(
                            string.Format("{0, -12}", column0) +
                            string.Format("{0, -12}", column1) +
                            string.Format("{0, -17}", column2) +
                            string.Format("{0, -15}", column3) +
                            string.Format("{0, -20}", column4));
                    }
                    foreach (var item in rawList)
                    {
                        sw.WriteLine(
                            string.Format("{0, -15}", item.KeyCode) + 
                            string.Format("{0, -15}", item.KeyChar) + 
                            string.Format("{0, -20}", item.KeyName) +
                            string.Format("{0, -20}", item.Current) + 
                            string.Format("{0, -20}", item.Total));
                    }
                }
            }
        }
    }

    class RowItem
    {
        private int keyCode;
        private string keyChar;
        private string keyName;
        private ulong current;
        private ulong total;

        public int KeyCode { get { return keyCode; } set { keyCode = value; } }
        public string KeyChar { get { return keyChar; } set { keyChar = value; } }
        public string KeyName { get { return keyName; } set { keyName = value; } }
        public ulong Current { get { return current; } set { current = value; } }
        public ulong Total { get { return total; } set { total = value; } }

    }
}
