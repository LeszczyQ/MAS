using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{

    enum status
    {
        Aktywne,
        Realizowane,
        Zrealizowane,
        Problem

    }

    [Serializable]
    class ZgloszenieSerwisowe
    {
        private static uint licznikZgloszen;
        private uint numerZgłoszenia;
        private DateTime dataZgloszenia;
        private DateTime? dataZakonczenia;
        private string opisUsterki;
        private string diagnostyka;
        private status status;

        private uint LicznikZgloszen
        {
            get { return licznikZgloszen; }
        }
        public uint NumerZgloszenia
        {
            get { return this.numerZgłoszenia; }
        }
        public DateTime DataZgloszenia
        {
            get { return dataZgloszenia; }
           private set { dataZgloszenia = value; }
        }

        public DateTime? DataZakonczenia
        {
            get { return dataZakonczenia; }
            set { dataZakonczenia = value; }
        }
        public string OpisUsterki
        {
            get { return opisUsterki; }
           private set { opisUsterki = value; }
        }
        public string Diagnostyka
        {
            get { return diagnostyka; }
            private set { diagnostyka = value; }
        }

        public status Status
        {
            get { return status; }
            set { status = value; }
        }

        public ZgloszenieSerwisowe(string opisUsterki, string diagnostyka)
        {

            numerZgłoszenia = LicznikZgloszen;
            licznikZgloszen += 1;
            DataZgloszenia = DateTime.Now;
            DataZakonczenia = null;
            OpisUsterki = opisUsterki;
            Diagnostyka = diagnostyka;
            Status = status.Aktywne;


        }

        public string DataToString(DateTime? data)
        {
            if (data.HasValue) {
                return String.Format("{0:dddd dd MMMM yyyy - HH:mm:ss }",data); 
                    }
            else
            {
                return "Zgłoszenie w trakcie realizacji";
            }
        }

        class NaprawaSerwisowa
        {

        }


    }


}
