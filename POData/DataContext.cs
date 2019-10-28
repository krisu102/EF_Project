using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using POData.Mappings;
using POLuokat;

namespace POData
{
    class DataContext : DbContext
    {
        public DataContext()
            : base("Name=DB")
        {
        }
        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DbSet<Customers> Asiakkaat { get; set; }
        public DbSet<OrderDetails> Tilausrivit { get; set; }
        public DbSet<Orders> Tilaukset { get; set; }
        public DbSet<Products> Tuotteet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomersMap());
            modelBuilder.Configurations.Add(new OrderDetailsMap());
            modelBuilder.Configurations.Add(new OrdersMap());
            modelBuilder.Configurations.Add(new ProductsMap());
        }
    }
}
