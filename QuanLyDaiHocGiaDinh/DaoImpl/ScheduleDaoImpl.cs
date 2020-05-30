using QuanLyDaiHocGiaDinh.IDao;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.DaoImpl
{
    class ScheduleDaoImpl : ISchedule
    {
        private LinQDataContext db;
        public Schedule getLastSchedule()
        {
            Schedule schedule = new Schedule();
            db = new LinQDataContext();
            var list = db.getLastSchedule().ToList();

            list.ForEach(x =>
            {
                schedule.UniqueID = x.UniqueID;
                schedule.Type = x.Type;
                schedule.StartDate = x.StartDate;
                schedule.EndDate = x.EndDate;
                schedule.AllDay = x.AllDay;
                schedule.Subject = x.Subject;
                schedule.Location = x.Location;
                schedule.Description = x.Description;
                schedule.Status = x.Status;
                schedule.Label = x.Label;
                schedule.ApprovalStatus = x.ApprovalStatus;
                schedule.AccountId = x.AccountId;
                schedule.DepartmentsList = x.DepartmentsList;
                schedule.PositionList = x.PositionList;
            });
            return schedule;
        }
    }
}
