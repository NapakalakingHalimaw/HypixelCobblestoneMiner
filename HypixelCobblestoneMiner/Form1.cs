using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace HypixelCobblestoneMiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelState.Text = GetTimerState();
            textDegrees.Text = "0";
        }

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        enum State
        {
            Stopped,
            Running,
            Enabled,
            Disabled
        }

        static InputSimulator simulator = new InputSimulator();
        Random rnd = new Random();
        int time, interval;
        int x = MousePosition.X;
        int y = MousePosition.Y;
        bool wActivated = false;

        private void mineTimer_Tick(object sender, EventArgs e)
        {
            labelInterval.Text = "Interval: " + mineTimer.Interval.ToString();
            time++;
            labelTime.Text = "Timer: " + time.ToString();
            labelState.Text = GetTimerState();

            //hold LMB and move mouse in textDegrees.Text
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            if (time % 2 == 0)
                SetCursorPos(MousePosition.X + rnd.Next(0, Int32.Parse(textDegrees.Text)), MousePosition.Y);
            else
                SetCursorPos(MousePosition.X - rnd.Next(0, Int32.Parse(textDegrees.Text)), MousePosition.Y);

            if(time > Int32.Parse(textTimer.Text))
            {
                mineTimer.Stop();
                labelState.Text = GetTimerState();
                time = 0;
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
        }

        private void textTimer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            mineTimer.Start();
        }

        private void textDegrees_TextChanged(object sender, EventArgs e)
        {
            if(textDegrees.Text == "" || textDegrees.Text.Trim() == string.Empty)
            {
                textDegrees.Text = "0";
            }
        }

        private void labelTime_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mineTimer.Stop();
            labelState.Text = GetTimerState();
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            time = 0;
        }

        private void labelInterval_Click(object sender, EventArgs e)
        {

        }

        private void textInterval_TextChanged(object sender, EventArgs e)
        {
            if(textInterval.Text == "" || textInterval.Text.Trim() == string.Empty)
            {
                return;
            }

            mineTimer.Interval = GetInterval(textInterval.Text);
        }

        private void labelState_Click(object sender, EventArgs e)
        {
            this.Refresh();
            labelState.Text = GetTimerState();
        }

        string GetTimerState()
        {
            string state;

            if (mineTimer.Enabled)
                state = "State: " + State.Running.ToString();
            else
                state = "State: " + State.Stopped.ToString();

            return state;
        }

        private void btnW_Click(object sender, EventArgs e)
        {

            if (!wActivated)
            {
                wActivated = true;

                Process p = Process.GetProcessesByName("javaw").FirstOrDefault();
                if (p != null)
                {
                    SetForegroundWindow(p.MainWindowHandle);
                }

                labelHolder.Text = "W Holder: " + State.Enabled.ToString();
            }
            else
            {
                wActivated = false;
                labelHolder.Text = "W Holder: " + State.Disabled.ToString();
            }

            if(wActivated)
            {
                //Simulate holding W
                Keyboard.HoldKey((byte)Keys.W, time);
                /*simulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);
                for (int i = 0; i < time; i++)
                {
                    simulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);
                    Thread.Sleep(100);
                    simulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
                }*/
            } else
            {
                
            }
        }

        private void labelHolder_Click(object sender, EventArgs e)
        {

        }

        int GetInterval(string txtInterval)
        {
            if (Int32.TryParse(txtInterval, out interval))
            {
                return interval;
            }
            else
            {
                return mineTimer.Interval;
            }
        }
    }

    public class Keyboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag
        const int PauseBetweenStrokes = 150;

        public static void HoldKey(byte key, int duration)
        {
            int totalDuration = 0;
            while (totalDuration < duration)
            {
                keybd_event(key, 0, KEY_DOWN_EVENT, 0);
                Thread.Sleep(PauseBetweenStrokes);
                keybd_event(key, 0, KEY_UP_EVENT, 0);
                totalDuration += PauseBetweenStrokes;
            }
        }
    }
}
