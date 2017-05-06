using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    public abstract class Klasa : ObjectPlusPlus
    {
        public Klasa() : base()
        {

        }

        public virtual DateTime DataZakonczeniaGwarancji(DateTime dataZakupu) // przesłaniana w Konsumenckie i biznesowe
        {
            return dataZakupu.AddYears(1);
        }
    }
}
