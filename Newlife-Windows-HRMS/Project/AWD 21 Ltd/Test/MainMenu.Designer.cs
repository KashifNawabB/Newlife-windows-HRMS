namespace Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.lblLEFT_LEFT_02 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.i32x32 = new System.Windows.Forms.ImageList(this.components);
            this.i24x24 = new System.Windows.Forms.ImageList(this.components);
            this.i16x16 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBOTTOM = new System.Windows.Forms.Panel();
            this.picBOTTOM_LEFT = new System.Windows.Forms.PictureBox();
            this.panelTOP = new System.Windows.Forms.Panel();
            this.btnToast = new System.Windows.Forms.Button();
            this.picTOP_LEFT_02 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelBOTTOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBOTTOM_LEFT)).BeginInit();
            this.panelTOP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTOP_LEFT_02)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLEFT_LEFT_02
            // 
            this.lblLEFT_LEFT_02.BackColor = System.Drawing.Color.FromArgb(17, 34, 68);
            this.lblLEFT_LEFT_02.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLEFT_LEFT_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLEFT_LEFT_02.Location = new System.Drawing.Point(0, 124);
            this.lblLEFT_LEFT_02.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLEFT_LEFT_02.Name = "lblLEFT_LEFT_02";
            this.lblLEFT_LEFT_02.Size = new System.Drawing.Size(213, 646);
            this.lblLEFT_LEFT_02.TabIndex = 52;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1011, 28);
            this.menuStrip1.TabIndex = 55;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeDetailToolStripMenuItem,
            this.salaryReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Visible = false;
            // 
            // employeeDetailToolStripMenuItem
            // 
            this.employeeDetailToolStripMenuItem.Name = "employeeDetailToolStripMenuItem";
            this.employeeDetailToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.employeeDetailToolStripMenuItem.Text = "Employee Detail";
            this.employeeDetailToolStripMenuItem.Click += new System.EventHandler(this.employeeDetailToolStripMenuItem_Click);
            // 
            // salaryReportToolStripMenuItem
            // 
            this.salaryReportToolStripMenuItem.Name = "salaryReportToolStripMenuItem";
            this.salaryReportToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.salaryReportToolStripMenuItem.Text = "Salary Report";
            this.salaryReportToolStripMenuItem.Click += new System.EventHandler(this.salaryReportToolStripMenuItem_Click);
            // 
            // i32x32
            // 
            this.i32x32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("i32x32.ImageStream")));
            this.i32x32.TransparentColor = System.Drawing.Color.Transparent;
            this.i32x32.Images.SetKeyName(0, "ADD-NEW.png");
            this.i32x32.Images.SetKeyName(1, "MODIFY.png");
            this.i32x32.Images.SetKeyName(2, "SEARCH.png");
            this.i32x32.Images.SetKeyName(3, "DELETE.png");
            this.i32x32.Images.SetKeyName(4, "RELOAD.png");
            this.i32x32.Images.SetKeyName(5, "PREVIEW.png");
            this.i32x32.Images.SetKeyName(6, "CLOSE.png");
            this.i32x32.Images.SetKeyName(7, "hand.png");
            this.i32x32.Images.SetKeyName(8, "17.png");
            this.i32x32.Images.SetKeyName(9, "error.png");
            this.i32x32.Images.SetKeyName(10, "business info.png");
            this.i32x32.Images.SetKeyName(11, "VIEW.png");
            this.i32x32.Images.SetKeyName(12, "SELECT.png");
            // 
            // i24x24
            // 
            this.i24x24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("i24x24.ImageStream")));
            this.i24x24.TransparentColor = System.Drawing.Color.Transparent;
            this.i24x24.Images.SetKeyName(0, "_2player_start.png");
            this.i24x24.Images.SetKeyName(1, "_2player_play_prev.png");
            this.i24x24.Images.SetKeyName(2, "_2player_play.png");
            this.i24x24.Images.SetKeyName(3, "_2player_end.png");
            this.i24x24.Images.SetKeyName(4, "purchase.png");
            this.i24x24.Images.SetKeyName(5, "3.png");
            this.i24x24.Images.SetKeyName(6, "1.png");
            this.i24x24.Images.SetKeyName(7, "2.png");
            this.i24x24.Images.SetKeyName(8, "3.png");
            this.i24x24.Images.SetKeyName(9, "4.png");
            this.i24x24.Images.SetKeyName(10, "3.png");
            // 
            // i16x16
            // 
            this.i16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("i16x16.ImageStream")));
            this.i16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.i16x16.Images.SetKeyName(0, "");
            this.i16x16.Images.SetKeyName(1, "");
            this.i16x16.Images.SetKeyName(2, "");
            this.i16x16.Images.SetKeyName(3, "");
            this.i16x16.Images.SetKeyName(4, "");
            this.i16x16.Images.SetKeyName(5, "");
            this.i16x16.Images.SetKeyName(6, "");
            this.i16x16.Images.SetKeyName(7, "");
            this.i16x16.Images.SetKeyName(8, "");
            this.i16x16.Images.SetKeyName(9, "");
            this.i16x16.Images.SetKeyName(10, "");
            this.i16x16.Images.SetKeyName(11, "");
            this.i16x16.Images.SetKeyName(12, "");
            this.i16x16.Images.SetKeyName(13, "");
            this.i16x16.Images.SetKeyName(14, "");
            this.i16x16.Images.SetKeyName(15, "");
            this.i16x16.Images.SetKeyName(16, "");
            this.i16x16.Images.SetKeyName(17, "");
            this.i16x16.Images.SetKeyName(18, "");
            this.i16x16.Images.SetKeyName(19, "");
            this.i16x16.Images.SetKeyName(20, "");
            this.i16x16.Images.SetKeyName(21, "VIEW.png");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(17, 34, 68);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 126);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(210, 204);
            this.flowLayoutPanel1.TabIndex = 57;

            // 
            // panelBOTTOM
            // 
            this.panelBOTTOM.BackgroundImage = global::Test.Properties.Resources.HR1;
            this.panelBOTTOM.Controls.Add(this.picBOTTOM_LEFT);
            this.panelBOTTOM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBOTTOM.Location = new System.Drawing.Point(0, 770);
            this.panelBOTTOM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBOTTOM.Name = "panelBOTTOM";
            this.panelBOTTOM.Size = new System.Drawing.Size(1011, 52);
            this.panelBOTTOM.TabIndex = 50;
            // 
            // picBOTTOM_LEFT
            // 
            this.picBOTTOM_LEFT.BackgroundImage = global::Test.Properties.Resources.HR1;
            this.picBOTTOM_LEFT.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBOTTOM_LEFT.Location = new System.Drawing.Point(0, 0);
            this.picBOTTOM_LEFT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBOTTOM_LEFT.Name = "picBOTTOM_LEFT";
            this.picBOTTOM_LEFT.Size = new System.Drawing.Size(430, 52);
            this.picBOTTOM_LEFT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBOTTOM_LEFT.TabIndex = 1;
            this.picBOTTOM_LEFT.TabStop = false;
            // 
            // panelTOP
            // 
            this.panelTOP.BackgroundImage = global::Test.Properties.Resources.payroll_03;
            this.panelTOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTOP.Controls.Add(this.btnToast);
            this.panelTOP.Controls.Add(this.picTOP_LEFT_02);
            this.panelTOP.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTOP.Location = new System.Drawing.Point(0, 28);
            this.panelTOP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTOP.Name = "panelTOP";
            this.panelTOP.Size = new System.Drawing.Size(1011, 96);
            this.panelTOP.TabIndex = 2;
            // 
            // btnToast
            // 
            this.btnToast.BackColor = System.Drawing.Color.FromArgb(212, 175, 55);
            this.btnToast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToast.ForeColor = System.Drawing.Color.FromArgb(17, 34, 68);
            this.btnToast.Location = new System.Drawing.Point(761, 62);
            this.btnToast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnToast.Name = "btnToast";
            this.btnToast.Size = new System.Drawing.Size(239, 32);
            this.btnToast.TabIndex = 2;
            this.btnToast.Text = "Expiring Documents";
            this.btnToast.UseVisualStyleBackColor = false;
            this.btnToast.Visible = false;
            this.btnToast.Click += new System.EventHandler(this.btnToast_Click);
            // 
            // picTOP_LEFT_02
            // 
            this.picTOP_LEFT_02.Dock = System.Windows.Forms.DockStyle.Left;
            this.picTOP_LEFT_02.Image = global::Test.Properties.Resources.HR2_2;
            this.picTOP_LEFT_02.Location = new System.Drawing.Point(0, 0);
            this.picTOP_LEFT_02.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picTOP_LEFT_02.Name = "picTOP_LEFT_02";
            this.picTOP_LEFT_02.Size = new System.Drawing.Size(302, 94);
            this.picTOP_LEFT_02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTOP_LEFT_02.TabIndex = 1;
            this.picTOP_LEFT_02.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 822);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblLEFT_LEFT_02);
            this.Controls.Add(this.panelBOTTOM);
            this.Controls.Add(this.panelTOP);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Life Windows UK Ltd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelBOTTOM.ResumeLayout(false);
            this.panelBOTTOM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBOTTOM_LEFT)).EndInit();
            this.panelTOP.ResumeLayout(false);
            this.panelTOP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTOP_LEFT_02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTOP;
        private System.Windows.Forms.PictureBox picTOP_LEFT_02;
        private System.Windows.Forms.Panel panelBOTTOM;
        private System.Windows.Forms.PictureBox picBOTTOM_LEFT;
        private System.Windows.Forms.Label lblLEFT_LEFT_02;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ImageList i32x32;
        public System.Windows.Forms.ImageList i24x24;
        public System.Windows.Forms.ImageList i16x16;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryReportToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnToast;
    }
}

