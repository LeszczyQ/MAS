using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Drukarka : IO
    {
        private string RozdzielczoscWydruku { get; set; }
        private bool Kolor { get; set; }
        private bool Skaner { get; set; }
        private bool Sieciowa { get; set; }
        private bool Fax { get; set; }
        private string ZywotnoscFusera { get; set; }

        public Drukarka(string model, DateTime dataZakupu, string rozdzielczoscWydruku, bool kolor, bool skaner,
            bool sieciowa, bool fax, string zywotnoscFusera) : base(model, dataZakupu)
        {
            RozdzielczoscWydruku = rozdzielczoscWydruku;
            Kolor = kolor;
            Skaner = skaner;
            Sieciowa = sieciowa;
            Fax = fax;
            ZywotnoscFusera = zywotnoscFusera;
        }
    }
}