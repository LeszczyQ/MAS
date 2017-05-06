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
        public enum TypObudowy
        {
            TOWER, MT, DT, SFF, USFF, MICRO
        }

        public TypObudowy Obudowa { get; set; }

        public Desktop(string model, DateTime dataZakupu, TypObudowy typ, bool kontrolerRAID) : base(model, dataZakupu, kontrolerRAID)
        {
            Obudowa = typ;
        }
    }
}
