using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.Forms.AutoTypeForm
{
    public partial class frmAutoTypeForm : Form
    {
        public frmAutoTypeForm()
        {
            InitializeComponent();
        }

        private void FrmAutoTypeForm_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void FillGrid(string searchvalue)
        {
            string query = string.Empty;
            dgvAutoType.DataSource = null;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select CarTypeID [ID], CarType [Auto Type], [Description] from CarTypeTable";
            }
            else
            {
                query = "select CarTypeID [ID], CarType [Auto Type], [Description] from CarTypeTable where CarType like '%" + searchvalue + "%' ";
            }

            DataTable dt = DatabaseAccess.Select(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dgvAutoType.DataSource = dt;
                    dgvAutoType.Columns[0].Width = 100;
                    dgvAutoType.Columns[1].Width = 200;
                    dgvAutoType.Columns[2].Width = 300;
                }
            }
        }

        private void EnableControls()
        {
            btnSave.Enabled = false;
            txtSearch.Enabled = false;
            dgvAutoType.Enabled = false;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void DisableControls()
        {
            btnSave.Enabled = true;
            txtSearch.Enabled = true;
            dgvAutoType.Enabled = true;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            ClearForm();
            FillGrid(string.Empty);
        }

        private void ClearForm()
        {
            txtSearch.Clear();
            txtDescription.Clear();
            txtAutoType.Clear();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DisableControls();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtAutoType.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAutoType, "Required Field!!");
                    txtAutoType.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Select("select * from CarTypeTable where CarType = '" + txtAutoType.Text.Trim() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtAutoType, "Already Exist!");
                        txtAutoType.SelectAll();
                        txtAutoType.Focus();
                        return;
                    }
                }

                string InsertQuery = string.Format(@"insert into CarTypeTable(CarType, Description) " +
                    " values ('" + txtAutoType.Text.Trim() + "', '" + txtDescription.Text.Trim() + "') ");
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
            if (dgvAutoType != null)
            {
                if (dgvAutoType.Rows.Count > 0)
                {
                    if (dgvAutoType.SelectedRows.Count == 1)
                    {
                        txtAutoType.Text = dgvAutoType.CurrentRow.Cells[1].Value.ToString();
                        txtDescription.Text = dgvAutoType.CurrentRow.Cells[2].Value.ToString();
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
                if (txtAutoType.Text.Trim().Length == 0)
                {
                    ep.SetError(txtAutoType, "Required Field!!");
                    txtAutoType.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Select("select * from CarTypeTable where CarType = '" + txtAutoType.Text.Trim() + "' and  CarTypeID != '" + dgvAutoType.CurrentRow.Cells[0].Value.ToString() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtAutoType, "Already Exist!");
                        txtAutoType.SelectAll();
                        txtAutoType.Focus();
                        return;
                    }
                }

                string updateQuery = string.Format(@"update CarTypeTable set CarType = '{0}' , Description = '{1}' where CarTypeID = '{2}' ", txtAutoType.Text.Trim(), txtDescription.Text.Trim(), dgvAutoType.CurrentRow.Cells[0].Value.ToString());
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
