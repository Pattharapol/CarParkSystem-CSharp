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
    public partial class frmParkingHistory : Form
    {
        public frmParkingHistory()
        {
            InitializeComponent();
        }

        private void FrmParkingHistory_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void FillGrid(string searchvalue)
        {
            DataTable dt = new DataTable();
            dgvHistory.DataSource = null;
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue))
                {
                    query = "SELECT dbo.ParkingTable.ParkingID, dbo.ParkingTable.PersonID, dbo.View_PersonList.FullName, dbo.View_PersonList.CarType, dbo.View_PersonList.DriverType, dbo.View_PersonList.CarNo, dbo.ParkingTable.CheckinDate, dbo.ParkingTable.CheckinTime, dbo.ParkingTable.SRTCode, dbo.ParkingTable.CheckoutDate, dbo.ParkingTable.CheckoutTime FROM dbo.ParkingTable INNER JOIN dbo.View_PersonList ON dbo.ParkingTable.PersonID = dbo.View_PersonList.PersonID";
                }
                else
                {
                    query = "SELECT dbo.ParkingTable.ParkingID, dbo.ParkingTable.PersonID, dbo.View_PersonList.FullName, dbo.View_PersonList.CarType, dbo.View_PersonList.DriverType, dbo.View_PersonList.CarNo, dbo.ParkingTable.CheckinDate, dbo.ParkingTable.CheckinTime, dbo.ParkingTable.SRTCode, dbo.ParkingTable.CheckoutDate, dbo.ParkingTable.CheckoutTime FROM dbo.ParkingTable INNER JOIN dbo.View_PersonList ON dbo.ParkingTable.PersonID = dbo.View_PersonList.PersonID where CarNo like '%" + searchvalue.Trim() + "%'  ";
                }

                dt = DatabaseAccess.Select(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dgvHistory.DataSource = dt;
                        dgvHistory.Columns[0].Visible = false; // ParkingID
                        dgvHistory.Columns[1].Visible = false;  // PersonID
                        dgvHistory.Columns[2].Width = 170;  // Name
                        dgvHistory.Columns[3].Width = 100; // No Flat
                        dgvHistory.Columns[4].Width = 100; // CheckinDate
                        dgvHistory.Columns[5].Width = 100; // CheckinTime
                        dgvHistory.Columns[6].Width = 85; // Auto Type
                        dgvHistory.Columns[7].Width = 100; // Driver Type
                        dgvHistory.Columns[8].Width = 150; // Check Out Code
                        dgvHistory.Columns[9].Width = 100; // Check Out Date
                        dgvHistory.Columns[10].Width = 100; // Check Out Time
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }
    }
}
