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
using DevExpress.XtraScheduler;
using QuanLyDaiHocGiaDinh.Services;
using QuanLyDaiHocGiaDinh.Controller;
using QuanLyDaiHocGiaDinh.Model;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;

namespace QuanLyDaiHocGiaDinh.Views
{
    public partial class UserHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account _account;
        private EmployeeService employeeService;
        private Position _position = new Position();
        private PositionServices positionServices = new PositionServices();
        private Department _department = new Department();
        private DepartmentServices departmentServices = new DepartmentServices();
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        UserCredential credential;
        CalendarService service;
        bool allowEventLoad;
        CalendarList calendarList;
        string activeCalendarId;

        public UserHome(Account account)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            this._account = account;
            employeeService = new EmployeeService(account);
            Employee employee = new Employee();

            employee = employeeService.getEmployeeByAccountId(_account.AccountId); //lấy employee đang đăng nhập
            showEmployee(employee);

            _position = positionServices.getPositionById((int)employee.PositionId);
            ShowPosition(_position);

            _department = departmentServices.getDepartmentById((int)_position.DepartmentId);
            ShowDepartment(_department);

            setVisibleScheduleRibbonPage(false);
            //  this.p_selectAllEmployeeTableAdapter.Fill(this.giaDinhUniversityDataSet.p_selectAllEmployee);
            this.scheduleTableAdapter.Fill(this.giaDinhUniversityDataSet.Schedule, this._account.AccountId, _department.DepartmentId, _position.PositionId);

            //Ví dụ để lấy employee đang đăng nhập

            // employee.FullName = "Duy Hieu";
            // employee.FirstName = "Việt Nè";
            //employeeService.updateEmployee(employee);//ví dụ về cập nhật 
            //   MessageBox.Show(employee.Position.PositionName);
            //Position position = new Position();   ///show PositionName
            // position = employeeService.getEmployeeByAccountId();
            //ShowPosition(position);

