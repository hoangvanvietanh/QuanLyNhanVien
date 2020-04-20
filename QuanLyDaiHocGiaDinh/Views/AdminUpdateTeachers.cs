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
using QuanLyDaiHocGiaDinh.Services;
using System.IO;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminUpdateTeachers : DevExpress.XtraEditors.XtraForm
    {
        String strFilePath = "";
        Byte[] ImageByArray;
        private Employee _employee = new Employee();
        private EmployeeService employeeService = new EmployeeService();
        private AccountServices accountServices = new AccountServices();
        public AdminUpdateTeachers(Employee employee)
        {
            
            this._employee = employee ;
            InitializeComponent();
        }

        private void AdminUpdateTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);

            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);        
           
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.giaDinhUniversityDataSet.Position);

            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.


        }

        public void updateTeacher(String fullName, String firstName, String lastName, String birthDate, String address, String ward, String district, String city, String phoneNumber, String email, String status, String hireDate, String positionName, String deparmentName, byte[] ImageArray)
        {
            FullNameTextEdit.Text = fullName;
            FirstNameTextEdit.Text = firstName;
            LastNameTextEdit.Text = lastName;
            BirthDateDateEdit.Text = birthDate;
            AddressTextEdit.Text = address;
            WardTextEdit.Text = ward;
            DistrictTextEdit.Text = district;
            CityTextEdit.Text = city;
            PhoneNumberTextEdit.Text = phoneNumber;
            EmailTextEdit.Text = email;
            StatusTextEdit.Text = status;
            HireDateDateEdit.Text = hireDate;
            PositionNameTextEdit.EditValue = positionName;
            DepartmentNameComboBoxEdit.Text = deparmentName;
            
            if (ImageArray.Length == 0)
            {
                ImagePictureEdit.Image = null;
            }
            else
            {
                ImageByArray = ImageArray;
                ImagePictureEdit.Image = Image.FromStream(new MemoryStream(ImageArray));
            }
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

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Employee emp = new Employee();
            emp = _employee;
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

          
           // emp.Account.Role = RoleComboBoxEdit.Text;
            //emp.Position.DepartmentId = Int32.Parse(String.Format("{1}", DepartmentNameComboBoxEdit.EditValue));
            emp.Image = ImageByArray;    
            employeeService.updateEmployee(emp);
            XtraMessageBox.Show("Sửa thành công !!!");
            this.Close();

        }

        
    }
}