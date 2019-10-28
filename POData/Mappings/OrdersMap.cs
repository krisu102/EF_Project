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
    class OrdersMap : EntityTypeConfiguration<Orders>
    {
        public OrdersMap()
        {
            //perusavain
            HasKey(t => t.OrderID);
            //tietokanta tuottaa arvon
            Property(t => t.OrderID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Muut sarakemääritykset
            Property(t => t.CustomerID).HasMaxLength(5);

            //Taulu & Sarake -mäppäykset
            ToTable("Orders", "dbo");
            Property(t => t.OrderID).HasColumnName("OrderID");
            Property(t => t.CustomerID).HasColumnName("CustomerID");
            Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            Property(t => t.OrderDate).HasColumnName("OrderDate");
            Property(t => t.RequiredDate).HasColumnName("RequiredDate");
            Property(t => t.ShippedDate).HasColumnName("ShippedDate");
            Property(t => t.ShipVia).HasColumnName("ShipVia");
            Property(t => t.Freight).HasColumnName("Freight");
            Property(t => t.ShipName).HasColumnName("ShipName");
            Property(t => t.ShipAddress).HasColumnName("ShipAddress");
            Property(t => t.ShipCity).HasColumnName("ShipCity");
            Property(t => t.ShipRegion).HasColumnName("ShipRegion");
            Property(t => t.ShipPostalCode).HasColumnName("ShipPostalCode");
            Property(t => t.ShipCountry).HasColumnName("ShipCountry");

            //viiteavain
            HasOptional(t => t.Customer).WithMany(x => x.Tilaukset).HasForeignKey(d => d.CustomerID);
        }
    }
}
