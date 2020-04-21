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

        //Thêm phòng ban
        public Department CreateDepartment(Department department)
        {
            db = new LinQDataContext();
            Department dep = new Department();
            dep = department;
            db.Departments.InsertOnSubmit(dep);
            db.SubmitChanges();
            return dep;
        }

        //Xóa phòng ban
        public void DeleteDepartment(int departmentId)
        {
            db = new LinQDataContext();
            Department dep = new Department();
            dep = db.Departments.Single(x => x.DepartmentId == departmentId);
            db.Departments.DeleteOnSubmit(dep);
            db.SubmitChanges();
        }

        //Cập nhật phòng ban
        public void UpdateDepartment(Department department)
        {
            db = new LinQDataContext();
            Department dep = new Department();
            dep = db.Departments.Single(x => x.DepartmentId == department.DepartmentId);
            setDepartmentUpdate(dep, department);
            db.SubmitChanges();
        }

        public Department setDepartmentUpdate(Department departmentDB, Department departmentUpdate)
        {
            departmentDB.DepartmentName = departmentUpdate.DepartmentName;
            return departmentUpdate;
        }
    }
}
