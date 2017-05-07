using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    public enum Status
    {
        Aktywne,
        Realizowane,
        Zrealizowane,
        Problem
    }

    [Serializable]
    public class ZgloszenieSerwisowe : ObjectPlus
    {
   
        public Agent _obslugiwanePrzez { get; set; }
        public Klient _zglaszanePrzez { get; set; }
        public Urzadzenie _dotyczace { get; set; }

        private List<NaprawaSerwisowa> _zawierajace = new List<NaprawaSerwisowa>();

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
        internal class NaprawaSerwisowa : ObjectPlus
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

            // asocjacja z atrybutem
            private List<PodzespolNaprawa> _zuzyla = new List<PodzespolNaprawa>();

            private Serwisant _realizowanaPrzez { get; set; }
            private ZgloszenieSerwisowe _wRamach { get; set; }
            private static int LicznikNapraw { get; set; }
            public int NumerNaprawy { get; set; }
            public DateTime DataRealizacji { get; set; }
            public DateTime? DataZakonczenia { get; set; }
            public Status StatusNaprawy { get; set; }

            // kompozycja - warunek 2 - brak mozliwosci utworzenia czesci bez całości
            private NaprawaSerwisowa(DateTime data)
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
