using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public abstract class IO : Urzadzenie
    {
        public enum ZLACZA
        {
            HDMI,
            DP,
            USB2_0,
            USB3_0,
            MiniDP,
            MiniHDMI,
            VGA,
            DVI,
            Ethernet,
        }

        private Dictionary<ZLACZA, int> zlacza;

        public IO(string model, DateTime dataZakupu) : base(model,dataZakupu){

        }

        public void DodajZlacze(IO.ZLACZA typ, int ilosc)
        {
            zlacza.Add(typ, ilosc);
        }

    }
}
