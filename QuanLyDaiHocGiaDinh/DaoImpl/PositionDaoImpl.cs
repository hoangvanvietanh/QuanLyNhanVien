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
    }
}
