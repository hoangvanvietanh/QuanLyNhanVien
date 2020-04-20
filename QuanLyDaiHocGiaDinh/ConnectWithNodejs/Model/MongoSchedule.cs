using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.ConnectWithNodejs.Model
{
    class MongoSchedule
    {
        public int id;
        public int year;
        public int month;
        public int day_of_month;
        public int hour;
        public int minute;
        public int duration;
        public int color;
        public bool isAllDay;
        public bool isCanceled;
        public string status;
        public string content;

        public MongoSchedule()
        {

        }

        public MongoSchedule(int id, int year, int month, int day_of_month, int hour, int minute, int duration, int color, bool isAllDay, bool isCanceled, string status, string content)
        {
            this.id = id;
            this.year = year;
            this.month = month;
            this.day_of_month = day_of_month;
            this.hour = hour;
            this.minute = minute;
            this.duration = duration;
            this.color = color;
            this.isAllDay = isAllDay;
            this.isCanceled = isCanceled;
            this.status = status;
            this.content = content;
        }
    }
}
