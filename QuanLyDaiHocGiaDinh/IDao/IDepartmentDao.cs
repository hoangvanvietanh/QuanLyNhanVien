using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.IDao
{
    interface IDepartment
    {
        Department getDepartmentById(int id);
        Department CreateDepartment(Department department);
        void DeleteDepartment(int department);
        void UpdateDepartment(Department department);
    }
}
