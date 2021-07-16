using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace KeyboardHook01
{
    partial class Form1 : Form
    {
        private Graphics graph;

        private void InitializeCanvas()
        {
            graph = lblKeyInput.CreateGraphics();
        }

        private void MyDrawLine(Color color, int positiion)
        {
            Pen myPen = new Pen(color, 1);
            graph.DrawLine(myPen, positiion, 0, positiion, lblKeyInput.Height);
        }

        /*
         * It seems that GDI+ sucks, drawing is slowly
         * so, I latter on used the picture box, but retain the previous code
         * and the file name is still the same, cause I don't want to change code
         * in a large scale
         
        private void MyDrawColorIndicator()
        {
            void threadWorking()
            {
                Thread.Sleep(100);
                lock (lblKeyInput)
                {
                    if (Configure.mode == 0 || Configure.mode == 1)
                    {
                        for (int i = 0; i < lblKeyInput.Width; i++)
                        {
                            Color color = ColorUtil.DisplayColor(Configure.colorKeystroke, 0, (ulong)lblKeyInput.Width - 1, (ulong)i);
                            MyDrawLine(color, i);
                        }
                    }
                }
            }
            if (Configure.mode == 0 || Configure.mode == 1)
            {
                Thread thread = new Thread(threadWorking);
                thread.Priority = ThreadPriority.Highest;
                thread.Start();
            }
        }

        private void MyDrawClear()
        {
            void threadWorking()
            {
                lock (lblKeyInput)
                {
                    graph.Clear(lblKeyInput.BackColor);
                }
            }
            Thread thread = new Thread(threadWorking);
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }
        */

        private void MyDrawColorIndicator()
        {
            if (Configure.mode == 0 || Configure.mode == 1)
            {
                picIndicator.Visible = true;
                lblKeyInput.Visible = false;
                switch (Configure.colorKeystroke)
                {
                    case 0:
                        picIndicator.Image = Properties.Resources.red;
                        break;
                    case 1:
                        picIndicator.Image = Properties.Resources.green;
                        break;
                    case 2:
                        picIndicator.Image = Properties.Resources.blue;
                        break;
                    case 3:
                        picIndicator.Image = Properties.Resources.yellow;
                        break;
                    case 4:
                        picIndicator.Image = Properties.Resources.cyan;
                        break;
                    case 5:
                        picIndicator.Image = Properties.Resources.magenta;
                        break;
                    case 6:
                        picIndicator.Image = Properties.Resources.half_rainbow;
                        break;
                    case 7:
                        picIndicator.Image = Properties.Resources.rainbow;
                        break;
                    case 8:
                        picIndicator.Image = Properties.Resources.black_and_white;
                        break;
                    default:
                        break;
                }
            }
            else if (Configure.mode == 2)
            {
                MyDrawClear();
            }
        }

        private void MyDrawClear()
        {
            picIndicator.Visible = false;
            lblKeyInput.Visible = true;
            lblKeyInput.Text = "";
        }
    }
}
