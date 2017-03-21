using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    class Podzespol
    {
        private enum TYP
        {
            pamiec, procesor, plytaGlowna, zasilacz, dysk, grafika, kartaLAN, kartaWWAN, kartaWLAN, serviceKit, lampa, przewod, obudowa 

        }
        private string
            kodPodzespolu,
            nazwa,
            producent,
            opis;
        private TYP typ;
        private double cena;

        public string KodPodzespolu
        {
            get { return kodPodzespolu; }
            private set { kodPodzespolu = value; }
        }

        private TYP Typ
        {
            get { return typ; }
            set { typ = value; }
        }

        public string Nazwa
        {
            get { return nazwa; }
            private set { nazwa = value; }
        }
        public string Producent
        {
            get { return producent; }
            private set { producent = value; }
        }
        public string Opis
        {
            get { return opis; }
            private set { opis = value; }
        }
        public double Cena
        {
            get { return cena; }
            private set { cena = value; }
        }

        public Podzespol(string kodPodzespolu, string nazwa, string producent, string opis, double cena) { }

    }
}
