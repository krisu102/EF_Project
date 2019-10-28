using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLuokat
{
    public class Products
    {
        public int ProductID { get; private set; }
        public string ProductName { get; set; }
        public int? SuplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public virtual List<OrderDetails> Tilausrivit { get; set; }

        public Products()
        {
            Tilausrivit = new List<OrderDetails>();
        }
        public override string ToString() => $"{ProductID} {ProductName}";
    }
}
