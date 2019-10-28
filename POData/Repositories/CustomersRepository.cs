using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POLuokat;

namespace POData.Repositories
{
    public class CustomersRepository
    {
        private DataContext _dc;
        public CustomersRepository()
        {
            _dc = new DataContext();
        }

        //metodit

        public Customers Hae(string id)
        {
            return _dc.Asiakkaat.Where(t => t.CustomerID == id).SingleOrDefault();
        }
        public List<Customers> HaeKaikki()
        {
            var paluu = _dc.Asiakkaat.ToList();
            return paluu;
        }
        public List<Customers> HaeKaikkiMaanmukaan(string alku)
        {
            var paluu = _dc.Asiakkaat.Where(t => t.Country.StartsWith(alku)).ToList();
            return paluu;
        }
        public List<Customers> HaeKaikkiKaupungingmukaan(string alku)
        {
            var paluu = _dc.Asiakkaat.Where(t => t.City.StartsWith(alku)).ToList();
            return paluu;
        }
        public List<Customers> HaeKaikkiNimenmukaan(string alku)
        {
            var paluu = _dc.Asiakkaat.Where(t => t.CompanyName.StartsWith(alku)).ToList();
            return paluu;
        }
        public bool Lisaa(Customers uusi)
        {
            _dc.Asiakkaat.Add(uusi);
            return (_dc.SaveChanges() == 1);
        }
        public bool Muuta(Customers o)
        {
            Customers muutettava = Hae(o.CustomerID);

            muutettava.CompanyName = o.CompanyName;
            muutettava.City = o.City;
            muutettava.Country = o.Country;
            muutettava.ContactName = o.ContactName;
            muutettava.ContactTitle = o.ContactTitle;
            muutettava.Address = o.Address;
            muutettava.Region = o.Region;
            muutettava.PostalCode = o.PostalCode;
            muutettava.Phone = o.Phone;
            muutettava.Fax = o.Fax;

            return (_dc.SaveChanges() == 1);
        }
        public bool Poista(string id)
        {
            _dc.Asiakkaat.Remove(Hae(id));
            return (_dc.SaveChanges() == 1);
        }

    }
}
