using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using Test;

    class DepartmentDAL
    {
        Commoncls cls = new Commoncls();
      

        public int Insert(Department_Details Dpm)
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO Dep_Details VALUES(@Dep_Id,@Dep_Name,@Dep_Head,@Dep_Description,'A')", connection);
            command.CommandType = CommandType.Text;
            try
            {
                command.Parameters.AddWithValue("@Dep_Id", Dpm.DEPID);
                command.Parameters.AddWithValue("@Dep_Name", Dpm.DepName);
                command.Parameters.AddWithValue("@Dep_Head", Dpm.DepHead);
                command.Parameters.AddWithValue("@Dep_Description", Dpm.DSC);
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }

        public int Update(Department_Details Dpm)
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = "UPDATE Dep_Details SET Dep_Name = @Dep_Name,Dep_Head=@Dep_Head,Dep_Description=@Dep_Description WHERE (Dep_Id = @Dep_Id)";
            SQLiteCommand command = new SQLiteCommand(selectStr, connection);
            command.CommandType = CommandType.Text;
            try
            {
                command.Parameters.AddWithValue("@Dep_Id", Dpm.DEPID);
                command.Parameters.AddWithValue("@Dep_Name", Dpm.DepName);
                command.Parameters.AddWithValue("@Dep_Head", Dpm.DepHead);
                command.Parameters.AddWithValue("@Dep_Description", Dpm.DSC);
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }


        public int Delete_Dep(Department_Details Dpm)
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = "DELETE FROM Dep_Details  WHERE (Dep_Id = @Dep_Id)";
            SQLiteCommand command = new SQLiteCommand(selectStr, connection);
            command.CommandType = CommandType.Text;
            try
            {
                command.Parameters.AddWithValue("@Dep_Id", Dpm.DEPID);
                
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }

        public void Find_DID(Department_Details d_id)
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT Dep_Id FROM Dep_Details WHERE Dep_Id=@did", connection);
            command.CommandType = CommandType.Text;
            try
            {
                command.Parameters.AddWithValue("@did", d_id.DEPID);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Department ID already exists", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // return 
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }

        public DataSet Find_dep(String arg)
        {
            DataSet ds = null;

            try
            {
                SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
                connection.Open();

                String selectStr = "select * from Dep_Details where Dep_Name = '" + arg + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(selectStr, connection);
                ds = new DataSet();
                da.Fill(ds, "Dep_Details");

            }
            catch (Exception e)
            {
                String Str = e.Message;
            }
            finally
            {

            }

            return ds;
        }

        public DataTable GetData()
        {
            string query = "SELECT * FROM Dep_Details";
            SQLiteCommand cmd = new SQLiteCommand(query);
            using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
            {
                using (SQLiteDataAdapter sda = new SQLiteDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable ds = new DataTable())
                    {
                        sda.Fill(ds);
                        cmd.Dispose();
                        return ds;
                    }
                }
            }
        }

        public DataTable GetDataWith(Department_Details dep)
        {
            string query = "SELECT * FROM Dep_Details WHERE Dep_Name LIKE '%" + dep.DepName + "%'";
            SQLiteCommand cmd = new SQLiteCommand(query);
            using (SQLiteConnection con = new SQLiteConnection(cls.setConnectionString()))
            {
                using (SQLiteDataAdapter sda = new SQLiteDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable ds = new DataTable())
                    {
                        sda.Fill(ds);
                        sda.Dispose();
                        return ds;
                    }
                }
            }
        }



    }

