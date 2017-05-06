using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Monitor : IO, IMonitor
    {

        public bool WsparcieMST { get; set; }
        public bool Dotykowy { get; set; }
        public bool Lcd3D { get; set; }
        public double RozmiarMatrycy { get; set; }
        public string RozdzielczoscMatrycy { get; set; }

        public Monitor(string model, DateTime dataZakupu, bool wsparcieMST, bool dotykowy, bool lcd3D, string rozdzielczosc, double rozmiar) : base(model, dataZakupu)
        {
            WsparcieMST = wsparcieMST;
            Dotykowy = dotykowy;
            Lcd3D = lcd3D;
            RozmiarMatrycy = rozmiar;
            RozdzielczoscMatrycy = rozdzielczosc;
        }
    }
}
