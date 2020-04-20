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
        IDepartment department = new DepartmentDaoImpl();

        public Department getDepartmentById(int id)
        {
            return department.getDepartmentById(id);
        }
    }
}
