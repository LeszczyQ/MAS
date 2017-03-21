using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    class Konsumenckie: Urzadzenie
    {
        private static int okresGwarancji=2;

        public Konsumenckie(string model, DateTime dataZakupu):base(model, dataZakupu) { }

        public static void ZmienOkresGwarancji (int iloscMiesiecy)
        {
            okresGwarancji = iloscMiesiecy;
        }
        override
        public DateTime DataZakonczeniaGwarancji()
        {
            return DataZakupu.AddMonths(okresGwarancji);
        }

        override
        public string ToString()
        {
            return "Data Zakupu : ["+DataZakupu+"] Okres Gwarancji : " + okresGwarancji + " M";
        }
    }
}
