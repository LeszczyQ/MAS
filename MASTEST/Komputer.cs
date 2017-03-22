using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
   [Serializable]
    public abstract class Komputer : Urzadzenie
    {
        public enum ZLACZA
        {
            HDMI,
            DP,
            USB2_0,
            USB3_0,
            ThunderBolt,
            MiniDP,
            MiniHDMI,
            VGA,
            DVI,
            Ethernet,
            RS232,
            Jack3_5,
        }


        private Dictionary<ZLACZA,int> zlacza;
        private bool raid;

        public Komputer(string model, DateTime dataZakupu) : base(model, dataZakupu) {
        }

        public void DodajZlacze(Komputer.ZLACZA typ, int ilosc)
        {
            zlacza.Add(typ, ilosc);
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
