using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using QuanLyDaiHocGiaDinh.Config;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class ConnectSqlServer : DevExpress.XtraEditors.XtraForm
    {
        public ConnectSqlServer()
        {
            InitializeComponent();
            txtDatabase.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Home home = new Home();
            home.Show();
        }

        private void ConnectSqlServer_Load(object sender, EventArgs e)
        {
            //Add server name to combobox
            cboServer.Properties.Items.Add(".");
            cboServer.Properties.Items.Add("(local)");
            cboServer.Properties.Items.Add(@".\SQLEXPRESS");
            cboServer.Properties.Items.Add(string.Format(@"{0}", Environment.MachineName));
            cboServer.Properties.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 3;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbTypeConnect.SelectedItem.ToString().Equals("Windows Authentication"))
            {
                //Set connection string
                string connectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", cboServer.Text, txtDatabase.Text);
                try
                {
                    SqlHelper helper = new SqlHelper(connectionString);
                    if (helper.IsConnection)
                    {
                        AppSetting setting = new AppSetting();
                        setting.SaveConnectionString("QuanLyDaiHocGiaDinh.Properties.Settings.GiaDinhUniversityConnectionString", connectionString);
                        MessageBox.Show("Kết nối sql server thành công.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home home = new Home();
                        home.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Set connection string
                string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
                try
                {
                    SqlHelper helper = new SqlHelper(connectionString);
                    if (helper.IsConnection)
                    {
                        AppSetting setting = new AppSetting();
                        setting.SaveConnectionString("QuanLyDaiHocGiaDinh.Properties.Settings.GiaDinhUniversityConnectionString", connectionString);
                        MessageBox.Show("Kết nối sql server thành công.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        private void cbTypeConnect_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTypeConnect.SelectedItem.ToString().Equals("Windows Authentication"))
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
    }
}