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
    class ScheduleServices
    {
        IScheduleDepartment scheduleDepartmentDao = new ScheduleDepartmentDaoImpl();

        public void createScheduleForDepartment(ScheduleDepartment schedule)
        {
            scheduleDepartmentDao.AddScheduleForDepartment(schedule);
        }

        public int getLastScheduleId()
        {
            return scheduleDepartmentDao.getLastIdUniqueSchedule();
        }

        public void deleteScheduleDepartment(ScheduleDepartment scheduleDepartment)
        {
            scheduleDepartmentDao.deleteSchdeduleDepartment(scheduleDepartment);
        }
    }
}
