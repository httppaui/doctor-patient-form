using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _169__Pamittan_Agcanas_DBConn1
{
    public partial class frmMain : Form
    {

        Form dform = new frmViewDoctors();
        Form pform = new frmViewPatients();
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cboSelect.Text == "Patient")
            {
                pform.ShowDialog();
            }
            else if (cboSelect.Text == "Doctor")
            {
                dform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pumili ka!", "Select", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();   
        }
    }
}
