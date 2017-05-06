using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    class AdresNaprawy : ObjectPlusPlus
    {
       
        private Adres AdresNaprawySerwisowej { get; set; }
       
        public AdresNaprawy(Adres adres)
        {
            AdresNaprawySerwisowej = adres;
        }


    }
}
