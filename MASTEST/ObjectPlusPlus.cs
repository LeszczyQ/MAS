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
        //Przechowuje informacje o wszystkich powiazaniach tego obiekt
        private Hashtable powiazania = new Hashtable();

        //Przechowuje informacje o wszystkich czesciach powiazanych z ktorymkolwiek z obiektow.
        private HashSet<ObjectPlusPlus> wszystkieCzesci = new HashSet<ObjectPlusPlus>();

        //konstruktor
        public ObjectPlusPlus() : base()
        {
            
        }

        private void DodajPowiazanie(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektDocelowy, Object kwalifikator, int licznik)
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

            if (powiazaniaObiektu.ContainsKey(kwalifikator)) return;
            powiazaniaObiektu.Add(kwalifikator, obiektDocelowy);
            obiektDocelowy.DodajPowiazanie(odwrotnaNazwaRoli, nazwaRoli, this, this, licznik - 1);
        }
       

        public void DodajPowiazanie(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektDocelowy, Object kwalifikator)
        {
           DodajPowiazanie(nazwaRoli, odwrotnaNazwaRoli, obiektDocelowy, kwalifikator, 2);
        }

        public void DodajPowiazanie(String nazwaRoli, String odwrotnaNazwaRoli, ObjectPlusPlus obiektDocelowy)
        {
            DodajPowiazanie(nazwaRoli, odwrotnaNazwaRoli, obiektDocelowy, obiektDocelowy);
        }

        public void DodajCzesc(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektCzesc)
        {
            if (wszystkieCzesci.Contains(obiektCzesc))
            {
                throw new Exception("Ta czesc jest już powiazana z jakas caloscia!!!");
            }
            DodajPowiazanie(nazwaRoli,odwrotnaNazwaRoli,obiektCzesc);
            wszystkieCzesci.Add(obiektCzesc);
        }

        public ObjectPlusPlus[] DajPowiazania(string nazwaRoli)
        {
            if (!powiazania.ContainsKey(nazwaRoli))
            {
                throw new Exception("Brak powiazan dla roli " + nazwaRoli);
            }
            var powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)powiazania[nazwaRoli];
            return (ObjectPlusPlus[])powiazaniaObiektu.Values.ToArray(); // brak ToArray(new ObjectPlusPlus[0]);

        }

        public void WyswietlPowiazania(string nazwaRoli)
        {
            if (!powiazania.ContainsKey(nazwaRoli))
            {
                //brak powiazania dla tej roli
                throw new Exception("Brak powiazania dla roli : " + nazwaRoli);
            }
            var powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)powiazania[nazwaRoli];
            List<ObjectPlusPlus> col = powiazaniaObiektu.Values.ToList();
            Console.WriteLine("\n------------------------------------------\n");
            Console.WriteLine(this.GetType().Name + " powiazania w roli " + nazwaRoli + " : ");
            foreach (Object obj in col)
            {
                Console.WriteLine(" " + obj.ToString());
            }
        }

        public ObjectPlusPlus DajPowiazanyObiekt(string nazwaRoli, Object kwalifikator)
        {
            if (!powiazania.ContainsKey(nazwaRoli))
            {
                throw new Exception("Brak powiazan dla roli : " + nazwaRoli);
            }
            var powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)powiazania[nazwaRoli];
            if (!powiazaniaObiektu.ContainsKey(kwalifikator))
            {
                throw new Exception("Brak powiazania dla kwalifikatora : " + kwalifikator);
            }

            return powiazaniaObiektu[kwalifikator];
        }
        public void UsunPowiazanie(string nazwaRoli, string odwrotnaNazwaRoli, ObjectPlusPlus obiektDocelowy)
        {
            var powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)this.powiazania[nazwaRoli];
            powiazaniaObiektu.Remove(obiektDocelowy);

            powiazaniaObiektu = (Dictionary<Object, ObjectPlusPlus>)obiektDocelowy.powiazania[odwrotnaNazwaRoli];
            powiazaniaObiektu.Remove(this);
        }
        public void UsunObiekt()
        {
            if (this.GetType().Equals(typeof(Agent)))
            {

            }

            
        }
    }
}
