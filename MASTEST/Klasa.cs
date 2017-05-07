using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public abstract class Klasa : ObjectPlus
    {

        //asocjacja binarna
        private Urzadzenie _urzadzenia { get; set; }

        protected Klasa() : base() { }

        public virtual DateTime DataZakonczeniaGwarancji(DateTime dataZakupu) // przesłaniana w Konsumenckie i biznesowe
        {
            return dataZakupu.AddYears(1);
        }
    }
}
