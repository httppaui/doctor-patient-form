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
    public partial class frmViewPatients : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Z:\\169_Pamittan_PaulaHewlett_SC\\169_Pamittan_PaulaHewlett_Agcanas_JakeRussel_AppDB\\dbHospital.accdb");

        public frmViewPatients()
        {
            InitializeComponent();
           
        }

        private void frmViewPatients_Load(object sender, EventArgs e)
        {
            search("SELECT patient.* FROM patient");
        }

        void search(string _query)
        {
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            grdPatients.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("SELECT patient.* FROM patient WHERE(((patient.Lastname) = '" + txtLName.Text + "'));");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPatient.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtSex.Clear();
            txtBday.Clear();
            txtAge.Clear();
            txtAdd.Clear();
            txtCP.Clear();

            search("SELECT patient.* FROM patient");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO patient(Firstname, Lastname, Sex, Birthday, Age, Address, CpNum) VALUES('"+txtFName.Text+ "','" + txtLName.Text + "', '" + txtSex.Text + "', '" + txtBday.Text + "', '" + txtAge.Text + "', '" + txtAdd.Text + "', '" + txtCP.Text + "') ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT patient.* FROM patient");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = " UPDATE patient SET Firstname = '"+txtFName.Text+ "', Lastname = '" + txtLName.Text + "', Sex = '" + txtSex.Text + "', Birthday = '" + txtBday.Text + "', Age = '" + txtAge.Text + "', Address = '" + txtAdd.Text + "', CpNum = '" + txtCP.Text + "' WHERE PatientID = "+ txtPatient.Text +"  ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT patient.* FROM patient");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM patient WHERE Lastname = '" + txtLName.Text + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();

            search("SELECT patient.* FROM patient");

        }
    }
}
