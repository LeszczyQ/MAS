using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
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

        private Agent _obslugiwanePrzez { get; set; }
        private Klient _zglaszanePrzez { get; set; }
        private Urzadzenie _dotyczace { get; set; }

        private List<NaprawaSerwisowa> _zawierajace = new List<NaprawaSerwisowa>();

        private static int LicznikZgloszen { get; set; }
        private int NumerZgloszenia { get; set; }
        private DateTime DataZgloszenia { get; set; }
        private DateTime? DataZakonczenia { get; set; }

        private string OpisUsterki { get; set; }
        private string Diagnostyka { get; set; }
        private Status Status { get; set; }


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
        public void PrzypiszAgenta(Agent agent)
        {
            _obslugiwanePrzez = agent;
        }

        public void PrzypiszUrzadzenie(Urzadzenie urzadzenie)
        {
            _dotyczace = urzadzenie;
        }
        public string DataToString(DateTime? data)
        {
            return data.HasValue ? String.Format("{0:dddd dd MMMM yyyy - HH:mm:ss }", data) : "Zgłoszenie w trakcie realizacji";
        }

        public int GetNumerZgloszenia()
        {
            return NumerZgloszenia;
        }

        public void PrzypiszKlienta(Klient klient)
        {
            _zglaszanePrzez = klient;
        }

        public NaprawaSerwisowa ZlecNaprawe(DateTime dataRealizacji, Serwisant serwisant)
        {
            //dodanie powiazan ZgloszenieSerwisowe<->NaprawaSerwisowa
            var naprawa = NaprawaSerwisowa.UtworzNaprawe(this, dataRealizacji, serwisant);
            _zawierajace.Add(naprawa);
            return naprawa;
        }

        //Kompozycja warunek 3 - Usuwanie części przy usunięciu całości. 
        public void UsunZgloszenie()
        {
            // usuniecie powiazania z Agentem 
            _obslugiwanePrzez.UsunPowiazanieZeZgloszeniem(this);
            //usuniecie powiazania z Klientem
            _zglaszanePrzez.UsunPowiazanieZeZgloszeniem(this);
            // usuniecie powiazania z Urzadzeniem
            _dotyczace.UsunPowiazanieZeZgloszeniem(this);

            //usuniecie powiazanych napraw
            for (int i = _zawierajace.Count - 1; i >= 0; i--)
            {
                    _zawierajace[i].UsunNaprawe(); 
            }

            //usuniecie zgloszenia
            ObjectPlus.ZwrocEkstensje(typeof(ZgloszenieSerwisowe)).Remove(this);
        }

    public void UsunPowiazanaNaprawe(NaprawaSerwisowa naprawa)
    {
        _zawierajace.Remove(naprawa);
    }

        public void PokazPowiazania()
        {
            Console.WriteLine("\n Powiązania: Agent");
            Console.WriteLine(_obslugiwanePrzez.ToString());

            Console.WriteLine("\n Powiązania: Klient");
            Console.WriteLine(_zglaszanePrzez.ToString());

            Console.WriteLine("\n Powiązania: Urządzenie");
            Console.WriteLine(_dotyczace.ToString());

            Console.WriteLine("\n Powiązania: NaprawaSerwisowa");
            foreach (var naprawa in _zawierajace)
            {
                Console.WriteLine(naprawa.ToString());
            }
        }
    
    public override string ToString()
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
}
}
