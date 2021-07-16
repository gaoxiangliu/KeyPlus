using System.Windows.Forms;

namespace KeyboardHook01
{
    partial class Form1 : Form
    {
        /// <summary>
        /// call back function when any key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GKH_KeyDown(object sender, KeyEventArgs e)
        {
            //TimeSpan ts = DateTime.Now.Subtract(Keyboard.keyCountCurrentStartsFrom);
            //MessageBox.Show(ts.TotalMilliseconds.ToString());

            SoundKeyDown(e.KeyValue);

            // update functional key status
            KeyAssignment.PresFunctionKey(e.KeyValue);

            // execute key command
            if (Configure.enableKeyAssignment == 1 && !KeyAssignment.IsFunctionKey(e.KeyValue))
            {
                string comboKeyString = KeyAssignment.GetCombinationKeyString(e.KeyValue);
                KeyAssignment.ExecuteCmd(comboKeyString, this);
            }

            // update LED indicator status
            if (e.KeyValue == (int)Keys.NumLock && !pressNumLock)
            {
                indicatorNumLock = !indicatorNumLock;
                UpdateLEDIndicatorStatus();
                pressNumLock = true;
            }
            if (e.KeyValue == (int)Keys.CapsLock && !pressCapsLock)
            {
                indicatorCapsLock = !indicatorCapsLock;
                UpdateLEDIndicatorStatus();
                pressCapsLock = true;
            }
            if (e.KeyValue == (int)Keys.Scroll && !pressScrollLock)
            {
                indicatorScrollLock = !indicatorScrollLock;
                UpdateLEDIndicatorStatus();
                pressScrollLock = true;
            }

            // display key char and show keystroke when in keyboard testing mode
            if (Configure.mode == 2)
            {
                SetTestColorForOneKey(e.KeyValue, 1);
                lblKeyInput.Text = Keyboard.keyChar[e.KeyValue].ToString() + " " + lblKeyInput.Text;
            }

            // store the moment when the current key being pressed
            //Keyboard.keyPressedMoment.Push(DateTime.Now);

            // record current pressed key
            //if (Keyboard.lastKeyDown != e.KeyValue)
            //{
            //    KeyAssignment.currentKeyDown += ("|" + e.KeyValue);

            //}

            ShowKeyInfo(e.KeyValue);
            Keyboard.keysDown.Add(e.KeyValue);
        }

        /// <summary>
        /// call back function when any key is released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GKH_KeyUp(object sender, KeyEventArgs e)
        {
            Keyboard.keysDown.Remove(e.KeyValue);

            SoundKeyUp(e.KeyValue);

            // update functional key statu
            KeyAssignment.ReleaseFunctionKey(e.KeyValue);

            isKeyPressed = true;
            Keyboard.AddOneHit(e.KeyValue);

            // update LED indicator status
            if (e.KeyValue == (int)Keys.NumLock)
                pressNumLock = false;
            if (e.KeyValue == (int)Keys.CapsLock)
                pressCapsLock = false;
            if (e.KeyValue == (int)Keys.Scroll)
                pressScrollLock = false;

            // show keystrokes graph
            if (Configure.refreshMode == 1 && Configure.mode != 2)
                ShowKeystrokesGraphByCurrentMode();

            // show keystroke trace when in keyboard testing mode
            if (Configure.mode == 2)
            {
                if (Configure.keepTrace == 1)
                    SetTestColorForOneKey(e.KeyValue, 2);
                else
                    SetTestColorForOneKey(e.KeyValue, 0);
            }
            //MessageBox.Show(e.KeyCode.ToString());

            ShowKeyInfo(e.KeyValue);

            // for spacebar CPS test
            if (formSpaceCPS.isReady())
            {
                formSpaceCPS.SpacePressedDown();
            }

            // calculate the depressed time for the key
            //var previousMoment = Keyboard.keyPressedMoment.Pop();

            // wipe this key from record
            //KeyAssignment.currentKeyDown = KeyAssignment.currentKeyDown.Substring(0, KeyAssignment.currentKeyDown.LastIndexOf("|"));
            //MessageBox.Show(KeyAssignment.currentKeyDown);

        }

    }
}
