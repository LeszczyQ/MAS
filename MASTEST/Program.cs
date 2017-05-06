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
            ObjectPlus.OdczytajEkstensje();

            Agent a1 = new Agent("Damian", "Dabacki","123456789", DateTime.Now);
            Agent a2 = new Agent("Marcin", "Mamacki", "123456789", DateTime.Now);
            Klient k1 = new Klient("Kamil", "Kabacki", "512532525", new Adres("nowa", "15/5", "02-554", "Warszawa"));
            Klient k2 = new Klient("Marcin", "Mabacki", "512532525", new Adres("nowa", "15/5", "02-554", "Warszawa"));
            ZgloszenieSerwisowe z1 = new ZgloszenieSerwisowe("cssdsds", "efefefefef");


            ObjectPlus.PokazEkstensje(typeof(Agent));

            ObjectPlus.PokazEkstensje(typeof(Klient));

            ObjectPlus.ZapiszEkstensje();
            Console.Read();
        }

    }
}
