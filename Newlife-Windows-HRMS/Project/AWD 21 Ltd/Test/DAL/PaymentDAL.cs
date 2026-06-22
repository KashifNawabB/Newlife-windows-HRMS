using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using Test;



class PaymentDAL
{

    Commoncls cls = new Commoncls();
    Payment pd = new Payment();
    public int Insert(Payment pay_det)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        SQLiteCommand command = new SQLiteCommand(@"INSERT INTO Pay_Details(Emp_Id, Salary_Date, Hours_Worked, Total_Pay,
        Income_Tax, NITax, Deductions, Net_Pay, Payslip_Data) VALUES(@emp_id, @sal_date, @hw, @total_pay, 
        @income_tax, @ni_tax, @deductions, @net_pay, @data)", connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@emp_id", pay_det.EMP_ID);
            command.Parameters.AddWithValue("@sal_date", pay_det.SALARY_DATE);
            command.Parameters.AddWithValue("@hw", pay_det.HOURS_WORKED);
            command.Parameters.AddWithValue("@total_pay", pay_det.TOTAL_PAY);
            command.Parameters.AddWithValue("@income_tax", pay_det.INCOME_TAX);
            command.Parameters.AddWithValue("@ni_tax", pay_det.NI_TAX);
            command.Parameters.AddWithValue("@deductions", pay_det.DEDUCTIONS);
            command.Parameters.AddWithValue("@net_pay", pay_det.NET_PAY);
            command.Parameters.AddWithValue("@data", pay_det.PAYSLIP_DATA);


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


    public int Update_Pay(Payment pay)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        String selectStr = @"UPDATE Pay_Details SET Emp_Id = @emp_id,Salary_Date=@sal_date,Hours_Worked=@hw,Total_Pay=@total_pay,
        Income_Tax=@income_tax,NITax=@ni_tax, Deductions=@deductions, Net_Pay=@net_pay WHERE (Id = '" + pay.ID + "')";
        SQLiteCommand command = new SQLiteCommand(selectStr, connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@emp_id", pay.EMP_ID);
            command.Parameters.AddWithValue("@sal_date", pay.SALARY_DATE);
            command.Parameters.AddWithValue("@hw", pay.HOURS_WORKED);
            command.Parameters.AddWithValue("@total_pay", pay.TOTAL_PAY);
            command.Parameters.AddWithValue("@income_tax", pay.INCOME_TAX);
            command.Parameters.AddWithValue("@ni_tax", pay.NI_TAX);
            command.Parameters.AddWithValue("@deductions", pay.DEDUCTIONS);
            command.Parameters.AddWithValue("@net_pay", pay.NET_PAY);
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


    public DataSet Find_pay(int arg)
    {
        DataSet ds = null;

        try
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = "SELECT Pay_Details.Id, Emp_Details.Full_Name, Pay_Details.Emp_Id, Pay_Details.Salary_Date, Pay_Details.Hours_Worked, Pay_Details.Total_Pay,Pay_Details.Income_Tax, Pay_Details.NITax, Pay_Details.Deductions, Pay_Details.Net_Pay  FROM  Pay_Details INNER JOIN  Emp_Details ON Pay_Details.Emp_Id = Emp_Details.Emp_Id   WHERE Pay_Details.Id = '" + arg + "'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectStr, connection);
            ds = new DataSet();
            da.Fill(ds, "Pay_Details");

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


    public DataSet Find_Pay_First(String arg)
    {
        DataSet ds = null;

        try
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = "SELECT * FROM Emp_Details WHERE Emp_Id = '" + arg + "'";//"SELECT Pay_Details.Pay_Id, Emp_Details.Full_Name,Emp_Details.Emp_Id,Emp_Details.Designation,Emp_Details.Basic_Sal, Pay_Details.Emp_Id, Pay_Details.Sal_Date, Pay_Details.Basic_Sal, Pay_Details.Incentives,Pay_Details.Apprisal, Pay_Details.Tot_Sal FROM  Pay_Details INNER JOIN  Emp_Details ON Pay_Details.Emp_Id = Emp_Details.Emp_Id   WHERE Pay_Details.Pay_Id = '" + arg + "'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectStr, connection);
            ds = new DataSet();
            da.Fill(ds, "Emp_Details");

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


    public int Delete_Pay(Payment pay_det)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        SQLiteCommand command = new SQLiteCommand("DELETE FROM Pay_Details WHERE Id = '" + pay_det.ID + "'", connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@payid", pay_det.ID);

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
        string query = "SELECT Pay_Details.Id, Emp_Details.Full_Name, Pay_Details.Emp_Id, Pay_Details.Salary_Date, Pay_Details.Hours_Worked, Pay_Details.Total_Pay,Pay_Details.Income_Tax, Pay_Details.NITax, Pay_Details.Deductions, Pay_Details.Net_Pay FROM  Pay_Details INNER JOIN  Emp_Details ON Pay_Details.Emp_Id = Emp_Details.Emp_Id ";
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


    public DataTable GetData_with(Payment P)
    {
        string query = "SELECT Pay_Details.Id, Emp_Details.Full_Name, Pay_Details.Emp_Id, Pay_Details.Salary_Date, Pay_Details.Hours_Worked, Pay_Details.Total_Pay,Pay_Details.Income_Tax, Pay_Details.NITax, Pay_Details.Deductions, Pay_Details.Net_Pay FROM  Pay_Details INNER JOIN  Emp_Details ON Pay_Details.Emp_Id = Emp_Details.Emp_Id WHERE Pay_Details.Pay_Id='" + P.ID + "' ";
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

