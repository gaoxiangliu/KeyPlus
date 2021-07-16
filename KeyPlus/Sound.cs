using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeyboardHook01
{
    partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        //private System.Media.SoundPlayer mxBlueDown = new System.Media.SoundPlayer(Properties.Resources.cherry_mx_blue_down);
        //private System.Media.SoundPlayer mxBlueUp = new System.Media.SoundPlayer(Properties.Resources.cherry_mx_blue_up);

        private static ulong trackSequence = 0;

        private void SoundKeyDown(int keyCode)
        {
            if (Keyboard.keysDown.Contains(keyCode))
                return;
            void threadWorking()
            {
                PlaySoundKeyDown(keyCode);
            }
            Thread t = new Thread(threadWorking);
            t.Priority = ThreadPriority.Highest;
            t.Start();
        }


        private void PlaySoundKeyDown(int keyCode)
        {
            string soundPath = Storage.pathSound;
            switch (Configure.mechanicalSound)
            {
                case 0:
                    return;
                case 1:
                    soundPath += "\\cherry_mx_blue_down.wav";
                    break;
                case 2:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\cherry_mx_brown_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\cherry_mx_brown_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\cherry_mx_brown_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\cherry_mx_brown_down.wav";
                            break;
                    }
                    break;
                case 3:
                    soundPath += "\\cherry_mx_red_down.wav";
                    break;
                case 4:
                    soundPath += "\\cherry_mx_silver_down.wav";
                    break;
                case 5:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\cherry_mx_black_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\cherry_mx_black_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\cherry_mx_black_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\cherry_mx_black_down.wav";
                            break;
                    }
                    break;
                case 6:
                    soundPath += "\\cherry_mx_red_silence_down.wav";
                    break;
                case 7:
                    soundPath += "\\cherry_mx_silence_black_down.wav";
                    break;
                case 8:
                    soundPath += "\\cherry_mx_green_down.wav";
                    break;
                case 9:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\novelkeys_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\novelkeys_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\novelkeys_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\novelkeys_down.wav";
                            break;
                    }
                    break;
                case 10:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\holy_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\holy_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\holy_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\holy_down.wav";
                            break;
                    }
                    break;
                case 11:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\turquoise_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\turquoise_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\turquoise_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\turquoise_down.wav";
                            break;
                    }
                    break;
                case 12:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\ink_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\ink_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\ink_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\ink_down.wav";
                            break;
                    }
                    break;
                case 13:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\kailh_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\kailh_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\kailh_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\kailh_down.wav";
                            break;
                    }
                    break;
                case 14:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\buckling_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\buckling_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\buckling_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\buckling_down.wav";
                            break;
                    }
                    break;
                case 15:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\skcm_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\skcm_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\skcm_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\skcm_down.wav";
                            break;
                    }
                    break;
                case 16:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\topre_space_down.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\topre_enter_down.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\topre_bs_down.wav";
                            break;
                        default:
                            soundPath += "\\topre_down.wav";
                            break;
                    }
                    break;
                default:
                    return;
            }
            var now = DateTime.Now;
            string trackName = "d" + now.ToString("yyyyMMddhhmmss") + now.Millisecond.ToString() + trackSequence.ToString();
            ++trackSequence;
            //string trackName = soundPath;
            StringBuilder sb = new StringBuilder();

            mciSendString("open \"" + soundPath + "\" alias " + trackName, sb, 0, IntPtr.Zero);
            mciSendString("play " + trackName, sb, 0, IntPtr.Zero);
            Thread.Sleep(300);
            mciSendString("close " + trackName, sb, 0, IntPtr.Zero);
        }

        private void SoundKeyUp(int keyCode)
        {
            void threadWorking()
            {
                PlaySoundKeyUp(keyCode);
            }
            Thread t = new Thread(threadWorking);
            t.Priority = ThreadPriority.Highest;
            t.Start();
        }

        private void PlaySoundKeyUp(int keyCode)
        {
            string soundPath = Storage.pathSound;
            switch (Configure.mechanicalSound)
            {
                case 0:
                    return;
                case 1:
                    soundPath += "\\cherry_mx_blue_up.wav";
                    break;
                case 2:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\cherry_mx_brown_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\cherry_mx_brown_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\cherry_mx_brown_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\cherry_mx_brown_up.wav";
                            break;
                    }
                    break;
                case 3:
                    soundPath += "\\cherry_mx_red_up.wav";
                    break;
                case 4:
                    soundPath += "\\cherry_mx_silver_up.wav";
                    break;
                case 5:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\cherry_mx_black_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\cherry_mx_black_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\cherry_mx_black_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\cherry_mx_black_up.wav";
                            break;
                    }
                    break;
                case 6:
                    soundPath += "\\cherry_mx_red_silence_up.wav";
                    break;
                case 7:
                    soundPath += "\\cherry_mx_silence_black_up.wav";
                    break;
                case 8:
                    soundPath += "\\cherry_mx_green_up.wav";
                    break;
                case 9:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\novelkeys_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\novelkeys_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\novelkeys_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\novelkeys_up.wav";
                            break;
                    }
                    break;
                case 10:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\holy_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\holy_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\holy_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\holy_up.wav";
                            break;
                    }
                    break;
                case 11:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\turquoise_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\turquoise_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\turquoise_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\turquoise_up.wav";
                            break;
                    }
                    break;
                case 12:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\ink_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\ink_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\ink_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\ink_up.wav";
                            break;
                    }
                    break;
                case 13:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\kailh_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\kailh_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\kailh_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\kailh_up.wav";
                            break;
                    }
                    break;
                case 14:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\buckling_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\buckling_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\buckling_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\buckling_up.wav";
                            break;
                    }
                    break;
                case 15:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\skcm_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\skcm_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\skcm_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\skcm_up.wav";
                            break;
                    }
                    break;
                case 16:
                    switch (keyCode)
                    {
                        case (int)Keys.Space:
                            soundPath += "\\topre_space_up.wav";
                            break;
                        case (int)Keys.Enter:
                            soundPath += "\\topre_enter_up.wav";
                            break;
                        case (int)Keys.Back:
                            soundPath += "\\topre_bs_up.wav";
                            break;
                        default:
                            soundPath += "\\topre_up.wav";
                            break;
                    }
                    break;
                default:
                    return;
            }
            var now = DateTime.Now;
            string trackName = "u" + now.ToString("yyyyMMddhhmmss") + now.Millisecond.ToString() + trackSequence.ToString();
            ++trackSequence;
            //string trackName = soundPath;
            StringBuilder sb = new StringBuilder();
            mciSendString("open \"" + soundPath + "\" alias " + trackName, sb, 0, IntPtr.Zero);
            mciSendString("play " + trackName, sb, 0, IntPtr.Zero);
            Thread.Sleep(300);
            mciSendString("close " + trackName, sb, 0, IntPtr.Zero);
        }
    }
}
