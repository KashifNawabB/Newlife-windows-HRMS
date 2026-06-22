using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using Test;

    class LeaveDAL
    {
        Commoncls cls = new Commoncls();
        Leave leaves = new Leave();

        public int Insert(Leave leave)
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            SQLiteCommand command = new SQLiteCommand("INSERT INTO Leave_Details VALUES('" + leave.LEAVEID + "','" + leave.EMPID + "','" + leave.APPDATE + "', '" + leave.RESDATE +"','" + leave.TYPE + "')", connection);
            command.CommandType = CommandType.Text;
            try
            {
                command.Parameters.AddWithValue("@attid", leave.LEAVEID);
                command.Parameters.AddWithValue("@Emp_Id", leave.EMPID);
                command.Parameters.AddWithValue("@DateTime", leave.APPDATE);
                command.Parameters.AddWithValue("@RsDateTime", leave.RESDATE);
                command.Parameters.AddWithValue("@Status", leave.TYPE);
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

        

        public DataSet Find_Leave(String arg)
        {
            DataSet ds = null;

            try
            {
                SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
                connection.Open();

                String selectStr = "SELECT Emp_Details.Emp_Id, Leave_Details.Leave_Id, Leave_Details.Emp_Id, CAST(Leave_Details.App_Date AS TEXT) as App_Date, CAST(Leave_Details.Res_Date AS TEXT) as Res_Date, Leave_Details.Type FROM  Leave_Details INNER JOIN  Emp_Details ON Leave_Details.Emp_Id = Emp_Details.Emp_Id  WHERE  Leave_Details.Leave_Id = '" + arg + "'";
                SQLiteDataAdapter da = new SQLiteDataAdapter(selectStr, connection);
                ds = new DataSet();
                da.Fill(ds, "Leave_Details");
                da.Dispose();
            }
            catch (Exception e)
            {
            System.Windows.Forms.MessageBox.Show(e.Message, "Error in Finding Leave");
        }

            return ds;
        }

        public int Update_Leave(Leave lev)
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = "UPDATE Leave_Details SET Emp_Id=@empid,App_Date=@appdate,Res_Date=@resdate,Type=@type WHERE (Leave_Id = @leave)";
            SQLiteCommand command = new SQLiteCommand(selectStr, connection);
            command.CommandType = CommandType.Text;
            try
            {
                command.Parameters.AddWithValue("@leave",lev.LEAVEID);
                command.Parameters.AddWithValue("@empid", lev.EMPID);
                command.Parameters.AddWithValue("@appdate", lev.APPDATE);
                command.Parameters.AddWithValue("@resdate", lev.RESDATE);
                command.Parameters.AddWithValue("@type", lev.TYPE);
               
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



        public int Delete_Leave(Leave le)
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = "DELETE FROM Leave_Details  WHERE (Leave_Id = '" + le.LEAVEID + "')";
            SQLiteCommand command = new SQLiteCommand(selectStr, connection);
            command.CommandType = CommandType.Text;
            try
            {
                command.Parameters.AddWithValue("@leave", le.LEAVEID);
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


        public DataTable GetData()
        {
            string query = "SELECT  Leave_Details.Leave_Id, Emp_Details.Full_Name, CAST(Leave_Details.App_Date AS TEXT) as App_Date, CAST(Leave_Details.Res_Date AS TEXT) as Res_Date, Leave_Details.Type FROM  Leave_Details INNER JOIN Emp_Details ON Leave_Details.Emp_Id = Emp_Details.Emp_Id";
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
                        return ds;
                    }
                }
            }
        }


        public DataTable GetData_DateRange(Leave l)
        {
            string query = "SELECT Leave_Details.Leave_Id, Emp_Details.Full_Name, CAST(Leave_Details.App_Date AS TEXT) as App_Date, CAST(Leave_Details.Res_Date AS TEXT) as Res_Date, Leave_Details.Type FROM   Leave_Details INNER JOIN Emp_Details ON Leave_Details.Emp_Id = Emp_Details.Emp_Id WHERE Leave_Id Like'%" + l.LEAVEID + "%' ";
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
                        return ds;
                    }
                }
            }
        }


    }

