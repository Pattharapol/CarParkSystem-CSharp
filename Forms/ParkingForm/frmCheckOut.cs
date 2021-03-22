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
    public partial class frmCheckOut : Form
    {
        public string personID = string.Empty;
        public string parkingID = string.Empty;

        public frmCheckOut()
        {
            InitializeComponent();
        }

        private void FrmCheckOut_Load(object sender, EventArgs e)
        {

        }

        private void getPersonInfo(string searchValue)
        {
            try
            {
                string query = string.Format(@"SELECT dbo.ParkingTable.ParkingID , dbo.ParkingTable.PersonID, dbo.View_PersonList.FullName, dbo.View_PersonList.CarNo, dbo.ParkingTable.CheckinDate, dbo.ParkingTable.CheckinTime, dbo.View_PersonList.CarType, dbo.View_PersonList.DriverType, dbo.ParkingTable.SRTCode FROM dbo.ParkingTable INNER JOIN dbo.View_PersonList ON dbo.ParkingTable.PersonID = dbo.View_PersonList.PersonID where SRTCode = '" + searchValue.Trim() + "'  ");
                DataTable dt = DatabaseAccess.Select(query);
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        parkingID = dt.Rows[0]["ParkingID"].ToString();
                        lblPersonName.Text = dt.Rows[0]["FullName"].ToString();
                        lblDriverType.Text = dt.Rows[0]["DriverType"].ToString();
                        lblAutoType.Text = dt.Rows[0]["CarType"].ToString();
                        lblNoFlat.Text = dt.Rows[0]["CarNo"].ToString();
                        lblCheckInDate.Text = dt.Rows[0]["CheckinDate"].ToString();
                        lblCheckInTime.Text = dt.Rows[0]["CheckinTime"].ToString();

                        return;
                    }
                    else
                    {
                        parkingID = "";
                        lblPersonName.Text = "";
                        lblDriverType.Text = "";
                        lblAutoType.Text = "";
                        lblNoFlat.Text = "";
                        lblCheckInDate.Text = "";
                        lblCheckInTime.Text = "";
                    }
                }
                else
                {
                    parkingID = "";
                    lblPersonName.Text = "";
                    lblDriverType.Text = "";
                    lblAutoType.Text = "";
                    lblNoFlat.Text = "";
                    lblCheckInDate.Text = "";
                    lblCheckInTime.Text = "";
                }
            }
            catch
            {
                parkingID = "";
                lblPersonName.Text = "";
                lblDriverType.Text = "";
                lblAutoType.Text = "";
                lblNoFlat.Text = "";
                lblCheckInDate.Text = "";
                lblCheckInTime.Text = "";
            }
        }

        private void TxtNoFlat_TextChanged(object sender, EventArgs e)
        {
            getPersonInfo(txtCode.Text.Trim());
        }

        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(parkingID))
            {
                MessageBox.Show("Please Enter Correct Code!");
                return;
            }

            DataTable dt = DatabaseAccess.Select("select * from ParkingTable where ParkingID = '"+parkingID+ "' and CheckoutDate is not null  and CheckoutTime is not null ");
            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("It's Already Check Out!@");
                    txtCode.Clear();
                    txtCode.Focus();
                    parkingID = "";
                    lblPersonName.Text = "";
                    lblDriverType.Text = "";
                    lblAutoType.Text = "";
                    lblNoFlat.Text = "";
                    lblCheckInDate.Text = "";
                    lblCheckInTime.Text = "";
                    return;
                }
            }

            string updatequery = string.Format(@"update ParkingTable set CheckoutDate = '{0}', CheckoutTime = '{1}' where ParkingID = '{2}' ", DateTime.Now.ToString("yyyy/MM/dd") , DateTime.Now.ToString("HH:mm"), parkingID);
            bool result = DatabaseAccess.InsertUpdateDelete(updatequery);
            if(result == true)
            {
                MessageBox.Show("Check Out Successfully!");
                txtCode.Clear();
                txtCode.Focus();
                parkingID = "";
                lblPersonName.Text = "";
                lblDriverType.Text = "";
                lblAutoType.Text = "";
                lblNoFlat.Text = "";
                lblCheckInDate.Text = "";
                lblCheckInTime.Text = "";
            }
            else
            {
                MessageBox.Show("Check Out Failed!, Please Try Again...");
                txtCode.Clear();
                txtCode.Focus();
                parkingID = "";
                lblPersonName.Text = "";
                lblDriverType.Text = "";
                lblAutoType.Text = "";
                lblNoFlat.Text = "";
                lblCheckInDate.Text = "";
                lblCheckInTime.Text = "";
            }
        }


    }
}
