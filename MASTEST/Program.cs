using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            // ObjectPlus.OdczytajEkstensje();
            var s1 = new Serwisant("Damian", "Dabacki", "123456789", 200.0, "02-554");
            var a1 = new Agent("Damian", "Dabacki", "123456789", new DateTime(
                2007, 2, 1));
            var k1 = new Klient("Kamil", "Kabacki", "512532525", new Adres("nowa", "15/5", "02-554", "Warszawa"));
            var u1 = new Desktop("3010", DateTime.Now, Desktop.TypObudowy.MT, false);
            u1.DodajZlacze(Komputer.TypyZlacz.HDMI,1);
            u1.DodajZlacze(Komputer.TypyZlacz.DP,2);

            var zgloszenie = a1.UtworzZgloszenie("gjhgjh", "gfgfdgf", k1, u1);
            var naprawa = zgloszenie.ZlecNaprawe(DateTime.Now, s1);
            ObjectPlus.PokazEkstensje(typeof(Serwisant));
            ObjectPlus.PokazEkstensje(typeof(Agent));
            ObjectPlus.PokazEkstensje(typeof(Klient));
            ObjectPlus.PokazEkstensje(typeof(ZgloszenieSerwisowe));
            ObjectPlus.PokazEkstensje(typeof(NaprawaSerwisowa));
            zgloszenie.PokazPowiazania();
           
            // naprawa.UsunNaprawe();
            zgloszenie.UsunZgloszenie();

            Console.WriteLine("\n__________________Powiazania po usunieciu__________________");

            zgloszenie.PokazPowiazania();

            Console.WriteLine("\n_________________po usunieciu___________________");

            ObjectPlus.PokazEkstensje(typeof(Serwisant));
            ObjectPlus.PokazEkstensje(typeof(Agent));
            ObjectPlus.PokazEkstensje(typeof(Klient));
            ObjectPlus.PokazEkstensje(typeof(ZgloszenieSerwisowe));
            ObjectPlus.PokazEkstensje(typeof(NaprawaSerwisowa));

           // ObjectPlus.ZapiszEkstensje();
            Console.Read();
        }

    }
}
