using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    class UtilityClass
    {
        public UtilityClass()
        {

        }

        Commoncls cls = new Commoncls();

        //Function to export datagridview data to excel
        public void Export_to_Excel(DataGridView dgView)
        {
            if (dgView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel (.xlsx)|  *.xlsx";
                sfd.FileName = "Output.xlsx";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel._Workbook workbook = XcelApp.Workbooks.Add(Type.Missing);
                            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                            worksheet = workbook.Sheets["Sheet1"];
                            worksheet = workbook.ActiveSheet;
                            worksheet.Name = "Output";
                            worksheet.Application.ActiveWindow.SplitRow = 1;
                            worksheet.Application.ActiveWindow.FreezePanes = true;

                            for (int i = 1; i < dgView.Columns.Count + 1; i++)
                            {
                                if (dgView.Columns[i - 1].HeaderText.Trim() != "Image" || dgView.Columns[i - 1].HeaderText.Trim() != "image")
                                {
                                    worksheet.Cells[1, i] = dgView.Columns[i - 1].HeaderText;
                                    worksheet.Cells[1, i].Font.NAME = "Calibri";
                                    worksheet.Cells[1, i].Font.Bold = true;
                                    worksheet.Cells[1, i].Interior.Color = Color.Wheat;
                                    worksheet.Cells[1, i].Font.Size = 12;
                                }

                            }

                            for (int i = 0; i < dgView.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgView.Columns.Count; j++)
                                {
                                    if (dgView.Rows[i].Cells[j].Value.ToString() != "System.Byte[]")
                                    {
                                        worksheet.Cells[i + 2, j + 1] = dgView.Rows[i].Cells[j].Value.ToString();
                                    }
                                }
                            }

                            worksheet.Columns.AutoFit();
                            workbook.SaveAs(sfd.FileName);
                            XcelApp.Quit();

                            ReleaseObject(worksheet);
                            ReleaseObject(workbook);
                            ReleaseObject(XcelApp);

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.Message, "Error");
            }
            finally
            {
                GC.Collect();
            }
        }


        //Function to clear all form fields
        public void ClearFormFields(Control parentControl, bool dltReadOnly=true)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is TextBox)
                {
                    if (dltReadOnly)
                    {
                        control.Text = String.Empty; // Clear text in TextBox
                    }
                    else
                    {
                        TextBox tb = (TextBox)control;
                        if (!tb.ReadOnly)
                        {
                            control.Text = String.Empty; // Clear text in TextBox
                        }
                    }
                }
                else if (control is ComboBox)
                {
                    control.ResetText();
                }
                else if (control is DateTimePicker)
                {
                    control.ResetText();
                }
                else if(control is PictureBox)
                {
                    PictureBox img = (PictureBox)control;
                    img.Image = null;
                }
                else if (control.HasChildren)
                {
                    ClearFormFields(control, dltReadOnly); // Recursively clear child controls
                }
            }
        }


        //Filter datagridview data based on employee ID Combobox
        public void filter_DGV_By_Emp_ID(DataGridView dg, string query, ComboBox cb)
        {
            string emp_id = cb.SelectedValue.ToString();
            SQLiteConnection con = new SQLiteConnection(cls.setConnectionString());
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (emp_id == "-- Select --")
            {
                dg.DataSource = dt;
            }
            else if (string.IsNullOrEmpty(emp_id)) dg.DataSource = dt;
            else
            {
                DataView filteredView = new DataView(dt);
                filteredView.RowFilter = $"Emp_Id = '{emp_id}'";
                dg.DataSource = filteredView.ToTable();
            }

            con.Close();
            sda.Dispose();
        }
    }
}
