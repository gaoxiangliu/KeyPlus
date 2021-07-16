using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace KeyboardHook01
{
    class KeyAssignment
    {
        public static bool isCtrlDown = false;
        public static bool isShiftDown = false;
        public static bool isAltDown = false;
        public static bool isWinDown = false;

        /// <summary>
        /// Definition: Function Key: Ctrl, Shift, Win, ALt
        ///                      The combination keys: a single non-functional key, 
        ///                      or one or more function keys and ONLY ONE non-functional key.
        /// for key of the dictionary, the general type is string, known as combo string
        /// there is no need to care about the meaning of the key though
        /// if Ctrl is press, it contains a "c", Shift -> "s", Win -> "w", Alt -> "a"
        /// the non-functional key code is added at the end
        /// 
        /// and for value, it is the path of program to be opened or special command
        /// (cmd code) command list:
        /// 0 restore: display (restore) the main form (window)
        /// 1 vup: volume up
        /// 2 vdown: volume down
        /// 3 vmute: mute
        /// 4 exe <path>: execute programm in the specified path
        /// </summary>
        public static Dictionary<string, string> combinationKey = new Dictionary<string, string>();

        /// <summary>
        /// Clear all key assignments
        /// </summary>
        public static void ClearKeyAssignment()
        {
            combinationKey.Clear();
        }

        /// <summary>
        /// used when the key is down
        /// </summary>
        /// <param name="keyCode"></param>
        public static void PresFunctionKey(int keyCode)
        {
            if (keyCode == (int)Keys.LControlKey || keyCode == (int)Keys.RControlKey)
                isCtrlDown = true;
            else if (keyCode == (int)Keys.LShiftKey || keyCode == (int)Keys.RShiftKey)
                isShiftDown = true;
            else if (keyCode == (int)Keys.LWin || keyCode == (int)Keys.RWin)
                isWinDown = true;
            else if (keyCode == (int)Keys.LMenu || keyCode == (int)Keys.RMenu)
                isAltDown = true;
        }

        /// <summary>
        /// used when the key is up
        /// </summary>
        /// <param name="keyCode"></param>
        public static void ReleaseFunctionKey(int keyCode)
        {
            if (keyCode == (int)Keys.LControlKey || keyCode == (int)Keys.RControlKey)
                isCtrlDown = false;
            else if (keyCode == (int)Keys.LShiftKey || keyCode == (int)Keys.RShiftKey)
                isShiftDown = false;
            else if (keyCode == (int)Keys.LWin || keyCode == (int)Keys.RWin)
                isWinDown = false;
            else if (keyCode == (int)Keys.LMenu || keyCode == (int)Keys.RMenu)
                isAltDown = false;
        }

        /// <summary>
        /// Show current pressed function keys, there is no "+" sign at the end of the string
        /// </summary>
        /// <returns></returns>
        public static string GetFunctionKeyString()
        {
            string res = "";
            if (isCtrlDown)
                res += "Ctrl+";
            if (isShiftDown)
                res += "Shift+";
            if (isWinDown)
                res += "Win+";
            if (isAltDown)
                res += "Alt+";
            if (res.Length > 0)
                return res.Substring(0, res.Length - 1);
            return "";
        }

        /// <summary>
        /// Generate the string for the key in Dictionary combinationKey
        /// </summary>
        /// <param name="keyCode">the non-function key</param>
        /// <returns></returns>
        public static string GetCombinationKeyString(int keyCode)
        {
            string res = "";
            if (isCtrlDown)
                res += "c";
            if (isShiftDown)
                res += "s";
            if (isWinDown)
                res += "w";
            if (isAltDown)
                res += "a";
            res += keyCode;
            return res;
        }


        /// <summary>
        /// Convert a combo key string (key in Dictionary combinationKey) to a normal key name text  
        /// </summary>
        /// <param name="comboKeys"></param>
        /// <returns></returns>
        public static string ConvertComboStringToNormalString(string comboKeys)
        {
            string res = "";
            int keyCode = 0;
            foreach (char item in comboKeys)
            {
                if (item == 'c')
                    res += "Ctrl+";
                else if (item == 's')
                    res += "Shift+";
                else if (item == 'w')
                    res += "Win+";
                else if (item == 'a')
                    res += "Alt+";
                else if (item >= '0' && item <= '9')
                {
                    keyCode *= 10;
                    keyCode += (item - '0');
                }
            }
            string keyChar = "";
            try
            {
                keyChar = Keyboard.keyChar[keyCode];
            }
            catch
            {
                return Language.GetText("error");
            }
            res += keyChar;
            return res;
        }

        /// <summary>
        /// interpret command string into assignment type
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string GetAssignmentType(string cmd)
        {
            string res = "";
            if (cmd.Equals("restore"))
                res = Language.GetText("display_main");
            else if (cmd.Equals("vup"))
                res = Language.GetText("volume_up");
            else if (cmd.Equals("vdown"))
                res = Language.GetText("volume_down");
            else if (cmd.Equals("vmute"))
                res = Language.GetText("mute");
            else if (cmd.Substring(0, 3).Equals("exe"))
                res = Language.GetText("execute_program");
            else
                res = Language.GetText("error");
            return res;
        }

        /// <summary>
        /// interpret command string into assignment type code
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>-1 if error occurs</returns>
        public static int GetAssignmentCode(string cmd)
        {
            if (cmd.Equals("restore"))
                return 0;
            else if (cmd.Equals("vup"))
                return 1;
            else if (cmd.Equals("vdown"))
                return 2;
            else if (cmd.Equals("vmute"))
                return 3;
            else if (cmd.Substring(0, 3).Equals("exe"))
                return 4;
            return -1;
        }


        /// <summary>
        /// get program's path if the command is about to exeucte a program
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>return the path, if not this type, return empty string</returns>
        public static string GetProgramPath(string cmd)
        {
            string res = "";
            if (cmd.Substring(0, 3).Equals("exe"))
            {
                res = cmd.Substring(4);
            }
            return res;
        }

        /// <summary>
        /// return true if the keyCode is a function key, false otherwise
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public static bool IsFunctionKey(int keyCode)
        {
            if (keyCode == (int)Keys.ControlKey || keyCode == (int)Keys.ShiftKey || 
                keyCode == (int)Keys.LWin || keyCode == (int)Keys.RWin ||
                keyCode == (int)Keys.Menu)
                return true;
            return false;
        }

        /// <summary>
        /// test whether a combo keys exists
        /// </summary>
        /// <param name="comboKeys"></param>
        /// <returns>return false if not exist, true otherwise</returns>
        public static bool IsComboExist(string comboKeys)
        {
            try
            {
                var a = combinationKey[comboKeys];
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// execute command 
        /// </summary>
        /// <param name="comboKeys">use GetCombinationKeyString to generate string</param>
        /// <param name="mainForm">main form object, used for restore window</param>
        public static void ExecuteCmd(string comboKeys, Form1 mainForm)
        {
            try
            {
                string cmd = combinationKey[comboKeys];
                if (cmd.Equals("restore")) 
                {
                    mainForm.showMainWindow();
                }
                else if (cmd.Equals("vup"))
                    new FormVolume().VolUp();
                else if (cmd.Equals("vdown"))
                    new FormVolume().VolDown();
                else if (cmd.Equals("vmute"))
                    new FormVolume().Mute();
                else if (cmd.Substring(0, 3).Equals("exe"))
                {
                    string path = cmd.Substring(4);
                    Process.Start(path);
                }
            }
            catch { }
        }
    }
}
