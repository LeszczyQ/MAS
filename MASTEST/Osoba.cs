using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public abstract class Osoba : ObjectPlusPlus
    {
        private string imie;// atrybut prosty
        private string nazwisko;
        private List<string> numeryKontaktowe = new List<string>();//atrybut powtarzalny
        private string adresEmail; //atrybut opcjonalny 

        public Osoba(string imie, string nazwisko, string numer):base()
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numeryKontaktowe.Add(numer);
            this.adresEmail = null;

        }

        public Osoba(string imie, string nazwisko, string numer, string adresEmail):base()
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numeryKontaktowe.Add(numer);
            this.adresEmail = adresEmail;
        }
        public string GetImie()
        {
            return this.imie;
        }
        public string GetNazwisko()
        {
            return this.nazwisko;
        }

        public List<string> GetNumeryKontaktowe()
        {
            return this.numeryKontaktowe;
        }
        public string getAdresEmail()
        {
            if (this.adresEmail == null)
            {
                return "brak adresu email";
            }
            return this.adresEmail;
        }

        public void SetImie(string imie)
        {
            this.imie = imie;
        }
        public void SetNazwisko(string nazwisko)
        {
            this.nazwisko = nazwisko;
        }

        public void DodajNumerKontaktowy(string numer)
        {
            if (numeryKontaktowe.Count > 2)
                throw new Exception("Osoba może mieć przypisane maksymalnie do 3 numerów");
            else
                this.numeryKontaktowe.Add(numer);
        }
        public void EdytujNumeryKontaktowe(int pozycja0_2, string nowyNumer)
        {
            if (pozycja0_2 > 2)
                throw new Exception("numery sa na pozycjach od 0 do 2");
            else
                numeryKontaktowe[pozycja0_2] = nowyNumer;

        }
        public void SetAdresEmail(string adresEmail)
        {
            this.adresEmail = adresEmail;
        }

        override
            public string ToString()
        {
            string tablicaNumerow = string.Join(", ", numeryKontaktowe.ToArray());
            if (adresEmail != null)
            {
                return imie + " " + nazwisko + " " + tablicaNumerow + " " + this.adresEmail;
            }
            else
            {
                return imie + " " + nazwisko + " " + tablicaNumerow + " brak adresu email";
            }
        }
    }
}
