using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.ConnectWithNodejs.IDao
{
    interface INodeJS
    {
        void addEmployee(Employee employee);
    }
}
