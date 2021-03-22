using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.Forms.UserForm
{
    public partial class LogInForm : Form
    {
        private HomeForm formhome;

        public LogInForm(HomeForm homeForm)
        {
            InitializeComponent();
            formhome = homeForm;
            this.ActiveControl = lbl1;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(lbl1.Text.Trim().Length == 0)
            {
                ep.SetError(lbl1, "Please Enter Username...");
                lbl1.Focus();
                return;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                ep.SetError(txtPassword, "Please Enter Password...");
                txtPassword.Focus();
                return;
            }

            string loginquery = string.Format(@"select * from UserTable where username = '"+txtUsername.Text.Trim()+"' and password = '"+txtPassword.Text.Trim()+"' ");
            DataTable dt = DatabaseAccess.Select(loginquery);
            if(dt != null)
            {
                if(dt.Rows.Count == 1)
                {
                    this.Close();
                    formhome.hometoolstrip.Enabled = true;
                }
            }



        }
    }
}
