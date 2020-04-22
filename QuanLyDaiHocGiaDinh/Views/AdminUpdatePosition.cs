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
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Win;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminUpdatePosition : DevExpress.XtraEditors.XtraForm
    {
        private Position _postion;
        private Department _department;
        private PositionServices positionServices = new PositionServices();
        private DepartmentServices departmentServices = new DepartmentServices();
        public AdminUpdatePosition(Position position)
        {
            InitializeComponent();
            this._postion = position;
            this._department = departmentServices.getDepartmentById((int)_postion.DepartmentId);
            txtPhongBan.Properties.SelectAllItemVisible = false;
            txtPhongBan.LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
        }
        void LookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            subscribe = true;
        }

        public void updatePosition(String positionName)
        {
            txtChucVu.Text = positionName;
            txtPhongBan.Text = _department.DepartmentName;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Position po = new Position();
            po = _postion;
            po.PositionName = txtChucVu.Text;
            Department dep = new Department();
            dep = _department;
            dep.DepartmentName = txtPhongBan.Text;
            departmentServices.updateDepartment(dep);
            positionServices.updatePosition(po);
            XtraMessageBox.Show("Sửa thành công !!!");
            this.Close();
        }

        private void AdminUpdatePosition_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);

        }

        //Check single for toolbox CheckcomboboxEdit
        bool subscribe = true;
        private void txtPhongBan_Popup(object sender, EventArgs e)
        {
            if (subscribe) // 1st approach
            {
                CheckedListBoxControl list = (sender as IPopupControl).PopupWindow.Controls.OfType<PopupContainerControl>().First().Controls.OfType<CheckedListBoxControl>().First();
                list.ItemCheck += list_ItemCheck;
                subscribe = false;
            }
        }

        void list_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (e.State == CheckState.Checked)
            {
                CheckedListBoxControl list = sender as CheckedListBoxControl;
                List<CheckedListBoxItem> items = new List<CheckedListBoxItem>();
                foreach (int index in list.CheckedIndices)
                {
                    if (index == e.Index) continue;
                    items.Add(list.Items[index]);
                }
                foreach (CheckedListBoxItem item in items)
                    item.CheckState = CheckState.Unchecked;
            }
        }
    }
}