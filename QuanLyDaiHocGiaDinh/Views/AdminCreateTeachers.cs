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

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminCreateTeachers : DevExpress.XtraEditors.XtraForm
    {

        
        public AdminCreateTeachers()
        {
            InitializeComponent();
        }

        private void AdminCreateTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);

        }

        private void ImagePictureEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
    }
}