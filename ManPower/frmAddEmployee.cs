using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManPowerModel;
using ManPowerBLL;
using System.IO;



namespace ManPower
{
    public partial class frmAddEmployee : Form
    {
        Employee emp = new Employee();
        BLemployee blObjct = new BLemployee();
        OpenFileDialog fd1 = new OpenFileDialog();
        public int EmpId { get; set; }
        public frmAddEmployee()
        {
            InitializeComponent();
            EmpId = 0;
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (EmpId != 0)
            {
                ShowData();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txt_VisaExpiryDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddEmployee add1 = new frmAddEmployee();
            add1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BLemployee blObjct = new BLemployee();
            if (txt_code.Text != "" && txt_Name.Text != "" && txt_fatherName.Text != "" && txt_address.Text != "" && txt_phon.Text != "" && txt_nationality.Text != "" && cbGender.Text != "" && txt_maritalStatus.Text != "" && dtpDob.Text != "" && txt_PassportNo.Text != "" && dtpPasprtExpryDate.Text != "" && txt_LabrCrdNo.Text != "" && dtpLbrCrdExpryDate.Text != "" && txt_noOchildren.Text != "" && cbBloodgrp.Text != "" && txt_BankAccNo.Text != "" && txt_BankName.Text != "" && txt_BankBrach.Text != "" && txt_qlifucation.Text != "" && cbYearOfPassing.Text != "" && txt_percentageOfMarks.Text != "" && txt_university.Text != "" && txt_yearOfExperience.Text != "" && txt_EmployeeStatus.Text != "" && txt_sponserName.Text != "" && txt_VisaNo.Text != "" && dtpVisaExpryDate.Text != "" && txt_AnnualLeave.Text != "")
            {
                blObjct.DeleteEmployee(EmpId);

                MessageBox.Show("Delete Succesful");
            }
            else
            {
                MessageBox.Show("No Row Selected");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmEmpView vw = new frmEmpView();
            vw.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_code.Text != "" && txt_Name.Text != "" && txt_fatherName.Text != "" && txt_address.Text != "" && txt_phon.Text != "" && txt_nationality.Text != "" && cbGender.Text != "" && txt_maritalStatus.Text != "" && dtpDob.Text != "" && txt_PassportNo.Text != "" && dtpPasprtExpryDate.Text != "" && txt_LabrCrdNo.Text != "" && dtpLbrCrdExpryDate.Text != "" && txt_noOchildren.Text != "" && cbBloodgrp.Text != "" && txt_BankAccNo.Text != "" && txt_BankName.Text!= "" && txt_BankBrach.Text != "" && txt_qlifucation.Text!= "" && cbYearOfPassing.Text != "" && txt_percentageOfMarks.Text != "" && txt_university.Text != "" && txt_yearOfExperience.Text != "" && txt_EmployeeStatus.Text != "" && txt_sponserName.Text != "" && txt_VisaNo.Text != "" && dtpVisaExpryDate.Text != "" && txt_AnnualLeave.Text != "")
            {

                if (EmpId < 1)
                {

                    emp.EmpCode = txt_code.Text;
                    emp.EmpName = txt_Name.Text;
                    emp.FatherName = txt_fatherName.Text;
                    emp.Address = txt_address.Text;
                    emp.PhoneNo = txt_phon.Text;
                    emp.Nationality = txt_nationality.Text;
                    emp.Gender = cbGender.Text;
                    emp.MaritalStatus = txt_maritalStatus.Text;
                    emp.DateOfBirth = Convert.ToDateTime(dtpDob.Text);
                    emp.PassportNo = txt_PassportNo.Text;
                    emp.PassportExpiryDate = Convert.ToDateTime(dtpPasprtExpryDate.Text);
                    emp.LabourCardNo = txt_LabrCrdNo.Text;
                    emp.LabourCardExpiryDate = Convert.ToDateTime(dtpLbrCrdExpryDate.Text);
                    emp.NoOfChildren = txt_noOchildren.Text;
                    emp.BloodGroup = cbBloodgrp.Text;
                    emp.BankAccNo = txt_BankAccNo.Text;
                    emp.BankName = txt_BankName.Text;
                    emp.BankBranch = txt_BankBrach.Text;
                    emp.Qualification = txt_qlifucation.Text;
                    emp.YearOfPassing = Convert.ToInt16(cbYearOfPassing.Text);
                    emp.PercentageOfMarks = txt_percentageOfMarks.Text;
                    emp.University = txt_university.Text;
                    emp.YearsOfExperience = Convert.ToDecimal(txt_yearOfExperience.Text);
                    emp.EmployeeStatus = txt_EmployeeStatus.Text;

                    MemoryStream mstream;

                    Byte[] EmpPhoto = null;

                    if (empPhoto.Image != null)
                    {
                        //Save image from PictureBox into MemoryStream object.
                        mstream = new MemoryStream();

                        empPhoto.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);

                        if (mstream.Length > 778240)
                        {
                            MessageBox.Show("Maximum logo image size is 760 KB");

                            return;
                        }

                        //Read from MemoryStream into Byte array.
                        EmpPhoto = new Byte[mstream.Length];

                        mstream.Position = 0;

                        mstream.Read(EmpPhoto, 0, Convert.ToInt32(mstream.Length));
                    }

                    //Save logo
                    emp.EmpPhoto = EmpPhoto;
                    emp.SponsorName = txt_sponserName.Text;
                    emp.VisaNo = txt_VisaNo.Text;
                    emp.VisaExpiryDate = Convert.ToDateTime(dtpVisaExpryDate.Text);
                    emp.AnnualLeaveMaturity = Convert.ToDecimal(txt_AnnualLeave.Text);
                    int result;
                    result = blObjct.AddEmployee(emp);
                    if (result > 0)
                    {
                        MessageBox.Show("success");

                    }
                   
                }
                else
                {
                    Employee emp = new Employee();
                    BLemployee blObjct = new BLemployee();
                    emp.EmpCode = txt_code.Text;
                    emp.EmpName = txt_Name.Text;
                    emp.FatherName = txt_fatherName.Text;
                    emp.Address = txt_address.Text;
                    emp.PhoneNo = txt_phon.Text;
                    emp.Nationality = txt_nationality.Text;
                    emp.Gender = cbGender.Text;
                    emp.MaritalStatus = txt_maritalStatus.Text;
                    emp.DateOfBirth = Convert.ToDateTime(dtpDob.Text);
                    emp.PassportNo = txt_PassportNo.Text;
                    emp.PassportExpiryDate = Convert.ToDateTime(dtpPasprtExpryDate.Text);
                    emp.LabourCardNo = txt_LabrCrdNo.Text;
                    emp.LabourCardExpiryDate = Convert.ToDateTime(dtpLbrCrdExpryDate.Text);
                    emp.NoOfChildren = txt_noOchildren.Text;
                    emp.BloodGroup = cbBloodgrp.Text;
                    emp.BankAccNo = txt_BankAccNo.Text;
                    emp.BankName = txt_BankName.Text;
                    emp.BankBranch = txt_BankBrach.Text;
                    emp.Qualification = txt_qlifucation.Text;
                    emp.YearOfPassing = Convert.ToInt16(cbYearOfPassing.Text);
                    emp.PercentageOfMarks = txt_percentageOfMarks.Text;
                    emp.University = txt_university.Text;
                    emp.YearsOfExperience = Convert.ToDecimal(txt_yearOfExperience.Text);
                    emp.EmployeeStatus = txt_EmployeeStatus.Text;

                    MemoryStream mstream;

                    Byte[] EmpPhoto = null;

                    if (empPhoto.Image != null)
                    {
                        //Save image from PictureBox into MemoryStream object.
                        mstream = new MemoryStream();

                        empPhoto.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);

                        if (mstream.Length > 778240)
                        {
                            MessageBox.Show("Maximum logo image size is 760 KB");

                            return;
                        }

                        //Read from MemoryStream into Byte array.
                        EmpPhoto = new Byte[mstream.Length];

                        mstream.Position = 0;

                        mstream.Read(EmpPhoto, 0, Convert.ToInt32(mstream.Length));
                    }

                    //Save logo
                    emp.EmpPhoto = EmpPhoto;
                    emp.SponsorName = txt_sponserName.Text;
                    emp.VisaNo = txt_VisaNo.Text;
                    emp.VisaExpiryDate = Convert.ToDateTime(dtpVisaExpryDate.Text);
                    emp.AnnualLeaveMaturity = Convert.ToDecimal(txt_AnnualLeave.Text);
                    emp.EmpId = EmpId;
                    int result = blObjct.UpdateEmployee(emp);
                    if (result > 0)
                    {
                        MessageBox.Show("Update Successful");
                    }

                }
            }
            else
            {
                MessageBox.Show("please fill the data");
            }
            txt_Name.Text = txt_code.Text = txt_fatherName.Text =txt_address.Text = txt_phon.Text =txt_nationality.Text = cbGender.Text=  txt_maritalStatus.Text=dtpDob.Text=txt_PassportNo.Text = dtpPasprtExpryDate.Text =txt_LabrCrdNo.Text =  dtpLbrCrdExpryDate.Text = txt_noOchildren.Text = cbBloodgrp.Text =txt_BankAccNo.Text = txt_BankName.Text= txt_BankBrach.Text =txt_qlifucation.Text=cbYearOfPassing.Text =txt_percentageOfMarks.Text=txt_university.Text=txt_yearOfExperience.Text=txt_EmployeeStatus.Text=txt_sponserName.Text =txt_VisaNo.Text =dtpVisaExpryDate.Text= txt_AnnualLeave.Text ="";
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();

