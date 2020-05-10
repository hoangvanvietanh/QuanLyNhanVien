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
using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Services;
using DevExpress.XtraSplashScreen;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminChangePassword : DevExpress.XtraEditors.XtraForm
    {

        private Account _account;
        private AccountServices accountServices = new AccountServices();
        public AdminChangePassword(Account account)
        {
            InitializeComponent();
            this._account = account;
            txtUsernameChange.Text = _account.UserName;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtPasswordOldChange.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập mật khẩu hiện tại !!!");
                
            }
            else
            {
                if (txtPasswordNewChange.Text == "")
                {
                    XtraMessageBox.Show("Bạn chưa nhập mật khẩu mới !!!");
                }
                else
                {
                    if (txtPasswordNewChangeComfirm.Text == "")
                    {
                        XtraMessageBox.Show("Bạn chưa nhập lại mật khẩu mới !!!");
                    }
                    else
                    {
                        if(_account.Password.Trim() != txtPasswordOldChange.Text)
                        {
                            XtraMessageBox.Show("Mật khẩu hiện tại không đúng !!!");
                        }
                        else
                        {
                            if (txtPasswordNewChange.Text != txtPasswordNewChangeComfirm.Text )
                            {
                                XtraMessageBox.Show("Mật khẩu nhập lại không đúng !!!");
                            }
                            else
                            {
                                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                                SplashScreenManager.Default.SetWaitFormCaption("Chờ tí nhé.....");

                                Account acc = new Account();
                                acc = _account;
                                acc.Password = txtPasswordNewChange.Text;
                                accountServices.updateAccount(acc);

                                SplashScreenManager.CloseForm();

                                XtraMessageBox.Show("Đổi mật khẩu thành công !!!");
                                this.Close();
                            }
                        }
                    }
                }

            }

        }


    }
}