namespace Test
{
    partial class Roster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Roster));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDownloadPic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterMonth = new System.Windows.Forms.ComboBox();
            this.tbFilterYear = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dgvRoster = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelFile = new System.Windows.Forms.Button();
            this.btnExpExcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.header1 = new PhoneBook.UserControls.Header();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoster)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnDownloadPic);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(844, 52);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(9, 24, 27, 24);
            this.panel4.Size = new System.Drawing.Size(777, 445);
            this.panel4.TabIndex = 33;
            // 
            // btnDownloadPic
            // 
            this.btnDownloadPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDownloadPic.Location = new System.Drawing.Point(9, 24);
            this.btnDownloadPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDownloadPic.Name = "btnDownloadPic";
            this.btnDownloadPic.Size = new System.Drawing.Size(741, 37);
            this.btnDownloadPic.TabIndex = 24;
            this.btnDownloadPic.Text = "Download Picture";
            this.btnDownloadPic.UseVisualStyleBackColor = true;
            this.btnDownloadPic.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(9, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(741, 397);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.BtnFilter);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cmbFilterMonth);
            this.panel3.Controls.Add(this.tbFilterYear);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.dgvRoster);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(836, 445);
            this.panel3.TabIndex = 32;
            // 
            // BtnFilter
            // 
            this.BtnFilter.Location = new System.Drawing.Point(260, 146);
            this.BtnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnFilter.Name = "BtnFilter";
            this.BtnFilter.Size = new System.Drawing.Size(119, 30);
            this.BtnFilter.TabIndex = 39;
            this.BtnFilter.Text = "Filter";
            this.BtnFilter.UseVisualStyleBackColor = true;
            this.BtnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "Year(YYYY)";
            // 
            // cmbFilterMonth
            // 
            this.cmbFilterMonth.FormattingEnabled = true;
            this.cmbFilterMonth.Items.AddRange(new object[] {
            "All",
            "January",
            "February",
            "March",
            "April",
            "May",
            "Jun",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbFilterMonth.Location = new System.Drawing.Point(22, 150);
            this.cmbFilterMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilterMonth.Name = "cmbFilterMonth";
            this.cmbFilterMonth.Size = new System.Drawing.Size(108, 24);
            this.cmbFilterMonth.TabIndex = 39;
            // 
            // tbFilterYear
            // 
            this.tbFilterYear.Location = new System.Drawing.Point(151, 150);
            this.tbFilterYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFilterYear.Name = "tbFilterYear";
            this.tbFilterYear.Size = new System.Drawing.Size(83, 22);
            this.tbFilterYear.TabIndex = 39;
            this.tbFilterYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterYear_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(17, 34, 68);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbMonth);
            this.panel1.Controls.Add(this.tbYear);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.tbFilePath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Location = new System.Drawing.Point(20, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 90);
            this.panel1.TabIndex = 18;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(684, 46);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(119, 31);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Year(YYYY)";
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "Jun",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(65, 52);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(108, 24);
            this.cmbMonth.TabIndex = 35;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(326, 52);
            this.tbYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(80, 22);
            this.tbYear.TabIndex = 34;
            this.tbYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbYear_KeyPress);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(268, 14);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(138, 26);
            this.dtpTo.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(65, 14);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(138, 26);
            this.dtpFrom.TabIndex = 31;
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(559, 46);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(119, 31);
            this.btnUpload.TabIndex = 17;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(428, 17);
            this.tbFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(251, 22);
            this.tbFilePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "From";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(684, 14);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(119, 27);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse Roaster";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dgvRoster
            // 
            this.dgvRoster.AllowUserToAddRows = false;
            this.dgvRoster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRoster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoster.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRoster.Location = new System.Drawing.Point(22, 182);
            this.dgvRoster.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRoster.Name = "dgvRoster";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoster.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoster.RowTemplate.Height = 28;
            this.dgvRoster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoster.Size = new System.Drawing.Size(676, 259);
            this.dgvRoster.TabIndex = 19;
            this.dgvRoster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoster_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnDelFile);
            this.panel2.Controls.Add(this.btnExpExcel);
            this.panel2.Location = new System.Drawing.Point(703, 182);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 234);
            this.panel2.TabIndex = 24;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(4, 106);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 47);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelFile
            // 
            this.btnDelFile.Location = new System.Drawing.Point(4, 2);
            this.btnDelFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelFile.Name = "btnDelFile";
            this.btnDelFile.Size = new System.Drawing.Size(116, 47);
            this.btnDelFile.TabIndex = 21;
            this.btnDelFile.Text = "Delete File";
            this.btnDelFile.UseVisualStyleBackColor = true;
            this.btnDelFile.Click += new System.EventHandler(this.btnDelFile_Click);
            // 
            // btnExpExcel
            // 
            this.btnExpExcel.Location = new System.Drawing.Point(4, 54);
            this.btnExpExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExpExcel.Name = "btnExpExcel";
            this.btnExpExcel.Size = new System.Drawing.Size(116, 47);
            this.btnExpExcel.TabIndex = 22;
            this.btnExpExcel.Text = "Export to Excel";
            this.btnExpExcel.UseVisualStyleBackColor = true;
            this.btnExpExcel.Click += new System.EventHandler(this.btnExpExcel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Filter by Month";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select Employee Document";
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.Color.White;
            this.header1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header1.BackgroundImage")));
            this.header1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.header1.Description = "";
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1634, 54);
            this.header1.TabIndex = 31;
            this.header1.Title = "Weekly Roster";
            // 
            // Roster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1634, 507);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Roster";
            this.Text = "Roster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Roster_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoster)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dgvRoster;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelFile;
        private System.Windows.Forms.Button btnExpExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button BtnFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterMonth;
        private System.Windows.Forms.TextBox tbFilterYear;
        private System.Windows.Forms.Button btnDownloadPic;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private PhoneBook.UserControls.Header header1;
    }
}