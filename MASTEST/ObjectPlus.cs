using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class ObjectPlus
    {
        private static Hashtable extensje = new Hashtable();

        public ObjectPlus()
        {
            List<Object> ekstensja = null;
            Type klasa = this.GetType();

            if (ObjectPlus.extensje.ContainsKey(klasa))
            {
                ekstensja = (List<Object>)ObjectPlus.extensje[klasa];
            }
            else
            {
                ekstensja = new List<object>();
                ObjectPlus.extensje.Add(klasa, ekstensja);
            }

            ekstensja.Add(this);
        }

        public void UsunZEkstensji()
        {
            List<Object> ekstensja = null;
            ekstensja = (List<Object>)ObjectPlus.extensje[this.GetType()];
            ekstensja.Remove(this);
        }

        public static void ZapiszEkstensje()
        {
            FileStream stream = File.Create("ekstensje.data");
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, ObjectPlus.extensje);
            stream.Close();
            ZgloszenieSerwisowe.ZapiszLicznik();

        }
        public static void OdczytajEkstensje()
        {
            FileStream stream = File.OpenRead("ekstensje.data");
            var formatter = new BinaryFormatter();
            ObjectPlus.extensje = (Hashtable)formatter.Deserialize(stream);
            stream.Close();
            ZgloszenieSerwisowe.OdczytajLicznik();

        }

        public static void PokazEkstensje(Type klasa)
        {
            List<Object> ekstensja = null;
            if (ObjectPlus.extensje.ContainsKey(klasa))
            {
                ekstensja = (List<Object>)ObjectPlus.extensje[klasa];
            }
            else
            {
                throw new Exception("Nieznana klasa" + klasa.Name);
            }
            Console.WriteLine("\n------------------------------------------\nekstensja klasy: " + klasa.Name);
            foreach (Object obiekt in ekstensja)
            {
                Console.WriteLine(obiekt.ToString());
            }
        }

        public static List<Object> ZwrocEkstensje(Type klasa)
        {
            List<Object> ekstensja = null;
            if (ObjectPlus.extensje.ContainsKey(klasa))
            {
                ekstensja = (List<Object>)ObjectPlus.extensje[klasa];
            }
            else
            {
               // throw new Exception("Nieznana klasa " + klasa.Name);
            }

            return ekstensja;
        }
        

    }
}
