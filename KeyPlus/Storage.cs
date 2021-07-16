using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KeyboardHook01
{
    class Storage
    {
        /// <summary>
        /// data storage file will be on user's MyDocument directory
        /// </summary>
        private static string pathDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "KeybaordStatistics");
        public static string pathSound = pathDirectory + "\\sound\\";
        private static string pathTotalStatistics = Path.Combine(pathDirectory, "total.dat");
        private static string pathConfiguration = Path.Combine(pathDirectory, "config.ini");
        private static string pathKeyAssignment = Path.Combine(pathDirectory, "assignment.dat");
        
        

        /// <summary>
        /// When executing write file, call this method. If the directory dost not exist, create one.
        /// </summary>
        private static void CreateDirectoryIfNotExist()
        {
            if (!Directory.Exists(pathDirectory))
            {
                Directory.CreateDirectory(pathDirectory);
            }
            if (!Directory.Exists(pathSound))
            {
                Directory.CreateDirectory(pathSound);
            }
        }

        /// <summary>
        /// When the program just runs, call this method. If data file does not exist, create one.
        /// </summary>
        /// <returns>0: success, 1: fail to read statistics file, 
        /// 2: fail to read configuration file 3: fail to read key assignment file</returns>
        public static int FirstRunCheck()
        {
            CreateDirectoryIfNotExist();

            // for total key strokes statistics file
            if (!File.Exists(pathTotalStatistics))
            {
                // first time to run, initialize the file
                Keyboard.ResetCount();
                Keyboard.keyCountStartsFrom = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss");
                WriteTheContentOfTotalStatisticsFile();
            }
            else
            {
                try
                {
                    ReadStatisticsFileAndStoreValue(pathTotalStatistics, Keyboard.keyCount);
                }
                catch
                {
                    return 1;
                }
            }

            // for configuration file
            if (!File.Exists(pathConfiguration))
            {
                Configure.InitilizeConfiguration();
                WriteConfigurationToFile();
            }
            else
            {
                try
                {
                    ReadConfigurationFile();
                }
                catch
                {
                    return 2;
                }
            }

            // for key assignment file
            if (!File.Exists(pathKeyAssignment))
            {
                WriteKeyAssignmentToFile();   
            }
            else
            {
                try
                {
                    ReadKeyAssignmentFromFile();
                }
                catch
                {
                    return 3;
                }
            }
            WriteSoundFiles();
            return 0;
        }

        private static void WriteSoundFiles()
        {
            if (!File.Exists(pathSound + "cherry_mx_blue_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_blue_down, "cherry_mx_blue_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_blue_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_blue_down, "cherry_mx_blue_up.wav");

            if (!File.Exists(pathSound + "cherry_mx_brown_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_bs_down, "cherry_mx_brown_bs_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_brown_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_down, "cherry_mx_brown_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_brown_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_enter_down, "cherry_mx_brown_enter_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_brown_space_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_space_down, "cherry_mx_brown_space_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_brown_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_up, "cherry_mx_brown_up.wav");
            if (!File.Exists(pathSound + "cherry_mx_brown_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_bs_up, "cherry_mx_brown_bs_up.wav");
            if (!File.Exists(pathSound + "cherry_mx_brown_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_enter_up, "cherry_mx_brown_enter_up.wav");
            if (!File.Exists(pathSound + "cherry_mx_brown_space_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_brown_space_up, "cherry_mx_brown_space_up.wav");


            if (!File.Exists(pathSound + "cherry_mx_red_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_red_down, "cherry_mx_red_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_red_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_red_up, "cherry_mx_red_up.wav");

            if (!File.Exists(pathSound + "cherry_mx_red_silence_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_red_silence_down, "cherry_mx_red_silence_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_red_silence_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_red_silence_up, "cherry_mx_red_silence_up.wav");

            if (!File.Exists(pathSound + "cherry_mx_silver_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_silver_down, "cherry_mx_silver_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_silver_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_silver_up, "cherry_mx_silver_up.wav");

            if (!File.Exists(pathSound + "cherry_mx_silence_black_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_silence_black_down, "cherry_mx_silence_black_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_silence_black_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_silence_black_up, "cherry_mx_silence_black_up.wav");

            if (!File.Exists(pathSound + "cherry_mx_green_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_green_down, "cherry_mx_green_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_green_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_green_up, "cherry_mx_green_up.wav");

            if (!File.Exists(pathSound + "cherry_mx_black_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_bs_down, "cherry_mx_black_bs_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_black_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_bs_up, "cherry_mx_black_bs_up.wav");
            if (!File.Exists(pathSound + "cherry_mx_black_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_down, "cherry_mx_black_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_black_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_enter_down, "cherry_mx_black_enter_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_black_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_enter_up, "cherry_mx_black_enter_up.wav");
            if (!File.Exists(pathSound + "cherry_mx_black_space_down.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_space_down, "cherry_mx_black_space_down.wav");
            if (!File.Exists(pathSound + "cherry_mx_black_space_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_space_up, "cherry_mx_black_space_up.wav");
            if (!File.Exists(pathSound + "cherry_mx_black_up.wav"))
                WriteASoundToFile(Properties.Resources.cherry_mx_black_up, "cherry_mx_black_up.wav");

            if (!File.Exists(pathSound + "novelkeys_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_bs_down, "novelkeys_bs_down.wav");
            if (!File.Exists(pathSound + "novelkeys_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_bs_up, "novelkeys_bs_up.wav");
            if (!File.Exists(pathSound + "novelkeys_down.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_down, "novelkeys_down.wav");
            if (!File.Exists(pathSound + "novelkeys_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_enter_down, "novelkeys_enter_down.wav");
            if (!File.Exists(pathSound + "novelkeys_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_enter_up, "novelkeys_enter_up.wav");
            if (!File.Exists(pathSound + "novelkeys_space_down.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_space_down, "novelkeys_space_down.wav");
            if (!File.Exists(pathSound + "novelkeys_space_up.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_space_up, "novelkeys_space_up.wav");
            if (!File.Exists(pathSound + "novelkeys_up.wav"))
                WriteASoundToFile(Properties.Resources.novelkeys_up, "novelkeys_up.wav");

            if (!File.Exists(pathSound + "holy_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.holy_bs_down, "holy_bs_down.wav");
            if (!File.Exists(pathSound + "holy_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.holy_bs_up, "holy_bs_up.wav");
            if (!File.Exists(pathSound + "holy_down.wav"))
                WriteASoundToFile(Properties.Resources.holy_down, "holy_down.wav");
            if (!File.Exists(pathSound + "holy_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.holy_enter_down, "holy_enter_down.wav");
            if (!File.Exists(pathSound + "holy_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.holy_enter_up, "holy_enter_up.wav");
            if (!File.Exists(pathSound + "holy_space_down.wav"))
                WriteASoundToFile(Properties.Resources.holy_space_down, "holy_space_down.wav");
            if (!File.Exists(pathSound + "holy_space_up.wav"))
                WriteASoundToFile(Properties.Resources.holy_space_up, "holy_space_up.wav");
            if (!File.Exists(pathSound + "holy_up.wav"))
                WriteASoundToFile(Properties.Resources.holy_up, "holy_up.wav");

            if (!File.Exists(pathSound + "turquoise_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_bs_down, "turquoise_bs_down.wav");
            if (!File.Exists(pathSound + "turquoise_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_bs_up, "turquoise_bs_up.wav");
            if (!File.Exists(pathSound + "turquoise_down.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_down, "turquoise_down.wav");
            if (!File.Exists(pathSound + "turquoise_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_enter_down, "turquoise_enter_down.wav");
            if (!File.Exists(pathSound + "turquoise_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_enter_up, "turquoise_enter_up.wav");
            if (!File.Exists(pathSound + "turquoise_space_down.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_space_down, "turquoise_space_down.wav");
            if (!File.Exists(pathSound + "turquoise_space_up.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_space_up, "turquoise_space_up.wav");
            if (!File.Exists(pathSound + "turquoise_up.wav"))
                WriteASoundToFile(Properties.Resources.turquoise_up, "turquoise_up.wav");

            if (!File.Exists(pathSound + "ink_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.ink_bs_down, "ink_bs_down.wav");
            if (!File.Exists(pathSound + "ink_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.ink_bs_up, "ink_bs_up.wav");
            if (!File.Exists(pathSound + "ink_down.wav"))
                WriteASoundToFile(Properties.Resources.ink_down, "ink_down.wav");
            if (!File.Exists(pathSound + "ink_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.ink_enter_down, "ink_enter_down.wav");
            if (!File.Exists(pathSound + "ink_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.ink_enter_up, "ink_enter_up.wav");
            if (!File.Exists(pathSound + "ink_space_down.wav"))
                WriteASoundToFile(Properties.Resources.ink_space_down, "ink_space_down.wav");
            if (!File.Exists(pathSound + "ink_space_up.wav"))
                WriteASoundToFile(Properties.Resources.ink_space_up, "ink_space_up.wav");
            if (!File.Exists(pathSound + "ink_up.wav"))
                WriteASoundToFile(Properties.Resources.ink_up, "ink_up.wav");

            if (!File.Exists(pathSound + "kailh_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.kailh_bs_down, "kailh_bs_down.wav");
            if (!File.Exists(pathSound + "kailh_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.kailh_bs_up, "kailh_bs_up.wav");
            if (!File.Exists(pathSound + "kailh_down.wav"))
                WriteASoundToFile(Properties.Resources.kailh_down, "kailh_down.wav");
            if (!File.Exists(pathSound + "kailh_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.kailh_enter_down, "kailh_enter_down.wav");
            if (!File.Exists(pathSound + "kailh_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.kailh_enter_up, "kailh_enter_up.wav");
            if (!File.Exists(pathSound + "kailh_space_down.wav"))
                WriteASoundToFile(Properties.Resources.kailh_space_down, "kailh_space_down.wav");
            if (!File.Exists(pathSound + "kailh_space_up.wav"))
                WriteASoundToFile(Properties.Resources.kailh_space_up, "kailh_space_up.wav");
            if (!File.Exists(pathSound + "kailh_up.wav"))
                WriteASoundToFile(Properties.Resources.kailh_up, "kailh_up.wav");

            if (!File.Exists(pathSound + "buckling_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.buckling_bs_down, "buckling_bs_down.wav");
            if (!File.Exists(pathSound + "buckling_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.buckling_bs_up, "buckling_bs_up.wav");
            if (!File.Exists(pathSound + "buckling_down.wav"))
                WriteASoundToFile(Properties.Resources.buckling_down, "buckling_down.wav");
            if (!File.Exists(pathSound + "buckling_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.buckling_enter_down, "buckling_enter_down.wav");
            if (!File.Exists(pathSound + "buckling_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.buckling_enter_up, "buckling_enter_up.wav");
            if (!File.Exists(pathSound + "buckling_space_down.wav"))
                WriteASoundToFile(Properties.Resources.buckling_space_down, "buckling_space_down.wav");
            if (!File.Exists(pathSound + "buckling_space_up.wav"))
                WriteASoundToFile(Properties.Resources.buckling_space_up, "buckling_space_up.wav");
            if (!File.Exists(pathSound + "buckling_up.wav"))
                WriteASoundToFile(Properties.Resources.buckling_up, "buckling_up.wav");

            if (!File.Exists(pathSound + "skcm_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.skcm_bs_down, "skcm_bs_down.wav");
            if (!File.Exists(pathSound + "skcm_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.skcm_bs_up, "skcm_bs_up.wav");
            if (!File.Exists(pathSound + "skcm_down.wav"))
                WriteASoundToFile(Properties.Resources.skcm_down, "skcm_down.wav");
            if (!File.Exists(pathSound + "skcm_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.skcm_enter_down, "skcm_enter_down.wav");
            if (!File.Exists(pathSound + "skcm_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.skcm_enter_up, "skcm_enter_up.wav");
            if (!File.Exists(pathSound + "skcm_space_down.wav"))
                WriteASoundToFile(Properties.Resources.skcm_space_down, "skcm_space_down.wav");
            if (!File.Exists(pathSound + "skcm_space_up.wav"))
                WriteASoundToFile(Properties.Resources.skcm_space_up, "skcm_space_up.wav");
            if (!File.Exists(pathSound + "skcm_up.wav"))
                WriteASoundToFile(Properties.Resources.skcm_up, "skcm_up.wav");

            if (!File.Exists(pathSound + "topre_bs_down.wav"))
                WriteASoundToFile(Properties.Resources.topre_bs_down, "topre_bs_down.wav");
            if (!File.Exists(pathSound + "topre_bs_up.wav"))
                WriteASoundToFile(Properties.Resources.topre_bs_up, "topre_bs_up.wav");
            if (!File.Exists(pathSound + "topre_down.wav"))
                WriteASoundToFile(Properties.Resources.topre_down, "topre_down.wav");
            if (!File.Exists(pathSound + "topre_enter_down.wav"))
                WriteASoundToFile(Properties.Resources.topre_enter_down, "topre_enter_down.wav");
            if (!File.Exists(pathSound + "topre_enter_up.wav"))
                WriteASoundToFile(Properties.Resources.topre_enter_up, "topre_enter_up.wav");
            if (!File.Exists(pathSound + "topre_space_down.wav"))
                WriteASoundToFile(Properties.Resources.topre_space_down, "topre_space_down.wav");
            if (!File.Exists(pathSound + "topre_space_up.wav"))
                WriteASoundToFile(Properties.Resources.topre_space_up, "topre_space_up.wav");
            if (!File.Exists(pathSound + "topre_up.wav"))
                WriteASoundToFile(Properties.Resources.topre_up, "topre_up.wav");
        }

        private static void WriteASoundToFile(UnmanagedMemoryStream sound, string fileName)
        {
            byte[] t = new byte[sound.Length];
            if (sound.CanRead)
            {
                for (int i = 0; i < sound.Length; ++i)
                {
                    t[i] = (byte)sound.ReadByte();
                }
            }
            using (BinaryWriter binWriter = new BinaryWriter(File.Open(pathSound + fileName, FileMode.Create)))
            {
                binWriter.Write(t);
            }
        }

        public static void WriteToTotalStatisticsFile()
        {
            CreateDirectoryIfNotExist();
            if (File.Exists(pathTotalStatistics))
            {
                WriteTheContentOfTotalStatisticsFile();
            } 
            else
            {
                // first time to run, initialize the file
                Keyboard.ResetCount();
                Keyboard.keyCountStartsFrom = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss");
                WriteTheContentOfTotalStatisticsFile();
                //FirstRunCheck();
            }
        }


        private static void WriteTheContentOfTotalStatisticsFile()
        {
            using (StreamWriter sw = File.CreateText(pathTotalStatistics))
            {
                sw.WriteLine(Keyboard.keyCountStartsFrom);
                sw.Write(ConvertCountToString(Keyboard.keyCount));
            }
        }

        /// <summary>
        /// Convert the key hit time map to a string which will be wrote into a file.
        /// </summary>
        /// <param name="count">map, key code: time of hit</param>
        /// <returns></returns>
        public static string ConvertCountToString(Dictionary<int, ulong> count)
        {
            string res = "";
            foreach (var pair in count)
            {
                int key = pair.Key;
                ulong value = pair.Value;
                res += key + ":" + value.ToString() + "\n";
            }
            return res;
        }

        public static void ReadStatisticsFileAndStoreValue(string filePath, Dictionary<int, ulong> count)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            bool first = true;
            bool flag = true;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    if (first)
                    {
                        // read the starting date and time
                        if (!line.Contains('-'))
                        {
                            Keyboard.keyCountStartsFrom = DateTime.Now.ToString("yyyy-MM-dd  hh:mm:ss");
                            flag = false;
                        }
                        else
                            Keyboard.keyCountStartsFrom = line;
                        first = false;
                    }
                    else
                    {
                        int i = line.IndexOf(":");
                        int key = Convert.ToInt32(line.Substring(0, i));
                        ulong value = Convert.ToUInt64(line.Substring(i + 1));
                        count[key] = value;
                    }
                }
            }
            if (!flag)
            {
                WriteToTotalStatisticsFile();
            }
        }

        public static void WriteConfigurationToFile()
        {
            using (StreamWriter sw = File.CreateText(pathConfiguration))
            {
                sw.WriteLine(Configure.language.ToString());
                sw.WriteLine(Configure.mode.ToString());
                sw.WriteLine(Configure.colorKeystroke.ToString());
                sw.WriteLine(Configure.refreshMode.ToString());
                sw.WriteLine(Configure.keepTrace.ToString());
                sw.WriteLine(Configure.stayOnTop.ToString());
                sw.WriteLine(Configure.stayOnTopStatistics.ToString());
                sw.WriteLine(Configure.statisticsFormHeight.ToString());
                sw.WriteLine(Configure.statisticsOrderColumn.ToString());
                sw.WriteLine(Configure.statisticsOrderMethod.ToString());
                sw.WriteLine(Configure.keyAssignmentFormHeight.ToString());
                sw.WriteLine(Configure.enableKeyAssignment.ToString());
                sw.WriteLine(Configure.runOnStartUp.ToString());
                sw.WriteLine(Configure.totalKeystrkesSaveInterval.ToString());
                sw.WriteLine(Configure.exitAfterAlert.ToString());
                sw.WriteLine(Configure.mechanicalSound.ToString());
                sw.WriteLine(Configure.saveNotify.ToString());
                sw.WriteLine(Configure.hideFormAfterRunning.ToString());
            }
        }

        public static void ReadConfigurationFile()
        {
            string[] lines = System.IO.File.ReadAllLines(pathConfiguration);
            Configure.language = Convert.ToInt32(lines[0]);
            Configure.mode = Convert.ToInt32(lines[1]);
            Configure.colorKeystroke = Convert.ToInt32(lines[2]);
            Configure.refreshMode = Convert.ToInt32(lines[3]);
            Configure.keepTrace = Convert.ToInt32(lines[4]);
            Configure.stayOnTop = Convert.ToInt32(lines[5]);
            Configure.stayOnTopStatistics = Convert.ToInt32(lines[6]);
            Configure.statisticsFormHeight = Convert.ToInt32(lines[7]);
            Configure.statisticsOrderColumn = Convert.ToInt32(lines[8]);
            Configure.statisticsOrderMethod = Convert.ToInt32(lines[9]);
            Configure.keyAssignmentFormHeight = Convert.ToInt32(lines[10]);
            Configure.enableKeyAssignment = Convert.ToInt32(lines[11]);
            Configure.runOnStartUp = Convert.ToInt32(lines[12]);
            Configure.totalKeystrkesSaveInterval = Convert.ToInt32(lines[13]);
            Configure.exitAfterAlert = Convert.ToInt32(lines[14]);
            Configure.mechanicalSound = Convert.ToInt32(lines[15]);
            Configure.saveNotify = Convert.ToInt32(lines[16]);
            Configure.hideFormAfterRunning = Convert.ToInt32(lines[17]);
        }

        public static void WriteKeyAssignmentToFile()
        {
            using (StreamWriter sw = File.CreateText(pathKeyAssignment))
            {
                foreach (var item in KeyAssignment.combinationKey)
                {
                    sw.WriteLine(item.Key + "|" + item.Value);
                }
            }
        }

        public static void ReadKeyAssignmentFromFile()
        {
            KeyAssignment.combinationKey.Clear();
            string[] lines = System.IO.File.ReadAllLines(pathKeyAssignment);
            foreach (var line in lines)
            {
                var item = line.Split('|');
                if (KeyAssignment.ConvertComboStringToNormalString(item[0]).Equals(Language.GetText("error")))
                    throw new Exception();
                if (KeyAssignment.GetAssignmentType(item[1]).Equals(Language.GetText("error")))
                    throw new Exception();
                KeyAssignment.combinationKey.Add(item[0], item[1]);
            }
        }
    }
}
