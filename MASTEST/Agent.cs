using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    class Agent : Osoba
    {
        public enum Rola
        {
            Obsluguje
        }

        private DateTime DataZatrudnienia { get; set; }
        private static double _podstawa = 2000.0;

        private static double Podstawa
        {
            get { return _podstawa; }
            set { _podstawa = value; }
        }

        public double PodstawaDoPremii => WyliczPodstaweDoPremii(); //atrybut wyliczalny

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
