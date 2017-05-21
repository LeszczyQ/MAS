using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Klient : Osoba
    {
        private List<ZgloszenieSerwisowe> _zglasza= new List<ZgloszenieSerwisowe>();

        private Adres AdresKlienta { get; set; } // atrybut złożony


        public Klient(string imie, string nazwisko, string numer, Adres adres):base(imie, nazwisko, numer)
        {
            AdresKlienta = adres;
        }

        public Klient(string imie, string nazwisko, string numer, string adresEmail, Adres adres):base(imie, nazwisko,numer,adresEmail)
        {
            AdresKlienta = adres;
        }

        public void PrzypiszZgloszenie(ZgloszenieSerwisowe zgloszenie)
        {
            _zglasza.Add(zgloszenie);
        }
        public void UsunPowiazanieZeZgloszeniem(ZgloszenieSerwisowe zgloszenie)
        {
            _zglasza.Remove(zgloszenie);
        }
        override
        public string ToString()
        {
            return base.ToString() +" "+ AdresKlienta.ToString();
        }
    }
}
