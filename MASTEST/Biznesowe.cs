using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Biznesowe : Urzadzenie
    {
        private bool wsparcie24Na7;
        private bool wsparcieOprogramowania;
        private int okresGwarancji;
        private int rozszerzenieGwarancji;


        public bool Wsparcie24Na7
        {
            get { return wsparcie24Na7; }
            set { wsparcie24Na7 = value; }
        }
        private bool WsparcieOprogramowania
        {
            get { return wsparcieOprogramowania; }
            set { wsparcieOprogramowania = value; }
        }
        private int OkresGwarancji
        {
            get { return okresGwarancji; }
            set { okresGwarancji = value; }
        }
        private int RozszerzenieGwarancji
        {
            get { return rozszerzenieGwarancji; }
            set { rozszerzenieGwarancji = value; }
        }

        public Biznesowe(string numerSeryjny, DateTime dataZakupu, bool wsparcie24Na7, bool wsparcieOprogramowania, int okresGwarancji, int rozszerzenieGwarancji) : base(numerSeryjny, dataZakupu)
        {
            Wsparcie24Na7 = wsparcie24Na7;
            WsparcieOprogramowania = wsparcieOprogramowania;
            OkresGwarancji = okresGwarancji;
            RozszerzenieGwarancji = rozszerzenieGwarancji;
        }
        override
        public DateTime DataZakonczeniaGwarancji()
        {
            return DataZakupu.AddYears(OkresGwarancji+RozszerzenieGwarancji);
        }

    }
}

