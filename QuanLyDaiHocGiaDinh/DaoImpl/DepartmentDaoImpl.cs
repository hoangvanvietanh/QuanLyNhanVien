using QuanLyDaiHocGiaDinh.IDao;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.DaoImpl
{
    class DepartmentDaoImpl : IDepartment
    {
        private LinQDataContext db;
        private List<Department> departments;

        public DepartmentDaoImpl()
        {
            db = new LinQDataContext();
            using (db)
            {
                var department = from x in db.Departments select x;
                departments = department.ToList();
            }
        }

        public Department getDepartmentById(int id)
        {
            Department department = new Department();
            departments.ForEach(de =>
            {
                if (de.DepartmentId == id)
                {
                    department = de;
                }
            });
            return department;
        }
    }
}
