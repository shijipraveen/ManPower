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
     

namespace ManPower
{
    public partial class frmNationality : Form
    {
        public frmNationality()
        {
            InitializeComponent();
        }
        public void refreshdata()
        {

            //DataTable dt = new DataTable();

            dgvNationality.DataSource = new BLnationality().SelectNationalities();
            dgvNationality.CurrentCell = null;
            txtName.Text = txtCode.Text = "";

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmNationality_Load(object sender, EventArgs e)
        {
            refreshdata();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BLnationality objBLL = new BLnationality();

            Nationality objnat = new Nationality();

            objnat.CountryName = txtName.Text;

            objnat.CountryCode = txtCode.Text;


            string val = objBLL.Validate(objnat);
            if (val != "")
            {
                MessageBox.Show(val);

                txtName.Focus();
            }
            else
            {
                try
                {
                    int retVal;

                    if (dgvNationality.CurrentCell == null)


                        retVal = objBLL.InsertNationality(objnat);
                    else
                        retVal = objBLL.UpdateNationality(dgvNationality["CountryName", dgvNationality.CurrentCell.RowIndex].Value.ToString(), objnat);

                    if (retVal > 0)
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }
                }
                catch //(Exception ex)
                {

                }
                finally
                {
                    objnat = null;

                    objBLL = null;
                }

                refreshdata();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BLnationality objBLL = new BLnationality();

            Nationality objnat = new Nationality();

            //int row = dataGridView1.CurrentCell.RowIndex;
            string CountryName = txtName.Text;
            try
            {
                int retVal = objBLL.DeleteNationality(CountryName);
                if (retVal > 0)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch //(Exception ex)
            {

            }
            finally
            {
                objnat = null;
                objBLL = null;
            }
            refreshdata();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvNationality.CurrentCell = null;
            txtName.Text = "";
            txtCode.Text = "";
        }

        private void dgvNationality_SelectionChanged(object sender, EventArgs e)
        {
            BLnationality objBLL = new BLnationality();

            Nationality objnat = new Nationality();
            DataGridViewRow row = this.dgvNationality.Rows[dgvNationality.CurrentCell.RowIndex];
            txtName.Text = row.Cells["CountryName"].Value.ToString();
            txtCode.Text = row.Cells["CountryCode"].Value.ToString();
        }
    }
}
