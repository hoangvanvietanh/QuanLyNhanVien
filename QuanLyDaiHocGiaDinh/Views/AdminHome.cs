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
using DevExpress.XtraScheduler;
using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Services;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account _account;
        private AccountServices accountServices = new AccountServices();

        public AdminHome(Account account)
        {
            this._account = account;
            InitializeComponent();
            navigationFrame.SelectedPageIndex = 3;
            setVisibleScheduleRibbonPage(false);
        }

        public AdminHome()
        {
            InitializeComponent();
            navigationFrame.SelectedPageIndex = 3;
            setVisibleScheduleRibbonPage(false);
        }

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        { 
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
            if (navigationFrame.SelectedPageIndex == 0)
            {
                setVisibleScheduleRibbonPage(false);
                setVisibleEmployeeRibbonPage(true);
            }
            else if (navigationFrame.SelectedPageIndex == 1)
            {
                setVisibleScheduleRibbonPage(true);
                setVisibleEmployeeRibbonPage(false);
            }
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.giaDinhUniversityDataSet.Employees);
            form_load(sender,e);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.giaDinhUniversityDataSet.Accounts);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);

        }

        //Hiển thị menu của Schedule (lịch trình)
        private void setVisibleScheduleRibbonPage(bool status)
        {
            fileScheduleRibbonPage.Visible = status;
            homeScheduleRibbonPage.Visible = status;
            viewScheduleRibbonPage.Visible = status;
        }

        //Hiển thị menu của Employee (Nhân viên)
        private void setVisibleEmployeeRibbonPage(bool status)
        {
            employeeHomeRibbonPage.Visible = status;
            employeeManageRibbonPage.Visible = status;
            employeeAboutRibbonPage.Visible = status;
        }

        private void btnDanhSachTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addButtonPage(2);
        }

        public void addButtonPage(int index)
        {
            navBarControl.Groups.Add();
            navBarControl.ActiveGroup = navBarControl.Groups[index];
            navBarControl.Groups.RemoveAt(index);
        }

        private void btnQuanLyGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrame.SelectedPageIndex = 0;
        }

        private void btnChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminChangePassword adminChangePassword = new AdminChangePassword();
            adminChangePassword.ShowDialog();
        }

        private void btnThongTinCaNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminInforTeachers adminInforTeachers = new AdminInforTeachers();
            adminInforTeachers.ShowDialog();
        }

        private void btnTaoMoiGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminCreateTeachers adminCreateTeachers = new AdminCreateTeachers();
            adminCreateTeachers.ShowDialog();
        }

        private void navBarControl_Click(object sender, EventArgs e)
        {

        }

        public void form_load(object sender, EventArgs e)
        {
            LinQDataContext db = new LinQDataContext();
            var Lst = (from s in db.Accounts select s).ToList();
            gridControlAccount.DataSource = Lst;
            txtUsername.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            txtRole.DataBindings.Clear();
            txtEmloyeeId.DataBindings.Clear();
            txtUsername.DataBindings.Add("text", Lst, "Username");
            txtPassword.DataBindings.Add("text", Lst, "Password");
            txtRole.DataBindings.Add("text", Lst, "Role");
            txtEmloyeeId.DataBindings.Add("text", Lst, "EmployeeId");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.UserName = txtUsername.Text;
            acc.Password = txtPassword.Text;
            acc.Role = txtRole.Text;
            accountServices.createAccount(acc);
            XtraMessageBox.Show("Thêm thành công !!!");
            form_load(sender, e);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtRole.Text = "";
            txtEmloyeeId.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LinQDataContext db = new LinQDataContext();
            string id = gridViewAccount.Columns.View.GetFocusedRowCellValue("AccountId").ToString();
            //acc = accountServices.getAccountByEmployeeId(Int32.Parse(id));
           Account acc = db.Accounts.Where(p => p.AccountId.Equals(id)).SingleOrDefault();
           //accountServices.deleteAccount(Int32.Parse(id));
           accountServices.deleteAccount(acc);
            XtraMessageBox.Show("Xóa thành công !!!"); 
            form_load(sender, e);
        }

  
    }
}