using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Test
{
    public partial class Attendance_Details : Form
    {
        Commoncls cls = new Commoncls();
       
       
        Atten_Details att_det = new Atten_Details();
        AttenBAL abal = new AttenBAL();
        UtilityClass ex = new UtilityClass();

        public Attendance_Details()
        {
            InitializeComponent();
        }

        private void Attendance_Details_Load(object sender, EventArgs e)
        {
            Load_Combo(cmbemp);
            Load_Combo(cmbEmpFilter);
            GridBind();
            new_ID();
           
        }

        private void Load_Combo(ComboBox cb)
        {
            cls.setComboList(cb, "Select Emp_Id,Full_Name From Emp_Details Order By Emp_Id ASC", "Emp_Details", "Emp_Id", "Emp_Id");
        }

        private void GridBind()
        {
            dataGridView1.DataSource = abal.BindGrid();
        }


        private string GetNextValue(string s)
        {
            return String.Format("A{0:D5}", Convert.ToInt32(s.Substring(3)) + 1);
        }
        
        #region ID
        private void new_ID()
        {
            try
            {
                          
                SQLiteConnection con = new SQLiteConnection(cls.setConnectionString());
                con.Open();
                SQLiteCommand cmddr = new SQLiteCommand("select max(Att_Id) as ids from Att_Details",con );
                SQLiteDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {

                        
                        txtattid.Text = "A00001";
                    }
                    else
                    {
                        strid = txtattid.Text;

                        string current = dr["ids"].ToString();// txtattid.Text;
                        string next = GetNextValue(current);
                       
                        txtattid.Text = GetNextValue(current);
                        
                    }

                }
                dr.Close();
                con.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        #endregion

        private void btnadd_Click(object sender, EventArgs e)
        {
            new_ID();

            int insertrec = 0;
            try
            {

                att_det.ATTID = txtattid.Text;
                att_det.EMPID = cmbemp.SelectedValue.ToString();
                att_det.DATETIME = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
                att_det.STATUS = cmbsta.Text;
                att_det.TIME = dtpInOutTime.Text;


                insertrec = abal.Insert(att_det);
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
            catch (Exception ee)
            {

                MessageBox.Show(ee.ToString(), "Insert Error");
            }
            finally
            {

            }


        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ex.ClearFormFields(this, false);

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                att_det.ATTID = txtattid.Text;
                abal.Delete_leave(att_det);
                MessageBox.Show("Record Delete Successfull", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridBind();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(),"Delete Error");
            }
           
        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            ex.ClearFormFields(this, false);

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                att_det.ATTID = txtattid.Text.Trim();
                att_det.EMPID = cmbemp.SelectedValue.ToString();
                att_det.DATETIME = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());
                att_det.STATUS = cmbsta.Text.ToString();
                att_det.TIME = dtpInOutTime.Text;
                abal.Upate_Att(att_det);
                GridBind();
                MessageBox.Show("Record Update Successfull", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ex.ClearFormFields(this);
                new_ID();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Update Error");
            }
        }

        private void btnExpExc_Click(object sender, EventArgs e)
        {
            ex.Export_to_Excel(dataGridView1);
        }

        private void cmbEmpFilter_DropDownClosed(object sender, EventArgs e)
        {
            string query = "SELECT Emp_Details.Full_Name,Emp_Details.Emp_Id,Att_Details.Att_Id, Att_Details.Emp_Id,Att_Details.Date_Time,Att_Details.Status, Att_Details.Time  FROM  Att_Details INNER JOIN  Emp_Details ON Att_Details.Emp_Id = Emp_Details.Emp_Id";
            ex.filter_DGV_By_Emp_ID(dataGridView1, query, cmbEmpFilter);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string AtID = dataGridView1.Rows[e.RowIndex].Cells["Att_Id"].Value.ToString();
                    DataSet ds = abal.Find_Attdet(AtID);
                    DataRow row;
                    row = ds.Tables[0].Rows[0];
                    MessageBox.Show("Edit mode for: " + row["Full_Name"].ToString());
                    foreach (DataRow rows in ds.Tables[0].Rows)
                    {
                        txtattid.Text = rows["Att_Id"].ToString();
                        cmbemp.Text = rows["Emp_Id"].ToString();
                        dateTimePicker1.Text = rows["Date_Time"].ToString();
                        cmbsta.Text = rows["Status"].ToString();
                        dtpInOutTime.Text = rows["Time"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
