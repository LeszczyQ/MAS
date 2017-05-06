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
        public enum TypyZlacz
        {
            HDMI,DP,USB2_0,USB3_0,ThunderBolt,MiniDP,MiniHDMI,VGA,DVI,RJ_45,RS232,Jack3_5,
        }

        private Dictionary<TypyZlacz,int> Zlacza { get; set; }
        public bool Raid { get; set; }

        protected Komputer(string model, DateTime dataZakupu, bool kontrolerRAID) : base(model, dataZakupu) {
            Zlacza= new Dictionary<TypyZlacz, int>();
            Raid = kontrolerRAID;
        }

        public void DodajZlacze(TypyZlacz typ, int ilosc)
        {
            Zlacza.Add(typ, ilosc);
        }

        public override string ToString()
        {
            return base.ToString()+ " złącza:" +Zlacza.ToString() ;
        }

    }
}
