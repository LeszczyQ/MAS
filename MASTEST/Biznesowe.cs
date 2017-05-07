using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Biznesowe : Klasa
    {
        private bool Wsparcie24Na7 { get; set; }
        private bool WsparcieOprogramowania { get; set; }
        private int OkresGwarancji { get; set; }
        private int RozszerzenieGwarancji { get; set;}
        

        public Biznesowe(string model, DateTime dataZakupu, bool wsparcie24Na7, bool wsparcieOprogramowania, int okresGwarancji, int rozszerzenieGwarancji)
        {
            Wsparcie24Na7 = wsparcie24Na7;
            WsparcieOprogramowania = wsparcieOprogramowania;
            OkresGwarancji = okresGwarancji;
            RozszerzenieGwarancji = rozszerzenieGwarancji;
        }


        public override DateTime DataZakonczeniaGwarancji(DateTime dataZakupu)
        {
            return dataZakupu.AddMonths(OkresGwarancji + RozszerzenieGwarancji);
        }

        
        public override string ToString()
        {
            return "Wsparcie 24/7- [" + Wsparcie24Na7 + "], Wsparcie oprogramowania- [" + WsparcieOprogramowania + "], Okres gwarancji podstawowej: " + OkresGwarancji + " M , rozszerzona o " + RozszerzenieGwarancji + " M.";
        }

    }
}

