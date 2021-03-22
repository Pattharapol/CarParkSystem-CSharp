using CarParkSystem.SourceCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.Forms.RegistrationForm
{
    public partial class PersonRegistration : Form
    {
        public PersonRegistration()
        {
            InitializeComponent();
        }

        private void PersonRegistration_Load(object sender, EventArgs e)
        {
            FillGrid(String.Empty);
            ComboList.FillCarType(cmbAutoType);
            ComboList.FillDriverType(cmbDriverType);
        }

        private void FillGrid(string searchvalue)
        {
            dgvPersonList.DataSource = null;
            string query = string.Empty;
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
                    dgvPersonList.DataSource = dt;
                    dgvPersonList.Columns[0].Width = 100; //PersonID
                    dgvPersonList.Columns[1].Width = 200; //FullName
                    dgvPersonList.Columns[2].Width = 120; //CNIC
                    dgvPersonList.Columns[3].Width = 120; //CellNo
                    dgvPersonList.Columns[4].Visible = false; //CarTypeID
                    dgvPersonList.Columns[5].Width = 120; //CarType
                    dgvPersonList.Columns[6].Visible = false; //DriverTypeID
                    dgvPersonList.Columns[7].Width = 150; //DriverType
                    dgvPersonList.Columns[8].Width = 120; //CarNo
                    dgvPersonList.Columns[9].Width = 130; //RegDate
                    dgvPersonList.Columns[10].Width = 300; //Description
                }
            }
        }

        private void EnableControls()
        {
            btnSave.Enabled = false;
            txtSearch.Enabled = false;
            dgvPersonList.Enabled = false;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void DisableControls()
        {
            btnSave.Enabled = true;
            txtSearch.Enabled = true;
            dgvPersonList.Enabled = true;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            ClearForm();
            FillGrid(string.Empty);
        }

        private void ClearForm()
        {
            cmbAutoType.SelectedIndex = 0;
            cmbDriverType.SelectedIndex = 0;
            txtFullName.Clear();
            txtCNIC.Clear();
            txtContactNo.Clear();
            txtRegno.Clear();
            txtSearch.Clear();
            txtDescription.Clear();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DisableControls();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (cmbAutoType.SelectedIndex == 0)
                {
                    ep.SetError(cmbAutoType, "Please Select Auto Type!");
                    cmbAutoType.Focus();
                    return;
                }

                if (cmbDriverType.SelectedIndex == 0)
                {
                    ep.SetError(cmbAutoType, "Please Select Driver Type!");
                    cmbDriverType.Focus();
                    return;
                }

                if (txtFullName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtFullName, "Required Field!!");
                    txtFullName.Focus();
                    return;
                }

                if (txtCNIC.Text.Trim().Length < 14)
                {
                    ep.SetError(txtCNIC, "Required Field!!");
                    txtCNIC.Focus();
                    return;
                }


                if (txtContactNo.Text.Trim().Length < 11)
                {
                    ep.SetError(txtContactNo, "Required Field!!");
                    txtContactNo.Focus();
                    return;
                }

                if (txtRegno.Text.Trim().Length == 0)
                {
                    ep.SetError(txtRegno, "Required Field!!");
                    txtRegno.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Select("select * from PersonTable where CarNo = '" + txtRegno.Text.Trim() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtRegno, "Already Exist!");
                        txtRegno.Focus();
                        txtRegno.SelectAll();
                        return;
                    }
                }

                string insertquery = string.Format(@"INSERT INTO [dbo].[PersonTable] ([DriverTypeID] ,[CarTypeID] ,[FullName] ,[CNIC] ,[CellNo] ,[CarNo] ,[RegDate] ,[Description]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", cmbDriverType.SelectedValue, cmbAutoType.SelectedValue, txtFullName.Text.Trim(), txtCNIC.Text.Trim(), txtContactNo.Text.Trim(), txtRegno.Text.Trim(), DateTime.Now.ToString("yyyy/MM/dd"), txtDescription.Text.Trim());

                bool result = DatabaseAccess.InsertUpdateDelete(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Insert Successfully!", "C# dev by TIK");
                    ClearForm();
                    FillGrid(string.Empty);
                }
                else
                {
                    MessageBox.Show("Insert Failed!", "C# dev by TIK");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (cmbAutoType.SelectedIndex == 0)
                {
                    ep.SetError(cmbAutoType, "Please Select Auto Type!");
                    cmbAutoType.Focus();
                    return;
                }

                if (cmbDriverType.SelectedIndex == 0)
                {
                    ep.SetError(cmbAutoType, "Please Select Driver Type!");
                    cmbDriverType.Focus();
                    return;
                }

                if (txtFullName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtFullName, "Required Field!!");
                    txtFullName.Focus();
                    return;
                }

                if (txtCNIC.Text.Trim().Length < 15)
                {
                    ep.SetError(txtCNIC, "Required Field!!");
                    txtCNIC.Focus();
                    return;
                }


                if (txtContactNo.Text.Trim().Length < 12)
                {
                    ep.SetError(txtContactNo, "Required Field!!");
                    txtContactNo.Focus();
                    return;
                }

                if (txtRegno.Text.Trim().Length < 12)
                {
                    ep.SetError(txtRegno, "Required Field!!");
                    txtRegno.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Select("select * from PersonTable where CarNo = '" + txtRegno.Text.Trim() + "' and  PersonID != '" + dgvPersonList.CurrentRow.Cells[0].Value.ToString() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtRegno, "Already Exist!");
                        txtRegno.Focus();
                        txtRegno.SelectAll();
                        return;
                    }
                }

                string updatequery = string.Format(@"UPDATE [dbo].[PersonTable] SET [DriverTypeID] = '{0}' ,[CarTypeID] = '{1}' ,[FullName] = '{2}' ,[CNIC] = '{3}' ,[CellNo] = '{4}' ,[CarNo] = '{5}' ,[RegDate] = '{6}' ,[Description] = '{7}' WHERE PersonID = '{8}' ", cmbDriverType.SelectedValue, cmbAutoType.SelectedValue, txtFullName.Text.Trim(), txtCNIC.Text.Trim(), txtContactNo.Text.Trim(), txtRegno.Text.Trim(), DateTime.Now.ToString("yyyy/MM/dd"), txtDescription.Text.Trim(), dgvPersonList.CurrentRow.Cells[0].Value.ToString());

                bool result = DatabaseAccess.InsertUpdateDelete(updatequery);
                if (result == true)
                {
                    MessageBox.Show("Updated Successfully!", "C# dev by TIK");
                    DisableControls();
                }
                else
                {
                    MessageBox.Show("Updated Failed!", "C# dev by TIK");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvPersonList != null)
            {
                if(dgvPersonList.Rows.Count > 0)
                {
                    if(dgvPersonList.SelectedRows.Count == 1)
                    {
                        txtFullName.Text = Convert.ToString(dgvPersonList.CurrentRow.Cells[1].Value); //FullName
                        txtCNIC.Text = Convert.ToString(dgvPersonList.CurrentRow.Cells[2].Value); //CNIC
                        txtContactNo.Text = Convert.ToString(dgvPersonList.CurrentRow.Cells[3].Value); //CellNo
                        cmbAutoType.SelectedIndex = Convert.ToInt32(dgvPersonList.CurrentRow.Cells[4].Value); //CarTypeID
                        cmbDriverType.SelectedIndex = Convert.ToInt32(dgvPersonList.CurrentRow.Cells[6].Value); //DriverTypeID
                        txtRegno.Text = Convert.ToString(dgvPersonList.CurrentRow.Cells[8].Value); //CarNo
                        txtDescription.Text = Convert.ToString(dgvPersonList.CurrentRow.Cells[10].Value); //Description
                        EnableControls();
                        btnClear.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record...", "C# dev by TIK");
                    }
                }
            }
        }
    }
}
