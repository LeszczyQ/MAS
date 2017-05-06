using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
   public class Podzespol : ObjectPlusPlus
    {
        public enum Rola
        {
            Uzyty,
            WchodziWSklad
        }
        public enum Typ
        {
            Pamiec, Procesor, PlytaGlowna, Zasilacz, Dysk, Grafika, KartaLAN, KartaWWAN, KartaWLAN, ServiceKit, Lampa, Przewod, Obudowa 
        }

        public string KodPodzespolu { get; set; }

        public Typ TypPodzespolu { get; set; }

        public string Nazwa { get; set; }
        public string Producent { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }

        public Podzespol(string kodPodzespolu,Typ typPodzespolu, string nazwa, string producent, string opis, double cena)
        {
            KodPodzespolu = kodPodzespolu;
            TypPodzespolu = typPodzespolu;
            Nazwa = nazwa;
            Producent = producent;
            Opis = opis;
            Cena = cena;
        }

    }
}
