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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminCreatePosition : DevExpress.XtraEditors.XtraForm
    {
        private PositionServices positionService = new PositionServices();
        public AdminCreatePosition()
        {
            InitializeComponent();
            txtPhongBan.Properties.SelectAllItemVisible = false;
            txtPhongBan.LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
        }

        void LookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            subscribe = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Position po = new Position();
            po.PositionName = txtChucVu.Text;
            po.DepartmentId = Int32.Parse(String.Format("{0}", txtPhongBan.EditValue));
            positionService.createPosition(po);

            XtraMessageBox.Show("Thêm thành công !!!");
            this.Close();
        }

        private void AdminCreatePosition_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);

        }

        //Check single for toolbox CheckcomboboxEdit
        bool subscribe = true;
        private void txtPhongBan_Popup_1(object sender, EventArgs e)
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