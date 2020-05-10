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
using DevExpress.XtraSplashScreen;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminCreateDepartment : DevExpress.XtraEditors.XtraForm
    {
        private DepartmentServices departmentServices = new DepartmentServices();
        public AdminCreateDepartment()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Chờ tí nhé.....");

            Department dep = new Department();
            dep.DepartmentName = txtPhongBan.Text;
            departmentServices.createDepartment(dep);
            SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Thêm thành công !!!");
            this.Close();
        }
    }
}