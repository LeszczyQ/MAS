using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    enum Status
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
            ZglaszanePrzez,
            ObslugiwanePrzez,
            Zawierajace,
            Dotyczace
        }

        
        private static int LicznikZgloszen { get; set; }
        public int NumerZgloszenia { get; set; }
        public DateTime DataZgloszenia { get; set; }
        public DateTime? DataZakonczenia { get; set; }

        public string OpisUsterki { get; set; }
        public string Diagnostyka { get; set; }
        public Status Status { get; set; }

        public ZgloszenieSerwisowe(string opisUsterki, string diagnostyka)
        {
            OdczytajLicznik();
            NumerZgloszenia = LicznikZgloszen;
            LicznikZgloszen++;
            ZapiszLicznik();
            DataZgloszenia = DateTime.Now;
            DataZakonczenia = null;
            OpisUsterki = opisUsterki;
            Diagnostyka = diagnostyka;
            Status = Status.Aktywne;
        }

        public string DataToString(DateTime? data)
        {
            return data.HasValue ? String.Format("{0:dddd dd MMMM yyyy - HH:mm:ss }", data) : "Zgłoszenie w trakcie realizacji";
        }

        override
        public string ToString()
        {
            return "Zgłoszenie : " + NumerZgloszenia + " z dnia " + DataToString(DataZgloszenia) + " status [" + Status + "]";
        }

        private static void ZapiszLicznik()
        {
            FileStream stream = File.Create("licznik.data");
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, LicznikZgloszen);
            stream.Close();
        }

        private static void OdczytajLicznik()
        {
            FileStream stream = File.OpenRead("licznik.data");
            var formatter = new BinaryFormatter();
            LicznikZgloszen = (int)formatter.Deserialize(stream);
            stream.Close();
        }

        [Serializable]
        private class NaprawaSerwisowa : ObjectPlusPlus
        {
            public enum Status
            {
                Aktywne,
                OczekiwanieNaCzesci,
                CzesciPobrane,
                TechnikWDrodze,
                Zakonczone,
                Problem
            }
            public enum Rola
            {
                RealizowanaPrzez,
                PodAdresem,
                WRamach,
                Zuzyla
            }

            private static int LicznikNapraw { get; set; }
            public int NumerNaprawy { get; set; }
            public DateTime DataRealizacji { get; set; }
            public DateTime? DataZakonczenia { get; set; }
            public Status StatusNaprawy { get; set; }

            public NaprawaSerwisowa(DateTime data)
            {
                OdczytajLicznik();
                NumerNaprawy = LicznikNapraw;
                LicznikNapraw++;
                ZapiszLicznik();
                DataRealizacji = data;
                DataZakonczenia = null;
                StatusNaprawy = Status.Aktywne;
            }

            private static void ZapiszLicznikNapraw()
            {
                FileStream stream = File.Create("licznikNapraw.data");
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, LicznikNapraw);
                stream.Close();
            }

            private static void OdczytajLicznikNapraw()
            {
                FileStream stream = File.OpenRead("licznikNapraw.data");
                var formatter = new BinaryFormatter();
                LicznikNapraw = (int)formatter.Deserialize(stream);
                stream.Close();
            }

        }
    }
}
