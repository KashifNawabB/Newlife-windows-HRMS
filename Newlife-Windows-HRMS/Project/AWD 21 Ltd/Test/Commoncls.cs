using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace Test
{
    class Commoncls
    {
        public static SQLiteConnection sSQLConnection = new SQLiteConnection();
        public SQLiteDataAdapter SqliteDataAdapter = new SQLiteDataAdapter();
        public SQLiteCommand sSQLCommand = new SQLiteCommand();
        // public static SQLiteDataReader sSQLDataReader;

        public string setConnectionString()
        {
            // Update to use the newly created NewlifeDB.db in the database folder
            string Database = "NewlifeDB.db";
            string dbPath = Path.Combine(Application.StartupPath, $"database\\{Database}");
            
            string connectionString = $"Data Source={dbPath};";
            return connectionString;
        }

        public void setSQLiteConnectionState()//For sql Connection
        {
            if (sSQLConnection.State == ConnectionState.Open)
                sSQLConnection.Close();
            sSQLConnection.ConnectionString = setConnectionString();
        }

        public static void setListview(ListView sListView, String sCaption, Byte sIcon, ImageList sImageList)
        {
            sListView.Width = 250;
            sListView.LargeImageList = sImageList;
            sListView.SmallImageList = sImageList;
            sListView.Items.Add(new ListViewItem(sCaption, sIcon));
        }

        public static void setCreateDirectory(string sFolder, string sLocation)
        {
            try { if (Directory.Exists(sLocation + "\\" + sFolder) == false) { Directory.CreateDirectory(sLocation + "\\" + sFolder); } }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public void getSqlRecordCount(DataSet dsFill, string sSQL, string sTable)
        {
            setSQLiteConnectionState();
            SqliteDataAdapter.SelectCommand = new SQLiteCommand(sSQL, sSQLConnection);
            dsFill.Clear();
            SqliteDataAdapter.Fill(dsFill, sTable);
        }

        public void setWebInfo_Create()
        {
            try
            {
                //DATASET VARIABLES
                DataSet dsEmployees = new DataSet();
                DataSet dsEmpFemale = new DataSet();
                DataSet dsEmpMale = new DataSet();
                DataSet dsDepartment = new DataSet();
                DataSet dsEmpActive = new DataSet();
                DataSet dsLeave = new DataSet();
                
                getSqlRecordCount(dsDepartment, "SELECT Dep_Status AS Dep FROM  Dep_Details Where Dep_Status='A' ", "Dep_Details");
                getSqlRecordCount(dsEmployees, "SELECT Sex FROM Emp_Details Where Sex ='Male' OR Sex='Female'", "Emp_Details");
                getSqlRecordCount(dsEmpMale, "SELECT Sex FROM Emp_Details Where Sex ='Male' ", "Emp_Details");
                getSqlRecordCount(dsEmpFemale, "SELECT Sex FROM Emp_Details Where Sex ='Female' ", "Emp_Details");
                //getSqlRecordCount(dsEmpActive, "SELECT * FROM Att_Details WHERE Status = 'IN' AND  (Date_Time >= CONVERT(CHAR(8), CURRENT_DATE, 112))", "Att_Details");
                getSqlRecordCount(dsEmpActive, "SELECT * FROM Att_Details  WHERE Status = 'IN'  AND DATE(Date_Time) >= DATE('now'); ", "Att_Details");
                getSqlRecordCount(dsLeave, "SELECT * FROM Leave_Details WHERE DATE(App_Date) >= DATE('now'); ", "Leave_Details");

                FileStream sFileStream = new FileStream(Path.GetTempPath().ToString() + @"hrmsinfo.htm", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sStreamWriter = new StreamWriter(sFileStream);

                // Write to the file using StreamWriter class 
                sStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                sStreamWriter.WriteLine("<html>");
                sStreamWriter.WriteLine("<body bgcolor = '#111222' leftmargin='0' topmargin='10' text='#D4AF37'>");
                sStreamWriter.WriteLine("<marquee behavior='scrol' direction='left' style='font-family:Arial, Helvetica, sans-serif; font-size:11px; color:#D4AF37;' scrolldelay='200'>");
                sStreamWriter.WriteLine("<strong>Department : " + dsDepartment.Tables["Dep_Details"].Rows.Count + " <<>>  </strong> ");
                sStreamWriter.WriteLine("<strong>Total Employees : " + dsEmployees.Tables["Emp_Details"].Rows.Count + " <<>>  </strong>");
                sStreamWriter.WriteLine("<strong text='#00FF00'>Male Employees   : " + dsEmpMale.Tables["Emp_Details"].Rows.Count + " <<>>  </strong>");
                sStreamWriter.WriteLine("<strong text='#00FF00'>Female Employees : " + dsEmpFemale.Tables["Emp_Details"].Rows.Count + " <<>>  </strong>");
                sStreamWriter.WriteLine("<strong text='#00FF00'>Today Active Employees : " + dsEmpActive.Tables["Att_Details"].Rows.Count + " <<>>  </strong>");
                sStreamWriter.WriteLine("<strong style='color:#D4AF37'>Today Leave Employees : " + dsLeave.Tables["Leave_Details"].Rows.Count + " </strong>");

                sStreamWriter.WriteLine("</marquee>");
                sStreamWriter.WriteLine("</body>");
                sStreamWriter.WriteLine("</html>");
                sStreamWriter.Flush();
            }
            catch (System.IO.IOException exp)
            {

                exp.ToString();
            }
        }

        public void setWebInfo_Remove()
        {
            try
            {
                File.Delete(Path.GetTempPath().ToString() + @"hrmsinfo.htm");
            }
            catch (System.IO.IOException exp)
            {

                exp.ToString();
            }

        }

        public void setMDIChild(Form sMDIChild, Form sMDIParent)
        {
            sMDIChild.MdiParent = sMDIParent;
            sMDIChild.Show();
            sMDIChild.Activate();
        }
        public void setSqlcommand(DataSet dsFill, SQLiteDataAdapter daFill, string sSQL, string sTable)
        {
            setSQLiteConnectionState();
            daFill.SelectCommand = new SQLiteCommand(sSQL, sSQLConnection);
            dsFill.Clear();
            daFill.Fill(dsFill, sTable);
        }

        public void setComboList(ComboBox sComboBox, string sSQL, string sTable, string sFieldName, string sValue)
        {
            DataSet sDataSet = new DataSet();
            SQLiteDataAdapter sOleDbDataAdapter = new SQLiteDataAdapter();
            setSqlcommand(sDataSet, sOleDbDataAdapter, sSQL, sTable);

            DataRow row = sDataSet.Tables[0].NewRow();
            //row[0] = 0;
            row[0] = "-- Select --";
            sDataSet.Tables[0].Rows.InsertAt(row, 0);

            sComboBox.DataSource = sDataSet.Tables[0].DefaultView;
            sComboBox.DisplayMember = sFieldName;
            sComboBox.ValueMember = sValue;
        }
        public void Sqlback()
        {
            string BackUpDbName = "NewLifeWindowsUKLtd_Database_Backup";
            SQLiteConnection con = new SQLiteConnection();
            SQLiteCommand sqlcmd = new SQLiteCommand();
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            DataTable dt = new DataTable();

            con.ConnectionString = setConnectionString();

            string destdir = "C:\\New Life Windows UK Ltd Database Backups";


            if (!System.IO.Directory.Exists(destdir))
            {
                System.IO.Directory.CreateDirectory(destdir);
            }
            try
            {
                string backupDbPath = $"{ destdir }\\{ BackUpDbName}_{ DateTime.Now.ToString("ddMMyyyy_HHmmss")}.db";
                using (var source = new SQLiteConnection(setConnectionString()))
                using (var destination = new SQLiteConnection($"Data Source={backupDbPath}"))
                {
                    source.Open();
                    destination.Open();
                    source.BackupDatabase(destination, "main", "main", -1, null, 0);
                }

                MessageBox.Show($"Database backup created successfully at {destdir}", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                con.Close();
                sqlcmd.Dispose();
                MessageBox.Show(ex.ToString(), "Error During backup database. Please try again!");
            }
        }

        public void setCreateError(string sErrorMessage, string sLocation, string sFileName)
        {
            try
            {
                FileStream sFileStream = new FileStream(sLocation + sFileName + ".err", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sStreamWriter = new StreamWriter(sFileStream);
                sStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                sStreamWriter.WriteLine(sErrorMessage);
                sStreamWriter.Flush();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



    }
}
