using QuanLyDaiHocGiaDinh.Dao;
using QuanLyDaiHocGiaDinh.Interface;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Services
{
    class EmployeeService 
    {
        IEmployee employeeDao = new EmployeeDaoImpl();
        private Account _account;

        public EmployeeService(Account account)
        {
            this._account = account;
        }

        //Lấy employee bằng accountID
        public Employee getEmployeeByAccountId(int accountId)
        {
            return employeeDao.getEmployeeByAccountId(accountId);
        }

        //Tự động lấy Id user hiện tại đang đăng nhập
        public Employee getEmployeeByAccountId()
        {
            return employeeDao.getEmployeeByAccountId(_account.AccountId);
        }

        public List<Employee> getAllEmployees()
        {
            return employeeDao.getAllEmployees();
        }

        //Cập nhật thông tin nhân viên
        public void updateEmployee(Employee employee)
        {
            employeeDao.UpdateEmployee(employee);
        }

        //Tạo nhân viên mới
        public void createEmployee(Employee employee)
        {
            employeeDao.CreateEmployee(employee);
        }

        //Xóa nhân viên
        public void deleteEmployee(Employee employee)
        {
            employeeDao.DeleteEmployee(employee);
        }
    }
}
