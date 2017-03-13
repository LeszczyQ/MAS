using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    abstract class Osoba : ObjectPlusPlus
    {
        private string imie;// atrybut prosty
        private string nazwisko;
        private List<string> numeryKontaktowe;//atrybut powtarzalny
        private string adresEmail; //atrybut opcjonalny 

        public Osoba(string imie, string nazwisko, List<string> numeryKontaktowe)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numeryKontaktowe = numeryKontaktowe;
            this.adresEmail = null;

        }

        public Osoba(string imie, string nazwisko, List<string> numeryKontaktowe, string adresEmail)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numeryKontaktowe = numeryKontaktowe;
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

        public void SetNumeryKontaktowe(List<string> numeryKontaktowe)
        {
            this.numeryKontaktowe = numeryKontaktowe;
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
                return imie + " " + nazwisko + " " + tablicaNumerow +" "+ this.adresEmail;
            }
            else
            {
                return imie + " " + nazwisko + " " + tablicaNumerow + " brak adresu email";
            }
        }
    } 
}
