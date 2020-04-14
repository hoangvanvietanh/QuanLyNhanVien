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
using QuanLyDaiHocGiaDinh.Services;
using QuanLyDaiHocGiaDinh.Controller;
using QuanLyDaiHocGiaDinh.Model;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class UserHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account _account;

        public UserHome(Account account)
        {
            //Ví dụ để lấy employee đang đăng nhập
            EmployeeService employeeService = new EmployeeService(account);
            Employee employee = new Employee();
            employee = employeeService.getEmployeeByAccountId();//lấy employee đang đăng nhập
            employee.FullName = "Việt Anh Update 3";
            employee.FirstName = "Việt Nè";
            employeeService.updateEmployee(employee);//ví dụ về cập nhật


            Console.WriteLine(employeeService.getEmployeeByAccountId().FullName);
            ////////////
            this._account = account;
            InitializeComponent();
            setVisibleScheduleRibbonPage(false);
            this.scheduleTableAdapter.Fill(this.giaDinhUniversityDataSet.Schedule, this._account.AccountId);
        }

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
            if (navigationFrame.SelectedPageIndex == 0)
            {
                setVisibleScheduleRibbonPage(false);
                setVisibleHomeRibbonPage(true);
            }
            else if (navigationFrame.SelectedPageIndex == 1)
            {
                setVisibleScheduleRibbonPage(true);
                setVisibleHomeRibbonPage(false);
            }
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void schedulerDataStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            scheduleTableAdapter.Update(giaDinhUniversityDataSet);
            giaDinhUniversityDataSet.AcceptChanges();
        }

        private void schedulerControl_InitNewAppointment(object sender, AppointmentEventArgs e)
        {
            e.Appointment.CustomFields["AccountId"] = this._account.AccountId;
        }

        private void setVisibleScheduleRibbonPage(bool status)
        {
            fileScheduleRibbonPage.Visible = status;
            homeScheduleRibbonPage.Visible = status;
            viewScheduleRibbonPage.Visible = status;
        }

        private void setVisibleHomeRibbonPage(bool status)
        {
            homeRibbonPage.Visible = status;
        }
    }
}