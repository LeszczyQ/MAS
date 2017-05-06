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
            Serwisant s1 = new Serwisant("Damian", "Dabacki", "123456789",200.0,"02-554");
            Agent a1 = new Agent("Damian", "Dabacki", "123456789", new DateTime(
                2007,2,1));
            
            //Agent a2 = new Agent("Marcin", "Mamacki", "123456789", DateTime.Now);
            //Klient k1 = new Klient("Kamil", "Kabacki", "512532525", new Adres("nowa", "15/5", "02-554", "Warszawa"));
            //Klient k2 = new Klient("Marcin", "Mabacki", "512532525", new Adres("nowa", "15/5", "02-554", "Warszawa"));
            ZgloszenieSerwisowe z1 = new ZgloszenieSerwisowe("cssdsds", "efefefefef");

            a1.DodajPowiazanie(Agent.Rola.Obsluguje.ToString(), ZgloszenieSerwisowe.Rola.ObslugiwanePrzez.ToString(), z1);
            a1.WyswietlPowiazania(Agent.Rola.Obsluguje.ToString());
            z1.WyswietlPowiazania(ZgloszenieSerwisowe.Rola.ObslugiwanePrzez.ToString());

            ObjectPlus.PokazEkstensje(typeof(Serwisant));
            ObjectPlus.PokazEkstensje(typeof(Agent));
            ObjectPlus.PokazEkstensje(typeof(ZgloszenieSerwisowe));
            //ObjectPlus.PokazEkstensje(typeof(Klient));

           // ObjectPlus.ZapiszEkstensje();
            Console.Read();
        }

    }
}
