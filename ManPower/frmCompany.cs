using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManPowerBLL;
using ManPowerModel;
using System.IO;
using System.Text.RegularExpressions;


namespace ManPower
{
    public partial class frmCompany : Form
    {
        BLcompany blobj = new BLcompany();
        Company cmp = new Company();
        public frmCompany()
        {
            InitializeComponent();
           
        }
        
       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_mobile_Click(object sender, EventArgs e)
        {

        }

        private void lbl_email_Click(object sender, EventArgs e)
        {

        }

        private void lbl_website_Click(object sender, EventArgs e)
        {

        }

        private void lbl_regno_Click(object sender, EventArgs e)
        {

        }

        private void lbl_brcodehdng_Click(object sender, EventArgs e)
        {

        }

        private void lbl_incometaxno_Click(object sender, EventArgs e)
        {

        }

        private void lbl_description_Click(object sender, EventArgs e)
        {

        }

        private void lbl_begdate_Click(object sender, EventArgs e)
        {

        }

        private void lbl_expirydate_Click(object sender, EventArgs e)
        {

        }

        private void txt_website_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_regno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_brcodehdng_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_incometaxno_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_cmpname_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {


            
                cmp.CompanyName = txt_cmpnyname.Text;
                cmp.Address = txt_adrs.Text;
                cmp.Phone = txt_phone.Text;
                cmp.Fax = txt_fax.Text;
                cmp.Mobile = txt_mobile.Text;
                cmp.Email = txt_email.Text;
                cmp.Website = txt_website.Text;
                cmp.RegisterNo = txt_regno.Text;
                cmp.BarcodeHeading = txt_brcodehdng.Text;
                cmp.IncomeTaxNo = txt_incometaxno.Text;
                cmp.Description = txt_description.Text;
                cmp.BookBeginningDate = Convert.ToDateTime(dtp_begdate.Text);
                cmp.CRexpiryDate = Convert.ToDateTime(dtp_expirydate.Text);


                MemoryStream mstream;

                Byte[] logo = null;

                if (pbLogo.Image != null)
                {
                    //Save image from PictureBox into MemoryStream object.
                    mstream = new System.IO.MemoryStream();

                    pbLogo.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);

                    if (mstream.Length > 778240)
                    {
                        MessageBox.Show("Maximum logo image size is 760 KB");

                        return;
                    }

                    //Read from MemoryStream into Byte array.
                    logo = new Byte[mstream.Length];

                    mstream.Position = 0;

                    mstream.Read(logo, 0, Convert.ToInt32(mstream.Length));
                }

                cmp.logo = logo;

           
            if (txt_cmpnyname.Text != "" &&txt_adrs.Text != "" && txt_phone.Text != "" && txt_mobile.Text != "" && txt_email.Text != "" && txt_website.Text != "" && txt_regno.Text != "" && txt_brcodehdng.Text != "" && txt_incometaxno.Text != "" && txt_description.Text != "" && dtp_begdate.Text != "" && dtp_expirydate.Text != "")
                {
                     blobj.UpdateCompany(cmp);
                 
                        MessageBox.Show("Updation successful");
                    
                }
               else
                   MessageBox.Show("Updation Failed\n"," Please Fill Data");
            
                  

        }

        private void FormCompany_Load(object sender, EventArgs e)
        {
           

            Company cmp = blobj.SelectCompany();

            txt_cmpnyname.Text = cmp.CompanyName;
            txt_adrs.Text = cmp.Address;
            txt_phone.Text = cmp.Phone;
            txt_fax.Text = cmp.Fax;
            txt_mobile.Text = cmp.Mobile;
            txt_email.Text = cmp.Email;
            txt_website.Text = cmp.Website;
            txt_regno.Text = cmp.RegisterNo;
            txt_brcodehdng.Text = cmp.BarcodeHeading;
            txt_incometaxno.Text = cmp.IncomeTaxNo;
            txt_description.Text = cmp.Description;
            dtp_begdate.Text = Convert.ToString(cmp.BookBeginningDate);
            dtp_expirydate.Text = Convert.ToString(cmp.CRexpiryDate);


            //if there is an already an image in picturebox, then delete it

            if (pbLogo.Image != null)
            {
                pbLogo.Image.Dispose();
            }

            MemoryStream stmBLOBData;

            try
            {
                //BLOB is read into Byte array, then used to construct MemoryStream, then passed to PictureBox.

                stmBLOBData = new MemoryStream(cmp.logo);

                pbLogo.Image = Image.FromStream(stmBLOBData);

            }
            catch
            { }
            finally
            {
                stmBLOBData = null;
            }
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

                    pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;

                    pbLogo.Image = (Image)newimg;
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            pbLogo.Image = null;
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            
         
        }

        private void txt_email_Validating(object sender, CancelEventArgs e)
        {

            string msg = blobj.validateEmail(cmp);
            // Regex rx = new Regex(emailpattern);
            if (Regex.IsMatch(txt_email.ToString(), msg))
                errorProvider1.Clear();
            else
            {
                errorProvider1.SetError(this.txt_email, "Invalid Format");
                e.Cancel = true;

            }

        }

        private void txt_website_Validating(object sender, CancelEventArgs e)
        {

            string msg = blobj.validateWebsite(cmp);
            // Regex rx = new Regex(emailpattern);
            if (Regex.IsMatch(txt_website.ToString(), msg))
                errorProvider2.Clear();
            else
            {
                errorProvider2.SetError(this.txt_website, "Invalid Format");
                e.Cancel = true;
            }


        }
    }
}
