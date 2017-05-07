using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Agent : Osoba
    {
        private DateTime DataZatrudnienia { get; set; }
        private static double _podstawa = 2000.0;
        private double PodstawaDoPremii => WyliczPodstaweDoPremii(); //atrybut wyliczalny
        private static double Podstawa
        {
            get { return _podstawa; }
            set { _podstawa = value; }
        }
        private List<ZgloszenieSerwisowe> _obsluguje = new List<ZgloszenieSerwisowe>();



        public Agent(string imie, string nazwisko, string numer, DateTime dataZatrudnienia) : base(imie, nazwisko, numer)
        {
            DataZatrudnienia = dataZatrudnienia;
        }

        public Agent(string imie, string nazwisko, string numer, string adresEmail, DateTime dataZatrudnienia) : base(imie, nazwisko, numer, adresEmail)
        {
            DataZatrudnienia = dataZatrudnienia;
        }

        
        private double WyliczPodstaweDoPremii()
        {
            var staz = (DateTime.Now - DataZatrudnienia).Days;
            if (staz <= 90)
            {
                return 0.0;
            }
            else if (staz > 90 && staz <= 365)
            {
                return 500.0;
            }
            else if (staz > 365 && staz <= 730)
            {
                return 1000.0;
            }
            else return 1500;
           
        }


        public void UtworzZgloszenie(string opisUsterki, string diagnostyka, Klient klient, Urzadzenie urzadzenie)
        {
            var zgloszenie = new ZgloszenieSerwisowe(opisUsterki, diagnostyka);
            // dodanie powiązań Agent<->ZgloszenieSerwisowe
            _obsluguje.Add(zgloszenie);
            zgloszenie._obslugiwanePrzez = this;

            // dodanie powiązań ZgloszenieSerwisowe<->Klient
            zgloszenie._dotyczace = urzadzenie;
            urzadzenie._zgloszoneWRamach.Add(zgloszenie.NumerZgloszenia, zgloszenie);

            //dodanie powiązań Klient<->ZgłoszenieSerwisowe
            zgloszenie._zglaszanePrzez = klient;
            klient._zglasza.Add(zgloszenie);
        }



        public double WyliczPremie()
        {
            var przepracowaneDni = (DateTime.Now - DataZatrudnienia).Days;

            return przepracowaneDni * 0.001 * PodstawaDoPremii;

        }

        public override string ToString()
        {
            return base.ToString() + " \nPodstawa: " + Podstawa + "\nPodstawa do premii: "+PodstawaDoPremii+"\nPremia :"+WyliczPremie();
        }

    }
}
