using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POLuokat;

namespace POData.Repositories
{
    public class OrdersRepository
    {
        private DataContext _dc;
        public OrdersRepository()
        {
            _dc = new DataContext();
        }

        //metodit

        public Orders Hae(int id)
        {
            return _dc.Tilaukset.Where(t => t.OrderID == id).SingleOrDefault();
        }
        public List<Orders> HaeKaikki()
        {
            var paluu = _dc.Tilaukset.ToList();
            return paluu;
        }
    }
}
