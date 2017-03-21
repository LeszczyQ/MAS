using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    class Klient : Osoba
    {
        enum Rola
        {
            zglasza
        }

        private Adres adres; // atrybut złożony


        public Klient(string imie, string nazwisko, string numer, Adres adres):base(imie, nazwisko, numer)
        {
            this.adres = adres;
        }

        public Klient(string imie, string nazwisko, string numer, string adresEmail, Adres adres):base(imie, nazwisko,numer,adresEmail)
        {
            this.adres = adres;
        }
        public static void PokazEkstensje()
        {
            ObjectPlus.PokazEkstensje(typeof(Klient));
        }

        override
        public string ToString()
        {
            return base.ToString() +" "+ adres.ToString();
        }
    }
}
