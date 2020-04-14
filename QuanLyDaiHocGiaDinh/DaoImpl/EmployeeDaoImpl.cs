using QuanLyDaiHocGiaDinh.Interface;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Dao
{
    class EmployeeDaoImpl : IEmployee
    {
        private LinQDataContext db ;
        private List<Employee> employees;

        //Lấy databse từ cơ sở dữ liệu
        public EmployeeDaoImpl()
        {
            db = new LinQDataContext();
            using (db)
            {
                var employee = from x in db.Employees select x;
                employees = employee.ToList();
            }
        }

        //Tạo nhân viên mới
        public void CreateEmployee(Employee employee)
        {
            db = new LinQDataContext();
            Employee emp = new Employee();
            emp = employee;
            db.Employees.InsertOnSubmit(emp);
            db.SubmitChanges();
        }

        //Xóa nhân viên
        public void DeleteEmployee(Employee employee)
        {
            db = new LinQDataContext();
            Employee emp = new Employee();
            emp = db.Employees.Single(x => x.EmployeeId == employee.EmployeeId);
            db.Employees.DeleteOnSubmit(emp);
            db.SubmitChanges();
        }

        //Cập nhật nhân viên
        public void UpdateEmployee(Employee employee)
        {
            db = new LinQDataContext();
            Employee emp = new Employee();
            emp = db.Employees.Single(x => x.EmployeeId == employee.EmployeeId);
            setEmployeeUpdate(emp, employee);
            db.SubmitChanges();
        }

        //Lấy tất cả nhân viên
        public List<Employee> getAllEmployees()
        {
            return employees;
        }

        //Lấy nhân viên theo accountId
        public Employee getEmployeeByAccountId(int accountId)
        {
            Employee employee = new Employee();
            employees.ForEach(emp =>
            {
                if (emp.AccountId == accountId)
                {
                    employee = emp;
                }
            });

            return employee;
        }

        //Lấy list nhân viên theo phòng ban
        public List<Employee> getEmployeesByDepartment(int departmentId)
        {
            List<Employee> employeesList = new List<Employee>();
            employees.ForEach(emp =>
            {
                if (emp.Position.DepartmentId == departmentId)
                {
                    employeesList.Add(emp);
                }
            });

            return employeesList;
        }

        //Lấy list nhân viên theo chức vụ
        public List<Employee> getEmployeesByPosition(int positionId)
        {
            List<Employee> employeesList = new List<Employee>();
            employees.ForEach(emp =>
            {
                if (emp.PositionId == positionId)
                {
                    employeesList.Add(emp);
                }
            });

            return employeesList;
        }

        //Ánh xạ nhân viên update qua nhân viên trên linq để update
        public Employee setEmployeeUpdate(Employee employeeDB,Employee employeeUpdate)
        {
            employeeDB.FirstName = employeeUpdate.FirstName;
            employeeDB.LastName = employeeUpdate.LastName;
            employeeDB.FullName = employeeUpdate.FullName;
            employeeDB.BirthDate = employeeUpdate.BirthDate;
            employeeDB.Address = employeeUpdate.Address;
            employeeDB.Ward = employeeUpdate.Ward;
            employeeDB.District = employeeUpdate.District;
            employeeDB.City = employeeUpdate.City;
            employeeDB.PhoneNumber = employeeUpdate.PhoneNumber;
            employeeDB.Status = employeeUpdate.Status;
            employeeDB.PositionId = employeeUpdate.PositionId;
            employeeDB.Email = employeeUpdate.Email;
            employeeDB.Image = employeeUpdate.Image;

            return employeeDB;
        }
    }
}
