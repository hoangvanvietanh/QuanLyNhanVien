using QuanLyDaiHocGiaDinh.IDao;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.DaoImpl
{
    class SchedulePositionDaoImpl : ISchedulePosition
    {
        private LinQDataContext db;

        public void AddScheduleForPostion(SchedulePosition schedulePosition)
        {
            db = new LinQDataContext();
            SchedulePosition schedule = new SchedulePosition();
            schedule = schedulePosition;
            db.SchedulePositions.InsertOnSubmit(schedule);
            db.SubmitChanges();
        }

        public void DeleteSchedulePostion(SchedulePosition schedule)
        {
            db = new LinQDataContext();
            SchedulePosition sch = new SchedulePosition();
            sch = db.SchedulePositions.FirstOrDefault(x => x.idSchedule == schedule.idSchedule && x.idPosition == schedule.idPosition);
            if (sch != null)
            {
                db.SchedulePositions.DeleteOnSubmit(sch);
                db.SubmitChanges();
            }
        }
    }
}
