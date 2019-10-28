using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POLuokat;

namespace POData.Repositories
{
    public class OrderDetailsRepository
    {
        private DataContext _dc;
        public OrderDetailsRepository()
        {
            _dc = new DataContext();
        }

        //metodit

        public OrderDetails Hae(int id)
        {
            return _dc.Tilausrivit.Where(t => t.OrderID == id).SingleOrDefault();
        }
        public List<OrderDetails> HaeKaikki()
        {
            var paluu = _dc.Tilausrivit.ToList();
            return paluu;
        }
        
    }
}
