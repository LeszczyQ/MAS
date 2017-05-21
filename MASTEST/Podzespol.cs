using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
   public class Podzespol : ObjectPlus
    {
        
        public enum Typ
        {
            Pamiec, Procesor, PlytaGlowna, Zasilacz, Dysk, Grafika, KartaLAN, KartaWWAN, KartaWLAN, ServiceKit, Lampa, Przewod, Obudowa 
        }

        //asocjacja z atrybutem
        private List<PodzespolUrzadzenie> _wchodziWSklad = new List<PodzespolUrzadzenie>();

        //asocjacja z atrybutem
        private List<PodzespolNaprawa> _uzyty = new List<PodzespolNaprawa>();

        private string KodPodzespolu { get; set; }
        private Typ TypPodzespolu { get; set; }
        private string Nazwa { get; set; }
        private string Producent { get; set; }
        private string Opis { get; set; }
        private double Cena { get; set; }

        public Podzespol(string kodPodzespolu,Typ typPodzespolu, string nazwa, string producent, string opis, double cena)
        {
            KodPodzespolu = kodPodzespolu;
            TypPodzespolu = typPodzespolu;
            Nazwa = nazwa;
            Producent = producent;
            Opis = opis;
            Cena = cena;
        }

        // asocjacja z atrybutem
        public void PowiazZUrzadzeniem(PodzespolUrzadzenie podurz)
        {
            _wchodziWSklad.Add(podurz);
        }

        public void UsunPowiazaniaZNaprawa(PodzespolNaprawa podurz)
        {
            _uzyty.Remove(podurz);
        }

    }
}
