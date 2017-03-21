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
        private Adres adresNaprawy;
        private Adres AdresN
        {
            get { return adresNaprawy; }
            set { adresNaprawy = value; }
        }

        public AdresNaprawy( Adres adres)
        {
            AdresN = adres;
        }


    }
}
