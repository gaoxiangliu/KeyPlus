using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KeyboardHook01
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// the keyboard buttons in this program is independant Buttons, we map it with the key code
        /// </summary>
        private static Dictionary<int, Button> keyButtonObjectMap = new Dictionary<int, Button>();

        private void InitializeKeyButtonObjectMapping()
        {
            keyButtonObjectMap.Add((int)Keys.Escape, btnKeyESC);
            keyButtonObjectMap.Add((int)Keys.F1, btnKeyF1);
            keyButtonObjectMap.Add((int)Keys.F2, btnKeyF2);
            keyButtonObjectMap.Add((int)Keys.F3, btnKeyF3);
            keyButtonObjectMap.Add((int)Keys.F4, btnKeyF4);
            keyButtonObjectMap.Add((int)Keys.F5, btnKeyF5);
            keyButtonObjectMap.Add((int)Keys.F6, btnKeyF6);
            keyButtonObjectMap.Add((int)Keys.F7, btnKeyF7);
            keyButtonObjectMap.Add((int)Keys.F8, btnKeyF8);
            keyButtonObjectMap.Add((int)Keys.F9, btnKeyF9);
            keyButtonObjectMap.Add((int)Keys.F10, btnKeyF10);
            keyButtonObjectMap.Add((int)Keys.F11, btnKeyF11);
            keyButtonObjectMap.Add((int)Keys.F12, btnKeyF12);
            keyButtonObjectMap.Add((int)Keys.A, btnKeyA);
            keyButtonObjectMap.Add((int)Keys.B, btnKeyB);
            keyButtonObjectMap.Add((int)Keys.C, btnKeyC);
            keyButtonObjectMap.Add((int)Keys.D, btnKeyD);
            keyButtonObjectMap.Add((int)Keys.E, btnKeyE);
            keyButtonObjectMap.Add((int)Keys.F, btnKeyF);
            keyButtonObjectMap.Add((int)Keys.G, btnKeyG);
            keyButtonObjectMap.Add((int)Keys.H, btnKeyH);
            keyButtonObjectMap.Add((int)Keys.I, btnKeyI);
            keyButtonObjectMap.Add((int)Keys.J, btnKeyJ);
            keyButtonObjectMap.Add((int)Keys.K, btnKeyK);
            keyButtonObjectMap.Add((int)Keys.L, btnKeyL);
            keyButtonObjectMap.Add((int)Keys.M, btnKeyM);
            keyButtonObjectMap.Add((int)Keys.N, btnKeyN);
            keyButtonObjectMap.Add((int)Keys.O, btnKeyO);
            keyButtonObjectMap.Add((int)Keys.P, btnKeyP);
            keyButtonObjectMap.Add((int)Keys.Q, btnKeyQ);
            keyButtonObjectMap.Add((int)Keys.R, btnKeyR);
            keyButtonObjectMap.Add((int)Keys.S, btnKeyS);
            keyButtonObjectMap.Add((int)Keys.T, btnKeyT);
            keyButtonObjectMap.Add((int)Keys.U, btnKeyU);
            keyButtonObjectMap.Add((int)Keys.V, btnKeyV);
            keyButtonObjectMap.Add((int)Keys.W, btnKeyW);
            keyButtonObjectMap.Add((int)Keys.X, btnKeyX);
            keyButtonObjectMap.Add((int)Keys.Y, btnKeyY);
            keyButtonObjectMap.Add((int)Keys.Z, btnKeyZ);
            keyButtonObjectMap.Add((int)Keys.D0, btnKey0);
            keyButtonObjectMap.Add((int)Keys.D1, btnKey1);
            keyButtonObjectMap.Add((int)Keys.D2, btnKey2);
            keyButtonObjectMap.Add((int)Keys.D3, btnKey3);
            keyButtonObjectMap.Add((int)Keys.D4, btnKey4);
            keyButtonObjectMap.Add((int)Keys.D5, btnKey5);
            keyButtonObjectMap.Add((int)Keys.D6, btnKey6);
            keyButtonObjectMap.Add((int)Keys.D7, btnKey7);
            keyButtonObjectMap.Add((int)Keys.D8, btnKey8);
            keyButtonObjectMap.Add((int)Keys.D9, btnKey9);
            keyButtonObjectMap.Add((int)Keys.LControlKey, btnKeyLCtrl);
            keyButtonObjectMap.Add((int)Keys.LShiftKey, btnKeyLShift);
            keyButtonObjectMap.Add((int)Keys.LMenu, btnKeyLAlt);
            keyButtonObjectMap.Add((int)Keys.LWin, btnKeyLWin);
            keyButtonObjectMap.Add((int)Keys.RControlKey, btnKeyRCtrl);
            keyButtonObjectMap.Add((int)Keys.RShiftKey, btnKeyRShift);
            keyButtonObjectMap.Add((int)Keys.RMenu, btnKeyRAlt);
            keyButtonObjectMap.Add((int)Keys.RWin, btnKeyRWin);
            keyButtonObjectMap.Add((int)Keys.CapsLock, btnKeyCapsLock);
            keyButtonObjectMap.Add((int)Keys.Back, btnKeyBacksapce);
            keyButtonObjectMap.Add((int)Keys.Apps, btnKeyRightClickMenu);
            keyButtonObjectMap.Add((int)Keys.Tab, btnKeyTab);
            keyButtonObjectMap.Add((int)Keys.Space, btnKeySpace);
            keyButtonObjectMap.Add((int)Keys.OemPipe, btnKeyBackSlash);
            keyButtonObjectMap.Add((int)Keys.Oemtilde, btnKeyTilde);
            keyButtonObjectMap.Add((int)Keys.OemMinus, btnKeyDash);
            keyButtonObjectMap.Add((int)Keys.Oemplus, btnKeyPlus);
            keyButtonObjectMap.Add((int)Keys.Oemcomma, btnKeyComma);
            keyButtonObjectMap.Add((int)Keys.OemPeriod, btnKeyPeriod);
            keyButtonObjectMap.Add((int)Keys.OemQuestion, btnKeySlash);
            keyButtonObjectMap.Add((int)Keys.OemQuotes, btnKeyQuotes);
            keyButtonObjectMap.Add((int)Keys.OemSemicolon, btnKeySemicolon);
            keyButtonObjectMap.Add((int)Keys.OemOpenBrackets, btnKeyLeftBra);
            keyButtonObjectMap.Add((int)Keys.OemCloseBrackets, btnKeyRightBra);
            keyButtonObjectMap.Add((int)Keys.Return, btnKeyEnter);
            keyButtonObjectMap.Add((int)Keys.Up, btnKeyUp);
            keyButtonObjectMap.Add((int)Keys.Down, btnKeyDown);
            keyButtonObjectMap.Add((int)Keys.Left, btnKeyLeft);
            keyButtonObjectMap.Add((int)Keys.Right, btnKeyRight);
            keyButtonObjectMap.Add((int)Keys.Delete, btnKeyDelete);
            keyButtonObjectMap.Add((int)Keys.End, btnKeyEnd);
            keyButtonObjectMap.Add((int)Keys.PageDown, btnKeyPageDown);
            keyButtonObjectMap.Add((int)Keys.PageUp, btnKeyPageUp);
            keyButtonObjectMap.Add((int)Keys.Home, btnKeyHome);
            keyButtonObjectMap.Add((int)Keys.Insert, btnKeyInsert);
            keyButtonObjectMap.Add((int)Keys.PrintScreen, btnKeyPrint);
            keyButtonObjectMap.Add((int)Keys.Scroll, btnKeyScroll);
            keyButtonObjectMap.Add((int)Keys.Pause, btnKeyPause);
            keyButtonObjectMap.Add((int)Keys.NumLock, btnKeyNumLock);
            keyButtonObjectMap.Add((int)Keys.NumPad0, btnKeyPad0);
            keyButtonObjectMap.Add((int)Keys.NumPad1, btnKeyPad1);
            keyButtonObjectMap.Add((int)Keys.NumPad2, btnKeyPad2);
            keyButtonObjectMap.Add((int)Keys.NumPad3, btnKeyPad3);
            keyButtonObjectMap.Add((int)Keys.NumPad4, btnKeyPad4);
            keyButtonObjectMap.Add((int)Keys.NumPad5, btnKeyPad5);
            keyButtonObjectMap.Add((int)Keys.NumPad6, btnKeyPad6);
            keyButtonObjectMap.Add((int)Keys.NumPad7, btnKeyPad7);
            keyButtonObjectMap.Add((int)Keys.NumPad8, btnKeyPad8);
            keyButtonObjectMap.Add((int)Keys.NumPad9, btnKeyPad9);
            keyButtonObjectMap.Add((int)Keys.Divide, btnKeyPadDiv);
            keyButtonObjectMap.Add((int)Keys.Multiply, btnKeyPadMul);
            keyButtonObjectMap.Add((int)Keys.Subtract, btnKeyPadMinus);
            keyButtonObjectMap.Add((int)Keys.Add, btnKeyPadPAdd);
            keyButtonObjectMap.Add((int)Keys.Decimal, btnKeyPadDecimal);

            RegisterKeyHandler();
        }

        private void ClearKeyboardColor()
        {
            try
            {
                foreach (var item in keyButtonObjectMap)
                {
                    Button btn = item.Value;
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                }

                // number pad Enter
                btnKeyPadEnter.BackColor = Color.White;
                btnKeyPadEnter.ForeColor = Color.Black;
            }
            catch { }
        }

        private void ShowKeystrokeGraph(Dictionary<int, ulong> count)
        {
            ClearKeyboardColor();
            ulong lower = count.ElementAt(0).Value;
            ulong higher = count.ElementAt(0).Value;
            foreach (var item in count)
            {
                ulong value = item.Value;
                if (value < lower)
                    lower = value;
                if (value > higher)
                    higher = value;
            }
            for (int i = 0; i < count.Count; i++)
            {

                Color background = ColorUtil.DisplayColor(Configure.colorKeystroke, lower, higher, count.ElementAt(i).Value);
                Color foreground = ColorUtil.GetTextColorBasedOnBackground(background);
                keyButtonObjectMap.ElementAt(i).Value.BackColor = background;
                keyButtonObjectMap.ElementAt(i).Value.ForeColor = foreground;
                if (keyButtonObjectMap.ElementAt(i).Key == (int)Keys.Return)
                {
                    btnKeyPadEnter.BackColor = background;
                    btnKeyPadEnter.ForeColor = foreground;
                }
            }
        }

        private void ShowKeystrokesGraphByCurrentMode()
        {
            try
            {
                if (Configure.mode == 0)
                {
                    ShowKeystrokeGraph(Keyboard.keyCount);
                }
                else if (Configure.mode == 1)
                {
                    ShowKeystrokeGraph(Keyboard.keyCountCurrent);
                }
            }
            catch { }
        }

        /// <summary>
        /// Only for Keyboard Test function
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="status">0: initial, 1: pressed down, 2: released</param>
        private void SetTestColorForOneKey(int keyCode, int status)
        {
            var key = keyButtonObjectMap[keyCode];
            Color targetColor = Color.White;
            bool flag = false;
            switch (status)
            {
                case 0:
                    targetColor = Color.White;
                    break;
                case 1:
                    targetColor = Color.DeepSkyBlue;
                    break;
                case 2:
                    targetColor = Color.LawnGreen;
                    break;
                default:
                    flag = true;
                    break;
            }
            if (!flag)
            {
                key.BackColor = targetColor;
                if (keyCode == (int)Keys.Return)
                {
                    btnKeyPadEnter.BackColor = targetColor;
                }

            }
        }

        private void RegisterKeyHandler()
        {
            int i = 0;
            for (; i < keyButtonObjectMap.Count; i++)
            {
                keyButtonObjectMap.ElementAt(i).Value.TabIndex = 1000 + i;
                keyButtonObjectMap.ElementAt(i).Value.KeyDown += new KeyEventHandler(DisableSelectKeyButtons);
                keyButtonObjectMap.ElementAt(i).Value.Enter += new EventHandler(RemoveKeyButtonFocus);
                keyButtonObjectMap.ElementAt(i).Value.Click += new EventHandler(KeyClickedActionHandler);
            }

            // for number pad Enter
            btnKeyPadEnter.TabIndex = 1000 + i;
            btnKeyPadEnter.KeyDown += new KeyEventHandler(DisableSelectKeyButtons);
            btnKeyPadEnter.Enter += new EventHandler(RemoveKeyButtonFocus);
            btnKeyPadEnter.Click += new EventHandler(KeyClickedActionHandler);
        }

        private void DisableSelectKeyButtons(object sender, KeyEventArgs e)
        {
            if (this.Focused == true)
            {
                btnRemoveFocus.Focus();
            }
        }

        private void RemoveKeyButtonFocus(object sender, EventArgs e)
        {
            btnRemoveFocus.Focus();
        }

        private void KeyClickedActionHandler(object sender, EventArgs e)
        {
            btnRemoveFocus.Focus();
            Button btn = (Button)sender;
            int keyCode = 0;
            switch (btn.Name)
            {
                case "btnKeyESC":
                    keyCode = (int)Keys.Escape;
                    break;
                case "btnKeyF1":
                    keyCode = (int)Keys.F1;
                    break;
                case "btnKeyF2":
                    keyCode = (int)Keys.F2;
                    break;
                case "btnKeyF3":
                    keyCode = (int)Keys.F3;
                    break;
                case "btnKeyF4":
                    keyCode = (int)Keys.F4;
                    break;
                case "btnKeyF5":
                    keyCode = (int)Keys.F5;
                    break;
                case "btnKeyF6":
                    keyCode = (int)Keys.F6;
                    break;
                case "btnKeyF7":
                    keyCode = (int)Keys.F7;
                    break;
                case "btnKeyF8":
                    keyCode = (int)Keys.F8;
                    break;
                case "btnKeyF9":
                    keyCode = (int)Keys.F9;
                    break;
                case "btnKeyF10":
                    keyCode = (int)Keys.F10;
                    break;
                case "btnKeyF11":
                    keyCode = (int)Keys.F11;
                    break;
                case "btnKeyF12":
                    keyCode = (int)Keys.F12;
                    break;
                case "btnKeyA":
                    keyCode = (int)Keys.A;
                    break;
                case "btnKeyB":
                    keyCode = (int)Keys.B;
                    break;
                case "btnKeyC":
                    keyCode = (int)Keys.C;
                    break;
                case "btnKeyD":
                    keyCode = (int)Keys.D;
                    break;
                case "btnKeyE":
                    keyCode = (int)Keys.E;
                    break;
                case "btnKeyF":
                    keyCode = (int)Keys.F;
                    break;
                case "btnKeyG":
                    keyCode = (int)Keys.G;
                    break;
                case "btnKeyH":
                    keyCode = (int)Keys.H;
                    break;
                case "btnKeyI":
                    keyCode = (int)Keys.I;
                    break;
                case "btnKeyJ":
                    keyCode = (int)Keys.J;
                    break;
                case "btnKeyK":
                    keyCode = (int)Keys.K;
                    break;
                case "btnKeyL":
                    keyCode = (int)Keys.L;
                    break;
                case "btnKeyM":
                    keyCode = (int)Keys.M;
                    break;
                case "btnKeyN":
                    keyCode = (int)Keys.N;
                    break;
                case "btnKeyO":
                    keyCode = (int)Keys.O;
                    break;
                case "btnKeyP":
                    keyCode = (int)Keys.P;
                    break;
                case "btnKeyQ":
                    keyCode = (int)Keys.Q;
                    break;
                case "btnKeyR":
                    keyCode = (int)Keys.R;
                    break;
                case "btnKeyS":
                    keyCode = (int)Keys.S;
                    break;
                case "btnKeyT":
                    keyCode = (int)Keys.T;
                    break;
                case "btnKeyU":
                    keyCode = (int)Keys.U;
                    break;
                case "btnKeyV":
                    keyCode = (int)Keys.V;
                    break;
                case "btnKeyW":
                    keyCode = (int)Keys.W;
                    break;
                case "btnKeyX":
                    keyCode = (int)Keys.X;
                    break;
                case "btnKeyY":
                    keyCode = (int)Keys.Y;
                    break;
                case "btnKeyZ":
                    keyCode = (int)Keys.Z;
                    break;
                case "btnKey0":
                    keyCode = (int)Keys.D0;
                    break;
                case "btnKey1":
                    keyCode = (int)Keys.D1;
                    break;
                case "btnKey2":
                    keyCode = (int)Keys.D2;
                    break;
                case "btnKey3":
                    keyCode = (int)Keys.D3;
                    break;
                case "btnKey4":
                    keyCode = (int)Keys.D4;
                    break;
                case "btnKey5":
                    keyCode = (int)Keys.D5;
                    break;
                case "btnKey6":
                    keyCode = (int)Keys.D6;
                    break;
                case "btnKey7":
                    keyCode = (int)Keys.D7;
                    break;
                case "btnKey8":
                    keyCode = (int)Keys.D8;
                    break;
                case "btnKey9":
                    keyCode = (int)Keys.D9;
                    break;
                case "btnKeyLCtrl":
                    keyCode = (int)Keys.LControlKey;
                    break;
                case "btnKeyLShift":
                    keyCode = (int)Keys.LShiftKey;
                    break;
                case "btnKeyLAlt":
                    keyCode = (int)Keys.LMenu;
                    break;
                case "btnKeyLWin":
                    keyCode = (int)Keys.LWin;
                    break;
                case "btnKeyRCtrl":
                    keyCode = (int)Keys.RControlKey;
                    break;
                case "btnKeyRShift":
                    keyCode = (int)Keys.RShiftKey;
                    break;
                case "btnKeyRAlt":
                    keyCode = (int)Keys.RMenu;
                    break;
                case "btnKeyRWin":
                    keyCode = (int)Keys.RWin;
                    break;
                case "btnKeyCapsLock":
                    keyCode = (int)Keys.CapsLock;
                    break;
                case "btnKeyBacksapce":
                    keyCode = (int)Keys.Back;
                    break;
                case "btnKeyRightClickMenu":
                    keyCode = (int)Keys.Apps;
                    break;
                case "btnKeyTab":
                    keyCode = (int)Keys.Tab;
                    break;
                case "btnKeySpace":
                    keyCode = (int)Keys.Space;
                    break;
                case "btnKeyBackSlash":
                    keyCode = (int)Keys.OemPipe;
                    break;
                case "btnKeyTilde":
                    keyCode = (int)Keys.Oemtilde;
                    break;
                case "btnKeyDash":
                    keyCode = (int)Keys.OemMinus;
                    break;
                case "btnKeyPlus":
                    keyCode = (int)Keys.Oemplus;
                    break;
                case "btnKeyComma":
                    keyCode = (int)Keys.Oemcomma;
                    break;
                case "btnKeyPeriod":
                    keyCode = (int)Keys.OemPeriod;
                    break;
                case "btnKeySlash":
                    keyCode = (int)Keys.OemQuestion;
                    break;
                case "btnKeyQuotes":
                    keyCode = (int)Keys.OemQuotes;
                    break;
                case "btnKeySemicolon":
                    keyCode = (int)Keys.OemSemicolon;
                    break;
                case "btnKeyLeftBra":
                    keyCode = (int)Keys.OemOpenBrackets;
                    break;
                case "btnKeyRightBra":
                    keyCode = (int)Keys.OemCloseBrackets;
                    break;
                case "btnKeyEnter":
                    keyCode = (int)Keys.Return;
                    break;
                case "btnKeyUp":
                    keyCode = (int)Keys.Up;
                    break;
                case "btnKeyDown":
                    keyCode = (int)Keys.Down;
                    break;
                case "btnKeyLeft":
                    keyCode = (int)Keys.Left;
                    break;
                case "btnKeyRight":
                    keyCode = (int)Keys.Right;
                    break;
                case "btnKeyDelete":
                    keyCode = (int)Keys.Delete;
                    break;
                case "btnKeyEnd":
                    keyCode = (int)Keys.End;
                    break;
                case "btnKeyPageDown":
                    keyCode = (int)Keys.PageDown;
                    break;
                case "btnKeyPageUp":
                    keyCode = (int)Keys.PageUp;
                    break;
                case "btnKeyHome":
                    keyCode = (int)Keys.Home;
                    break;
                case "btnKeyInsert":
                    keyCode = (int)Keys.Insert;
                    break;
                case "btnKeyPrint":
                    keyCode = (int)Keys.PrintScreen;
                    break;
                case "btnKeyScroll":
                    keyCode = (int)Keys.Scroll;
                    break;
                case "btnKeyPause":
                    keyCode = (int)Keys.Pause;
                    break;
                case "btnKeyNumLock":
                    keyCode = (int)Keys.NumLock;
                    break;
                case "btnKeyPad0":
                    keyCode = (int)Keys.NumPad0;
                    break;
                case "btnKeyPad1":
                    keyCode = (int)Keys.NumPad1;
                    break;
                case "btnKeyPad2":
                    keyCode = (int)Keys.NumPad2;
                    break;
                case "btnKeyPad3":
                    keyCode = (int)Keys.NumPad3;
                    break;
                case "btnKeyPad4":
                    keyCode = (int)Keys.NumPad4;
                    break;
                case "btnKeyPad5":
                    keyCode = (int)Keys.NumPad5;
                    break;
                case "btnKeyPad6":
                    keyCode = (int)Keys.NumPad6;
                    break;
                case "btnKeyPad7":
                    keyCode = (int)Keys.NumPad7;
                    break;
                case "btnKeyPad8":
                    keyCode = (int)Keys.NumPad8;
                    break;
                case "btnKeyPad9":
                    keyCode = (int)Keys.NumPad9;
                    break;
                case "btnKeyPadDiv":
                    keyCode = (int)Keys.Divide;
                    break;
                case "btnKeyPadMul":
                    keyCode = (int)Keys.Multiply;
                    break;
                case "btnKeyPadMinus":
                    keyCode = (int)Keys.Subtract;
                    break;
                case "btnKeyPadPAdd":
                    keyCode = (int)Keys.Add;
                    break;
                case "btnKeyPadDecimal":
                    keyCode = (int)Keys.Decimal;
                    break;
                case "btnKeyPadEnter":
                    keyCode = (int)Keys.Return;
                    break;
                default:
                    break;
            }
            ShowKeyInfo(keyCode);
        }

    }
}