                //fldlg.InitialDirectory = @"D:\";

                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png;*.ico;*.pdf;*.psd)|*.jpg;*.bmp;*.gif,*.png,*.ico";

                if (fldlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap newimg = new Bitmap(fldlg.FileName);

                    empPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                    empPhoto.Image = (Image)newimg;
                }

                fldlg = null;
            }

            catch (System.ArgumentException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            empPhoto.Image = null;
        }
        private void ShowData()
        {
            Employee emp = blObjct.SelectEmployee(EmpId);


            txt_code.Text = emp.EmpCode;
            txt_Name.Text = emp.EmpName;
            txt_fatherName.Text = emp.FatherName;
            txt_address.Text = emp.Address;
            txt_phon.Text = emp.PhoneNo;
            txt_nationality.Text = emp.Nationality;
            cbGender.Text = emp.Gender;
            txt_maritalStatus.Text = emp.MaritalStatus;
            dtpDob.Text = Convert.ToString(emp.DateOfBirth);
            txt_PassportNo.Text = emp.PassportNo;
            dtpPasprtExpryDate.Text = Convert.ToString(emp.PassportExpiryDate);
            txt_LabrCrdNo.Text = emp.LabourCardNo;
            dtpLbrCrdExpryDate.Text = Convert.ToString(emp.LabourCardExpiryDate);
            txt_noOchildren.Text = emp.NoOfChildren;
            cbBloodgrp.Text = emp.BloodGroup;
            txt_BankAccNo.Text = emp.BankAccNo;
            txt_BankName.Text = emp.BankName;
            txt_BankBrach.Text = emp.BankBranch;
            txt_qlifucation.Text = emp.Qualification;
            cbYearOfPassing.Text = Convert.ToString(emp.YearOfPassing);
            txt_percentageOfMarks.Text = emp.PercentageOfMarks;
            txt_university.Text = emp.University;
            txt_yearOfExperience.Text = Convert.ToString(emp.YearsOfExperience);
            txt_EmployeeStatus.Text = emp.EmployeeStatus;

            if (empPhoto.Image != null)
            {
                empPhoto.Image.Dispose();
            }

            MemoryStream stmBLOBData;

            try
            {
                //BLOB is read into Byte array, then used to construct MemoryStream, then passed to PictureBox.
                Byte[] byteBLOBData = new Byte[0];




                stmBLOBData = new MemoryStream(emp.EmpPhoto);

                empPhoto.Image = Image.FromStream(stmBLOBData);

            }
            catch
            { }
            finally
            {
                stmBLOBData = null;
            }

            txt_sponserName.Text = emp.SponsorName;
            txt_VisaNo.Text = emp.VisaNo;
            dtpVisaExpryDate.Text = Convert.ToString(emp.VisaExpiryDate);
            txt_AnnualLeave.Text = Convert.ToString(emp.AnnualLeaveMaturity);



        }

        private void txt_nationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbYearOfPassing_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbYearOfPassing_MouseClick(object sender, MouseEventArgs e)
        {
            
            for (int year = DateTime.UtcNow.Year; year >1950; --year)
            {

                cbYearOfPassing.Items.Add(year);
            }
        }
    }
}
