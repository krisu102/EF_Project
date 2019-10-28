using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POLuokat;

namespace POData.Repositories
{
    public class ProductsRepository
    {
        private DataContext _dc;
        public ProductsRepository()
        {
            _dc = new DataContext();
        }

        //metodit

        public Products Hae(int id)
        {
            return _dc.Tuotteet.Where(t => t.ProductID == id).SingleOrDefault();
        }
        public List<Products> HaeKaikki()
        {
            var paluu = _dc.Tuotteet.ToList();
            return paluu;
        }
    }
}
