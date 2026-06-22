using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing.Imaging;

namespace Test
{
    public partial class Roster : Form
    {
        public Roster()
        {
            InitializeComponent();
        }

        Commoncls cls = new Commoncls();
        UtilityClass ex = new UtilityClass();
        private byte[] imageData = null;

        private void Roster_Load(object sender, EventArgs e)
        {
            loadDocData();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg, *.png, *.gif, *.jpeg)|*.jpg;*.png;*.gif, *.jpeg";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbFilePath.Text = openFileDialog1.FileName;
                btnUpload.Enabled = true;

                // Read the image file into a byte array

                string imagePath = openFileDialog1.FileName;
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, (int)fs.Length);
                }

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
                if (imageData == null || cmbMonth.SelectedIndex < 0 || string.IsNullOrWhiteSpace(tbYear.Text))
                {
                    MessageBox.Show("Please, fill in all the fields");
                }
                else
                {
                    saveToDatabase(imageData);
                    loadDocData();
                    MessageBox.Show("File Uploaded Successfull", "Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ex.ClearFormFields(this);
                    btnUpload.Enabled = false;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void loadDocData()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
                {
                    string query = "SELECT Id, _Month, _From, _To, Description FROM Roster";
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgvRoster.DataSource = dt;
                    }
                    sda.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void saveToDatabase(byte[] imageData)
        {
            string month = cmbMonth.SelectedItem.ToString() + "/" + tbYear.Text;
            string ext = new FileInfo(tbFilePath.Text).Extension;
            string query = "INSERT INTO Roster(_From, _To, Description, Data, _Month, Extension) values(@from, @to, @description, @data, @month, @ext)";
            using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
            {
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@from", DateTime.Parse(dtpFrom.Value.ToShortDateString()));
                cmd.Parameters.AddWithValue("@to", DateTime.Parse(dtpTo.Value.ToShortDateString()));
                cmd.Parameters.AddWithValue("@description", $"{ dtpFrom.Text} - {dtpTo.Text}");
                cmd.Parameters.AddWithValue("@data", imageData);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@ext", ext);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ex.ClearFormFields(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExpExcel_Click(object sender, EventArgs e)
        {
            ex.Export_to_Excel(dgvRoster);
        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void btnDelFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's choice
                if (result == DialogResult.Yes)
                {
                    if (dgvRoster.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dgvRoster.SelectedRows[0];
                        int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                        string description = selectedRow.Cells["Description"].Value.ToString();
                        string query = "DELETE FROM Roster WHERE Id='" + id + "'";

                        using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
                        {
                            SQLiteCommand cmd = new SQLiteCommand(query, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            loadDocData();
                        }
                        MessageBox.Show("Roaster: '" + description + "' Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void dgvRoster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                //btnDownloadPic.Visible = false;
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int recordID = Convert.ToInt32(dgvRoster.Rows[e.RowIndex].Cells["Id"].Value);

                    // Retrieve the PDF content from the database based on the ID

                    byte[] content = retrieveDocumentById(recordID);

                    if (content != null)
                    {
                        // Display image preview
                        using (MemoryStream ms = new MemoryStream(content))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                            pictureBox1.Visible = true;
                            //btnDownloadPic.Visible = true;
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
            string query = "SELECT Data FROM Roster WHERE Id='" + id + "'";

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

        private void tbFilterYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            string query = "SELECT Id, _Month, _From, _To, Description FROM Roster";
            SQLiteConnection con = new SQLiteConnection(cls.setConnectionString());
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (cmbFilterMonth.SelectedIndex >=0)
            {
                if (cmbFilterMonth.SelectedItem.ToString() == "All")
                {
                    tbFilterYear.Clear();
                    dgvRoster.DataSource = dt;
                }
                else if(!string.IsNullOrWhiteSpace(tbFilterYear.Text))
                {
                    string month = cmbFilterMonth.SelectedItem.ToString();
                    string year = tbFilterYear.Text.Trim();
                    string filter = month + "/" + year;

                    DataView filteredView = new DataView(dt);
                    filteredView.RowFilter = $"_Month = '{filter}'";
                    dgvRoster.DataSource = filteredView.ToTable();
                }
                else
                {
                    tbFilterYear.Clear();
                }

                con.Close();
                sda.Dispose();
            }
        }

        public void filter_DGV_By_Month_Year(string query)
        {
        }

        //private void btnDownloadPic_Click(object sender, EventArgs e)
        //{
        //    // Create a SaveFileDialog to allow the user to choose where to save the image.
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All Files|*.*"; // Specify the file filters for different image formats.
        //        saveFileDialog.Title = "Save Image"; // Dialog title.
        //        saveFileDialog.FileName = "image"; // Default file name.

        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            // Get the user-selected file name and format.
        //            string filePath = saveFileDialog.FileName;
        //            ImageFormat format = ImageFormat.Jpeg; // Default format (JPEG).

        //            // Determine the format based on the file extension.
        //            string fileExtension = Path.GetExtension(filePath);
        //            if (string.Equals(fileExtension, ".png", StringComparison.OrdinalIgnoreCase))
        //            {
        //                format = ImageFormat.Png;
        //            }

        //            // Save the image from the PictureBox to the chosen file path in the selected format.
        //            pictureBox1.Image.Save(filePath, format);

        //            MessageBox.Show("Image saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }

        //}
    }
}
