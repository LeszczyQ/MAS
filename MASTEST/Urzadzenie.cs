using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public abstract class Urzadzenie : ObjectPlusPlus
    {
        public enum Rola
        {
            SkladaSieZ,
            ZgloszoneWRamach,
            ZKlasy,
        }
        public int NumerSeryjny { get; set; }

        public string Model { get; set; }

        public DateTime DataZakupu { get; set; }

        protected Urzadzenie(string model, DateTime dataZakupu):base()
        {
            Model = model;
            DataZakupu = dataZakupu;
        }

        public override string ToString()
        {
            return "\nNumer seryjny: "+NumerSeryjny+"\nModel :" + Model + "\nData zakupu : [" + DataZakupu + "]\n";
        }
    }
}
