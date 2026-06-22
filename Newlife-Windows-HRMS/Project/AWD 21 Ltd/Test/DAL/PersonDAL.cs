using System;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SQLite;
using Test;
/// <summary>
/// Summary description for PersonDAL
/// </summary>
public class PersonDAL
{
    Commoncls cls = new Commoncls();
    
	public PersonDAL()
	{
	     //
		// TODO: Add constructor logic here
	   //
	}

    public int Insert(Person person)
    {
        int result = 0;
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(@"INSERT INTO Emp_Details VALUES(@Emp_Id,@Dep_Id,@NIC,@conf,@First_Name,@Last_Name,@Full_Name,
                                            @Sex,@msta,@Age,@DOB,@Address,@City,@Country,@Contact,@basic,@designation, @Visa_Type, @Visa_Exp,
                                            @NextOfKin, @Relation, @Allergies, @MedicalCondition, @RegularMedication, @GPContact, @GPAddress,
                                            @EmergencyContact, @PassportCountry, @PassportIssue, @PassportExpiry, @Image, @Visa_Issue)", connection);   
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@Emp_Id", person.EMPID);
            command.Parameters.AddWithValue("@Dep_Id",  person.DEPID);
            command.Parameters.AddWithValue("@NIC",  person.NIC);
            command.Parameters.AddWithValue("@conf", person.CONFIRM);
            command.Parameters.AddWithValue("@First_Name",person.FIRSTNAME);
            command.Parameters.AddWithValue("@Last_Name", person.LASTNAME);
            command.Parameters.AddWithValue("@Full_Name", person.FULLNAME);
            command.Parameters.AddWithValue("@Sex", person.SEX);
            command.Parameters.AddWithValue("@msta", person.MSTATUS);
            command.Parameters.AddWithValue("@Age", person.AGE);
            command.Parameters.AddWithValue("@DOB", person.DOB);
            command.Parameters.AddWithValue("@Address", person.ADDRESS);
            command.Parameters.AddWithValue("@City", person.CITY);
            command.Parameters.AddWithValue("@Country", person.COUNTRY);
            //command.Parameters.AddWithValue("@Bus_Number", person.BUSNUMBER);
            command.Parameters.AddWithValue("@Contact", person.HOMENUMBER);
            command.Parameters.AddWithValue("@basic", person.BASIC);
            command.Parameters.AddWithValue("@designation", person.DESIGNATION);
            command.Parameters.AddWithValue("@Visa_Type", person.VISATYPE);
            command.Parameters.AddWithValue("@Visa_Exp", person.VISAEXP);

            command.Parameters.AddWithValue("@NextOfKin", person.Nextkin);
            command.Parameters.AddWithValue("@Relation", person.Relation);
            command.Parameters.AddWithValue("@Allergies", person.Allergies);
            command.Parameters.AddWithValue("@MedicalCondition", person.Medicalcondition);
            command.Parameters.AddWithValue("@RegularMedication", person.Regularmedication);
            command.Parameters.AddWithValue("@GPContact", person.Gpcontact);
            command.Parameters.AddWithValue("@GPAddress", person.Gpaddress);
            command.Parameters.AddWithValue("@EmergencyContact", person.Emergencycontact);
            command.Parameters.AddWithValue("@PassportCountry", person.Passportcountry);
            command.Parameters.AddWithValue("@PassportIssue", person.Passportissue);
            command.Parameters.AddWithValue("@PassportExpiry", person.Passportexp);
            command.Parameters.AddWithValue("@Image", person.Picture);
            command.Parameters.AddWithValue("@Visa_Issue", person.VISAISSUE);

            result = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
        }
        finally
        {
            command.Dispose();
            connection.Close();
        }
        return result;
    }


    public int Update_Emp(Person pup)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        String selectStr = @"UPDATE Emp_Details SET Dep_Id = @dep_Id, NIC= @nic, Confirmation=@conf, First_Name=@fname, Last_Name=@lname,
                            Full_Name=@fullname, Sex=@sex, M_Sta=@msta, Age=@age, D_O_Birth=@dob, Address=@address, City=@city, Country=@country, 
                            Contact=@contact, Basic_sal=@basic,Designation=@designation, Visa_Type=@visa_type, Visa_Exp=@visa_exp, 
                            NextOfKin=@NextOfKin, Relation=@Relation, Allergies=@Allergies, MedicalCondition=@MedicalCondition, 
                            RegularMedication=@RegularMedication, GPContact=@GPContact, GPAddress=@GPAddress, EmergencyContact=@EmergencyContact, 
                            PassportCountry=@PassportCountry, PassportIssue=@PassportIssue, PassportExpiry=@PassportExpiry, Image=@Image, Visa_Issue = @Visa_Issue
                            WHERE (Emp_Id = @empid)";
        SQLiteCommand command = new SQLiteCommand(selectStr, connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@empid",pup.EMPID);
            command.Parameters.AddWithValue("@dep_Id", pup.DEPID);
            command.Parameters.AddWithValue("@nic", pup.NIC);
            command.Parameters.AddWithValue("@conf", pup.CONFIRM);
            command.Parameters.AddWithValue("@fname", pup.FIRSTNAME);
            command.Parameters.AddWithValue("@lname", pup.LASTNAME);
            command.Parameters.AddWithValue("@fullname", pup.FULLNAME);
            command.Parameters.AddWithValue("@sex", pup.SEX);
            command.Parameters.AddWithValue("@msta", pup.MSTATUS);
            command.Parameters.AddWithValue("@age", pup.AGE);
            command.Parameters.AddWithValue("@dob", pup.DOB);
            command.Parameters.AddWithValue("@address", pup.ADDRESS);
            command.Parameters.AddWithValue("@city", pup.CITY);
            command.Parameters.AddWithValue("@country", pup.COUNTRY);
            command.Parameters.AddWithValue("@contact", pup.HOMENUMBER);
            command.Parameters.AddWithValue("@basic", pup.BASIC);
            command.Parameters.AddWithValue("@designation", pup.DESIGNATION);
            command.Parameters.AddWithValue("@visa_type", pup.VISATYPE);
            command.Parameters.AddWithValue("@visa_exp", pup.VISAEXP);

            command.Parameters.AddWithValue("@NextOfKin", pup.Nextkin);
            command.Parameters.AddWithValue("@Relation", pup.Relation);
            command.Parameters.AddWithValue("@Allergies", pup.Allergies);
            command.Parameters.AddWithValue("@MedicalCondition", pup.Medicalcondition);
            command.Parameters.AddWithValue("@RegularMedication", pup.Regularmedication);
            command.Parameters.AddWithValue("@GPContact", pup.Gpcontact);
            command.Parameters.AddWithValue("@GPAddress", pup.Gpaddress);
            command.Parameters.AddWithValue("@EmergencyContact", pup.Emergencycontact);
            command.Parameters.AddWithValue("@PassportCountry", pup.Passportcountry);
            command.Parameters.AddWithValue("@PassportIssue", pup.Passportissue);
            command.Parameters.AddWithValue("@PassportExpiry", pup.Passportexp);
            command.Parameters.AddWithValue("@Image", pup.Picture);
            command.Parameters.AddWithValue("@Visa_Issue", pup.VISAISSUE);

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
    public DataSet Find_Emp(String arg)
    {
        DataSet ds = null;

        try
        {
            SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
            connection.Open();

            String selectStr = @"SELECT  Emp_Details.Emp_Id, Dep_Details.Dep_Name, Emp_Details.NIC, Emp_Details.First_Name, Emp_Details.Last_Name, 
            Emp_Details.Full_Name, Emp_Details.Sex,  Emp_Details.Age, Emp_Details.D_O_Birth, Emp_Details.Address, Emp_Details.City, 
            Emp_Details.Country, Emp_Details.Contact,Emp_Details.M_Sta,Emp_Details.Confirmation,Emp_Details.Basic_sal,Emp_Details.Designation, 
            Emp_Details.Visa_Type,Emp_Details.Visa_Issue, Emp_Details.Visa_Exp, Emp_Details.NextOfKin, Emp_Details.Relation, Emp_Details.Allergies, 
            Emp_Details.MedicalCondition, Emp_Details.RegularMedication, Emp_Details.GPContact, Emp_Details.GPAddress, Emp_Details.EmergencyContact, 
            Emp_Details.PassportCountry, Emp_Details.PassportIssue, Emp_Details.PassportExpiry, Emp_Details.Image
            FROM  Emp_Details 
            LEFT JOIN Dep_Details ON Emp_Details.Dep_Id = Dep_Details.Dep_Id
            WHERE Emp_Details.NIC = '" + arg + "'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(selectStr, connection);
            ds = new DataSet();
            da.Fill(ds, "Job_HSDetails");

            connection.Close();
            da.Dispose();
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

    public bool Find(Person p_id)
    {
        bool idExist = false;
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        SQLiteCommand command = new SQLiteCommand("SELECT * FROM Emp_Details WHERE Emp_Id=@pid", connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@pid", p_id.EMPID);
            SQLiteDataReader reader=command.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Employee ID already exists","Exists",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                idExist = true;
            }

            return idExist;
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

    public int Delete_Per(Person per)
    {
        SQLiteConnection connection = new SQLiteConnection(cls.setConnectionString());
        connection.Open();

        String selectStr = "DELETE FROM Emp_Details  WHERE (NIC = @nic)";
        SQLiteCommand command = new SQLiteCommand(selectStr, connection);
        command.CommandType = CommandType.Text;
        try
        {
            command.Parameters.AddWithValue("@nic", per.NIC);

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


    public  DataTable GetData()
    {
        string query = @"SELECT  Emp_Details.Emp_Id, Dep_Details.Dep_Name, Emp_Details.NIC, Emp_Details.First_Name, Emp_Details.Last_Name, 
        Emp_Details.Full_Name, Emp_Details.Sex,  Emp_Details.Age, Emp_Details.D_O_Birth, Emp_Details.Address, Emp_Details.City, 
        Emp_Details.Country, Emp_Details.Contact,Emp_Details.Basic_sal,Emp_Details.Designation, Emp_Details.Visa_Type, Emp_Details.Visa_Issue, Emp_Details.Visa_Exp,
        Emp_Details.NextOfKin, Emp_Details.Relation, Emp_Details.Allergies, Emp_Details.MedicalCondition, Emp_Details.RegularMedication,
        Emp_Details.GPContact, Emp_Details.GPAddress, Emp_Details.EmergencyContact, Emp_Details.PassportCountry, Emp_Details.PassportIssue,
        Emp_Details.PassportExpiry, Emp_Details.Image
        FROM  Emp_Details 
        LEFT JOIN Dep_Details ON Emp_Details.Dep_Id = Dep_Details.Dep_Id";
        //string query = "SELECT * FROM Emp_Details INNER JOIN Dep_Details ON Emp_Details.Dep_Id = Dep_Details.Dep_Id";
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

    public DataTable GetDataWith(Person p)
    {
        string query = @"SELECT  Emp_Details.Emp_Id, Dep_Details.Dep_Name, Emp_Details.NIC, Emp_Details.First_Name, Emp_Details.Last_Name, 
            Emp_Details.Full_Name, Emp_Details.Sex,  Emp_Details.Age, Emp_Details.D_O_Birth, Emp_Details.Address, Emp_Details.City, 
            Emp_Details.Country, Emp_Details.Contact,Emp_Details.Basic_sal,Emp_Details.Designation, Emp_Details.Visa_Type,Emp_Details.Visa_Issue, Emp_Details.Visa_Exp,
            Emp_Details.NextOfKin, Emp_Details.Relation, Emp_Details.Allergies, Emp_Details.MedicalCondition, Emp_Details.RegularMedication,
            Emp_Details.GPContact, Emp_Details.GPAddress, Emp_Details.EmergencyContact, Emp_Details.PassportCountry, Emp_Details.PassportIssue,
            Emp_Details.PassportExpiry, Emp_Details.Image
            FROM  Emp_Details
            LEFT JOIN Dep_Details ON Emp_Details.Dep_Id = Dep_Details.Dep_Id WHERE NIC LIKE '%" + p.NIC + "%'";
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
