using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.Forms.ParkingForm
{
    public partial class frmCheckIn : Form
    {
        public string personID = string.Empty;

        public frmCheckIn()
        {
            InitializeComponent();
        }

        

        private void FrmCheckIn_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void FillGrid(string searchvalue)
        {
            DataTable dt = new DataTable();
            dgvCheckIn.DataSource = null;
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue))
                {
                    query = "SELECT dbo.ParkingTable.PersonID [ID], dbo.View_PersonList.FullName [Name], dbo.View_PersonList.CarNo [No Flat], dbo.ParkingTable.CheckinDate, dbo.ParkingTable.CheckinTime, dbo.View_PersonList.CarType [Auto Type], dbo.View_PersonList.DriverType [Driver Type], dbo.ParkingTable.SRTCode [Check Out Code] FROM  dbo.ParkingTable INNER JOIN dbo.View_PersonList ON dbo.ParkingTable.PersonID = dbo.View_PersonList.PersonID";
                }
                else
                {
                    query = "SELECT dbo.ParkingTable.PersonID [ID], dbo.View_PersonList.FullName [Name], dbo.View_PersonList.CarNo [No Flat], dbo.ParkingTable.CheckinDate, dbo.ParkingTable.CheckinTime, dbo.View_PersonList.CarType [Auto Type], dbo.View_PersonList.DriverType [Driver Type], dbo.ParkingTable.SRTCode [Check Out Code] FROM dbo.ParkingTable INNER JOIN dbo.View_PersonList ON dbo.ParkingTable.PersonID = dbo.View_PersonList.PersonID where CheckoutDate is null and CheckoutTime is null and CarNo like '%" + searchvalue.Trim() + "%'  ";
                }

                dt = DatabaseAccess.Select(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dgvCheckIn.DataSource = dt;
                        dgvCheckIn.Columns[0].Visible = false; // personID
                        dgvCheckIn.Columns[1].Width = 150;  // Name
                        dgvCheckIn.Columns[2].Width = 100; // No Flat
                        dgvCheckIn.Columns[3].Width = 100; // CheckinDate
                        dgvCheckIn.Columns[4].Width = 100; // CheckinTime
                        dgvCheckIn.Columns[5].Width = 100; // Auto Type
                        dgvCheckIn.Columns[6].Width = 100; // Driver Type
                        dgvCheckIn.Columns[7].Width = 130; // Check Out Code
                    }
                }
            }
            catch (Exception)
            {
             
            }
        }

        private void getPersonInfo(string searchValue)
        {
            try
            {
                string query = string.Format(@"select PersonID, FullName,CNIC from PersonTable where CarNo = '" + searchValue + "' ");
                DataTable dt = DatabaseAccess.Select(query);
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        personID = dt.Rows[0][0].ToString();
                        lblPersonName.Text = dt.Rows[0][1].ToString();
                        lblCNIC.Text = dt.Rows[0][2].ToString();
                        return;
                    }
                    else
                    {
                        personID = string.Empty;
                        lblPersonName.Text = "";
                        lblCNIC.Text = "";
                    }
                }
                else
                {
                    personID = string.Empty;
                    lblPersonName.Text = "";
                    lblCNIC.Text = "";
                }
            }
            catch
            {
                personID = string.Empty;
                lblPersonName.Text = "";
                lblCNIC.Text = "";
            }
        }

        private void TxtNoFlat_TextChanged(object sender, EventArgs e)
        {
            getPersonInfo(txtNoFlat.Text.Trim());
        }

        private void BtnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(personID))
                {
                    MessageBox.Show("Please Enter Correct No-Flat!!");
                    return;
                }


                // getHashCode
                string SRTCode = txtNoFlat.Text.Trim() + GetCodeForParking(txtNoFlat.Text.Trim()) + DateTime.Now.ToString("ss");


                DataTable dt = DatabaseAccess.Select("select * from ParkingTable where PersonID = '"+personID+"' and CheckoutDate is null and CheckoutTime is null");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("It's Already in Parking!!");
                        txtNoFlat.SelectAll();
                        txtNoFlat.Focus();
                        return;
                    }
                }

                string insertquery = string.Format(@"insert into ParkingTable (PersonID, CheckInDate, CheckInTime, SRTCode) values ('{0}', '{1}', '{2}', '{3}') ", personID, DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("HH:mm"), SRTCode);
                bool result = DatabaseAccess.InsertUpdateDelete(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Check In Successfully!");
                    FillGrid(string.Empty);
                    txtNoFlat.Clear();
                    txtNoFlat.Focus();
                }
                else
                {
                    MessageBox.Show("Check In Failed, Please try again...");
                    txtNoFlat.SelectAll();
                    txtNoFlat.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Some unexpected occure, Please contact IT team...");
            }

        }


        // define characters alowed in passcode
        static char[] ValidChars = {'2','3','4','5','6','7','8','9','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        const string hashkey = "password";
        const int codeLenght = 6;


        // getHashCode
        private string GetCodeForParking(string noFlat)
        {
            byte[] hash;
            // system.security.cryptography
            using (HMACSHA1 sha1 = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(hashkey)))
            {
                hash = sha1.ComputeHash(UTF8Encoding.UTF8.GetBytes(noFlat));
                int startPos = hash[hash.Length - 1] % (hash.Length - codeLenght);
                StringBuilder passbuilder = new StringBuilder();
                for(int i = startPos; i < startPos+codeLenght; i++)
                {
                    passbuilder.Append(ValidChars[hash[i] % ValidChars.Length]);
                }
                return passbuilder.ToString();
            }
            
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }
    }
}
