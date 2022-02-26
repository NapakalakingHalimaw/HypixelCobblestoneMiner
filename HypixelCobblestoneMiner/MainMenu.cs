using System;
using System.Collections.Concurrent;
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
using System.Media;

namespace HypixelCobblestoneMiner
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            labelState.Text = GetTimerState();
            textDegrees.Text = "0";
            textTimer.Text = "0";
        }

        //Setting an application to foreground window
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        //Setting X,Y mouse position
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        //Getting a keyboard event for keystroke simulation
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const int KEYEVENTF_KEYUP = 0x0002;

        //Getting a mouse event for mouseclick simulation
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        //enum holding state of specific application details
        enum State
        {
            Stopped,
            Running,
            Enabled,
            Disabled
        }

        //static InputSimulator simulator = new InputSimulator();
        readonly Random rnd = new Random();
        readonly int x = MousePosition.X;
        readonly int y = MousePosition.Y;
        int time, shifts, interval;
        bool wActivated = false;
        bool shiftActivated = false;

        // default 967,628
        readonly int[] slots = new int[] { 820, 855, 890, 930, 960, 1000, 1035, 1070, 1105 };
        int slotIndex = -1;
        bool[] slotUsed = new bool[] { false, false, false, false, false, false, false, false, false };
        int shiftsToStack = 16;

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

        private async void shiftTimer_Tick(object sender, EventArgs e)
        {
            if(shiftActivated)
            {
                keybd_event((byte)Keys.ShiftKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
                await Task.Delay(500);
                keybd_event((byte)Keys.ShiftKey, 0, KEYEVENTF_KEYUP, 0);

                // ------ Debug ------
                /*
                 * txtTasks.Text += "Slot Index: " + slotIndex + "\r\n";
                 * for (int i = 0; i < slotUsed.Length; i++)
                 * {
                 *    txtTasks.Text += i + " slot: " + slotUsed[i] + "\r\n";
                 * }
                 */
                // ------ Debug ------

                shifts++;
                labelTask.Text = "Current shift count: " + shifts;
                if(shifts == shiftsToStack)
                {
                    await Task.Delay(1000);

                    // Open Inventory
                    keybd_event((byte)Keys.E, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event((byte)Keys.E, 0, KEYEVENTF_KEYUP, 0);
                    //txtTasks.Text += "Opening Inventory\r\n";

                    await Task.Delay(1000);

                    // Move cursor on an Item slot 
                    SetCursorPos(MousePosition.X, MousePosition.Y + 20); //hardcoded, don't need to dynamically change it
                    //txtTasks.Text += "Setting curPos\r\n";

                    await Task.Delay(1000);

                    // Double click to stack eggs in 1 slot
                    mouse_event(MOUSEEVENTF_LEFTDOWN, MousePosition.X, MousePosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, MousePosition.X, MousePosition.Y, 0, 0);

                    await Task.Delay(100);

                    mouse_event(MOUSEEVENTF_LEFTDOWN, MousePosition.X, MousePosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, MousePosition.X, MousePosition.Y, 0, 0);
                    //txtTasks.Text += "Performing double click\r\n";

                    await Task.Delay(1000);

                    // Place them on bottom slots
                    //SetCursorPos(MousePosition.X, MousePosition.Y + 75);
                    int index = DetermineEmptySlotIndex();
                    txtTasks.Text += "Index of next valid slot: " + (index + 1) + "\r\n";
                    txtTasks.Text += "Empty slot found: " + FindEmptySlot(index) + "\r\n";
                    SetCursorPos(FindEmptySlot(index), MousePosition.Y + 75); //hardcoded, don't need to dynamically change it
                    mouse_event(MOUSEEVENTF_LEFTDOWN, MousePosition.X, MousePosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, MousePosition.X, MousePosition.Y, 0, 0);
                    txtTasks.Text += "Placing items on the " + (index + 1) + " slot\r\n";

                    await Task.Delay(1000);

                    // Close Inventory
                    keybd_event((byte)Keys.E, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    keybd_event((byte)Keys.E, 0, KEYEVENTF_KEYUP, 0);
                    //txtTasks.Text += "Closing Inventory\r\n";

                    // Reset shifts back to 0
                    shifts = 0;
                }
            } else
            {
                shiftTimer.Enabled = false;
            }
        }

        private void textTimer_TextChanged(object sender, EventArgs e)
        {
            if (textTimer.Text == "" || textTimer.Text.Trim() == string.Empty)
            {
                textTimer.Text = "0";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(!mineTimer.Enabled)
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
            shiftTimer.Stop();
            wActivated = false;
            labelState.Text = GetTimerState();

            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            keybd_event((byte)Keys.W, 0, KEYEVENTF_KEYUP, 0);

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
            labelState.Text = "Loading...";
            this.Refresh();
            labelState.Text = GetTimerState();
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

                    //Simulate holding W on another thread, so we won't freeze the actual application

                } else
                {
                    wActivated = false;
                    labelTask.Text = "Process javaw.exe could not be found!";
                }

                labelHolder.Text = "W Holder: " + GetHolderState().ToString();
            }
            else
            {
                //Cancel the thread holding W key

                wActivated = false;
                labelHolder.Text = "W Holder: " + GetHolderState().ToString();
            }
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            if(!shiftActivated)
            {
                shiftActivated = true;

                Process p = Process.GetProcessesByName("javaw").FirstOrDefault();
                if(p != null)
                {
                    SetForegroundWindow(p.MainWindowHandle);
                    shiftTimer.Start();

                    labelTask.Text = "Auto-Shifter activated successfully!";
                } else
                {
                    shiftActivated = false;
                    labelTask.Text = "Process javaw.exe could not be found!";
                }
            } else
            {
                shiftActivated = false;
                labelTask.Text = "Auto-Shifter deactivated successfully!";
            }

        }

        private void labelHolder_Click(object sender, EventArgs e)
        {
            labelHolder.Text = "Loading...";
            this.Refresh();
            labelHolder.Text = "W Holder: " + GetHolderState().ToString();
        }

        int GetInterval(string txtInterval)
        {
            return int.TryParse(txtInterval, out interval) ? interval : mineTimer.Interval;
        }

        string GetTimerState()
        {
            return mineTimer.Enabled ? "State: " + State.Running.ToString() : "State: " + State.Stopped.ToString();
        }

        State GetHolderState()
        {
            return wActivated ? State.Enabled : State.Disabled;
        }

        int DetermineEmptySlotIndex()
        {
            int prevSlot = slotIndex;

            for (int i = 0; i < slotUsed.Length; i++)
            {
                if (!slotUsed[i])
                {
                    slotIndex = i;
                    slotUsed[i] = true;
                    break;
                }
            }

            if (slotIndex > slots.Length)
            {
                labelTask.Text = "Invalid index value!";
                shiftActivated = false;
                return -1;
            }
            else if (prevSlot == slotIndex)
            {
                labelTask.Text = "Index has the same value as previous one!";
                shiftActivated = false;
                return -1;
            }
            else
                return slotIndex;
        }

        int FindEmptySlot(int index)
        {
            //int slot = -1;

            if(index == -1)
            {
                labelTask.Text = "Could not find a valid empty slot! Disabling Auto-Shifter!";
                shiftActivated = false;

                SystemSounds.Asterisk.Play();
                Task.Delay(500).Wait();
                SystemSounds.Asterisk.Play();
                Task.Delay(500).Wait();
                SystemSounds.Asterisk.Play();

                return -1;
            }

            int slot = slots[index];

            if (slot != -1)
                return slot;
            else
                throw new ArgumentException("Slot value is not valid!");
        }
    }
}
