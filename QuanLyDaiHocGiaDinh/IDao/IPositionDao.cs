using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.IDao
{
    interface IPosition
    {
        Position getPositionById(int id);
        Position CreatePosition(Position position);
        void DeletePosition(int position);
        void UpdatePosition(Position position);
    }
}
