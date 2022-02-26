namespace HypixelCobblestoneMiner
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textTimer = new System.Windows.Forms.TextBox();
            this.mineTimer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textDegrees = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.labelInterval = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textInterval = new System.Windows.Forms.TextBox();
            this.labelState = new System.Windows.Forms.Label();
            this.btnW = new System.Windows.Forms.Button();
            this.labelHolder = new System.Windows.Forms.Label();
            this.labelTask = new System.Windows.Forms.Label();
            this.txtTasks = new System.Windows.Forms.TextBox();
            this.btnShift = new System.Windows.Forms.Button();
            this.shiftTimer = new System.Windows.Forms.Timer(this.components);
            this.labelDebugger = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "How long (in seconds) do you want the CobbleMiner to work?";
            // 
            // textTimer
            // 
            this.textTimer.Location = new System.Drawing.Point(15, 35);
            this.textTimer.Name = "textTimer";
            this.textTimer.Size = new System.Drawing.Size(100, 20);
            this.textTimer.TabIndex = 1;
            this.textTimer.TextChanged += new System.EventHandler(this.textTimer_TextChanged);
            // 
            // mineTimer
            // 
            this.mineTimer.Interval = 1000;
            this.mineTimer.Tick += new System.EventHandler(this.mineTimer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 182);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Wiggle level (in degrees)";
            // 
            // textDegrees
            // 
            this.textDegrees.Location = new System.Drawing.Point(15, 156);
            this.textDegrees.Name = "textDegrees";
            this.textDegrees.Size = new System.Drawing.Size(100, 20);
            this.textDegrees.TabIndex = 3;
            this.textDegrees.TextChanged += new System.EventHandler(this.textDegrees_TextChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(245, 213);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(84, 13);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Timer: Waiting...";
            this.labelTime.Click += new System.EventHandler(this.labelTime_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(96, 182);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Force Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(236, 200);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(93, 13);
            this.labelInterval.TabIndex = 0;
            this.labelInterval.Text = "Interval: Waiting...";
            this.labelInterval.Click += new System.EventHandler(this.labelInterval_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Interval (change only if you want the time to pass faster / slower)";
            // 
            // textInterval
            // 
            this.textInterval.Location = new System.Drawing.Point(15, 96);
            this.textInterval.Name = "textInterval";
            this.textInterval.Size = new System.Drawing.Size(100, 20);
            this.textInterval.TabIndex = 2;
            this.textInterval.TextChanged += new System.EventHandler(this.textInterval_TextChanged);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(245, 187);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(83, 13);
            this.labelState.TabIndex = 0;
            this.labelState.Text = "State: Waiting...";
            this.labelState.Click += new System.EventHandler(this.labelState_Click);
            // 
            // btnW
            // 
            this.btnW.Enabled = false;
            this.btnW.Location = new System.Drawing.Point(15, 211);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(75, 23);
            this.btnW.TabIndex = 6;
            this.btnW.Text = "Hold W";
            this.btnW.UseVisualStyleBackColor = true;
            this.btnW.Click += new System.EventHandler(this.btnW_Click);
            // 
            // labelHolder
            // 
            this.labelHolder.AutoSize = true;
            this.labelHolder.Location = new System.Drawing.Point(12, 237);
            this.labelHolder.Name = "labelHolder";
            this.labelHolder.Size = new System.Drawing.Size(99, 13);
            this.labelHolder.TabIndex = 0;
            this.labelHolder.Text = "W Holder: Disabled";
            this.labelHolder.Click += new System.EventHandler(this.labelHolder_Click);
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Location = new System.Drawing.Point(12, 250);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(82, 13);
            this.labelTask.TabIndex = 0;
            this.labelTask.Text = "Task: Waiting...";
            // 
            // txtTasks
            // 
            this.txtTasks.Location = new System.Drawing.Point(15, 296);
            this.txtTasks.Multiline = true;
            this.txtTasks.Name = "txtTasks";
            this.txtTasks.ReadOnly = true;
            this.txtTasks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTasks.Size = new System.Drawing.Size(313, 72);
            this.txtTasks.TabIndex = 8;
            // 
            // btnShift
            // 
            this.btnShift.Location = new System.Drawing.Point(96, 211);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(75, 23);
            this.btnShift.TabIndex = 7;
            this.btnShift.Text = "Auto-Shifter";
            this.btnShift.UseVisualStyleBackColor = true;
            this.btnShift.Click += new System.EventHandler(this.btnShift_Click);
            // 
            // shiftTimer
            // 
            this.shiftTimer.Interval = 20500;
            this.shiftTimer.Tick += new System.EventHandler(this.shiftTimer_Tick);
            // 
            // labelDebugger
            // 
            this.labelDebugger.AutoSize = true;
            this.labelDebugger.Location = new System.Drawing.Point(12, 280);
            this.labelDebugger.Name = "labelDebugger";
            this.labelDebugger.Size = new System.Drawing.Size(54, 13);
            this.labelDebugger.TabIndex = 9;
            this.labelDebugger.Text = "Debugger";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 380);
            this.Controls.Add(this.labelDebugger);
            this.Controls.Add(this.btnShift);
            this.Controls.Add(this.txtTasks);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.labelHolder);
            this.Controls.Add(this.btnW);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.textInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textDegrees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.textTimer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Hypixel Utilities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTimer;
        private System.Windows.Forms.Timer mineTimer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDegrees;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textInterval;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Label labelHolder;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.TextBox txtTasks;
        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.Timer shiftTimer;
        private System.Windows.Forms.Label labelDebugger;
    }
}

