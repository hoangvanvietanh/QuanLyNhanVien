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
using System.IO;
using QuanLyDaiHocGiaDinh.Services;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminCreateTeachers : DevExpress.XtraEditors.XtraForm
    {
        private AccountServices accountServices = new AccountServices();
        private EmployeeService employeeService = new EmployeeService();
       

        String strFilePath = "";
        Byte[] ImageByArray;
        public AdminCreateTeachers()
        {
            InitializeComponent();
        }

        private void AdminCreateTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.giaDinhUniversityDataSet.Position);


        }

        private void ImagePictureEdit_EditValueChanged(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                ImagePictureEdit.Image = new Bitmap(strFilePath);
            }

            if (strFilePath == "")
            {
                /*if (ImageByArray.Length != 0)
                    ImageByArray = new byte[] { };*/
                XtraMessageBox.Show("Vui lòng chọn hình đại diện ^^");
                
                ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    strFilePath = ofd.FileName;
                    ImagePictureEdit.Image = new Bitmap(strFilePath);
                }
                Image temp = new Bitmap(strFilePath);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByArray = strm.ToArray();
            }
            else
            {
                Image temp = new Bitmap(strFilePath);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByArray = strm.ToArray();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Account acc = new Account();
            acc.UserName = EmailTextEdit.Text.Trim();
            acc.Password = EmailTextEdit.Text.Trim();
            acc.Role = RoleTextEdit.Text; 
            
            Employee emp = new Employee();
            emp.AccountId = accountServices.createAccount(acc).AccountId;
            emp.FullName = FullNameTextEdit.Text;
            emp.FirstName = FirstNameTextEdit.Text;
            emp.LastName = LastNameTextEdit.Text;
            emp.BirthDate = BirthDateDateEdit.DateTime;
            emp.Address = AddressTextEdit.Text;
            emp.Ward = WardTextEdit.Text;
            emp.District = DistrictTextEdit.Text;
            emp.City = CityTextEdit.Text;
            emp.PhoneNumber = PhoneNumberTextEdit.Text;
            emp.Email = EmailTextEdit.Text;
            emp.Status = StatusTextEdit.Text;
            emp.HireDate = HireDateDateEdit.DateTime;
            emp.PositionId = Int32.Parse(String.Format("{0}", PositionNameTextEdit.EditValue));
            emp.Image = ImageByArray;
            employeeService.createEmployee(emp);

            XtraMessageBox.Show("Thêm thành công !!!");
            this.Close();

            

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

     
    }
}