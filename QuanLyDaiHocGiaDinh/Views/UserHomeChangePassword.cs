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
using QuanLyDaiHocGiaDinh.Services;
using QuanLyDaiHocGiaDinh.Model;
using System.Net.Mail;
using System.Net;
using DevExpress.XtraSplashScreen;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class UserHomeChangePassword : DevExpress.XtraEditors.XtraForm
    {

        private AccountServices accountServices = new AccountServices();
        private Account _account = new Account();
        private EmployeeService employeeService = new EmployeeService();
       
        public UserHomeChangePassword(Account account)
        {

            InitializeComponent();
            this._account = account;
           
        }

        private void btnChangePasswordExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePasswordSave_Click(object sender, EventArgs e)
        {
            
            //Account account = new Account();
            // MessageBox.Show(_account.Password + "---" + txtPassword.Text);
            // account = accountServices.getAccountByEmployeeId();
            if (txtPassword.Text.Trim() == "") XtraMessageBox.Show("Bạn chưa nhập password");
            else if (txtNewPassword.Text.Trim() == "") XtraMessageBox.Show("Bạn chưa nhập password mới");
            else if (txtAgainPassword.Text.Trim() == "") XtraMessageBox.Show("Bạn chưa nhập lại password mới ");
            else if (txtPassword.Text.Trim() == txtNewPassword.Text.Trim()) XtraMessageBox.Show("Password mới trùng với Password cũ");
            else if (txtAgainPassword.Text.Trim() != txtNewPassword.Text.Trim()) XtraMessageBox.Show("Password không trùng nhau");
            else if (_account.Password.Trim() != txtPassword.Text.Trim()) XtraMessageBox.Show("Pass cũ không chính sát");
            else
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Chờ tí nhé.....");
                _account.Password = txtNewPassword.Text;
                accountServices.updateAccount(_account);
                XtraMessageBox.Show("Đổi Password thành công");
                Sendgmail();
                SplashScreenManager.CloseForm();
                this.Close();
            }

        }


        private void Sendgmail()
        {
            Employee employee = new Employee();
            employee = employeeService.getEmployeeByAccountId(_account.AccountId);
            try
            {
                MailMessage mail = new MailMessage();
             //   MessageBox.Show(employee.Email);
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("giadinh.gdu@gmail.com");
                mail.To.Add(employee.Email);
                mail.Subject = "Change Password";
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
            Employee employee = new Employee();
            employee = employeeService.getEmployeeByAccountId(_account.AccountId);
            return "<!DOCTYPE html> " +
                 "<html " +
                "<head>" +
                    "<title>Email</title>" +
                "</head>" +
                "<body style=\"font-family:'Century Gothic'\">" +
                    "<h1>" + "Change Password"+ "</h1>" +
                    "<h2 style=\"font-size:14px;\">" +
                        "Full Name : " + employee.FullName +  "<br />" +
                        "Email : " + employee.Email +
                    "</h2>" +
                    "<p style=\"font-size:16px;\">" + "Mật Khẩu của bạn đã bị thay đỗi vào lúc : "+ DateTime.Now.ToString()  + "</p>" +
                "</body>" +
                "</html>";
        }
    }
}