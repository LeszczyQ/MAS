using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    class Program
    {
        static void Main(string[] args)
        {

            Agent a1 = new Agent("Damian", "Dabacki","123456789", DateTime.Now);
            Klient k1 = new Klient("Kamil", "Kabacki", "512532525", new Adres("nowa", "15/5", "02-554", "Warszawa"));
            Klient k2 = new Klient("Marcin", "Mabacki", "512532525", new Adres("nowa", "15/5", "02-554", "Warszawa"));

            //ObjectPlus.PokazEkstensje(typeof(Agent));



            ZgloszenieSerwisowe z1 = a1.UtworzZgloszenie(k1, "coś się tam zadziało", "inne pamięci - ok");
            a1.UtworzZgloszenie(k2, "cos nowego", "klient odmowil wspolpracy");
            a1.WyswietlPowiazania("obsluguje");
            k1.WyswietlPowiazania("zglasza");
            k2.WyswietlPowiazania("zglasza");
            z1.WyswietlPowiazania("obslugiwanePrzez");
            


            //ObjectPlus.PokazEkstensje(typeof(ZgloszenieSerwisowe));
            // ObjectPlus.ZapiszEkstensje();
            Console.Read();
        }

    }
}
