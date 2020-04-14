using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Interface
{
    interface IEmployee
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        Employee getEmployeeByAccountId(int accountId);
        List<Employee> getEmployeesByPosition(int positionId);
        List<Employee> getEmployeesByDepartment(int departmentId);
        List<Employee> getAllEmployees();
    }
}
