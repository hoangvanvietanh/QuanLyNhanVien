using Newtonsoft.Json;
using QuanLyDaiHocGiaDinh.Controller;
using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Services;
using QuanLyDaiHocGiaDinh.Views;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDaiHocGiaDinh
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        private string userName = "My friend";
        HomeController homeController = new HomeController();
        public Home()
        {
            InitializeComponent();
            txtUserName.Select();
            setVisibleFormAldreadyLogin(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String role = homeController.Login(txtUserName.Text, txtPassword.Text);
            openFormWithRole(role);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            isLoginAdready(false, "Đăng nhập");
        }

        private void isLoginAdready(bool isLogin, string userName)
        {
            if (isLogin == true)
            {
                setVisibleFormLogin(false);
                setVisibleFormAldreadyLogin(true);
                laTitle.Text = "Hi, " + userName;
            }
            else
            {
                setVisibleFormLogin(true);
                setVisibleFormAldreadyLogin(false);
                laTitle.Text = "Đăng nhập";
            }
           
        }

        private void setVisibleFormAldreadyLogin(bool status)
        {
            btnLogout.Visible = status;
            btnComback.Visible = status;
        }
        private void txtUserName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            laNotice.Text = "";
        }

        private void txtPassword_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            laNotice.Text = "";
        }

        private void btnComback_Click(object sender, EventArgs e)
        {
            openFormWithRole(homeController.getAccountLoggedIn().Role);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            btnLogin.Focus();
        }

        private void setVisibleFormLogin(bool status)
        {
            txtPassword.Visible = status;
            txtUserName.Visible = status;
            btnLogin.Visible = status;
            btnExit.Visible = status;
        }

        private void openFormWithRole(string role)
        {
            if (String.Compare(role.Trim(), "employee", true) == 0)
            {
                UserHome userHome = new UserHome(homeController.getAccountLoggedIn());
                userHome.ShowDialog();
                isLoginAdready(true, userName);
            }
            else if (String.Compare(role.Trim(), "manage", true) == 0)
            {
                AdminHome adminHome = new AdminHome(homeController.getAccountLoggedIn());
                adminHome.ShowDialog();
                isLoginAdready(true, userName);
            }
            else
            {
                laNotice.Text = "Sai tài khoản hoặc mật khẩu";
            }
        }
    }
}
