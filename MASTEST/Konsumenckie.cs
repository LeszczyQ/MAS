using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    class Konsumenckie : Klasa
    {
        private static int okresGwarancji = 24;

        public Konsumenckie() { }

        public static void ZmienOkresGwarancji(int iloscMiesiecy)
        {
            okresGwarancji = iloscMiesiecy;
        }

        
        public override DateTime DataZakonczeniaGwarancji(DateTime dataZakupu)
        {
            return dataZakupu.AddMonths(okresGwarancji);
        }

        
        public override string ToString()
        {
            return " Okres Gwarancji : " + okresGwarancji + " M";
        }
    }
}
