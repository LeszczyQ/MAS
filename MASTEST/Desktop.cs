using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class Desktop : Komputer
    {
      public enum TYPOBUDOWY
        {
            TOWER,
            MT,
            DT,
            SFF,
            USFF,
            MICRO,
        }

        private TYPOBUDOWY typObudowy;

        public TYPOBUDOWY TypObudowy
        {
            get { return typObudowy; }
            private set { typObudowy = value;}
        }

        public Desktop(string model, DateTime dataZakupu, TYPOBUDOWY typ) : base(model,dataZakupu)
        {
            typObudowy = typ;
        }
    }
}
