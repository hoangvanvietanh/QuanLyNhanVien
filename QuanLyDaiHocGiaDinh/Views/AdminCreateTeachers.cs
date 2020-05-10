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
using System.Drawing.Imaging;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Win;
using DevExpress.XtraSplashScreen;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class AdminCreateTeachers : DevExpress.XtraEditors.XtraForm
    {
        private AccountServices accountServices = new AccountServices();
        private EmployeeService employeeService = new EmployeeService();
        private PositionServices positionServices = new PositionServices();
        private DepartmentServices departmentServices = new DepartmentServices();

       

        String strFilePath = "";
        Byte[] ImageByArray;
        public AdminCreateTeachers()
        {
            InitializeComponent();
            HireDateDateEdit.DateTime = DateTime.Now;
            PositionNameTextEdit.Properties.SelectAllItemVisible = false;
            PositionNameTextEdit.LookAndFeel.StyleChanged += LookAndFeel_StyleChanged;
        }

        void LookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            subscribe = true;
        }

        private void AdminCreateTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.giaDinhUniversityDataSet.Departments);
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.Position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.giaDinhUniversityDataSet.Position);
          
           
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Chờ tí nhé.....");

            Account acc = new Account();
            acc.UserName = EmailTextEdit.Text.Trim();
            acc.Password = EmailTextEdit.Text.Trim();
            acc.Role = RoleTextEdit.SelectedItem.ToString();

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
            SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Thêm thành công !!!");
            this.Close();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ImagePictureEdit_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)  /// click chuột chọn ảnh từ OpenFileDialog
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
                            ImagePictureEdit.EditValue = stream.ToArray();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
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

        private void FirstNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
             FullNameTextEdit.Text = LastNameTextEdit.Text + FirstNameTextEdit.Text;
        }

        private void LastNameTextEdit_EditValueChanged(object sender, EventArgs e)
        { 
            FullNameTextEdit.Text = LastNameTextEdit.Text + FirstNameTextEdit.Text;
        }
    }
}