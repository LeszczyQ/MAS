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
        private bool WiDi { get; set; }
        private bool WiGig { get; set; }
        private double Waga { get; set; }
        public bool WsparcieMST { get; set; }
        public bool Dotykowy { get; set; }
        public bool Lcd3D { get; set; }
        public double RozmiarMatrycy { get; set; }
        public string RozdzielczoscMatrycy { get; set; }

        public Notebook(string model, DateTime dataZakupu,bool wiDi, bool wiGig, double waga, bool wsparcieMST, bool dotykowy, bool lcd3D, string rozdzielczosc, double rozmiar, bool kontrolerRAID) :base(model, dataZakupu, kontrolerRAID)
        {
            WiDi= wiDi;
            WiGig = wiGig;
            Waga = waga;
            WsparcieMST = wsparcieMST;
            Dotykowy = dotykowy;
            Lcd3D = lcd3D;
            RozmiarMatrycy = rozmiar;
            RozdzielczoscMatrycy = rozdzielczosc;
        }
    }
}
