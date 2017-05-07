using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Projektor : IO
    {
        private string MaxRozmiarObrazu { get; set; }
        private string RozdzielczoscMatrycy { get; set; }
        private bool Obraz3D { get; set; }
        private string Jasnosc { get; set; }
        private string ZywotnoscLampy { get; set; }
        private string TypLampy { get; set; }

        public Projektor(string model, DateTime dataZakupu, string maxRozmiarObrazu, string rozdzielczoscMatrycy,
            bool obraz3D, string jasnosc, string zywotnoscLampy, string typLampy) : base(model, dataZakupu)
        {
            MaxRozmiarObrazu = maxRozmiarObrazu;
            RozdzielczoscMatrycy = rozdzielczoscMatrycy;
            Obraz3D = obraz3D;
            Jasnosc = jasnosc;
            ZywotnoscLampy = zywotnoscLampy;
            TypLampy = typLampy;
        }
    }
}
