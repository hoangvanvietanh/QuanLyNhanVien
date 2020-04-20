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

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class UserHomeChangePassword : DevExpress.XtraEditors.XtraForm
    {

        private AccountServices accountServices = new AccountServices();
        private Account _account = new Account();
        private EmployeeService EmployeeService = new EmployeeService();
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
            else if (txtAgainPassword.Text.Trim() != txtNewPassword.Text.Trim()) XtraMessageBox.Show("Password không trùng nhau");
            else if (_account.Password.Trim() != txtPassword.Text.Trim()) XtraMessageBox.Show("Pass cũ không chính sát");
            else
            {
                _account.Password = txtNewPassword.Text;
                accountServices.updateAccount(_account);
                XtraMessageBox.Show("Đổi Password thành công");
                this.Close();
            }
            
        }
    }
}