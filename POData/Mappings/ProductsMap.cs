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
    class ProductsMap : EntityTypeConfiguration<Products>
    {
        public ProductsMap()
        {
            //perusavain
            HasKey(t => t.ProductID);
            //tietokanta tuottaa arvon
            Property(t => t.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Muut sarakemääritykset
            Property(t => t.ProductName).IsRequired().HasMaxLength(40);
            Property(t => t.QuantityPerUnit).HasMaxLength(20);
            Property(t => t.Discontinued).IsRequired();

            //Taulu & Sarake -mäppäykset
            ToTable("Products", "dbo");
            Property(t => t.ProductID).HasColumnName("ProductID");
            Property(t => t.ProductName).HasColumnName("ProductName");
            Property(t => t.SuplierID).HasColumnName("SuplierID");
            Property(t => t.CategoryID).HasColumnName("CategoryID");
            Property(t => t.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            Property(t => t.UnitsInStock).HasColumnName("UnitsInStock");
            Property(t => t.UnitsOnOrder).HasColumnName("UnitsOnOrder");
            Property(t => t.ReorderLevel).HasColumnName("ReorderLevel");
            Property(t => t.Discontinued).HasColumnName("Discontinued");
        }
    }
}
