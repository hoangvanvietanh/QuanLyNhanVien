using QuanLyDaiHocGiaDinh.ConnectWithNodejs.DaoImpl;
using QuanLyDaiHocGiaDinh.ConnectWithNodejs.IDao;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.ConnectWithNodejs.Services
{
    class NodeJSServices
    {
        INodeJS nodeJSDao = new NodeJSDaoImpl();

        public void addEmployeeToNodejs(Employee emlployee)
        {
            nodeJSDao.addEmployee(emlployee);
        }
    }
}
