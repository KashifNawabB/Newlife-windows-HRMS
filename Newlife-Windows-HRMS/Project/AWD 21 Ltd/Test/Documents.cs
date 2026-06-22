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
    public partial class Documents : Form
    {
        public Documents()
        {
            InitializeComponent();
        }

        Commoncls cls = new Commoncls();
        UtilityClass ex = new UtilityClass();


        private void Documents_Load(object sender, EventArgs e)
        {
            loadDocData();
            Load_Combo(this.cmbemp);
            Load_Combo(this.cmbEmpFilter);
        }

        private void Load_Combo(ComboBox cb)
        {
            cls.setComboList(cb, "Select Emp_Id,Full_Name From Emp_Details Order By Emp_Id ASC", "Emp_Details", "Emp_Id", "Emp_Id");

        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image/DPF Files (*.jpg, *.png, *.gif, *.jpeg, *.pdf)|*.jpg;*.png;*.gif; *.jpeg; *.pdf;";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                tbFilePath.Text = openFileDialog1.FileName;
                btnUpload.Enabled = true;
            }
            else if (result == DialogResult.Cancel)
            {
                tbFilePath.Clear();
                btnUpload.Enabled = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbemp.SelectedValue.ToString().Trim() != "-- Select --" || tbFilePath.Text.Trim() == "")
                {
                    saveFile(tbFilePath.Text);
                    loadDocData();
                    MessageBox.Show("File Upload Successfull", "Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbFilePath.Clear();
                    tbDescription.Clear();
                    btnUpload.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please select an Employee ID", "Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        private void saveFile(string filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                string extn = new FileInfo(filePath).Extension;
                string name = new FileInfo(filePath).Name;

                string query = "insert into documents(Title, Description, Data, emp_id, Exp_Date) values(@title, @desc, @data, @emp_id, @exp_date)";
                using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
                {
                    SQLiteCommand cmd = new SQLiteCommand(query, con);
                    cmd.Parameters.AddWithValue("@title", name);
                    cmd.Parameters.AddWithValue("@desc", tbDescription.Text.ToString());
                    cmd.Parameters.AddWithValue("@data", buffer);
                    cmd.Parameters.AddWithValue("@emp_id", cmbemp.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@exp_date", DateTime.Parse(dateTimePicker2.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
        }


        private void loadDocData()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
                {
                    string query = "SELECT id, Title, Description, Emp_Id, Exp_Date FROM Documents";
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgvDoc.DataSource = dt;
                    }
                    sda.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                int? id = Convert.ToInt32(row.Cells[0].Value);
                if(id != null) openFile(id.Value);
                else MessageBox.Show("No file selected", "File not selected");
            }
        }

        private void openFile(int id)
        {
            using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
            {
                string query = "SELECT Title, Data FROM Documents WHERE id='" + id + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["Title"].ToString();
                    var data = (byte[])reader["Data"];
                    string extn = name.Split('.')[1];
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFileName, data);
                    System.Diagnostics.Process.Start(newFileName);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            ex.Export_to_Excel(dgvDoc);
        }

        private void btnDelFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's choice
                if (result == DialogResult.Yes)
                {
                    if (dgvDoc.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dgvDoc.SelectedRows[0];
                        int id = int.Parse(selectedRow.Cells["id"].Value.ToString());
                        string fileName = selectedRow.Cells["Title"].Value.ToString();
                        string query = "DELETE FROM Documents WHERE id='" + id + "'";

                        using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
                        {
                            SQLiteCommand cmd = new SQLiteCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            loadDocData();
                        }
                        MessageBox.Show("'" + fileName + "' Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void cmbEmpFilter_DropDownClosed(object sender, EventArgs e)
        {
            string query = "SELECT id, Title, Description, Emp_Id, Exp_Date FROM Documents";
            ex.filter_DGV_By_Emp_ID(dgvDoc, query, cmbEmpFilter);
        }

        private void dgvDoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) // Ensure it's not a header cell
            {
                var exp_date = Convert.ToDateTime(e.Value); // Get the value of the cell
                if (exp_date <= DateTime.Now.AddMonths(1))
                {
                    // Set the cell's text color to red
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    // Set the cell's text color to default
                    e.CellStyle.ForeColor = dgvDoc.DefaultCellStyle.ForeColor;
                }
            }
        }

        private void dgvDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                pdfViewer1.CloseDocument();
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    int recordID = Convert.ToInt32(dgvDoc.Rows[e.RowIndex].Cells["id"].Value);

                    // Retrieve the PDF content from the database based on the ID

                    byte[] content = retrieveDocumentById(recordID);
                    string extn = dgvDoc.Rows[e.RowIndex].Cells["Title"].Value.ToString().Split('.')[1].Trim();

                    if (content != null)
                    {
                        if (extn == "pdf")
                        {
                            // Display PDF preview
                            using (MemoryStream ms = new MemoryStream(content))
                            {
                                //webBrowser1.DocumentStream = ms;
                                pdfViewer1.LoadFromStream(ms);
                                pictureBox1.Visible = false;
                                pdfViewer1.Visible = true;
                            }
                        }
                        else
                        {
                            // Display image preview
                            using (MemoryStream ms = new MemoryStream(content))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                                pictureBox1.Visible = true;
                                pdfViewer1.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        

        private byte[] retrieveDocumentById(int id)
        {
            byte[] binaryData = null;
            string query = "SELECT Data FROM Documents WHERE id='" + id + "'";

            using (SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString()))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        binaryData = (byte[])reader["Data"];
                    }
                }
            }
            return binaryData;
        }
    }
}
