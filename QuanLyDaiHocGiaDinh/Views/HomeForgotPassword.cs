﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Controller;
using QuanLyDaiHocGiaDinh.Services;
using System.Net.Mail;
using System.Net;
using DevExpress.XtraSplashScreen;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class HomeForgotPassword : DevExpress.XtraEditors.XtraForm
    {
     
        private Account _account = new Account();
        private HomeController homeController = new HomeController();
        private AccountServices accountServices = new AccountServices();
        private Account account = new Account();
        private Random random = new Random();
        private EmployeeService employeeService = new EmployeeService();
        private int num;
        public HomeForgotPassword(Account account)
        {
            InitializeComponent();
            //  this._account = account;
           
        }
        public HomeForgotPassword()
        {
            InitializeComponent();
            //  this._account = account;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String Login(string user)
        {
           
            string accountRole = "";
            bool isCorrect = false;
            Account ac = accountServices.getAccountByUserName(user);
            if (ac != null)
            {
                this.account = ac;
                accountRole = ac.UserName;
                isCorrect = true;
            }
            /*accountServices.GetAllAccounts().ForEach(x =>
            {
                if (String.Compare(x.UserName.Trim(), user.Trim(), true) == 0)
                {
                        isCorrect = true;
                        accountRole = x.UserName;
                        account = x;      
                }
            });*/
            if (isCorrect == true)
            {
                return accountRole;
            }
            return accountRole;
        }
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Chờ tí nhé.....");

            string username = Login(txtEmailForgotPassword.Text);

            //accountServices.getRoleByAccountId();

            if (txtEmailForgotPassword.Text.Trim()==username.Trim())
            {
                lblThongBao.Text = "Email tồn tại, Kiễm tra Gmail và nhập mã";
                txtMatuEmail.Enabled = true;
                num = random.Next(100000,999999);
                //MessageBox.Show(num.ToString());
                Sendgmail();
                btnTiepTuc.Visible = false;
                btnTiepTuc1.Visible = true;
                SplashScreenManager.CloseForm();
            }
            else
            {
                MessageBox.Show("Emmail không tồn tại");
                SplashScreenManager.CloseForm();
            }
        }
        private void btnTiepTuc1_Click(object sender, EventArgs e)
        {
            if(txtMatuEmail.Text.Trim() == num.ToString().Trim())
            {
                lblThongBao.Text = "Mã nhập chính sát , bạn có thể đổi mật khẩu mới !!!";
                btnTiepTuc1.Visible = false;
                btnSave.Visible = true;
                setVisibleMatKhau(true);
                setVisibleCheckEmail(false);
            }    
            else
            {
                MessageBox.Show("Mã nhập không chính sát,vui lòng nhập Email và gửi lại");
                HomeForgotPassword home = new HomeForgotPassword(account);
                home.ShowDialog();
                this.Close();
               
            }    
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtMatKhauMoi.Text.Trim() == "") XtraMessageBox.Show("Bạn Chưa nhập mật khẩu mới");
            else if (txtNhapLaiMatKhau.Text.Trim() == "") XtraMessageBox.Show("Bạn chưa nhập lại mật khẩu");
            else if (txtMatKhauMoi.Text.Trim() != txtNhapLaiMatKhau.Text.Trim()) XtraMessageBox.Show("Mật khẩu chưa trùng nhau");
            else
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Chờ tí nhé.....");
                
                Account ac = accountServices.getAccountByUserName(txtEmailForgotPassword.Text);
                if (ac != null)
                {
                    _account = ac;
                }
                /*
                accountServices.GetAllAccounts().ForEach(account =>
                {
                    if (account.UserName.Trim().CompareTo(txtEmailForgotPassword.Text.Trim()) == 0)
                    {
                        _account = account;
                    }
                });*/
                _account.Password = txtMatKhauMoi.Text;
           //     MessageBox.Show(_account.Password);
                accountServices.updateAccount(_account);
                XtraMessageBox.Show("Đổi Password thành công");
                this.Close();
                Home _home = new Home();
                SplashScreenManager.CloseForm();
                _home.ShowDialog();
            }    
        }

        
        private void setVisibleCheckEmail(bool status)
        {
            lblEmail.Visible = status;
            lblMaTuEmail.Visible = status;
            txtEmailForgotPassword.Visible = status;
            txtMatuEmail.Visible = status;
        }
        private void setVisibleMatKhau(bool status)
        {
            lblMatKhauMoi.Visible = status;
            lblNhapLaiMatKhau.Visible = status;
            txtMatKhauMoi.Visible = status;
            txtNhapLaiMatKhau.Visible = status;
        }
        private void Sendgmail()
        {
            // Employee employee = new Employee();
            //  employee = employeeService.getEmployeeByAccountId(_account.AccountId);
            try
            {
                MailMessage mail = new MailMessage();
                //   MessageBox.Show(employee.Email);
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("giadinh.gdu@gmail.com");
                mail.To.Add(txtEmailForgotPassword.Text);
                mail.Subject = "Khôi phục mật khẩu";
                mail.IsBodyHtml = true;
                mail.Body = MessgeHTMl();


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("giadinh.gdu@gmail.com", "thanhthuongnghia");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Thông báo tới Email");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Thất bại");
            }
        }
        private string MessgeHTMl()
        {
            //  Employee employee = new Employee();
            //   employee = employeeService.getEmployeeByAccountId(_account.AccountId);
            return "<!DOCTYPE html> " +
                 "<html " +
                "<head>" +
                    "<title>Email</title>" +
                "</head>" +
                "<body style=\"font-family:'Century Gothic'\",\"background-color:'#6d695c'\">" +
                    "<h1>" + "Mã kích hoạt tài khoảng" + "</h1>" +
                    "<h2 style=\"font-size:14px;\">" +
                        //   "Full Name : " + employee.FullName + "<br />" +
                        "Email : " + txtEmailForgotPassword.Text +
                    "</h2>" +
                    "<p style=\"font-size:16px;\">" + "Mật mã là : " + num.ToString() + "</p>" +
                "</body>" +
                "</html>";
        }


    }
}