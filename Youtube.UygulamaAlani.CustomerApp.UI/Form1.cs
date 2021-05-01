using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Youtube.UygulamaAlani.CustomerApp.Core.Entities;
using Youtube.UygulamaAlani.CustomerApp.Core.Repositories;

namespace Youtube.UygulamaAlani.CustomerApp.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Lütfen giriş bilgilerinizi eksiksiz olarak doldurunuz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SystemUserRepository systemUserRepository = new SystemUserRepository();
                SystemUser dataItem = systemUserRepository.CheckSystemUser(new Core.Entities.SystemUser()
                {
                    UserName = txtUserName.Text,
                    Pass = txtPass.Text
                });

                if (dataItem != null && dataItem.Id > 0)
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş Bilgileriniz Hatalı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
