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
        private int numerSeryjny;
            private string model;
        private DateTime dataZakupu;

        public int NumerSeryjny
        {
            get { return numerSeryjny; }
            private set { numerSeryjny = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public DateTime DataZakupu
        {
            get { return dataZakupu; }
            set { dataZakupu = value; }
        }


        public Urzadzenie(string model, DateTime dataZakupu)
        {
            Model = model;
            DataZakupu = dataZakupu;
        }

        public abstract DateTime DataZakonczeniaGwarancji();
        
        
        


    }
}
