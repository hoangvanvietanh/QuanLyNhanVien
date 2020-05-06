using QuanLyDaiHocGiaDinh.IDao;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.DaoImpl
{
    class ScheduleDepartmentDaoImpl : IScheduleDepartment
    {
        private LinQDataContext db;

        public void AddScheduleForDepartment(ScheduleDepartment scheduleDepartment)
        {
            db = new LinQDataContext();
            ScheduleDepartment schedule = new ScheduleDepartment();
            schedule = scheduleDepartment;
            db.ScheduleDepartments.InsertOnSubmit(schedule);
            db.SubmitChanges();
        }

        public void deleteSchdeduleDepartment(ScheduleDepartment scheduleDepartment)
        {
            db = new LinQDataContext();
            ScheduleDepartment sch = new ScheduleDepartment(); 
            sch = db.ScheduleDepartments.FirstOrDefault(x => x.idSchedule == scheduleDepartment.idSchedule && x.idDepartment == scheduleDepartment.idDepartment);
            if (sch != null)
            {
                db.ScheduleDepartments.DeleteOnSubmit(sch);
                db.SubmitChanges();
            }
        }

        public int getLastIdUniqueSchedule()
        {
            int id = 0;
            db = new LinQDataContext();
            var list = db.getLastIdUniqueSchedule().ToList();
            
            list.ForEach(x =>
            {
                id = x.UniqueID;
            });
            return id;
        }
    }
}
