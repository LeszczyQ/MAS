using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{

    [Serializable]
    public class PodzespolUrzadzenie : ObjectPlus
    {

        // asocjacja z atrybutem
        private Urzadzenie _skladaSieZ { get; set; }
        private Podzespol _wchodziWsklad { get; set; }

        private int Ilosc { get; set; }

        public PodzespolUrzadzenie(int ilosc)
        {
            Ilosc = ilosc;
        }

        // asocjacja z atrybutem
        public void DodajPodzespolDoUrzadzenia(Podzespol podzespol, Urzadzenie urzadzenie)
        {
            _skladaSieZ = urzadzenie;
            _wchodziWsklad = podzespol;
        }
    }
}
