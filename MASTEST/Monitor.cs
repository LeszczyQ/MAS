using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    public class Monitor : IO, IMonitor
    {

        private bool wsparcieMST;
        private bool dotykowy;
        private bool lcd3D;
        private double rozmiarMatrycy;
        private string rozdzielczoscMatrycy;

        public Monitor(string model, DateTime dataZakupu, bool wsparcieMST, bool dotykowy, bool lcd3D, string rozdzielczosc, double rozmiar) : base(model, dataZakupu)
        {

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
