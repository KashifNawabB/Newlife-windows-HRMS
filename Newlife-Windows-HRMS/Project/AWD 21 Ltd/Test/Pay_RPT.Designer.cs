namespace Test
{
    partial class Pay_RPT
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.txtempid = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Pay_DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HRMS_DBDataSet1 = new Test.PayDetailsDataset();
            this.Pay_DetailsTableAdapter = new Test.PayDetailsDatasetTableAdapters.Pay_DetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Pay_DetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRMS_DBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtempid
            // 
            this.txtempid.Location = new System.Drawing.Point(151, 12);
            this.txtempid.Name = "txtempid";
            this.txtempid.Size = new System.Drawing.Size(117, 20);
            this.txtempid.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(373, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Salary Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(521, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "PRINT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Pay_DetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Test.PayRpt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 53);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(639, 380);
            this.reportViewer1.TabIndex = 5;
            // 
            // Pay_DetailsBindingSource
            // 
            this.Pay_DetailsBindingSource.DataMember = "Pay_Details";
            this.Pay_DetailsBindingSource.DataSource = this.HRMS_DBDataSet1;
            // 
            // HRMS_DBDataSet1
            // 
            this.HRMS_DBDataSet1.DataSetName = "HRMS_DBDataSet1";
            this.HRMS_DBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Pay_DetailsTableAdapter
            // 
            this.Pay_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // Pay_RPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 445);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtempid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pay_RPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pay_RPT_FormClosing);
            this.Load += new System.EventHandler(this.Pay_RPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pay_DetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRMS_DBDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtempid;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private PayDetailsDataset HRMS_DBDataSet1;
        private PayDetailsDatasetTableAdapters.Pay_DetailsTableAdapter Pay_DetailsTableAdapter;
        public System.Windows.Forms.BindingSource Pay_DetailsBindingSource;
    }
}