using QuanLyDaiHocGiaDinh.IDao;
using QuanLyDaiHocGiaDinh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDaiHocGiaDinh.DaoImpl
{
    class PositionDaoImpl : IPosition
    {

        private LinQDataContext db;
        private List<Position> positions;

        public PositionDaoImpl()
        {
            db = new LinQDataContext();
            using (db)
            {
                var position = from x in db.Positions select x;
                positions = position.ToList();
            }
        }

        public Position getPositionById(int id)
        {
            Position position = new Position();
            positions.ForEach(po =>
            {
                if (po.PositionId == id)
                {
                    position = po;
                }
            });
            return position;
        }

        //Thêm chức vụ
        public Position CreatePosition(Position position)
        {
            db = new LinQDataContext();
            Position po = new Position();
            po = position;
            db.Positions.InsertOnSubmit(po);
            db.SubmitChanges();
            return po;
        }

        //Xóa chức vụ
        public void DeletePosition(int positionId)
        {
            db = new LinQDataContext();
            Position po = new Position();
            po = db.Positions.Single(x => x.PositionId == positionId);
            db.Positions.DeleteOnSubmit(po);
            db.SubmitChanges();
        }

        //Cập nhật chức vụ
        public void UpdatePosition(Position position)
        {
            db = new LinQDataContext();
            Position po = new Position();
            po = db.Positions.Single(x => x.PositionId == position.PositionId);
            setPositionUpdate(po, position);
            db.SubmitChanges();
        }

        public Position setPositionUpdate(Position positionDB, Position positionUpdate)
        {
            positionDB.PositionName = positionUpdate.PositionName;
            return positionUpdate;
        }
    }
}
