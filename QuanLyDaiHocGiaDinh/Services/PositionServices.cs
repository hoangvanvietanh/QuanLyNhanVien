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

    class PositionServices
    {
        IPosition pos = new PositionDaoImpl();
        DepartmentServices department = new DepartmentServices();

        public Position getPositionById(int id)
        {
            return pos.getPositionById(id);
        }

        public Department getDepartmentByIdPosition(int id)
        {
            return department.getDepartmentById(getPositionById(id).DepartmentId);
        }

        //Thêm chức vụ
        public Position createPosition(Position position)
        {
            return pos.CreatePosition(position);
        }

        //Cập nhật chức vụ
        public void updatePosition(Position position)
        {
            pos.UpdatePosition(position);
        }

        //Xóa chức vụ
        public void deletePosition(int position)
        {
            pos.DeletePosition(position);
        }
    }
}
