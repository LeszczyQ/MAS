using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Notebook : Komputer, IMonitor
    {
        private bool wiDi;
        private bool wiGig;
        private double waga;
        private bool wsparcieMST;
        private bool dotykowy;
        private bool lcd3D;
        private double rozmiarMatrycy;
        private string rozdzielczoscMatrycy;

        public Notebook(string model, DateTime dataZakupu,bool wiDi, bool wiGig, double waga, bool wsparcieMST, bool dotykowy, bool lcd3D, string rozdzielczosc, double rozmiar) :base(model, dataZakupu)
        {
            this.wiDi = wiDi;
            this.wiGig = wiGig;
            this.waga = waga;
            this.wsparcieMST = wsparcieMST;
            this.dotykowy = dotykowy;
            this.lcd3D = lcd3D;
            this.rozmiarMatrycy = rozmiar;
            this.rozdzielczoscMatrycy = rozdzielczosc;
        }

        public bool Dotykowy()
        {
            return dotykowy;
        }

        public bool Lcd3D()
        {
            return lcd3D;
        }

        public string RozdzielczoscMatrycy()
        {
            return rozdzielczoscMatrycy;
        }

        public double RozmiarMatrycy()
        {
            return rozmiarMatrycy;
        }

        public bool WsparcieMST()
        {
            return wsparcieMST;
        }
    }
}
