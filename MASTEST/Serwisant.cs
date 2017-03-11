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

        private static double premia = 1200.0; // atrybut klasowy
        private double stawkaZaWizyte;
        private List<string> obslugiwaneKodyPocztowe = new List<string>();

        public Serwisant(string imie, string nazwisko, List<string> numeryKontaktowe, double stawkaZaWizyte) : base(imie, nazwisko, numeryKontaktowe)
        {
            this.stawkaZaWizyte = stawkaZaWizyte;
        }
        public Serwisant(string imie, string nazwisko, List<string> numeryKontaktowe, double stawkaZaWizyte, string adresEmail) : base(imie, nazwisko, numeryKontaktowe, adresEmail)
        {
            this.stawkaZaWizyte = stawkaZaWizyte;
        }

        public static double GetPremia()
        {
            return premia;
        }

        public double GetStawkaZaWizyte()
        {
            return stawkaZaWizyte;
        }

        public void SetStawkaZaWizyte(double stawka)
        {
            this.stawkaZaWizyte = stawka;
        }

        public static void ZwiększPremie(double procent)// metoda klasowa
        {
            premia = premia + premia * procent* 0.01;
        }

        public static void pokazEkstensje()
        {
            ObjectPlus.pokazEkstensje(typeof(Serwisant));
        }
        public void DodajObslugiwanyKodPocztowy(string kodPocztowy)
        {
            if (obslugiwaneKodyPocztowe.Count >= 4)
            {
                new Exception(" Można dodać maksymalnie 3 numery kontaktowe");
            }
            else {
                this.obslugiwaneKodyPocztowe.Add(kodPocztowy);
            }
        }

        public List<string> GetObsługiwaneKodyPocztowe()
        {
            return this.obslugiwaneKodyPocztowe;
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
            return base.ToString() + "\nObsługiwane kody pocztowe : \n" + ObsługiwaneKodyToString()+ "\n premia :"+ premia+"\n";
        }
    }
}
