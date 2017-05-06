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
        public enum TypyZlacz
        {
            HDMI, DP, USB2_0, USB3_0, ThunderBolt, MiniDP, MiniHDMI, VGA, DVI, RJ_45, RS232, Jack3_5
        }

        private Dictionary<TypyZlacz, int> Zlacza { get; set; }

        protected IO(string model, DateTime dataZakupu) : base(model, dataZakupu)
        {
            Zlacza = new Dictionary<TypyZlacz, int>();
        }

        public void DodajZlacze(TypyZlacz typ, int ilosc)
        {
            Zlacza.Add(typ, ilosc);
        }

    }
}
