using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.Forms.DriverType
{
    public partial class frmDriverType : Form
    {
        public frmDriverType()
        {
            InitializeComponent();
        }

        private void FillGrid(string searchvalue)
        {
            dgvDriverType.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select DriverTypeID [ID], DriverType [Driver Type], [Description] from DriverTypeTable";
            }
            else
            {
                query = "select DriverTypeID [ID], DriverType [Driver Type], [Description] from DriverTypeTable where DriverType like '%" + searchvalue.Trim() + "%' ";
            }

            DataTable dt = DatabaseAccess.Select(query);
            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                    dgvDriverType.DataSource = dt;
                    dgvDriverType.Columns[0].Width = 100;
                    dgvDriverType.Columns[1].Width = 200;
                    dgvDriverType.Columns[2].Width = 300;
                }
            }
        }

        private void FrmDriverType_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void EnableControls()
        {
            btnSave.Enabled = false;
            txtSearch.Enabled = false;
            dgvDriverType.Enabled = false;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void DisableControls()
        {
            btnSave.Enabled = true;
            txtSearch.Enabled = true;
            dgvDriverType.Enabled = true;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            ClearForm();
            FillGrid(string.Empty);
        }

        private void ClearForm()
        {
            txtSearch.Clear();
            txtDescription.Clear();
            txtDriverType.Clear();
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
                if (txtDriverType.Text.Trim().Length == 0)
                {
                    ep.SetError(txtDriverType, "Required Field!!");
                    txtDriverType.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Select("select * from DriverTypeTable where DriverType = '" + txtDriverType.Text.Trim() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtDriverType, "Already Exist!");
                        txtDriverType.SelectAll();
                        txtDriverType.Focus();
                        return;
                    }
                }

                string InsertQuery = string.Format(@"insert into DriverTypeTable(DriverType, Description) " +
                    " values ('"+txtDriverType.Text.Trim()+"', '"+txtDescription.Text.Trim()+"') ");
                bool result = DatabaseAccess.InsertUpdateDelete(InsertQuery);
                if (result == true)
                {
                    ClearForm();
                    FillGrid(string.Empty);
                    MessageBox.Show("Save successfully!", "C# dev by TIK");
                }
                else
                {
                    MessageBox.Show("Save Failed!, Please Try Again...", "C# dev by TIK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvDriverType != null)
            {
                if(dgvDriverType.Rows.Count > 0)
                {
                    if(dgvDriverType.SelectedRows.Count == 1)
                    {
                        txtDriverType.Text = dgvDriverType.CurrentRow.Cells[1].Value.ToString();
                        txtDescription.Text = dgvDriverType.CurrentRow.Cells[2].Value.ToString();
                        EnableControls();
                        btnClear.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Record!", "C# dev by TIK");
                    }
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtDriverType.Text.Trim().Length == 0)
                {
                    ep.SetError(txtDriverType, "Required Field!!");
                    txtDriverType.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Select("select * from DriverTypeTable where DriverType = '" + txtDriverType.Text.Trim() + "' and  DriverTypeID != '"+ dgvDriverType.CurrentRow.Cells[0].Value.ToString() +"' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtDriverType, "Already Exist!");
                        txtDriverType.SelectAll();
                        txtDriverType.Focus();
                        return;
                    }
                }

                string updateQuery = string.Format(@"update DriverTypeTable set DriverType = '{0}' , Description = '{1}' where DriverTypeID = '{2}' ", txtDriverType.Text.Trim(), txtDescription.Text.Trim(), dgvDriverType.CurrentRow.Cells[0].Value.ToString()) ;
                bool result = DatabaseAccess.InsertUpdateDelete(updateQuery);
                if (result == true)
                {
                    ClearForm();
                    FillGrid(string.Empty);
                    DisableControls();
                    MessageBox.Show("Updated successfully!", "C# dev by TIK");
                }
                else
                {
                    MessageBox.Show("Save Failed!, Please Try Again...", "C# dev by TIK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
