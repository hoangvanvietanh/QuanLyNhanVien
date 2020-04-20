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
using System.IO;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account _account;
        private AccountServices accountServices = new AccountServices();
        private EmployeeService employeeService = new EmployeeService();
        Byte[] ImageByArray;

        public AdminHome(Account account)
        {
            this._account = account;
            InitializeComponent();
            navigationFrame.SelectedPageIndex = 3;
            setVisibleScheduleRibbonPage(false);
        }

        public AdminHome()
        {
            skins();
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
            skins();
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.giaDinhUniversityDataSet.Employees);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.giaDinhUniversityDataSet.Accounts);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);
        }

        //Default Skin
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Office 2016 Black";
        }

        public void load_gridViewEmployee()
        {
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);
        }

        public void load_gridViewAccount()
        {
            this.accountsTableAdapter.Fill(this.giaDinhUniversityDataSet.Accounts);
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

        //Phương thức click button chuyển page trong 1 nav
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
            AdminChangePassword adminChangePassword = new AdminChangePassword(_account);
            adminChangePassword.ShowDialog();
            load_gridViewAccount();
        }

        private void btnThongTinCaNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminInforTeachers adminInforTeachers = new AdminInforTeachers(employeeService.getEmployeeByAccountId(_account.AccountId));
            adminInforTeachers.showInfoAdmin();
            adminInforTeachers.ShowDialog();
        }

        private void btnTaoMoiGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminCreateTeachers adminCreateTeachers = new AdminCreateTeachers();
            adminCreateTeachers.ShowDialog();
            load_gridViewEmployee();
        }

        //Sửa giảng viên
        private void btnSuaGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string id = gridViewEmployee.Columns.View.GetFocusedRowCellValue("AccountId").ToString();
            string fullName = gridViewEmployee.Columns.View.GetFocusedRowCellValue("FullName").ToString();
            string firstName = gridViewEmployee.Columns.View.GetFocusedRowCellValue("FirstName").ToString();
            string lastName = gridViewEmployee.Columns.View.GetFocusedRowCellValue("LastName").ToString();
            string birthDate = gridViewEmployee.Columns.View.GetFocusedRowCellValue("BirthDate").ToString();
            string address = gridViewEmployee.Columns.View.GetFocusedRowCellValue("Address").ToString();
            string ward = gridViewEmployee.Columns.View.GetFocusedRowCellValue("Ward").ToString();
            string district = gridViewEmployee.Columns.View.GetFocusedRowCellValue("District").ToString();
            string city = gridViewEmployee.Columns.View.GetFocusedRowCellValue("City").ToString();
            string phoneNumber = gridViewEmployee.Columns.View.GetFocusedRowCellValue("PhoneNumber").ToString();
            string email = gridViewEmployee.Columns.View.GetFocusedRowCellValue("Email").ToString();
            string status = gridViewEmployee.Columns.View.GetFocusedRowCellValue("Status").ToString();
            string hireDate = gridViewEmployee.Columns.View.GetFocusedRowCellValue("HireDate").ToString();
            string positionName = gridViewEmployee.Columns.View.GetFocusedRowCellValue("PositionName").ToString();
            string departmentName = gridViewEmployee.Columns.View.GetFocusedRowCellValue("DepartmentName").ToString();
            byte[] ImageArray = (byte[])gridViewEmployee.Columns.View.GetFocusedRowCellValue("Image");
            AdminUpdateTeachers adminUpdateTeachers = new AdminUpdateTeachers(employeeService.getEmployeeByAccountId(Int32.Parse(id)));
            adminUpdateTeachers.updateTeacher(fullName,firstName,lastName,birthDate,address,ward,district,city,phoneNumber,email,status,hireDate,positionName, departmentName, ImageArray);
            adminUpdateTeachers.ShowDialog();

            load_gridViewEmployee();

        }

        //Xóa giảng viên
        private void btnXoaGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string idAccount = gridViewEmployee.Columns.View.GetFocusedRowCellValue("AccountId").ToString();
            
            string idEmployee = gridViewEmployee.Columns.View.GetFocusedRowCellValue("EmployeeId").ToString();
            employeeService.deleteEmployee(Int32.Parse(idEmployee));
            accountServices.deleteAccount(Int32.Parse(idAccount));
            
            XtraMessageBox.Show("Xóa thành công !!!");
            load_gridViewEmployee();
        }

        private void gridViewEmployee_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(gridViewEmployee.Columns.View.GetFocusedRowCellValue("FullName") == null)
            {
                btnSuaGiangVien.Enabled = false;
                btnXoaGiangVien.Enabled = false;
            }
            else
            {
                btnSuaGiangVien.Enabled = true;
                btnXoaGiangVien.Enabled = true;
                txtFullNameShow.Text = gridViewEmployee.Columns.View.GetFocusedRowCellValue("FullName").ToString();
                txtEmailShow.Text = gridViewEmployee.Columns.View.GetFocusedRowCellValue("Email").ToString();
                txtPhoneShow.Text = gridViewEmployee.Columns.View.GetFocusedRowCellValue("PhoneNumber").ToString();
                txtStatusShow.Text = gridViewEmployee.Columns.View.GetFocusedRowCellValue("Status").ToString();
                txtDepartmentNameShow.Text = gridViewEmployee.Columns.View.GetFocusedRowCellValue("DepartmentName").ToString();
                txtPositionNameShow.Text = gridViewEmployee.Columns.View.GetFocusedRowCellValue("PositionName").ToString();
                byte[] ImageArray = (byte[])gridViewEmployee.Columns.View.GetFocusedRowCellValue("Image");
                ImageByArray = ImageArray;
                if (ImageArray.Length == 0)
                {
                    pictureEditShow.Image = null;
                }
                else
                {
                    pictureEditShow.Image = Image.FromStream(new MemoryStream(ImageArray));
                }
            }
        }

        private void gridViewAccount_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string id = gridViewAccount.Columns.View.GetFocusedRowCellValue("AccountId").ToString();
            txtUsername.Text = gridViewAccount.Columns.View.GetFocusedRowCellValue("UserName").ToString();
            txtPassword.Text = gridViewAccount.Columns.View.GetFocusedRowCellValue("Password").ToString();
            txtRole.Text = gridViewAccount.Columns.View.GetFocusedRowCellValue("Role").ToString();

            Employee emp = new Employee();
            emp = employeeService.getEmployeeByAccountId(Int32.Parse(id));
            txtFullName.Text = emp.FullName;
            txtEmail.Text = emp.Email;
            txtPhone.Text = emp.PhoneNumber;
            txtStatus.Text = emp.Status;
            //picInfor.Image = (byte[])emp.Image;
        }
    }
}