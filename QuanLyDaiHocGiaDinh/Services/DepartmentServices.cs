using QuanLyDaiHocGiaDinh.DaoImpl;
using QuanLyDaiHocGiaDinh.IDao;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.Services
{
    class DepartmentServices
    {
        IDepartment dep = new DepartmentDaoImpl();

        public Department getDepartmentById(int id)
        {
            return dep.getDepartmentById(id);
           
        }

        //Thêm phòng ban
        public Department createDepartment(Department department)
        {
            return dep.CreateDepartment(department);
        }

        //Cập nhật phòng ban
        public void updateDepartment(Department department)
        {
            dep.UpdateDepartment(department);
        }

        //Xóa phòng ban
        public void deleteDepartment(int department)
        {
            dep.DeleteDepartment(department);
        }
    }
}
