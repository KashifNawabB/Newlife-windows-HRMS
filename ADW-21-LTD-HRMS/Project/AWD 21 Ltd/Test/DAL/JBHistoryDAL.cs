using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using Test;


class JBHistoryDAL
{
    Commoncls cls = new Commoncls();


    public int InsertJBH(JBHistory JBH)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        //SQLiteCommand command = new SQLiteCommand("InsertData",connection);
        //command.CommandType = CommandType.StoredProcedure;
        SQLiteCommand command = new SQLiteCommand("INSERT INTO Job_HSDetails VALUES('" + JBH.JBHID + "','" + JBH.JBEMPID + "','" + JBH.JBJOINGDATE + "','" + JBH.JBRSGDATE + "','" + JBH.JBTITLE + "','" + JBH.COMMENT + "')", connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@jbhid", JBH.JBHID);
            command.Parameters.AddWithValue("@jbempid", JBH.JBEMPID);
            command.Parameters.AddWithValue("@jbjoingdate", JBH.JBJOINGDATE);
            command.Parameters.AddWithValue("@jbrsgdate", JBH.JBRSGDATE);
            command.Parameters.AddWithValue("@jbtitle", JBH.JBTITLE);
            command.Parameters.AddWithValue("@jbcomment", JBH.COMMENT);

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


    public int Update(JBHistory JBH)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        String selectStr = "UPDATE Job_HSDetails SET Jh_Joingdate='" + JBH.JBJOINGDATE + "',jh_Resigndate='" + JBH.JBRSGDATE + "',jh_Jobtitle='" + JBH.JBTITLE + "',jh_comment= '" + JBH.COMMENT + "' WHERE (Jh_ID = '" + JBH.JBHID + "')";
        SQLiteCommand command = new SQLiteCommand(selectStr, connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@jbhid", JBH.JBHID);
            command.Parameters.AddWithValue("@jbempid", JBH.JBEMPID);
            command.Parameters.AddWithValue("@jbjoingdate", JBH.JBJOINGDATE);
            command.Parameters.AddWithValue("@jbrsgdate", JBH.JBRSGDATE);
            command.Parameters.AddWithValue("@jbtitle", JBH.JBTITLE);
            command.Parameters.AddWithValue("@comment", JBH.COMMENT);

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


    public int Delete(JBHistory JBH)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        String selectStr = "DELETE FROM Job_HSDetails  WHERE (Jh_ID = '" + JBH.JBHID + "')";
        SQLiteCommand command = new SQLiteCommand(selectStr, connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@jbheid", JBH.JBEMPID);

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


    public DataSet Find_Jobh(String arg)
    {
        DataSet ds = null;
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        String selectStr = @"SELECT e.Full_Name, e.Emp_Id, jh.Jh_ID, jh.Jh_EmpID, 
                            CAST(jh.Jh_Joingdate AS TEXT) AS Jh_Joingdate,
                            CAST(jh.jh_Resigndate AS TEXT) AS jh_Resigndate,
                            jh.jh_Jobtitle, jh.jh_comment
                            FROM Job_HSDetails jh 
                            INNER JOIN Emp_Details e ON e.Emp_Id = jh.Jh_EmpID
                            WHERE jh.Jh_EmpID = '" + arg + "'";
        connection.Open();
        SQLiteDataAdapter da = new SQLiteDataAdapter(selectStr, connection);
        ds = new DataSet();
        try
        {
            da.Fill(ds, "Job_HSDetails");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error");
        }
        finally
        {
            connection.Close();
            da.Dispose();
        }
        return ds;
    }

    public DataTable GetData()
    {
        string query = @"SELECT e.Full_Name, j.Jh_ID, j.Jh_EmpID,
                        CAST(j.Jh_Joingdate AS TEXT) AS Jh_Joingdate,
                        CAST(j.jh_Resigndate AS TEXT) AS jh_Resigndate,
                        j.jh_Jobtitle,
                        j.jh_comment
                        FROM Job_HSDetails j
                        INNER JOIN Emp_Details e ON j.Jh_EmpID = e.Emp_Id";

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

