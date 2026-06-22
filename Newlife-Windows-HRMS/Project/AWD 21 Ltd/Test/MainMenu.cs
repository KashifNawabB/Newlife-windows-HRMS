using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Test
{
    public partial class MainMenu : Form
    {
        private string toast_msg = "";
        private DateTime lastExecutionTime = DateTime.MinValue;

        public MainMenu()
        {
            InitializeComponent();
        }

        Commoncls cls = new Commoncls();
        public static MainMenu publicMDIParent;

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer2.Interval = 60000; // 1 minute in milliseconds
            //timer2.Start();
            ShortCutMenu sForm = new ShortCutMenu();
            sForm.MdiParent = this;
            sForm.Show();
            publicMDIParent = this;
            checkExpiryDocuments();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                refreshToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                checkExpiryDocuments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void employeeDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emp_RPT emprpt = new Emp_RPT();
            emprpt.ShowDialog();
        }

        private void salaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pay_RPT par = new Pay_RPT();
            par.ShowDialog();
        }


        private void checkExpiryDocuments()
        {
            using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
            {
                string query = @"SELECT d.Title, d.Emp_Id, d.Exp_Date, e.First_Name
                                  FROM Documents d
                                  JOIN Emp_Details e ON d.Emp_Id = e.Emp_Id
                                  WHERE DATE(d.Exp_Date) <= DATE('now', '+1 month')";


                SQLiteDataAdapter sda = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                toast_msg = "";
                foreach (DataRow row in dt.Rows)
                {
                    toast_msg += $"Document: {row["Title"]}, \nEmployee: {row["First_Name"]}, \nEmployee ID: {row["Emp_Id"]}, \nis Expiring on {row["Exp_Date"]} \n\n";
                }
                if (dt.Rows.Count > 0)
                {
                    btnToast.Visible = true;
                }
                else
                {
                    btnToast.Visible = false;
                }
                sda.Dispose();
            }
        }

        private void btnToast_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toast_msg, "Expiring Documents",MessageBoxButtons.OK);
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    DateTime currentTime = DateTime.Now;

        //    if ((currentTime - lastExecutionTime).TotalHours >= 24)
        //    {
        //        // Execute your code here
        //        MessageBox.Show("Timer executed");
        //        checkExpiryDocuments();
        //        // Update the last execution time
        //        lastExecutionTime = currentTime;
        //    }
        //}
    }

}
