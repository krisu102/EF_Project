using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using POLuokat;

namespace POData.Mappings
{
    class OrderDetailsMap : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsMap()
        {
            //perusavain
            HasKey(t => new { t.OrderID, t.ProductID });

            //Muut sarakemääritykset
            Property(t => t.OrderID).IsRequired();
            Property(t => t.ProductID).IsRequired();
            Property(t => t.UnitPrice).IsRequired();
            Property(t => t.Quantity).IsRequired();
            Property(t => t.Discount).IsRequired();

            //Taulu & Sarake -mäppäykset
            ToTable("Order Details", "dbo");
            Property(t => t.OrderID).HasColumnName("OrderID");
            Property(t => t.ProductID).HasColumnName("ProductID");
            Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            Property(t => t.Quantity).HasColumnName("Quantity");
            Property(t => t.Discount).HasColumnName("Discount");

            //viiteavain
            HasRequired(t => t.Product).WithMany(x => x.Tilausrivit).HasForeignKey(d => d.ProductID);
            HasRequired(t => t.Order).WithMany(x => x.Tilausrivit).HasForeignKey(d => d.OrderID);
        }
    }
}
