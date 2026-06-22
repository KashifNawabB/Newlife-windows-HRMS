using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using Test;

class AttenDAL
{
    Commoncls cls = new Commoncls();

    public int Insert(Atten_Details att_det)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        SQLiteCommand command = new SQLiteCommand("INSERT INTO Att_Details VALUES(@attid,@Emp_Id,@DateTime,@Status, @Time)", connection);

        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@attid", att_det.ATTID);
            command.Parameters.AddWithValue("@Emp_Id", att_det.EMPID);
            command.Parameters.AddWithValue("@DateTime", att_det.DATETIME.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@Status", att_det.STATUS);
            
            DateTime parsedTime;
            if (DateTime.TryParse(att_det.TIME, out parsedTime))
            {
                command.Parameters.AddWithValue("@Time", parsedTime.ToString("HH:mm:ss"));
            }
            else
            {
                command.Parameters.AddWithValue("@Time", att_det.TIME);
            }
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

    public DataSet Find_att(String arg)
    {
        DataSet ds = null;

        try
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = "SELECT Emp_Details.Full_Name,Emp_Details.Emp_Id,Att_Details.Att_Id, Att_Details.Emp_Id,Att_Details.Date_Time,Att_Details.Status, Att_Details.Time  FROM  Att_Details INNER JOIN  Emp_Details ON Att_Details.Emp_Id = Emp_Details.Emp_Id  WHERE  Att_Details.Att_Id = '" + arg + "'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectStr, connection);
            ds = new DataSet();
            da.Fill(ds, "Att_Details");

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


    public void Update_Att(Atten_Details att)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        String selectStr = "UPDATE Att_Details SET Emp_Id = @emp_Id,Date_Time=@date,Status=@status, Time=@time  WHERE (Att_Id = '" + att.ATTID + "')";
        SQLiteCommand command = new SQLiteCommand(selectStr, connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@emp_Id", att.EMPID);
            command.Parameters.AddWithValue("@date", att.DATETIME.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@status", att.STATUS);
            
            DateTime parsedTimeUpdate;
            if (DateTime.TryParse(att.TIME, out parsedTimeUpdate))
            {
                command.Parameters.AddWithValue("@time", parsedTimeUpdate.ToString("HH:mm:ss"));
            }
            else
            {
                command.Parameters.AddWithValue("@time", att.TIME);
            }

            //return command.ExecuteNonQuery();
            command.ExecuteNonQuery();
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
        string query = "SELECT Att_Details.Att_Id,Emp_Details.Full_Name,Att_Details.Date_Time,Att_Details.Status, Att_Details.Time  FROM  Att_Details INNER JOIN  Emp_Details ON Att_Details.Emp_Id = Emp_Details.Emp_Id";
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

    public int Delete_Att(Atten_Details at)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        String selectStr = "DELETE FROM Att_Details  WHERE (Att_Id = @att)";
        SQLiteCommand command = new SQLiteCommand(selectStr, connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@att", at.ATTID);

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

    public void Find(Atten_Details a_id)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        SQLiteCommand command = new SQLiteCommand("SELECT max(Att_Id) FROM Att_Details", connection);
        command.CommandType = CommandType.Text;
        try
        {

            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                //MessageBox.Show("Employee ID already exists", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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



}

