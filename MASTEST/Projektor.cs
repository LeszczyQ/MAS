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
        public string MaxRozmiarObrazu { get; set; }
        public string RozdzielczoscMatrycy { get; set; }
        public bool Obraz3D { get; set; }
        public string Jasnosc { get; set; }
        public string ZywotnoscLampy { get; set; }
        public string TypLampy { get; set; }

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
