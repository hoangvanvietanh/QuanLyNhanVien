using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.ConnectWithNodejs.Model
{
    class MongoEmployee
    {
        public string EmployeeId;
        public string FullName;
        public string Email;
        public string Address;
        public string PhoneNumber;
        public string PositionName;
        public string DepartmentName;
        public string Image;
        public string BirthDate;
        public List<MongoSchedule> Schedules;
        public MongoAccount Account;

        public MongoEmployee()
        {

        }
        public MongoEmployee(string EmployeeId, string FullName, string Email, string Address, string PhoneNumber, string PositionName, string DepartmentName, string Image, string BirthDate, MongoAccount accounts, List<MongoSchedule> schedules)
        {
            this.EmployeeId = EmployeeId;
            this.FullName = FullName;
            this.Email = Email;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.PositionName = PositionName;
            this.DepartmentName = DepartmentName;
            this.Image = Image;
            this.BirthDate = BirthDate;
            this.Schedules = schedules;
            this.Account = accounts;
        }
    }
}
