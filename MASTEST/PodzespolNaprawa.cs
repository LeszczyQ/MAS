using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class PodzespolNaprawa : ObjectPlus
    {
       
        private Podzespol _uzyty { get; set; }
        private NaprawaSerwisowa _zuzyla { get; set; }
        private int Ilosc { get; set; }

       public PodzespolNaprawa(int ilosc)
        {
            Ilosc = ilosc;
        }

        public void UsunPodzespolNaprawa()
        {
            _uzyty.UsunPowiazaniaZNaprawa(this);
            ObjectPlus.ZwrocEkstensje(typeof(PodzespolNaprawa)).Remove(this);

        }
    }
}
