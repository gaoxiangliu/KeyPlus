using System.Globalization;

namespace KeyboardHook01
{
    class Configure
    {
        /// <summary>
        /// 0: English, 1: Simplfifed Chinese
        /// </summary>
        public static int language;

        /// <summary>
        /// 0: total keystrokes, 1: keystrkoes this time, 2: keyboard test
        /// </summary>
        public static int mode = 2;

        /// <summary>
        /// color tone
        /// </summary>
        public static int colorKeystroke;
        
        /// <summary>
        /// 0: delayed, 1: real-time
        /// </summary>
        public static int refreshMode;

        /// <summary>
        /// keep the key down trace when testing
        /// </summary>
        public static int keepTrace;

        /// <summary>
        /// for Main Form
        /// </summary>
        public static int stayOnTop;

        /// <summary>
        /// for statistics list form
        /// </summary>
        public static int stayOnTopStatistics;

        /// <summary>
        /// the height of the statistics list form
        /// </summary>
        public static int statisticsFormHeight;

        /// <summary>
        /// 0: key code, 1: key char, 2: key name, 3: current keystrokes, 4: total keystrokes
        /// </summary>
        public static int statisticsOrderColumn;

        /// <summary>
        /// 0: asceding, 1: desceding
        /// </summary>
        public static int statisticsOrderMethod;

        /// <summary>
        /// the height of the key assignment form
        /// </summary>
        public static int keyAssignmentFormHeight;

        /// <summary>
        /// 1: enable key assignment, 0: disable key assignment
        /// </summary>
        public static int enableKeyAssignment;

        /// <summary>
        /// 0: disable run on startup, 1: enable run on startup
        /// </summary>
        public static int runOnStartUp;

        /// <summary>
        /// time interval of saving total keystrokes file (seconds)
        /// </summary>
        public static int totalKeystrkesSaveInterval;

        /// <summary>
        /// lower bound for total keystrokes saving interval
        /// not writing to configuration file
        /// </summary>
        public static int lowerInterval = 5;

        /// <summary>
        /// higher bound for total keystrokes saving interval
        /// not writing to configuration file
        /// </summary>
        public static int upperInterval = 7200;

        /// <summary>
        /// 0: exit immediate after click exit, 1: alert before exit
        /// </summary>
        public static int exitAfterAlert;

        /// <summary>
        /// 0: slient 1:cherry mx blue 2: cherry mx brown 3: cherry mx red 4: cherry mx sliver
        /// 5: cherry mx black 6: cherry mx silent red 7: cherry slient balck 8: cherry mx green
        /// 9: NovelKeys Creams 10: Holy Pandas 11: Turquoise Tealios 12: Gateron Black Inks
        /// 13: Kailh Box Navies 14:Buckling Spring 15: SKCM Blue Alps 16: Topre
        /// </summary>
        public static int mechanicalSound;

        /// <summary>
        /// when saving manually, notify the user?
        /// 0: none, 1: message box, 2: win10 notify, 3: both
        /// using bit operation
        /// </summary>
        public static int saveNotify;

        /// <summary>
        /// 0: show main window after running
        /// 1: hide main window after running
        /// </summary>
        public static int hideFormAfterRunning;

        public static void GetSystemLanguage()
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            switch (ci.Name)
            {
                case "en-US":
                    language = 0;
                    break;
                case "zh-CN":
                    language = 1;
                    break;
                case "zh-SG":
                    language = 1;
                    break;
                default:
                    language = 0;
                    break;
            }
        }

        public static void InitilizeConfiguration()
        {
            GetSystemLanguage();
            mode = 0;
            colorKeystroke = 5;
            refreshMode = 0;
            keepTrace = 1;
            stayOnTop = 0;
            stayOnTopStatistics = 0;
            statisticsFormHeight = 500;
            statisticsOrderColumn = 0;
            statisticsOrderMethod = 0;
            keyAssignmentFormHeight = 489;
            enableKeyAssignment = 1;
            runOnStartUp = 1;
            totalKeystrkesSaveInterval = 600;
            exitAfterAlert = 1;
            mechanicalSound = 0;
            saveNotify = 2;
            hideFormAfterRunning = 1;
        }
    }
}
