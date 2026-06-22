using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Employee_Details : Form
    {
        public Employee_Details()
        {
            InitializeComponent();
        }
        int age;
        bool editMode = false;
        Commoncls cls = new Commoncls();
        Person persond = new Person();
      
        PersonBAL pbal = new PersonBAL();

        UtilityClass ex = new UtilityClass();

        private byte[] imgBytes = null;

        private void Employee_Details_Load(object sender, EventArgs e)
        {

            #region screen
            int x = Screen.GetWorkingArea(this).Width;//1024
            int y = Screen.GetWorkingArea(this).Height;//768
            this.Location = new Point(x - 100 - this.Size.Width, 150);
            #endregion
            Load_combo();
            GridView1.DataSource = pbal.Bind_Getdata();
            imgBytes = null;
        }

        private bool FinindID()
        {
            bool idExist = false;
            try
            {
               
                persond.EMPID = txtempid.Text;
              
               idExist = pbal.Find(persond);
                
            }
            catch (Exception)
            {
                
            }
            return idExist;
        }

        private void Load_combo()
        {
            cls.setComboList(cmb1, "Select Dep_Id,Dep_Name From Dep_Details Order By Dep_Id ASC", "Dep_Details", "Dep_Name", "Dep_Id");       
        }

        private void GridBind()
        {
            try
            {
                persond.NIC = txtfind.Text;
                GridView1.DataSource = pbal.Bind_Getdata_with(persond);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void age_find()
        {
            DateTime bday;
            bday = DateTime.Parse(dateTimePicker1.Text);
            DateTime now = DateTime.Today;
             age = now.Year - bday.Year;
            if (bday > now.AddYears(-age)) age--;
           
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            age_find();
            bool idExist = FinindID();

            if (!idExist)
            {


                Image image = pictureBox1.Image;
                byte[] imageBytes = null;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Change format as needed
                        image.Save(ms, image.RawFormat);
                        imageBytes = ms.ToArray();
                    }
                }
                int insertrec = 0;
                try
                {
                    if (txtempid.Text == "")
                    {
                        MessageBox.Show("Employee ID Cannot Be Blank", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        persond.EMPID = txtempid.Text;
                        persond.DEPID = cmb1.SelectedValue.ToString();
                        persond.FIRSTNAME = txtfname.Text;
                        persond.LASTNAME = txtlname.Text;
                        persond.FULLNAME = txtfullname.Text;
                        persond.SEX = cbgender.Text;
                        persond.CONFIRM = cmbconf.Text;
                        persond.AGE = int.Parse(age.ToString());
                        persond.DOB = DateTime.Parse(dateTimePicker1.Text);
                        persond.NIC = txtnic.Text;
                        persond.MSTATUS = cmbsta.Text;
                        persond.ADDRESS = txtaddress.Text;
                        persond.CITY = txtcity.Text;
                        persond.COUNTRY = txtcountry.Text;
                        persond.BUSNUMBER = txtvisatype.Text;
                        persond.HOMENUMBER = txtContact.Text;
                        persond.BASIC = txtnote.Text;
                        persond.DESIGNATION = txtdesig.Text;
                        persond.VISATYPE = txtvisatype.Text;

                        persond.VISAISSUE = DateTime.Parse(dtpVisaIssue.Text);
                        persond.VISAEXP = DateTime.Parse(dateTimePicker2.Text);

                        persond.Nextkin = tbNextKin.Text.Trim();
                        persond.Relation = tbRelation.Text.Trim();
                        persond.Allergies = tbAllergies.Text.Trim();
                        persond.Medicalcondition = tbMCondition.Text.Trim();
                        persond.Regularmedication = tbRegularMed.Text.Trim();
                        persond.Gpcontact = tbGPContact.Text.Trim();
                        persond.Gpaddress = tbGPAddress.Text.Trim();
                        persond.Emergencycontact = tbEmerContact.Text.Trim();
                        persond.Passportcountry = tbPassportCountry.Text.Trim();
                        persond.Passportissue = DateTime.Parse(dtpPassportIssue.Text.Trim());
                        persond.Passportexp = DateTime.Parse(dtpPassportExp.Text.Trim());
                        persond.Picture = imageBytes;


                        insertrec = pbal.Insert(persond);

                        GridView1.DataSource = pbal.Bind_Getdata();
                        if (insertrec > 0)
                        {
                            MessageBox.Show("Record Insert Successfull", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Record Already Inserted!!!");
                        }
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                finally
                {

                }
            }
        }
        
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btncloase_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ex.ClearFormFields(this);
        }

        
        

        private void txtfind_TextChanged(object sender, EventArgs e)
        {
            GridBind();

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                persond.NIC = txtfind.Text;
                pbal.Delete_Per(persond);
                MessageBox.Show("Record Delete Successfull", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridView1.DataSource = pbal.Bind_Getdata();
                ex.ClearFormFields(this, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Delete Error");
            }
            
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            try
            {
                String nic = txtfind.Text;

                DataSet ds = pbal.Find_Emp(nic);
                DataRow row;
                row = ds.Tables[0].Rows[0];

                MessageBox.Show(row["NIC"].ToString());

              //  GridBind();

                foreach (DataRow rows in ds.Tables[0].Rows)
                {
                    editMode = true;

                     txtempid.Text=rows["Emp_Id"].ToString();
                     cmb1.Text = rows["Dep_Name"].ToString();
                     txtfname.Text = rows["First_Name"].ToString();
                     txtlname.Text = rows["Last_Name"].ToString();
                     txtfullname.Text = rows["Full_Name"].ToString();
                     cbgender.Text = rows["Sex"].ToString();
                     cmbsta.Text = rows["M_Sta"].ToString();//
                     dateTimePicker1.Text = rows["D_O_Birth"].ToString();
                     txtnic.Text = rows["NIC"].ToString();
                     cmbconf.Text = rows["Confirmation"].ToString();//
                     txtaddress.Text = rows["Address"].ToString();
                     txtcity.Text = rows["City"].ToString();
                     txtcountry.Text = rows["Country"].ToString();
                     //txtvisatype.Text = rows["Business_Number"].ToString();
                     txtContact.Text = rows["Contact"].ToString();

                     txtnote.Text = rows["Basic_sal"].ToString();//
                     txtdesig.Text = rows["Designation"].ToString();

                    txtvisatype.Text = rows["Visa_Type"].ToString();
                    dateTimePicker2.Text = rows["Visa_Exp"].ToString();

                    tbNextKin.Text = rows["NextOfKin"].ToString();
                    tbRelation.Text = rows["Relation"].ToString();
                    tbAllergies.Text = rows["Allergies"].ToString();
                    tbMCondition.Text = rows["MedicalCondition"].ToString();
                    tbRegularMed.Text = rows["RegularMedication"].ToString();
                    tbGPContact.Text = rows["GPContact"].ToString();
                    tbGPAddress.Text = rows["GPAddress"].ToString();
                    tbEmerContact.Text = rows["EmergencyContact"].ToString();
                    tbPassportCountry.Text = rows["PassportCountry"].ToString();
                    dtpPassportIssue.Text = rows["PassportIssue"].ToString();
                    dtpPassportExp.Text = rows["PassportExpiry"].ToString();
                    var imageBytes = (byte[])rows["Image"];
                    dtpVisaIssue.Text = rows["Visa_Issue"].ToString();
                    if(imageBytes != null)
                    {
                        using(MemoryStream ms= new MemoryStream(imageBytes))
                        {
                            Image img = Image.FromStream(ms);
                            pictureBox1.Image = img;
                        }
                    }
                    imgBytes = imageBytes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editMode)
            {


                age_find();

                try
                {
                    persond.EMPID = txtempid.Text.Trim();
                    persond.NIC = txtfind.Text.Trim();
                   persond.DEPID = cmb1.SelectedValue.ToString().Trim();
                    persond.FIRSTNAME = txtfname.Text.Trim();
                    persond.LASTNAME = txtlname.Text.Trim();
                    persond.FULLNAME = txtfullname.Text.Trim();
                    persond.SEX = cbgender.Text.Trim();
                    persond.AGE = int.Parse(age.ToString().Trim());
                    persond.DOB = DateTime.Parse(dateTimePicker1.Text);
                    persond.ADDRESS = txtaddress.Text.Trim();
                    persond.CITY = txtcity.Text.Trim();
                    persond.COUNTRY = txtcountry.Text.Trim();
                    persond.HOMENUMBER = txtContact.Text.Trim();
                    //persond.VISATYPE = txtvisatype.Text;
                    persond.NIC = txtnic.Text.Trim();

                    persond.CONFIRM = cmbconf.Text.Trim();
                    persond.MSTATUS = cmbsta.Text.Trim();
                    persond.BASIC = txtnote.Text.Trim();
                    persond.DESIGNATION = txtdesig.Text.Trim();
                    persond.VISATYPE = txtvisatype.Text.Trim();
                    persond.VISAEXP = DateTime.Parse(dateTimePicker2.Text);
                    persond.VISAISSUE = DateTime.Parse(dtpVisaIssue.Text);

                    persond.Nextkin = tbNextKin.Text.Trim();
                    persond.Relation = tbRelation.Text.Trim();
                    persond.Allergies = tbAllergies.Text.Trim();
                    persond.Medicalcondition = tbMCondition.Text.Trim();
                    persond.Regularmedication = tbRegularMed.Text.Trim();
                    persond.Gpcontact = tbGPContact.Text.Trim();
                    persond.Gpaddress = tbGPAddress.Text.Trim();
                    persond.Emergencycontact = tbEmerContact.Text.Trim();
                    persond.Passportcountry = tbPassportCountry.Text.Trim();
                    persond.Passportissue = DateTime.Parse(dtpPassportIssue.Text);
                    persond.Passportexp = DateTime.Parse(dtpPassportExp.Text);
                    persond.Picture = imgBytes;

                    pbal.Update_P(persond);
                    MessageBox.Show("Record Updated Successfull", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridView1.DataSource = pbal.Bind_Getdata();
                    imgBytes = null;
                    editMode = false;
                    ex.ClearFormFields(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
        

        private void btnExpExc_Click(object sender, EventArgs e)
        {
            ex.Export_to_Excel(GridView1);
        }

        private void tbGPContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txtnote_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9) and decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Suppress the key press
            }

            // Ensure that the decimal point occur only once
            if ((e.KeyChar == '.') && (txtnote.Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Suppress the key press
            }

        }

        private void txtlname_Leave(object sender, EventArgs e)
        {
            txtfullname.Clear();
            txtfullname.Text += txtfname.Text + " " + txtlname.Text;
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg, *.png, *.gif, *.jpeg)|*.jpg;*.png;*.gif, *.jpeg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into the PictureBox
                pictureBox1.Image = Image.FromFile(dialog.FileName);

                //Load Image into global variable imgBytes for updating
                Image image = pictureBox1.Image;
                byte[] imageBytes = null;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Change format as needed
                        image.Save(ms, image.RawFormat);
                        imgBytes = ms.ToArray();
                    }
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void txtempid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }
    }
}
