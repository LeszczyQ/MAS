using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class NaprawaSerwisowa : ObjectPlus
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

        // część(NaprawaSerwisowa) połączona tylko z jedną całością(ZgłoszenieSerwisowe)
        private ZgloszenieSerwisowe _wRamach { get; set; }

        private static int LicznikNapraw { get; set; }
        private int NumerNaprawy { get; set; }
        private DateTime DataRealizacji { get; set; }
        private DateTime? DataZakonczenia { get; set; }
        private Status StatusNaprawy { get; set; }


        private NaprawaSerwisowa(DateTime data)
        {
            OdczytajLicznikNapraw();
            NumerNaprawy = LicznikNapraw;
            LicznikNapraw++;
            ZapiszLicznikNapraw();
            DataRealizacji = data;
            DataZakonczenia = null;
            StatusNaprawy = Status.Aktywne;
        }

        //Kompozycja warunek 2 - Brak mozliwosci utworzenia czesci bez całości
        //Kompozycja warunek 1 - Brak współdzielenia części. 
        public static NaprawaSerwisowa UtworzNaprawe(ZgloszenieSerwisowe zgloszenie, DateTime dataRealizacji, Serwisant serwisant)
        {
            if (zgloszenie.Equals(null))
            {
                throw new Exception("Całość nie istnieje!");
            }
            else if (serwisant.Equals(null))
            {
                throw new Exception("Naprawa nie może zostać zrealizowana bez Serwisanta");
            }
            else
            {
                var naprawa = new NaprawaSerwisowa(dataRealizacji)
                {
                    //powiązanie ze Zgłoszeniem występuje tylko w jednym miejscu. brak publicznej metody do dodania powiazania
                    _wRamach = zgloszenie,

                    // dodanie powiązań NaprawaSerwisowa<->Serwisant
                    _realizowanaPrzez = serwisant
                };
                serwisant.PrzypiszDoNaprawy(naprawa);

                return naprawa;
            }
        }
        public Serwisant PrzypisanySerwisant()
        {
            return _realizowanaPrzez;
        }



        public void UsunNaprawe()
        {
            //usuniecie powiazanych obiektow PodzespolNaprawa
            foreach (var czesc in _zuzyla)
            {
                czesc.UsunPodzespolNaprawa();
            }
            // usuniecie powiazania z Serwisantem
            _realizowanaPrzez.UsunPowiazanieNaprawa(this);

            //usuniecie powiazan ze ZgloszeniemSerwisowym
            _wRamach.UsunPowiazanaNaprawe(this);

            // usuniecie z ekstensji
            ObjectPlus.ZwrocEkstensje(typeof(NaprawaSerwisowa)).Remove(this);
        }
        public override string ToString()
        {
            return "Naprawa : " + NumerNaprawy + " z dnia " + DataToString(DataRealizacji) + " status [" + StatusNaprawy + "]";
        }
        public string DataToString(DateTime? data)
        {
            return data.HasValue ? String.Format("{0:dddd dd MMMM yyyy - HH:mm:ss }", data) : "Naprawa w trakcie realizacji";
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