            Console.WriteLine(employeeService.getEmployeeByAccountId().FullName);
            ////////////
            //   dataLayoutControl1.DataSource = new QuanLyDaiHocGiaDinh.Model.LinQDataContext().Accounts;
        }

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
            if (navigationFrame.SelectedPageIndex == 0)
            {
                setVisibleScheduleRibbonPage(false);
                setVisibleHomeRibbonPage(true);
            }
            else if (navigationFrame.SelectedPageIndex == 1)
            {
                setVisibleScheduleRibbonPage(true);
                setVisibleHomeRibbonPage(false);
            }
        }
        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void schedulerDataStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            try
            {
                Console.WriteLine("----------------------------------------------------->");
                scheduleTableAdapter.Update(giaDinhUniversityDataSet);
                giaDinhUniversityDataSet.AcceptChanges();
            }
            catch
            {
                
            }
           
        }

        private void schedulerControl_InitNewAppointment(object sender, AppointmentEventArgs e)
        {
            e.Appointment.CustomFields["AccountId"] = this._account.AccountId;
        }

        private void setVisibleScheduleRibbonPage(bool status)
        {
            fileScheduleRibbonPage.Visible = status;
            homeScheduleRibbonPage.Visible = status;
            viewScheduleRibbonPage.Visible = status;
        }

        private void setVisibleHomeRibbonPage(bool status)
        {
            homeRibbonPage.Visible = status;
        }



        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserHomeUpdate userHomeUpdate = new UserHomeUpdate(_account);
            userHomeUpdate.ShowDialog();
            this.Close();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserHomeChangePassword userHomeChangePassword = new UserHomeChangePassword(_account);
            userHomeChangePassword.ShowDialog();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        public void showEmployee(Employee employee)
        {
            FullNameTextEdit.Text = employee.FullName;
            lblEmloyee.Text = employee.FullName;
            AddressTextEdit.Text = employee.Address;
            CityTextEdit.Text = employee.City;
            DistrictTextEdit.Text = employee.District;
            EmailTextEdit.Text = employee.Email;
            FirstNameTextEdit.Text = employee.FirstName;
            HireDateDateEdit.Text = employee.HireDate.ToString();
            LastNameTextEdit.Text = employee.LastName;
            PhoneNumberTextEdit.Text = employee.PhoneNumber;
            StatusTextEdit.Text = employee.Status;
            BirthDateDateEdit.Text = employee.BirthDate.ToString();
            lblEmployeeId.Text = employee.EmployeeId.ToString();
            WardTextEdit.Text = employee.Ward;

            //  lblPositition.Text = employee.Position.PositionName;
            //    picEmployee.Image = employee.Image;
            //  byte[] ImageArray = (byte[]);
            // picEmployee.Image = (byte[]) employee.Image.ToArray();
            //  picEmployee.Image= Image.FromStream(new MemoryStream((byte[])employee.Image.ToArray()));


            byte[] Arraybyte = (byte[])employee.Image.ToArray();// load picture từ database
            MemoryStream memoryStream = new MemoryStream(Arraybyte);
            picEmployee.Image = Image.FromStream(memoryStream);

        }
        public void ShowPosition(Position position)
        {
            lblPositition.Text = position.PositionName;
        }
        public void ShowDepartment(Department department)
        {
            lblPhongBan.Text = department.DepartmentName;
        }

        private void btnSynCalendar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        #region Authorization
        async protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                this.credential = await AuthorizeToGoogle();
                this.service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = this.credential,
                    ApplicationName = "GoogleCalendarSyncSample"
                });
                this.dxGoogleCalendarSync.CalendarService = this.service;
                this.allowEventLoad = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            await UpdateCalendarListUI();
            this.allowEventLoad = true;
            UpdateBbiAvailability();
            ricbCalendarList.SelectedIndexChanged += RicbCalendarList_SelectedIndexChanged;
            bbiSynchronize.ItemClick += BbiSynchronize_ItemClick;
        }

        async Task<UserCredential> AuthorizeToGoogle()
        {
            using (FileStream stream = new FileStream("../../Config/credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/GoogleSchedulerSync.json");
                return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new String[] { CalendarService.Scope.Calendar },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }
        }
        #endregion


        async Task UpdateCalendarListUI()
        {
            CalendarListResource.ListRequest listRequest = this.service.CalendarList.List();
            this.calendarList = await listRequest.ExecuteAsync();
            this.ricbCalendarList.Items.Clear();
            foreach (CalendarListEntry item in this.calendarList.Items)
                this.ricbCalendarList.Items.Add(item.Summary);
            if (!String.IsNullOrEmpty(this.activeCalendarId))
            {
                CalendarListEntry itemToSelect = this.calendarList.Items.FirstOrDefault(x => x.Id == this.activeCalendarId);
                this.dxGoogleCalendarSync.CalendarId = this.activeCalendarId;
                if (this.ricbCalendarList.Items.Contains(itemToSelect.Summary))
                {
                    this.beiCalendarList.EditValue = itemToSelect.Summary;
                }
                else
                    this.activeCalendarId = String.Empty;
            }
            UpdateBbiAvailability();
        }

        void UpdateBbiAvailability()
        {
            this.bbiSynchronize.Enabled = !String.IsNullOrEmpty(this.activeCalendarId) && this.allowEventLoad;
        }

        private void RicbCalendarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit edit = (ComboBoxEdit)sender;
            string selectedCalendarSummary = (string)edit.SelectedItem;
            CalendarListEntry selectedCalendar = this.calendarList.Items.FirstOrDefault(x => x.Summary == selectedCalendarSummary);
            this.activeCalendarId = selectedCalendar.Id;
            this.dxGoogleCalendarSync.CalendarId = selectedCalendar.Id;
            UpdateBbiAvailability();
        }

        private void BbiSynchronize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.dxGoogleCalendarSync.Synchronize();
        }

    }
}
