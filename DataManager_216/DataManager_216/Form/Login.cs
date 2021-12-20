using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManager_216
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Clear_Click(object sender, EventArgs e)
        {
            tb_Login_UserName.Clear();
            tb_Login_Password.Clear();
        }

        private async void btn_Login_Login_Click(object sender, EventArgs e)
        {
            GlobalAppProperties.Password = tb_Login_Password.Text.Trim();
            GlobalAppProperties.Username = tb_Login_UserName.Text.Trim();

            tb_Login_Password.Text = String.Concat(Enumerable.Repeat("•", GlobalAppProperties.Password.Length));
            tb_Login_UserName.Text = GlobalAppProperties.Username;
            this.Refresh();

            await Task.Run(() => System.Threading.Thread.Sleep(700));
            if(LoginInfoValid() == true)
            {
                //this.Close();
                this.Hide();
                frmMain frmMain = new frmMain(this);
                frmMain.Show();
            }
            else
            {
                MessageBox.Show(null, "Invalid login credentials. Please try again or verify that Microsoft Azure is not offline.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LoginInfoValid()
        {
            bool LoginSuccessful = GeneralFormLibrary1.DatabaseAPI.IsServerConnected(GeneralFormLibrary1.DatabaseAPI.ConnectionString("QuantDB",GlobalAppProperties.GetCredentials()));
            return LoginSuccessful;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

