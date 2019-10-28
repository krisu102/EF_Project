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
    class CustomersMap : EntityTypeConfiguration<Customers>
    {
        public CustomersMap()
        {
            //perusavain
            HasKey(t => t.CustomerID);

            //Muut sarakemääritykset
            Property(t => t.CustomerID).IsRequired().HasMaxLength(5);
            Property(t => t.CompanyName).IsRequired().HasMaxLength(40);
            Property(t => t.City).HasMaxLength(15);
            Property(t => t.Country).HasMaxLength(15);
            Property(t => t.ContactName).HasMaxLength(30);
            Property(t => t.ContactTitle).HasMaxLength(30);
            Property(t => t.Address).HasMaxLength(60);
            Property(t => t.Region).HasMaxLength(15);
            Property(t => t.PostalCode).HasMaxLength(10);
            Property(t => t.Phone).HasMaxLength(24);
            Property(t => t.Fax).HasMaxLength(24);

            //Taulu & Sarake -mäppäykset
            ToTable("Customers", "dbo");
            Property(t => t.CustomerID).HasColumnName("CustomerID");
            Property(t => t.CompanyName).HasColumnName("CompanyName");
            Property(t => t.ContactName).HasColumnName("ContactName");
            Property(t => t.ContactTitle).HasColumnName("ContactTitle");
            Property(t => t.Address).HasColumnName("Address");
            Property(t => t.City).HasColumnName("City");
            Property(t => t.Region).HasColumnName("Region");
            Property(t => t.PostalCode).HasColumnName("PostalCode");
            Property(t => t.Country).HasColumnName("Country");
            Property(t => t.Phone).HasColumnName("Phone");
            Property(t => t.Fax).HasColumnName("Fax");
        }
    }
}
