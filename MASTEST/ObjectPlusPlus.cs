using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public class ObjectPlusPlus : ObjectPlus
    {
        private Hashtable powiazania = new Hashtable();
        private HashSet<ObjectPlusPlus> wszystkieCzesci = new HashSet<ObjectPlusPlus>();

        public ObjectPlusPlus() : base()
        {
            
        }

        private void dodajPowiazanie(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektDocelowy, Object kwalifikator, int licznik)
        {
            Dictionary<Object, ObjectPlusPlus> powiazaniaObiektu;

            if (licznik < 1)
            {
                return;
            }
            if (powiazania.ContainsKey(nazwaRoli))
            {
                powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)powiazania[nazwaRoli];
            }
            else
            {
                powiazaniaObiektu = new Dictionary<Object, ObjectPlusPlus>();
                powiazania.Add(nazwaRoli, powiazaniaObiektu);
            }
            if (!powiazaniaObiektu.ContainsKey(kwalifikator))
            {
                powiazaniaObiektu.Add(kwalifikator, obiektDocelowy);
                obiektDocelowy.dodajPowiazanie(odwrotnaNazwaRoli, nazwaRoli, this, this, licznik - 1);
            }
        }
        public void dodajPowiazanie(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektDocelowy, Object kwalifikator)
        {
            dodajPowiazanie(nazwaRoli, odwrotnaNazwaRoli, obiektDocelowy, kwalifikator, 2);
        }
        public void dodajPowiazanie(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektDocelowy)
        {
            dodajPowiazanie(nazwaRoli, odwrotnaNazwaRoli, obiektDocelowy, obiektDocelowy);
        }

        public void dodajCzesc(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektCzesc)
        {
            if (wszystkieCzesci.Contains(obiektCzesc))
            {
                throw new Exception("Ta czesc jest już powiazana z jakas caloscia!!!");
            }
            dodajPowiazanie(nazwaRoli, odwrotnaNazwaRoli, obiektCzesc);
            wszystkieCzesci.Add(obiektCzesc);
        }

        public ObjectPlusPlus[] dajPowiazania(string nazwaRoli)
        {
            Dictionary<Object, ObjectPlusPlus> powiazaniaObiektu;
            if (!powiazania.ContainsKey(nazwaRoli))
            {
                throw new Exception("Brak powiazan dla roli " + nazwaRoli);
            }
            powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)powiazania[nazwaRoli];
            return (ObjectPlusPlus[])powiazaniaObiektu.Values.ToArray(); // brak ToArray(new ObjectPlusPlus[0]);

        }

        public void wyswietlPowiazania(string nazwaRoli)
        {
            Dictionary<Object, ObjectPlusPlus> powiazaniaObiektu;
            if (!powiazania.ContainsKey(nazwaRoli))
            {
                //brak powiazania dla tej roli
                throw new Exception("Brak powiazania dla roli : " + nazwaRoli);
            }
            powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)powiazania[nazwaRoli];
            List<ObjectPlusPlus> col = powiazaniaObiektu.Values.ToList();

            Console.WriteLine(this.GetType().Name + " powiazania w roli " + nazwaRoli + " : ");
            foreach (Object obj in col)
            {
                Console.WriteLine(" " + obj);
            }
        }

        public ObjectPlusPlus dajPowiazanyObiekt(string nazwaRoli, Object kwalifikator)
        {
            Dictionary<Object, ObjectPlusPlus> powiazaniaObiektu;
            if (!powiazania.ContainsKey(nazwaRoli))
            {
                throw new Exception("Brak powiazan dla roli : " + nazwaRoli);
            }
            powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)powiazania[nazwaRoli];
            if (!powiazaniaObiektu.ContainsKey(kwalifikator))
            {
                throw new Exception("Brak powiazania dla kwalifikatora : " + kwalifikator);
            }

            return powiazaniaObiektu[kwalifikator];
        }

    }
}
