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

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account _account;

        public AdminHome(Account account)
        {
            this._account = account;
            InitializeComponent();
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
        }
    }
}