using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLuokat
{
    public class Customers
    {
        public string CustomerID { get; private set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public virtual List<Orders> Tilaukset { get; set; }

        public Customers()
        {
            Tilaukset = new List<Orders>();
        }
        public Customers(string tunnus, string maa, string kaupunki, string nimi)
            :this()
        {
            CustomerID = tunnus;
            Country = maa;
            City = kaupunki;
            CompanyName = nimi;
        }

        public override string ToString() => $"{Tilaukset})";

    }
}
