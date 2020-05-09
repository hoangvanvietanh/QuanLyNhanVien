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
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DevExpress.Export.Xl;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account _account;
        private AccountServices accountServices = new AccountServices();
        private EmployeeService employeeService = new EmployeeService();
        private PositionServices positionServices = new PositionServices();
        private DepartmentServices departmentServices = new DepartmentServices();
        Byte[] ImageByArray;

        public AdminHome(Account account)
        {
            this._account = account;
            InitializeComponent();
            navigationFrame.SelectedPageIndex = 3;
            setVisibleScheduleRibbonPage(false);
            setVisiblePositionRibbonPage(false);
            setVisibleDepartmentRibbonPage(false);
            skins();
            schedulerControl1.Start = DateTime.Now;
            schedulerControl2.Start = DateTime.Now;
        }

        public AdminHome()
        {
            InitializeComponent();
            navigationFrame.SelectedPageIndex = 3;
            setVisibleScheduleRibbonPage(false);
            setVisiblePositionRibbonPage(false);
            setVisibleDepartmentRibbonPage(false);

            skins();
        }

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        { 
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
            if (navigationFrame.SelectedPageIndex == 0)
            {
                setVisibleScheduleRibbonPage(false);
                setVisibleEmployeeRibbonPage(true);
                setVisiblePositionRibbonPage(false);
                setVisibleDepartmentRibbonPage(false);
            }
            else if (navigationFrame.SelectedPageIndex == 1)
            {
                setVisibleScheduleRibbonPage(true);
                setVisibleEmployeeRibbonPage(false);
                setVisiblePositionRibbonPage(false);
                setVisibleDepartmentRibbonPage(false);
            }
            else if (navigationFrame.SelectedPageIndex == 2)
            {
                setVisibleScheduleRibbonPage(false);
                setVisibleEmployeeRibbonPage(false);
                setVisiblePositionRibbonPage(true);
                setVisibleDepartmentRibbonPage(false);
                navigationFrame.SelectedPageIndex = 5;
            }
            else if (navigationFrame.SelectedPageIndex == 3)
            {
                setVisibleScheduleRibbonPage(false);
                setVisibleEmployeeRibbonPage(false);
                setVisiblePositionRibbonPage(false);
                setVisibleDepartmentRibbonPage(true);
                navigationFrame.SelectedPageIndex = 6;
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
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.giaDinhUniversityDataSet.Position);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.giaDinhUniversityDataSet.Employees);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.giaDinhUniversityDataSet.Accounts);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);

            this.scheduleTableAdapter.FillBy(this.giaDinhUniversityDataSet.Schedule);
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

        public void load_gridCardViewEmployee()
        {
            this.employeesTableAdapter.Fill(this.giaDinhUniversityDataSet.Employees);
        }

        public void load_gridViewPosition()
        {
            this.positionTableAdapter.Fill(this.giaDinhUniversityDataSet.Position);
        }

        public void load_gridViewDepartment()
        {
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);
        }

        public void load_allGridView()
        {
            
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);
           
            this.positionTableAdapter.Fill(this.giaDinhUniversityDataSet.Position);
            
            this.employeesTableAdapter.Fill(this.giaDinhUniversityDataSet.Employees);
            
            this.accountsTableAdapter.Fill(this.giaDinhUniversityDataSet.Accounts);
            
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

        //Hiển thị menu của Position (Chức vụ)
        private void setVisiblePositionRibbonPage(bool status)
        {
            positionRibbonPageCategory.Visible = status;

        }

        //Hiển thị menu của Department (Phòng ban)
        private void setVisibleDepartmentRibbonPage(bool status)
        {
            departmentRibbonPageCategory.Visible = status;
        }

        //Show List Employee
        private void btnDanhSachTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //addButtonPage(2);
            navigationFrame.SelectedPageIndex = 2;
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

        //Show listView Employee 
        private void btnList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrame.SelectedPageIndex = 0;
        }

        //Show cardView Employee
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrame.SelectedPageIndex = 4;
        }

        private void btnChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminChangePassword adminChangePassword = new AdminChangePassword(_account);
            adminChangePassword.ShowDialog();
            load_gridViewAccount();
        }

        private void btnThongTinCaNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (_account.UserName.Trim().Equals("admin"))
            {
                
            }
            else
            {
                AdminInforTeachers adminInforTeachers = new AdminInforTeachers(employeeService.getEmployeeByAccountId(_account.AccountId));
                adminInforTeachers.showInfoAdmin();
                adminInforTeachers.ShowDialog();
            }
        }

        private void btnTaoMoiGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminCreateTeachers adminCreateTeachers = new AdminCreateTeachers();
            adminCreateTeachers.ShowDialog();
            load_allGridView();
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
            load_allGridView();
        }

        //Xóa giảng viên
        private void btnXoaGiangVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string idAccount = gridViewEmployee.Columns.View.GetFocusedRowCellValue("AccountId").ToString();
            
            string idEmployee = gridViewEmployee.Columns.View.GetFocusedRowCellValue("EmployeeId").ToString();
            employeeService.deleteEmployee(Int32.Parse(idEmployee));
            accountServices.deleteAccount(Int32.Parse(idAccount));
            
            XtraMessageBox.Show("Xóa thành công !!!");
            load_allGridView();
        }

        private void gridViewEmployee_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridViewEmployee.Columns.View.GetFocusedRowCellValue("FullName") == null)
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
                txtPhoneNumberShow.Text = gridViewEmployee.Columns.View.GetFocusedRowCellValue("PhoneNumber").ToString();
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

        private void GridViewEmployee_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            txtPhoneNumber.Text = emp.PhoneNumber;
            txtStatus.Text = emp.Status;
            byte[] ImageArray = (byte[])emp.Image.ToArray();
            if (ImageArray.Length == 0)
            {
                picInfo.Image = null;
            }
            else
            {
                picInfo.Image = Image.FromStream(new MemoryStream(ImageArray));
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDangXuatChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnDangXuatPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminCreatePosition adminCreatePosition = new AdminCreatePosition();
            adminCreatePosition.ShowDialog();
            load_gridViewPosition();
        }

        private void btnThemPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminCreateDepartment adminCreateDepartment = new AdminCreateDepartment();
            adminCreateDepartment.ShowDialog();
            load_gridViewDepartment();
        }

        private void btnSuaChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string id = gridViewPositon.Columns.View.GetFocusedRowCellValue("PositionId").ToString();
            string positionName = gridViewPositon.Columns.View.GetFocusedRowCellValue("PositionName").ToString();
            AdminUpdatePosition adminUpdatePosition = new AdminUpdatePosition(positionServices.getPositionById(Int32.Parse(id)));
            adminUpdatePosition.updatePosition(positionName);
            adminUpdatePosition.ShowDialog();
            load_allGridView();
        }

        private void btnXoaChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string idPosition = gridViewPositon.Columns.View.GetFocusedRowCellValue("PositionId").ToString();

            positionServices.deletePosition(Int32.Parse(idPosition));

            XtraMessageBox.Show("Xóa thành công");
            load_allGridView();
        }

        private void btnSuaPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string id = gridViewDepartment.Columns.View.GetFocusedRowCellValue("DepartmentId").ToString();
            string departmentName = gridViewDepartment.Columns.View.GetFocusedRowCellValue("DepartmentName").ToString();
            AdminUpdateDepartment adminUpdateDepartment = new AdminUpdateDepartment(departmentServices.getDepartmentById(Int32.Parse(id)));
            adminUpdateDepartment.updateDepartment(departmentName);
            adminUpdateDepartment.ShowDialog();
            load_allGridView();
        }

        private void btnXoaPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string idDepartment = gridViewDepartment.Columns.View.GetFocusedRowCellValue("DepartmentId").ToString();

            departmentServices.deleteDepartment(Int32.Parse(idDepartment));

            XtraMessageBox.Show("Xóa thành công");
            load_allGridView();
        }

        private void gridViewPositon_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void schedulerDataStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            try
            {
                
                scheduleTableAdapter.Update(giaDinhUniversityDataSet);
                giaDinhUniversityDataSet.AcceptChanges();
            }
            catch
            {
                
            }
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            QuanLyDaiHocGiaDinh.Views.OutlookAppointmentForm1 form = new QuanLyDaiHocGiaDinh.Views.OutlookAppointmentForm1(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }

        private void schedulerDataStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            ScheduleServices scheduleServices = new ScheduleServices();
            for (int i = 0; i < schedulerControl1.SelectedAppointments.Count; i++)
            {
                Appointment apt = schedulerControl1.SelectedAppointments[i];
                if (apt.CustomFields["UniqueID"] != null && apt.CustomFields["DepartmentsList"] != null)
                {
                    int idSchedule = Int32.Parse(apt.CustomFields["UniqueID"].ToString());
                    String[] listDepartment = apt.CustomFields["DepartmentsList"].ToString().Split(',');
                    for (int j = 0; j < listDepartment.Length; j++)
                    {
                        if (listDepartment[j].Trim() != "")
                        {
                            ScheduleDepartment scheduleDepartment = new ScheduleDepartment();
                            scheduleDepartment.idSchedule = idSchedule;
                            scheduleDepartment.idDepartment = Int32.Parse(listDepartment[j]);
                            //MessageBox.Show(scheduleDepartment.idSchedule + "--" + scheduleDepartment.idDepartment);
                            scheduleServices.deleteScheduleDepartment(scheduleDepartment);
                        }
                    }

                    String[] listPosition = apt.CustomFields["PositionList"].ToString().Split(',');
                    for (int k = 0; k < listPosition.Length; k++)
                    {
                        if (listPosition[i].Trim() != "")
                        {
                            SchedulePosition schedule = new SchedulePosition();
                            schedule.idPosition = Int32.Parse(listPosition[k]);
                            //MessageBox.Show(scheduleServices.getLastScheduleId().ToString());
                            schedule.idSchedule = idSchedule;
                            scheduleServices.deleteSchedulePosition(schedule);
                        }
                    }
                }
            }
            scheduleTableAdapter.Update(giaDinhUniversityDataSet);
            giaDinhUniversityDataSet.AcceptChanges();
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {
            btnXoaGiangVien.Enabled = false;
            btnSuaGiangVien.Enabled = false;
        }

        //Xuất File Excel Employee
        private void btnXuatFileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportExcelEmployee("");
        }

        private bool ExportExcelEmployee(string filename)
        {
            try
            {
                if (gridViewEmployee.FocusedRowHandle < 0)
                {

                }
                else
                {
                    var dialog = new SaveFileDialog();
                    dialog.Title = @"Export file excel";
                    dialog.FileName = filename;
                    dialog.Filter = @"Microsoft Excel|.xlsx";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        gridViewEmployee.ColumnPanelRowHeight = 40;
                        gridViewEmployee.OptionsPrint.AutoWidth = AutoSize;
                        gridViewEmployee.OptionsPrint.ShowPrintExportProgress = true;
                        gridViewEmployee.OptionsPrint.AllowCancelPrintExport = true;
                        XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                        options.TextExportMode = TextExportMode.Text;
                        options.LayoutMode = DevExpress.Export.LayoutMode.Table;
                        options.ExportMode = XlsxExportMode.SingleFile;
                        options.SheetName = @"Sheet1";

                        ExportSettings.DefaultExportType = ExportType.Default;
                        gridViewEmployee.ExportToXlsx(dialog.FileName, options);
                        XtraMessageBox.Show("Thành Công !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Lỗi: " + e, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        //Xuất File Excel Account
        private void btnXuatFileAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportExcelAccount("");
        }

        private bool ExportExcelAccount(string filename)
        {
            try
            {
                if (gridViewAccount.FocusedRowHandle < 0)
                {

                }
                else
                {
                    var dialog = new SaveFileDialog();
                    dialog.Title = @"Export file excel";
                    dialog.FileName = filename;
                    dialog.Filter = @"Microsoft Excel|.xlsx";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        gridViewAccount.ColumnPanelRowHeight = 40;
                        gridViewAccount.OptionsPrint.AutoWidth = AutoSize;
                        gridViewAccount.OptionsPrint.ShowPrintExportProgress = true;
                        gridViewAccount.OptionsPrint.AllowCancelPrintExport = true;
                        XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                        options.TextExportMode = TextExportMode.Text;
                        options.LayoutMode = DevExpress.Export.LayoutMode.Table;
                        options.ExportMode = XlsxExportMode.SingleFile;
                        options.SheetName = @"Sheet1";

                        ExportSettings.DefaultExportType = ExportType.Default;
                        gridViewAccount.ExportToXlsx(dialog.FileName, options);
                        XtraMessageBox.Show("Thành Công !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Lỗi: " + e, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}