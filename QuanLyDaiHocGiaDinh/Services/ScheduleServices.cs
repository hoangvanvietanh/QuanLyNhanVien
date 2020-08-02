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
        ISchedulePosition schedulePositionDao = new SchedulePositionDaoImpl();
        ISchedule scheduleDao = new ScheduleDaoImpl();


        public Schedule getLastSchedule(Account account)
        {
            return scheduleDao.getLastSchedule(account);
        }
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

        public void createSchedulePosition(SchedulePosition schedulePosition)
        {
            schedulePositionDao.AddScheduleForPostion(schedulePosition);
        }

        public void deleteSchedulePosition(SchedulePosition schedulePosition)
        {
            schedulePositionDao.DeleteSchedulePostion(schedulePosition);
        }
    }
}
