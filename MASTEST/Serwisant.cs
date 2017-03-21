using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    class Serwisant : Osoba
    {
        public enum Rola
        {
            realizuje
        }

        private static double premia = 1200.0; // atrybut klasowy
        private double stawkaZaWizyte;
        private List<string> obslugiwaneKodyPocztowe = new List<string>();

        public Serwisant(string imie, string nazwisko, string numer, double stawkaZaWizyte, string kodPocztowy) : base(imie, nazwisko, numer)
        {
            this.stawkaZaWizyte = stawkaZaWizyte;
            obslugiwaneKodyPocztowe.Add(kodPocztowy);
        }
        public Serwisant(string imie, string nazwisko, string numer, double stawkaZaWizyte, string kodPocztowy, string adresEmail) : base(imie, nazwisko, numer, adresEmail)
        {
            this.stawkaZaWizyte = stawkaZaWizyte;
            obslugiwaneKodyPocztowe.Add(kodPocztowy);

        }

        public static double Premia
        {
            get { return premia; }
            // set { premia = value; }
        }
        public double StawkaZaWizyte
        {
            get { return stawkaZaWizyte; }
            set { stawkaZaWizyte = value; }
        }
        public List<string> ObslugiwaneKodyPocztowe
        {
            get { return obslugiwaneKodyPocztowe; }
            set { obslugiwaneKodyPocztowe = value; }
        }

        public static void ZwiekszPremie(double kwota)
        {
            premia += kwota;
        }
        
        public void DodajObslugiwanyKodPocztowy(string kodPocztowy)
        {
            obslugiwaneKodyPocztowe.Add(kodPocztowy);
        }


        public string ObsługiwaneKodyToString()
        {
            if (obslugiwaneKodyPocztowe != null)
                return string.Join("; ", obslugiwaneKodyPocztowe);
            else return "brak ";
        }
        public bool CzyObslugujeKod(string kodPocztowy)
        {
            if (obslugiwaneKodyPocztowe != null)
                return obslugiwaneKodyPocztowe.Contains(kodPocztowy);
            else return false;

        }





        public override string ToString()
        {
            return base.ToString() + "\nObsługiwane kody pocztowe : \n" + ObsługiwaneKodyToString() + "\n premia :" + premia + "\n";
        }
    }
}
