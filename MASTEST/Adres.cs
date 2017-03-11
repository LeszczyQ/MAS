﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Adres : ObjectPlusPlus
    {
        private string ulica;
        private string numer;
        private string kodPocztowy;
        private string miasto;

        public Adres(string ulica, string numer, string kodPocztowy, string miasto)
        {
            this.ulica = ulica;
            this.numer = numer;
            this.kodPocztowy = kodPocztowy;
            this.miasto = miasto;
        }

        public static void pokazEkstensje()
        {
            ObjectPlus.pokazEkstensje(typeof(Adres));
        }

        override
        public string ToString()
        {
            return "\nUl. " + this.ulica + " " + this.numer + "\n" + this.kodPocztowy + "\n" + this.miasto;
        }

    }
}
