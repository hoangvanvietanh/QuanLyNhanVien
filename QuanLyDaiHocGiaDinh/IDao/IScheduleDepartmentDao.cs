using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.IDao
{
    interface IScheduleDepartment
    {
        void AddScheduleForDepartment(ScheduleDepartment scheduleDepartment);
        int getLastIdUniqueSchedule();
        void deleteSchdeduleDepartment(ScheduleDepartment scheduleDepartment);
    }
}
