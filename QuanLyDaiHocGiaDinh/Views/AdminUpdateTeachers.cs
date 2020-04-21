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
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Win;
using DevExpress.XtraTab;
using DevExpress.Utils.Text;
using DevExpress.Utils;
using DevExpress.Skins;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Internal;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Menu;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraBars.Ribbon;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminUpdateTeachers : DevExpress.XtraEditors.XtraForm
    {
        String strFilePath = "";
        Byte[] ImageByArray;
        private Employee _employee;
        private Position _position;
        private Department _deparment;
        private Account _account;
        private EmployeeService employeeService = new EmployeeService();
        private AccountServices accountServices = new AccountServices();
        private PositionServices positionServices = new PositionServices();
        private DepartmentServices departmentServices = new DepartmentServices();
        public AdminUpdateTeachers(Employee employee)
        {
            InitializeComponent();
            
            this._employee = employee ;
            this._position =  positionServices.getPositionById((int)_employee.PositionId);
            this._deparment = departmentServices.getDepartmentById((int)_position.DepartmentId);
            this._account = accountServices.getAccountById((int)_employee.AccountId);
            PositionNameDepartmentNameCheckComboBoxEdit.Properties.SelectAllItemVisible = false;
            PositionNameDepartmentNameCheckComboBoxEdit.LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
        }
        void LookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            subscribe = true;
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
            DepartmentNameCheckComboBoxEdit.Text = deparmentName;
            PositionNameDepartmentNameCheckComboBoxEdit.Text = positionName;
            if(_account.Role.Trim() == "manage")
            {
                RoleComboBoxEdit.EditValue = "manage";
            }
            else
            {
                RoleComboBoxEdit.EditValue = "employee";
            }
            
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

            //DevExpress.XtraEditors.Camera.TakePictureDialog dialog = new DevExpress.XtraEditors.Camera.TakePictureDialog();
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    System.Drawing.Image image = dialog.Image;
            //    using (var stream = new MemoryStream())
            //    {
            //        image.Save(stream, ImageFormat.Jpeg);
            //        ImageByArray = stream.ToArray();
            //    }
            //}
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
            Position po = new Position();
            po = _position;
            po.PositionName = PositionNameDepartmentNameCheckComboBoxEdit.Text;
            Department dep = new Department();
            dep.DepartmentName = DepartmentNameCheckComboBoxEdit.Text;
            Account ac = new Account();
            ac = _account;
            ac.Role = RoleComboBoxEdit.SelectedItem.ToString();
            emp.Image = ImageByArray;    
            employeeService.updateEmployee(emp);
            accountServices.updateAccount(ac);
            
            XtraMessageBox.Show("Sửa thành công !!!");
            this.Close();

        }


        //Check single for toolbox CheckcomboboxEdit
        bool subscribe = true;
        private void PositionNameTextEdit_Popup(object sender, EventArgs e)
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