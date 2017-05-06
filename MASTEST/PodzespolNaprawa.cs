using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    class PodzespolNaprawa : ObjectPlusPlus
    {

        public int Ilosc { get; set; }

       public PodzespolNaprawa(int ilosc)
        {
            Ilosc = ilosc;
        }
    }
}
