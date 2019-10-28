using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POData.Repositories;
using POLuokat;
using static System.Console;

namespace POSovellus
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Yellow;
            CustomersRepository cr = new CustomersRepository();
            OrderDetailsRepository odr = new OrderDetailsRepository();
            OrdersRepository or = new OrdersRepository();
            ProductsRepository pr = new ProductsRepository();
            int vastaus;
            bool jatka = true;

            do
            {
                TulostaValikko();
                if (int.TryParse(ReadLine(), out vastaus))
                {
                    switch (vastaus)
                    {
                        case 1:
                            Hae(cr, odr);
                            break;
                        case 2:
                            Lisaa(cr);
                            break;
                        case 3:
                            Muuta(cr);
                            break;
                        case 4:
                            Poista(cr);
                            break;
                        case 5:
                            jatka = false;
                            break;
                        default:
                            WriteLine("Väärä valinta. Paina Enter.");
                            ReadLine();
                            break;
                    }
                }
            } while (jatka);
        }

        private static void TulostaValikko()
        {
            Clear();
            WriteLine(String.Format("{0," + WindowWidth / 2 + "}", "Northwind-asiakkaat"));
            WriteLine("1. Hae");
            WriteLine("2. Lisää");
            WriteLine("3. Muuta");
            WriteLine("4. Poista");
            WriteLine("5. Lopeta");
            Write("Valitse: ");
        }

        private static void Hae(CustomersRepository cr, OrderDetailsRepository odr)
        {
            Clear();
            WriteLine(String.Format("{0," + WindowWidth / 2 + "}", "Northwind-asiakkaat"));
            WriteLine("Asiakastietojen haku");
            WriteLine("Valitse hakukriteeri");
            WriteLine("1. Nimi");
            WriteLine("2. Kaupunki");
            WriteLine("3. Maa");
            WriteLine("4. Palaa takaisin");
            Write("Valitse: ");
            int valinta;
            if (int.TryParse(ReadLine(), out valinta))
            {
                if (valinta == 1)
                {
                    Write("Anna haettavien alku: ");
                    string aloitus = ReadLine();
                    List<Customers> asiakkaat = cr.HaeKaikkiNimenmukaan(aloitus);
                    Haku(odr, asiakkaat);
                }
                else if (valinta == 2)
                {
                    Write("Anna haettavien alku: ");
                    string aloitus = ReadLine();
                    List<Customers> asiakkaat = cr.HaeKaikkiKaupungingmukaan(aloitus);
                    Haku(odr, asiakkaat);
                }
                else if (valinta == 3)
                {
                    Write("Anna haettavien alku: ");
                    string aloitus = ReadLine();
                    List<Customers> asiakkaat = cr.HaeKaikkiMaanmukaan(aloitus);
                    Haku(odr, asiakkaat);
                }
                else if (valinta == 4)
                {
                    return;
                } 
            }       
        }
        private static void Lisaa(CustomersRepository cr)
        {
            string tunnus, maa, kaupunki, nimi;
            WriteLine("Uusi asiakas");
            Write("Anna tunnus: ");
            tunnus = ReadLine();
            if (tunnus == "")
            {
                tunnus = null;
            }
            Write("Anna nimi: ");
            nimi = ReadLine();
            if (nimi == "")
            {
                nimi = null;
            }
            Write("Anna maa: ");
            maa = ReadLine();
            if (maa == "")
            {
                maa = null;
            }
            Write("Anna kaupunki: ");
            kaupunki = ReadLine();
            if (kaupunki == "")
            {
                kaupunki = null;
            }

            Customers c = new Customers(tunnus, maa, kaupunki, nimi);
            
                try
                {
                    cr.Lisaa(c);

                    WriteLine("Asiakas lisätty");
                    Write("Paina Enter");
                    ReadLine();
                }
                catch (Exception)
                {
                    WriteLine("Lisääminen epäonnistui");
                    Write("Paina Enter");
                    ReadLine();
                }       
        }
        private static void Muuta(CustomersRepository cr)
        {
            string tunnus;
            Customers muutettava;
            string nimi, kaupunki, maa;

            WriteLine("Asiakkaan muuttaminen");
            Write("Anna muutettavan asiakkaan tunnus: ");
            tunnus = ReadLine();
            try
            {
                muutettava = cr.Hae(tunnus);
                WriteLine($"Asiakkaan tiedot {muutettava.CustomerID}{muutettava.CompanyName}, {muutettava.City} {muutettava.Country}");
            }
            catch (Exception)
            {
                WriteLine("Asiakasta ei löytynyt");
                Write("Paina Enter");
                ReadLine();
                return;
            }

            Write("Anna uusi nimi tai tyhjä: ");
            nimi = ReadLine();
            if (nimi != "")
            {
                muutettava.CompanyName = nimi;
            }
            Write("Anna uusi kaupunki tai tyhjä: ");
            kaupunki = ReadLine();
            if (kaupunki != "")
            {
                muutettava.City = kaupunki;
            }
            Write("Anna uusi maa tai tyhjä: ");
            maa = ReadLine();
            if (maa != "")
            {
                muutettava.Country = maa;
            }

            try
            {
                cr.Muuta(muutettava);

                WriteLine("Asiakas muutettu");
                Write("Paina Enter");
                ReadLine();
            }
            catch (Exception)
            {
                WriteLine("Muuttaminen epäonnistui");
                Write("Paina Enter");
                ReadLine();
            }    
            
        }
        private static void Poista(CustomersRepository cr)
        {
            List<Customers> asiakkaat = new List<Customers>();
            asiakkaat = cr.HaeKaikki();
            var tulos = asiakkaat.Where(a => a.Tilaukset.Count == 0).ToList();

            string tunnus;
            Customers poistettava;

            WriteLine("Asiakkaan Poistaminen");
            WriteLine("Seuraavilla asiakkailla ei ole tilauksia:");
            foreach (var c in tulos)
            {
                WriteLine($"{c.CustomerID}, {c.CompanyName}, {c.City} {c.Country}");
            }
            Write("Anna poistettavan tunnus: ");
            tunnus = ReadLine();

            try
            {
                poistettava = cr.Hae(tunnus);
                Write($"Haluatko varmasti poistaa asiakkaan {poistettava.CustomerID}(k/e)? ");
            }
            catch (Exception)
            {
                WriteLine("Asiakasta ei löytynyt");
                Write("Paina Enter");
                ReadLine();
                return;
            }

            if(ReadLine().ToUpper() == "K")
            {
                try
                {
                    cr.Poista(poistettava.CustomerID);

                    WriteLine("Asiakas Poistettu");
                    Write("Paina Enter");
                    ReadLine();
                }
                catch (Exception)
                {
                    WriteLine("Poistaminen epäonnistui");
                    Write("Paina Enter");
                    ReadLine();
                }  
            }
            else
            {
                WriteLine("Asiakasta ei poistettu");
                Write("Paina Enter");
                ReadLine();
            }
        }

        private static void Haku(OrderDetailsRepository odr, List<Customers> asiakkaat)
        {  
            WriteLine($"löydetyt asiakkaat: {asiakkaat.Count()} kpl");

            for (int i = 0; i < asiakkaat.Count(); i++)
            {
                int nro = 1 + i;
                WriteLine($"{nro}. Asiakas {asiakkaat[i].CompanyName}, {asiakkaat[i].City} {asiakkaat[i].Country}");

                foreach (Orders t in asiakkaat[i].Tilaukset)
                {
                    List<OrderDetails> rivit = odr.HaeKaikki().Where(x => x.OrderID == t.OrderID).ToList();
                    decimal summa = 0;
                    for (int j = 0; j < t.Tilausrivit.Count(); j++)
                    {
                        summa = summa + rivit[j].UnitPrice * rivit[j].Quantity;
                    }

                    WriteLine($"Tilaus: {t.OrderID} Tuotteita: {t.Tilausrivit.Count()}, Arvo yhteensä {summa.ToString("0.00")}");                   
                }

                if (i < asiakkaat.Count() - 1)
                {
                    Write("Seuraava painamalla Enter.");
                    ReadLine(); 
                }
                else
                {
                    Write("Paina Enter");
                    ReadLine();
                }
            }
        }
    }
}
