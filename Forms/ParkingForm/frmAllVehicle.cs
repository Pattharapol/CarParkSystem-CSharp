using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.Forms.ParkingForm
{
    public partial class frmAllVehicle : Form
    {
        public frmAllVehicle()
        {
            InitializeComponent();
        }

        private void FrmAllVehicle_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void FillGrid(string searchvalue)
        {
            string query = string.Empty;
            dgvAllVehicle.DataSource = null;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "SELECT PersonID [ID],FullName [Full Name],CNIC [CNIC],CellNo [Contact No],CarTypeID ,CarType [Auto Type],DriverTypeID ,DriverType [Driver Type] ,CarNo [Reg PlateNo] ,RegDate [Reg Date] ,[Description] FROM [dbo].[View_PersonList]";
            }
            else
            {
                query = "SELECT PersonID[ID],FullName[Full Name],CNIC[CNIC],CellNo[Contact No],CarTypeID ,CarType[Auto Type],DriverTypeID ,DriverType[Driver Type] ,CarNo[Reg PlateNo] ,RegDate[Reg Date] ,[Description] FROM[dbo].[View_PersonList] where FullName like '%" + searchvalue.Trim() + "%' "; // or CNIC like '%" + searchvalue + "%' or CellNo like '%" + searchvalue + "%' or CarType like '%" + searchvalue + "%' or DriverType like '%" + searchvalue + "%' or CarNo like '%" + searchvalue + "%' ";
            }

            DataTable dt = DatabaseAccess.Select(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dgvAllVehicle.DataSource = dt;
                    dgvAllVehicle.Columns[0].Width = 100; //PersonID
                    dgvAllVehicle.Columns[1].Width = 200; //FullName
                    dgvAllVehicle.Columns[2].Width = 120; //CNIC
                    dgvAllVehicle.Columns[3].Width = 120; //CellNo
                    dgvAllVehicle.Columns[4].Visible = false; //CarTypeID
                    dgvAllVehicle.Columns[5].Width = 120; //CarType
                    dgvAllVehicle.Columns[6].Visible = false; //DriverTypeID
                    dgvAllVehicle.Columns[7].Width = 150; //DriverType
                    dgvAllVehicle.Columns[8].Width = 120; //CarNo
                    dgvAllVehicle.Columns[9].Width = 130; //RegDate
                    dgvAllVehicle.Columns[10].Width = 300; //Description
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }
    }
}
