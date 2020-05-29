using QuanLyDaiHocGiaDinh.ConnectWithNodejs.IDao;
using QuanLyDaiHocGiaDinh.ConnectWithNodejs.Model;
using QuanLyDaiHocGiaDinh.Model;
using QuanLyDaiHocGiaDinh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace QuanLyDaiHocGiaDinh.ConnectWithNodejs.DaoImpl
{
    class NodeJSDaoImpl : INodeJS
    {
        private AccountServices accountServices = new AccountServices();
        private PositionServices positionServices = new PositionServices();


        public void addEmployee(Employee emp)
        {   
            //Console.WriteLine("------------------------>" + emp.Account.UserName);
            var json = new JavaScriptSerializer().Serialize(setAddEmployee(emp)).ToString();
            //create the constructor with post type and few data
            MyWebRequest myRequest = new MyWebRequest("https://thongbaogdu-server.herokuapp.com/Ma_so_Xu_ly=Them_nhan_vien_moi_mssql", "POST", json.ToString());
            //show the response string on the console screen.
            Console.WriteLine(myRequest.GetResponse());
        }

        public MongoEmployee setAddEmployee(Employee x)
        {
            
            String department = positionServices.getDepartmentByIdPosition((int)x.PositionId).DepartmentName;
            String position = positionServices.getPositionById((int)x.PositionId).PositionName;
            DateTime dateTime = (DateTime)x.BirthDate;
            String birthdate = dateTime.Day + "/" + dateTime.Month + "/" + dateTime.Year;


            List<MongoSchedule> schedulesList = new List<MongoSchedule>();
            MongoAccount acc = new MongoAccount(x.AccountId.ToString(), x.Email, x.Email, "employee");
            Console.WriteLine( "------------------------>"+acc.UserName);
            MongoEmployee emp = new MongoEmployee(x.EmployeeId.ToString(), x.FullName, x.Email, x.Address, x.PhoneNumber, position, department, "Hình nè", birthdate, acc, schedulesList);
            
            return emp;
        }
    }
}
