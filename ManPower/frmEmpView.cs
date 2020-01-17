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

namespace ManPower
{
    public partial class frmEmpView : Form
    {
        BLemployee bl = new BLemployee();
        public frmEmpView()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

        private void frmEmpView_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = bl.SelectEmployees();


        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddEmployee frm = new frmAddEmployee();
            frm.EmpId = Convert.ToInt32(dataGridView1["EmpId", dataGridView1.CurrentCell.RowIndex].Value);
            frm.ShowDialog();

        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddEmployee frm = new frmAddEmployee();
            frm.EmpId = Convert.ToInt32(dataGridView1["EmpId", dataGridView1.CurrentCell.RowIndex].Value);
            frm.ShowDialog();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddEmployee frm = new frmAddEmployee();
            frm.EmpId = Convert.ToInt32(dataGridView1["EmpId", dataGridView1.CurrentCell.RowIndex].Value);
            frm.ShowDialog();

        }
    }
}
