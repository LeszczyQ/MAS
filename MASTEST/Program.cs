﻿using System;
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

           // Agent a1 = new Agent("Damian", "Dabacki","123456789", DateTime.Now);
            //a1.DodajNumerKontaktowy("612612612");
            //a1.DodajNumerKontaktowy("626626626");

            //ObjectPlus.PokazEkstensje(typeof(Agent));


            //ObjectPlus.OdczytajEkstensje();

            ZgloszenieSerwisowe z1 = new ZgloszenieSerwisowe("komputer nie bootuje", "HdTune odnalazl bledne sektory");
            ZgloszenieSerwisowe z2 = new ZgloszenieSerwisowe("brak reakcji na przycisk power", "bez baterii - to samo, bez pamięci i dysku - to samo");
            ZgloszenieSerwisowe z3 = new ZgloszenieSerwisowe("nie laczy sie z siecia wlan", " sterowniki - aktualne, w trybie awaryjnym - to samo, inna siec - to samo");
           

           

            ObjectPlus.PokazEkstensje(typeof(ZgloszenieSerwisowe));
            ObjectPlus.ZapiszEkstensje();
            Console.Read();
        }

    }
}
