using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// true: files will be saved on exit, flase: filles won't be saved
        /// for most cases, true. False only happens when fail to read files
        /// </summary>
        private bool saveOnExitFlag = true;

        GlobalKeyboardHook gkh = new GlobalKeyboardHook();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        // for keybaord LED indicator status
        private static bool indicatorCapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
        private static bool indicatorNumLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
        private static bool indicatorScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
        private static bool pressNumLock = false;
        private static bool pressCapsLock = false;
        private static bool pressScrollLock = false;

        // for other forms, singleton
        private FormSpaceCPS formSpaceCPS;
        private FormStatisticsList formStatisticsList;
        private FormKeyAssignment formKeyAssignment;
        private FormSettings formSettings;
        private FormHelp formHelp;
        private FormAbout formAbout;

        /// during a write file interval, is any keys pressed
        /// if not, there is not need to write file
        private static bool isKeyPressed = false;

        public Form1()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            // Only in case fail to read the files, display error messages
            // Langauage will be loaded based on configuration file latter
            Configure.GetSystemLanguage();
            Language.LoadTextByLanguage();

            // for singleton forms
            formSpaceCPS = new FormSpaceCPS();
            formSettings = null;
            formStatisticsList = null;
            formKeyAssignment = null;
            formHelp = null;
            formAbout = null;
            FormStatisticsList.open = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // only used in GDI+ drawing
            //InitializeCanvas();

            Keyboard.InitializeMap();
            Keyboard.Register_Key(gkh);

            // read data files, and validate them
            int temp = CheckFirstRun();
            if (temp == 1)  // exit application
                return;
            else if (temp == -1)    // reset correspongding file
            {
                while ((temp = CheckFirstRun()) == -1)  // read again
                    continue;
                if (temp == 1)
                    return;
            }

            InitializeUIComponents();
            RemoveAllComponentsFocus();

            UpdateLEDIndicatorStatus();
            InitializeKeyButtonObjectMapping();

            //ShowKeystrokeGraph(Keyboard.keyCount);
            ShowKeystrokesGraphByCurrentMode();

            gkh.KeyDown += new KeyEventHandler(GKH_KeyDown);
            gkh.KeyUp += new KeyEventHandler(GKH_KeyUp);

            UpdateTimerInterval();
            RunOnStartUpBasedOnSettings();

            this.Text = Language.GetText("program_title");
            this.Icon = Properties.Resources.logo64;

            // set window postition
            setWindowCenterPosition();
        }

        /// <summary>
        /// After running the program, check whether configuration and 
        /// statistics files can be read successfully.
        /// </summary>
        /// <returns>
        /// 0: success, 1: do not reset file, just exit application,
        /// -1: reset the corresponding file
        /// </returns>
        private int CheckFirstRun()
        {
            int checkRes = Storage.FirstRunCheck();
            if (checkRes == 1)  // keystrokes statistics
            {
                var result = MessageBox.Show(Language.GetText("statistics_corruption"), Language.GetText("program_title"), MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Keyboard.ResetCount();
                    Storage.WriteToTotalStatisticsFile();
                    return -1;
                }
                else
                {
                    saveOnExitFlag = false;
                    Application.Exit();
                    return 1;
                }
            }
            else if (checkRes == 2) // configuration
            {
                var result = MessageBox.Show(Language.GetText("configuration_corruption"), Language.GetText("program_title"), MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Configure.InitilizeConfiguration();
                    Storage.WriteConfigurationToFile();
                    return -1;
                }
                else
                {
                    saveOnExitFlag = false;
                    Application.Exit();
                    return 1;
                }
            }
            else if (checkRes == 3) // key assignment
            {
                var result = MessageBox.Show(Language.GetText("key_assignment_corruption"), Language.GetText("program_title"), MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    KeyAssignment.ClearKeyAssignment();
                    Storage.WriteKeyAssignmentToFile();
                    return 0;
                }
                else
                {
                    saveOnExitFlag = false;
                    Application.Exit();
                    return 1;
                }
            }
            return 0;
        }


        private void OnApplicationExit(object sender, EventArgs e)
        {
            // when application exits, save the current result and configuration
            if (saveOnExitFlag == true)
            {
                Storage.WriteToTotalStatisticsFile();
                Storage.WriteConfigurationToFile();
                Storage.WriteKeyAssignmentToFile();
            }
        }

        private void UpdateLEDIndicatorStatus()
        {
            if (indicatorNumLock)
                lblIndicatorNum.BackColor = Color.FromArgb(50, 239, 0);
            else
                lblIndicatorNum.BackColor = Color.DarkGray;
            if (indicatorCapsLock)
                lblIndicatorCaps.BackColor = Color.FromArgb(50, 239, 0);
            else
                lblIndicatorCaps.BackColor = Color.DarkGray;
            if (indicatorScrollLock)
                lblIndicatorScroll.BackColor = Color.FromArgb(50, 239, 0);
            else
                lblIndicatorScroll.BackColor = Color.DarkGray;
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            // if any key pressed detected in a saving cycle, save the statistics file
            if (isKeyPressed)
            {
                isKeyPressed = false;
                Storage.WriteToTotalStatisticsFile();
                ShowKeystrokesGraphByCurrentMode();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            if (saveOnExitFlag)
            {
                Storage.WriteConfigurationToFile();
                Storage.WriteToTotalStatisticsFile();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Hide();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // run in the background
            if (Configure.hideFormAfterRunning == 1)
            {
                this.Hide();
            }
        }

        //private void Form1_MouseEnter(object sender, EventArgs e)
        //{
        //    // only used in GDI+ drawing
        //    // even if using GDI+, we can use Actived and Enter

        //    // draw the color indicator legend when in statistcis mode
        //    //if (Configure.mode == 0 || Configure.mode == 1)
        //    //{
        //    //    //MyDrawColorIndicator();
        //    //}
        //}

        //private void Form1_Enter(object sender, EventArgs e)
        //{
        //    // only used in GDI+ drawing

        //    //if (Configure.mode == 0 || Configure.mode == 1)
        //    //    MyDrawColorIndicator();
        //    //else
        //    //    MyDrawClear();
        //}

        //private void Form1_Activated(object sender, EventArgs e)
        //{
        //    // only used in GDI+ drawing

        //    //if (Configure.mode == 0 || Configure.mode == 1)
        //    //    MyDrawColorIndicator();
        //    //else
        //    //    MyDrawClear();
        //}
    }
}
