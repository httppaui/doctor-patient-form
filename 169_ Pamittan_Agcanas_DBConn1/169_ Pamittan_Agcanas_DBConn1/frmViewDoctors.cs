using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _169__Pamittan_Agcanas_DBConn1
{
    public partial class frmViewDoctors : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Z:\\169_Pamittan_PaulaHewlett_SC\\169_Pamittan_PaulaHewlett_Agcanas_JakeRussel_AppDB\\dbHospital.accdb");

        public frmViewDoctors()
        {
            InitializeComponent();
        }

        void search(string _query)
        {
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            grdDoctors.DataSource = dt;
        }

        private void frmViewDoctors_Load(object sender, EventArgs e)
        {
            search("SELECT doctor.* FROM doctor");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("SELECT doctor.* FROM doctor WHERE(((doctor.Lastname) = '" + txtLName.Text + "'));");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDoctorID.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtBday.Clear();
            txtAdd.Clear();
            txtCpNum.Clear();
            txtEmail.Clear();
            txtSpec.Clear();

            search("SELECT doctor.* FROM doctor");

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO doctor(Firstname, Lastname, Birthday, Address, CpNum, Email, Specialization) VALUES('" + txtFName.Text + "','" + txtLName.Text + "', '" + txtBday.Text + "', '" + txtAdd.Text + "', '" + txtCpNum.Text + "', '" + txtEmail.Text + "', '" + txtSpec.Text + "') ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT doctor.* FROM doctor");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE doctor SET  Firstname = '" + txtFName.Text + "', Lastname = '" + txtLName.Text + "', Birthday = '" + txtBday.Text + "', Address = '" + txtAdd.Text + "', CpNum = '" + txtCpNum.Text + "', Email = '" + txtEmail.Text + "', Specialization  = '" + txtSpec.Text + "' WHERE doctorID = "+txtDoctorID.Text+" ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT doctor.* FROM doctor");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM doctor WHERE Lastname = '" + txtLName.Text + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT doctor.* FROM doctor");
        }
    }
}
