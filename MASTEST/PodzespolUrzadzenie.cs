using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{

    [Serializable]
    class PodzespolUrzadzenie : ObjectPlusPlus
    {
        public int Ilosc { get; set; }

        public PodzespolUrzadzenie(int ilosc)
        {
            Ilosc = ilosc;
        }
    }
}
