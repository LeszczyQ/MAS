using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Serwisant : Osoba
    {
        
        private List<NaprawaSerwisowa> _realizuje = new List<NaprawaSerwisowa>();

        private static double _podstawa = 1200.0;

        private static double Podstawa  // atrybut klasowy
        {
            get { return _podstawa; }
            set { _podstawa = value; }
        }

        private double StawkaZaWizyte { get; set; }

        private List<string> ObslugiwaneKodyPocztowe { get; set; }


        public Serwisant(string imie, string nazwisko, string numer, double stawkaZaWizyte, string kodPocztowy) : base(imie, nazwisko, numer)
        {
            StawkaZaWizyte= stawkaZaWizyte;
            ObslugiwaneKodyPocztowe = new List<string>() {kodPocztowy};
        }

        public Serwisant(string imie, string nazwisko, string numer, double stawkaZaWizyte, string kodPocztowy, string adresEmail) : base(imie, nazwisko, numer, adresEmail)
        {
            StawkaZaWizyte = stawkaZaWizyte;
            ObslugiwaneKodyPocztowe = new List<string>() { kodPocztowy };
        }

        public void PrzypiszDoNaprawy(NaprawaSerwisowa naprawa)
        {
            _realizuje.Add(naprawa);
        }

        public void UsunPowiazanieNaprawa(NaprawaSerwisowa naprawa)
        {
            if (_realizuje.Contains(naprawa))
            {
                _realizuje.Remove(naprawa);
            }
            else
            {
                throw new Exception("Ten serwisant nie realizuje tego zgłoszenia");
            }
        }

        public void DodajObslugiwanyKodPocztowy(string kodPocztowy)
        {
            ObslugiwaneKodyPocztowe.Add(kodPocztowy);
        }


        public string ObsługiwaneKodyToString()
        {
            if (ObslugiwaneKodyPocztowe != null)
                return string.Join("; ", ObslugiwaneKodyPocztowe);
            else return "brak ";
        }

        public bool CzyObslugujeKod(string kodPocztowy)
        {
            return ObslugiwaneKodyPocztowe != null && ObslugiwaneKodyPocztowe.Contains(kodPocztowy);
        }
        
        public override string ToString()
        {
            return base.ToString() + "\nObsługiwane kody pocztowe : \n" + ObsługiwaneKodyToString() + "\nPodstawa :" + Podstawa + "\n";
        }
    }
}
