using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    class ZgloszenieSerwisowe : ObjectPlusPlus
    {
        public enum Rola
        {
            zglaszanePrzez,
            obslugiwanePrzez,
            zawierajace,
            dotyczace
        }

        private static int licznikZgloszen;
        private int numerZgloszenia;
        private DateTime dataZgloszenia;
        private DateTime? dataZakonczenia;
        private string opisUsterki;
        private string diagnostyka;
        private status status;

        public static int LicznikZgloszen
        {
            get { return licznikZgloszen; }
            set { licznikZgloszen = value; }
        }
        public int NumerZgloszenia
        {
            get { return numerZgloszenia; }
            set { numerZgloszenia = value; }

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

        public ZgloszenieSerwisowe(string opisUsterki, string diagnostyka, int numer)
        {

            NumerZgloszenia = numer;
            LicznikZgloszen++;
            DataZgloszenia = DateTime.Now;
            DataZakonczenia = null;
            OpisUsterki = opisUsterki;
            Diagnostyka = diagnostyka;
            Status = status.Aktywne;
        }

        public ZgloszenieSerwisowe(string opisUsterki, string diagnostyka)
        {
            NumerZgloszenia = LicznikZgloszen;
            LicznikZgloszen++;
            DataZgloszenia = DateTime.Now;
            DataZakonczenia = null;
            OpisUsterki = opisUsterki;
            Diagnostyka = diagnostyka;
            Status = status.Aktywne;
        }

        public string DataToString(DateTime? data)
        {
            if (data.HasValue)
            {
                return String.Format("{0:dddd dd MMMM yyyy - HH:mm:ss }", data);
            }
            else
            {
                return "Zgłoszenie w trakcie realizacji";
            }
        }



        override
        public string ToString()
        {
            return "Zgłoszenie : " + NumerZgloszenia + " z dnia " + DataToString(DataZgloszenia) + " status [" + Status + "]";
        }

        public static void ZapiszLicznik()
        {
            FileStream stream = File.Create("licznik.data");
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, LicznikZgloszen);
            stream.Close();

        }

        public static void OdczytajLicznik()
        {
            FileStream stream = File.OpenRead("licznik.data");
            var formatter = new BinaryFormatter();
            LicznikZgloszen = (int)formatter.Deserialize(stream);
            stream.Close();

        }

        [Serializable]
        private class NaprawaSerwisowa : ObjectPlusPlus
        {
            private enum STATUS
            {
                aktywne,
                oczekiwanieNaCzesci,
                czesciPobrane,
                technikWDrodze,
                zakonczone,
                problem

            }

            private static int liczbaNapraw;
            private int numerNaprawy;
            private DateTime dataRealizacji;
            private DateTime? dataZakonczenia;
            private STATUS status;

            private int NumerNaprawy
            {
                get { return numerNaprawy; }
                set { numerNaprawy = value; }
            }
            private DateTime DataRealizacji
            {
                get { return dataRealizacji; }
                set { dataRealizacji = value; }
            }
            private DateTime? DataZakonczenia
            {
                get { return dataZakonczenia; }
                set { dataZakonczenia = value; }
            }
            private STATUS Status
            {
                get { return status; }
                set { status = value; }
            }

            //konstruktor   par data = planowana data realizacji zgloszenia
            public NaprawaSerwisowa(DateTime data)
            {
                DataRealizacji = data;
                DataZakonczenia = null;
                Status = STATUS.aktywne;

            }




        }


    }


}
