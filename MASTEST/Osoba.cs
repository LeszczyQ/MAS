﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public abstract class Osoba : ObjectPlusPlus
    {
        private string Imie { get; set; } // atrybut prosty
        private string Nazwisko { get; set; }
        private List<string> NumeryKontaktowe { get; set; } //atrybut powtarzalny

        private string AdresEmail //atrybut opcjonalny 
        {
            get
            {
                return AdresEmail ?? "brak adresu email";
            }
            set
            {
                AdresEmail = value;
            }
        }

        public Osoba(string imie, string nazwisko, string numer) : base()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            NumeryKontaktowe.Add(numer);
            AdresEmail = null;

        }

        public Osoba(string imie, string nazwisko, string numer, string adresEmail) : base() //Przeciążenie 
        {
            Imie = imie;
            Nazwisko = nazwisko;
            NumeryKontaktowe.Add(numer);
            AdresEmail = adresEmail;
        }


        public void DodajNumerKontaktowy(string numer)
        {
            if (NumeryKontaktowe.Count > 2)
                throw new Exception("Osoba może mić przypisane maksymalnie do 3 numerów");
            else
                NumeryKontaktowe.Add(numer);
        }

        public void EdytujNumeryKontaktowe(int pozycja02, string nowyNumer)
        {
            if (pozycja02 > 2)
                throw new Exception("numery sa na pozycjach od 0 do 2");
            else
                NumeryKontaktowe[pozycja02] = nowyNumer;
        }

       
        override
            public string ToString()
        {
            var tablicaNumerow = string.Join(", ", NumeryKontaktowe.ToArray());
            return "\n" + Imie + " " + Nazwisko + " " + tablicaNumerow + " " + AdresEmail;
        }
    }
}
