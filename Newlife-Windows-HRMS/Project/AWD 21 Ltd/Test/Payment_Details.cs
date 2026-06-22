using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Payment_Details : Form
    {
        public Payment_Details()
        {
            InitializeComponent();
        }
        Commoncls cls = new Commoncls();
        Payment pay = new Payment();
        PaymentBAL pbal = new PaymentBAL();
        UtilityClass ex = new UtilityClass();
        bool isFinal = false;

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (isFinal)
            {
                int insertrec = 0;
                //try
                //{
                if (tbBasic.Text == "" || tbNiTax.Text == "" || tbIncomeTax.Text == "" || tbFilePath.Text.Trim() == "")
                {
                    MessageBox.Show("Please Fill All field Correctly", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    pay.EMP_ID = cmemp.SelectedValue.ToString();
                    pay.SALARY_DATE = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
                    pay.HOURS_WORKED = float.Parse(tbHoursWorked.Text);
                    pay.TOTAL_PAY = float.Parse(tbBasic.Text);
                    pay.INCOME_TAX = float.Parse(tbIncomeTax.Text);
                    pay.NI_TAX = float.Parse(tbNiTax.Text);
                    pay.DEDUCTIONS = float.Parse(tbDeduction.Text);
                    pay.NET_PAY = float.Parse(tbNetPay.Text);
                    using (Stream stream = File.OpenRead(tbFilePath.Text))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        pay.PAYSLIP_DATA = buffer;
                    }

                    insertrec = pbal.Insert(pay);
                    GridBind();
                    if (insertrec > 0)
                    {
                        MessageBox.Show("Record Insert Successfull", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record Already Insert!!!");
                    }
                }
                //}
                //catch (Exception ee)
                //{
                //    MessageBox.Show(ee.ToString(), "Insert Error");
                //}
                //finally
                //{

                //}
            }
            else
            {
                MessageBox.Show("Please Finalize Editing First");
            }
        }

        private void Payment_Details_Load(object sender, EventArgs e)
        {
            Load_Combo(cmemp);
            Load_Combo(cmbEmpFilter);
            GridBind();
        }

        private void Load_Combo(ComboBox cb)
        {
            cls.setComboList(cb, "Select Emp_Id,Full_Name From Emp_Details Order By Emp_Id ASC", "Emp_Details", "Emp_Id", "Emp_Id");
        }

        private void GridBind()
        {
            dataGridView1.DataSource = pbal.BindGrid();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (isFinal)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    pay.ID = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    pay.EMP_ID = cmemp.SelectedValue.ToString();
                    pay.SALARY_DATE = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
                    pay.HOURS_WORKED = float.Parse(tbHoursWorked.Text);
                    pay.TOTAL_PAY = float.Parse(tbBasic.Text);
                    pay.INCOME_TAX = float.Parse(tbIncomeTax.Text);
                    pay.NI_TAX = float.Parse(tbNiTax.Text);
                    pay.DEDUCTIONS = float.Parse(tbDeduction.Text);
                    pay.NET_PAY = float.Parse(tbNetPay.Text);
                    pbal.Update_Pay(pay);

                    GridBind();
                    MessageBox.Show("Record Update Successfull", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ex.ClearFormFields(this);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Please Finalize Editing First");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Check the user's choice
                if (result == DialogResult.Yes)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        pay.ID = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                        pbal.Delete_Pay(pay);
                        string msg = "Record: " + selectedRow.Cells["Full_Name"].Value.ToString() + "\nSalary Date:" + selectedRow.Cells["Salary_Date"].Value.ToString() + "\n";
                        GridBind();

                        MessageBox.Show(msg+ "Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Delete Error");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ex.ClearFormFields(this);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btncheck_Click(object sender, EventArgs e)
        {
            try
           {
                String EmpID = cmemp.SelectedValue.ToString();

                DataSet ds = pbal.Find_Pay_Firstly(EmpID);
                DataRow row;
                row = ds.Tables[0].Rows[0];

                // MessageBox.Show(row["Full_Name"].ToString());

                // GridBind();

                foreach (DataRow rows in ds.Tables[0].Rows)
                {
                    txtempname.Text = rows["Full_Name"].ToString();
                    //tbPayRate.Text = rows["Basic_Sal"].ToString();
                    txtdesig.Text = rows["Designation"].ToString();
                    tbNINum.Text = row["NIC"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnExpExc_Click(object sender, EventArgs e)
        {
            ex.Export_to_Excel(dataGridView1);
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            double pension = tbPension.Text.Trim() == string.Empty ? 0 : double.Parse(tbPension.Text.Trim());
            double deduction = double.Parse(tbIncomeTax.Text.Trim()) + double.Parse(tbNiTax.Text.Trim()) + pension;
            tbDeduction.Text = deduction.ToString();

            tbNetPay.Text = Convert.ToString(double.Parse(tbBasic.Text.Trim()) - deduction);
            isFinal = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF Files|*.pdf"; // Only allow PDF files
            openFileDialog1.Title = "Select a PDF File";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                tbFilePath.Text = openFileDialog1.FileName;
                btnFinalize.Enabled = true;
            }
            else if (result == DialogResult.Cancel)
            {
                tbFilePath.Clear();
                btnFinalize.Enabled = false;
            }
        }

        private void cmbEmpFilter_DropDownClosed(object sender, EventArgs e)
        {
            String query = "SELECT Pay_Details.Id, Emp_Details.Full_Name, Pay_Details.Emp_Id, Pay_Details.Salary_Date, Pay_Details.Hours_Worked, Pay_Details.Total_Pay,Pay_Details.Income_Tax, Pay_Details.NITax, Pay_Details.Deductions, Pay_Details.Net_Pay  FROM  Pay_Details INNER JOIN  Emp_Details ON Pay_Details.Emp_Id = Emp_Details.Emp_Id";
            ex.filter_DGV_By_Emp_ID(dataGridView1, query, cmbEmpFilter);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pdfViewer1.CloseDocument();
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int pay_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                    // Retrieve the PDF content from the database based on the ID
                    byte[] content = retrievePaySlipById(pay_id);

                    if (content != null)
                    {
                        using (MemoryStream ms = new MemoryStream(content))
                        {
                            pdfViewer1.LoadFromStream(ms);
                            pdfViewer1.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] retrievePaySlipById(int id)
        {
            byte[] binaryData = null;
            string query = "SELECT Payslip_Data FROM Pay_Details WHERE Id='" + id + "'";

            using (SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString()))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        binaryData = (byte[])reader["Payslip_Data"];
                    }
                }
            }
            return binaryData;
        }

        private void send_data_for_editing()
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int PayID = int.Parse(selectedRow.Cells["Id"].Value.ToString());

                DataSet ds = pbal.Find_Pay(PayID);
                string msg = "Edit mode for: " + selectedRow.Cells["Full_Name"].Value.ToString() + "\nSalary Date:" + selectedRow.Cells["Salary_Date"].Value.ToString();
                MessageBox.Show(msg);

                // GridBind();

                foreach (DataRow rows in ds.Tables[0].Rows)
                {
                    cmemp.Text = rows["Emp_Id"].ToString();
                    dateTimePicker1.Text = rows["Salary_Date"].ToString();
                    tbHoursWorked.Text = rows["Hours_Worked"].ToString();
                    tbBasic.Text = rows["Total_Pay"].ToString();
                    tbIncomeTax.Text = rows["Income_Tax"].ToString();
                    tbNiTax.Text = rows["NITax"].ToString();
                    tbDeduction.Text = rows["Deductions"].ToString();
                    tbNetPay.Text = rows["Net_Pay"].ToString();
                }
                btncheck.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            send_data_for_editing();
        }
    }
}

