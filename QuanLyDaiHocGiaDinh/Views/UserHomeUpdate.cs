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
using System.IO;
using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Services;
using DevExpress.XtraEditors.Camera;
using System.Drawing.Imaging;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class UserHomeUpdate : DevExpress.XtraEditors.XtraForm
    {
        private Account _account;
        private AccountServices accountServices = new AccountServices();
        private EmployeeService employeeService = new EmployeeService();
        String strFilePath = "";
        Byte[] ImageByArray;
        public UserHomeUpdate(Account account)
        {
           
            InitializeComponent();
          
            this._account = account;
            employeeService = new EmployeeService(account);
            Employee employee = new Employee();
            employee = employeeService.getEmployeeByAccountId(); 
            showEmployeeUpdate(employee);
        }

        private void UserHomeUpdate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Employees' table. You can move, or remove it, as needed.
          //  this.employeesTableAdapter.Fill(this.giaDinhUniversityDataSet.Employees,this._account.AccountId);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Employees' table. You can move, or remove it, as needed.
            //this.employeesTableAdapter.Fill(this.giaDinhUniversityDataSet.Employees);

        }

         // Picture từ camera !!!
       // private void showCamera()
          //  {
            //DevExpress.XtraEditors.Camera.TakePictureDialog dialog = new DevExpress.XtraEditors.Camera.TakePictureDialog();
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    System.Drawing.Image image = dialog.Image;
            //    using (var stream = new MemoryStream())
            //    {
            //        image.Save(stream, ImageFormat.Jpeg);
            //        ImageByArray = stream.ToArray();
            //        pictureEmployeeEdit.EditValue = stream.ToArray();
            //    }
            //}
     //   }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee = employeeService.getEmployeeByAccountId(_account.AccountId);
              
            employee.Address = AddressTextEdit.Text;
            employee.BirthDate = BirthDateDateEdit.DateTime;
            employee.City = CityTextEdit.Text;
            employee.District = DistrictTextEdit.Text;
            employee.Email = EmailTextEdit.Text;
            employee.FirstName =FirstNameTextEdit.Text;
            employee.FullName = FullNameTextEdit.Text;
            employee.LastName = LastNameTextEdit.Text;
            employee.PhoneNumber =PhoneNumberTextEdit.Text;
            employee.Status = StatusTextEdit.Text;
            employee.Ward = WardTextEdit.Text;

            employee.Image = ImageByArray;
          
            employeeService.updateEmployee(employee);

            XtraMessageBox.Show("Update successful");
            UserHome userHome = new UserHome(_account);
            userHome.ShowDialog();
            this.Close();
       
        }
        public void showEmployeeUpdate(Employee employee) ///show thông tin của employee
        {
            FullNameTextEdit.Text = employee.FullName;
            AddressTextEdit.Text = employee.Address;
            CityTextEdit.Text = employee.City;
            DistrictTextEdit.Text = employee.District;
            EmailTextEdit.Text = employee.Email;
            FirstNameTextEdit.Text = employee.FirstName;
            LastNameTextEdit.Text = employee.LastName;
            PhoneNumberTextEdit.Text = employee.PhoneNumber;
            StatusTextEdit.Text = employee.Status;
            BirthDateDateEdit.Text = employee.BirthDate.ToString();
            WardTextEdit.Text = employee.Ward;

              byte[] Arraybyte = (byte[])employee.Image.ToArray();// load picture từ database
              ImageByArray = Arraybyte;
               MemoryStream memoryStream = new MemoryStream(Arraybyte);
              pictureEmployeeEdit.Image = Image.FromStream(memoryStream);

          //  byte[] Arraybyte = (byte[])employee.Image.ToArray();// load picture từ database
        //    if (employee.Image.ToString().CompareTo("") == 0 || employee.Image.ToString() == null)
        //    {
       //         MemoryStream memoryStream = new MemoryStream(Arraybyte);
        //        pictureEmployeeEdit.Image = Image.FromStream(memoryStream);
        ///    }

        }  
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            UserHome userHome = new UserHome(_account);
            userHome.ShowDialog();
        }



        private void pictureEmployeeEdit_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  /// click chuột chọn ảnh từ OpenFileDialog
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    strFilePath = ofd.FileName;
                    pictureEmployeeEdit.Image = new Bitmap(strFilePath);
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
                        pictureEmployeeEdit.Image = new Bitmap(strFilePath);
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
            else
            {
                ///// Chọn ảnh từ Camera
                DevExpress.XtraEditors.Camera.TakePictureDialog dialog = new DevExpress.XtraEditors.Camera.TakePictureDialog();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.Drawing.Image image = dialog.Image;
                    using (var stream = new MemoryStream())
                    {
                        image.Save(stream, ImageFormat.Jpeg);
                        ImageByArray = stream.ToArray();
                        pictureEmployeeEdit.EditValue = stream.ToArray();
                    }
                }
            }    
        }
    }
}