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
        

        private DateTime dataZatrudnienia;
        private static double wynagrodzeniePodstawowe= 2000.0;
        private double podstawaDoPremii;

        public Agent(string imie, string nazwisko, string numer, DateTime dataZatrudnienia):base(imie, nazwisko, numer)
        {
            this.dataZatrudnienia = dataZatrudnienia;
        }

        public Agent(string imie, string nazwisko, string numer, string adresEmail, DateTime dataZatrudnienia) :base(imie, nazwisko, numer ,adresEmail)
        {
            this.dataZatrudnienia = dataZatrudnienia;
        }

        public double GetPodstawaDoPremii()
        {
            this.WyliczPodstaweDoPremii();
            return this.podstawaDoPremii;
        }
        public static double GetWynagrodzeniePodstawowe()
        {
            return wynagrodzeniePodstawowe;
        }
        public void WyliczPodstaweDoPremii()
        {
            int staz = (DateTime.Now- dataZatrudnienia).Days;
            Console.Write("\nliczbaPrzepracowanychDni : " + staz);
            if (staz <= 90)
            {
                this.podstawaDoPremii = 0;
            }else if (staz > 90 && staz <= 365)
            {
                this.podstawaDoPremii = 500;
            }
            else
            {
                this.podstawaDoPremii = 1500;
            }
                }


        public double WyliczPremie()
        {
            int przepracowaneDni = (DateTime.Now- dataZatrudnienia ).Days;

            return przepracowaneDni * 0.001 * podstawaDoPremii;

        }

        //public ZgloszenieSerwisowe UtworzZgloszenie(Klient klient, string opisUsterki, string diagnostyka)
        //{
        //    ZgloszenieSerwisowe z = new ZgloszenieSerwisowe(opisUsterki, diagnostyka);
        //    this.DodajPowiazanie(z);
        //    klient.DodajPowiazanie(z);
        //    return z;
        //}


        public override string ToString()
        {
            return base.ToString() + " Podstawa do premii : " + podstawaDoPremii + "\n";
        }

    }
}
