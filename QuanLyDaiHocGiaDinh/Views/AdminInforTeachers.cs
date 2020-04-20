﻿using System;
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
    public partial class AdminInforTeachers : DevExpress.XtraEditors.XtraForm
    {
        String strFilePath = "";
        Byte[] ImageByArray;
        private Employee _employee;
        private EmployeeService employeeService = new EmployeeService();
        public AdminInforTeachers(Employee employee)
        {
            InitializeComponent();
            this._employee = employee;
            // This line of code is generated by Data Source Configuration Wizard
            dataLayoutControl1.DataSource = new QuanLyDaiHocGiaDinh.Model.LinQDataContext().Accounts;
        }

        private void AdminCreateTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'giaDinhUniversityDataSet.p_selectAllEmployee' table. You can move, or remove it, as needed.
            this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);

        }

        public void showInfoAdmin()
        {
            Employee emp = new Employee();
            emp = _employee;
            FullNameTextEdit.Text = emp.FullName;
            FirstNameTextEdit.Text = emp.FirstName;
            LastNameTextEdit.Text = emp.LastName;
            BirthDateDateEdit.Text = emp.BirthDate.ToString();
            AddressTextEdit.Text = emp.Address;
            WardTextEdit.Text = emp.Ward;
            DistrictTextEdit.Text = emp.District;
            CityTextEdit.Text = emp.City;
            PhoneNumberTextEdit.Text = emp.PhoneNumber;
            EmailTextEdit.Text = emp.Email;
            StatusTextEdit.Text = emp.Status;
            HireDateDateEdit.Text = emp.HireDate.ToString();
            PositionNameTextEdit.Text = String.Format("{0}", emp.PositionId);
            byte[] Arraybyte = (byte[])emp.Image.ToArray();
            if (Arraybyte.Length == 0)
            {
                ImagePictureEdit.Image = null;
            }
            else
            {
                ImagePictureEdit.Image = Image.FromStream(new MemoryStream(Arraybyte));
            }
        }

        private void ImagePictureEdit_Click(object sender, EventArgs e)
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
    }
}