using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Adres : ObjectPlus
    {
        private string Ulica { get; set; }
        private string Numer { get; set; }
        private string KodPocztowy { get; set; }
        private string Miasto { get; set; }

        public Adres(string ulica, string numer, string kodPocztowy, string miasto)
        {
            Ulica = ulica;
            Numer = numer;
            KodPocztowy = kodPocztowy;
            Miasto = miasto;
        }

        override
        public string ToString()
        {
            return "\nUl. " + Ulica + " " + Numer + "\n" + KodPocztowy + "\n" + Miasto;
        }

    }
}
