using CarParkSystem.Forms.AutoTypeForm;
using CarParkSystem.Forms.DriverType;
using CarParkSystem.Forms.GRMForm;
using CarParkSystem.Forms.ParkingForm;
using CarParkSystem.Forms.RegistrationForm;
using CarParkSystem.Forms.UserForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void TsbtnDriverType_Click(object sender, EventArgs e)
        {
            frmDriverType frm = new frmDriverType();
            frm.btnCancel.Enabled = false;
            frm.btnUpdate.Enabled = false;
            frm.ShowDialog();
            
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            frmAutoTypeForm frm = new frmAutoTypeForm();
            frm.btnCancel.Enabled = false;
            frm.btnUpdate.Enabled = false;
            frm.ShowDialog();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            PersonRegistration personRegistration = new PersonRegistration();
            personRegistration.btnCancel.Enabled = false;
            personRegistration.btnUpdate.Enabled = false;
            personRegistration.ShowDialog();
        }

        private void TsbtnAllVehicle_Click(object sender, EventArgs e)
        {
            frmAllVehicle frmAllVehicle = new frmAllVehicle();
            frmAllVehicle.ShowDialog();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            frmGSMconnection frmGSMconnection = new frmGSMconnection();
            frmGSMconnection.ShowDialog();
        }

        private void TsbtnCheckIn_Click(object sender, EventArgs e)
        {
            frmCheckIn frmCheckIn = new frmCheckIn();
            frmCheckIn.ShowDialog();
        }

        private void TsbtnCheckOut_Click(object sender, EventArgs e)
        {
            frmCheckOut frmCheckOut = new frmCheckOut();
            frmCheckOut.ShowDialog();
        }

        private void TsbtnHistory_Click(object sender, EventArgs e)
        {
            frmParkingHistory frmParkingHistory = new frmParkingHistory();
            frmParkingHistory.ShowDialog();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            //LogInForm login = new LogInForm(this);
            //login.ShowDialog();
        }
    }
}
