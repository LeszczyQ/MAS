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

            //Adres a4 = new Adres("Kartoflana", "22/3", "02-654", "Warszawa");
            //Klient k1 = new Klient("Adam", "Abacki", new List<string> { "791587887", "448448448" }, "hyc@cyc.pl", a4);

            //Serwisant.ZwiekszPremie(200);
            //Serwisant s1 = new Serwisant("Famian", "Fabacki", new List<string> { "791587887", "448448448" },160.0,"02-200" ,"serwis@serwis.pl");
            //Console.WriteLine(s1.CzyObslugujeKod("02-000"));
            //s1.DodajObslugiwanyKodPocztowy("02-000");
            //Console.WriteLine(s1.CzyObslugujeKod("02-000"));



            //Agent ag1 = new Agent("Daniel", "Dabacki", new List<string> { "791587887", "448448448" }, DateTime.Now);
            //ZgloszenieSerwisowe z1 = new ZgloszenieSerwisowe("cos sie zjebalo", "KLIENT ODMOWIL WSPOLPRACY");
            //ZgloszenieSerwisowe z2 = new ZgloszenieSerwisowe("cos sie znowu zjebalo", " znowu KLIENT ODMOWIL WSPOLPRACY");
            //ag1.DodajPowiazanie("obsluguje", "obslugiwanePrzez", z1);
            //ag1.DodajPowiazanie("obsluguje", "obslugiwanePrzez", z2);

            //Console.WriteLine(z1.ToString());
            //Console.WriteLine(z2.ToString());

            //ag1.WyswietlPowiazania("obsluguje");
            //z1.WyswietlPowiazania("obslugiwanePrzez");
            //z2.WyswietlPowiazania("obslugiwanePrzez");
            ZgloszenieSerwisowe.PokazEkstensje();
            Console.WriteLine(ZgloszenieSerwisowe.Rola.dotyczace.ToString());
            ObjectPlus.ZapiszEkstensje();
            Console.Read();
        }

    }
}
