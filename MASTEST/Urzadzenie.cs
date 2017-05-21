using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASTEST
{
    [Serializable]
    public abstract class Urzadzenie : ObjectPlus
    {

        // asocjacja kwalifikowana, kwalifikator = NumerZgloszenia, wartosc = ZgloszenieSerwisowe
        private Dictionary<int,ZgloszenieSerwisowe> _zgloszoneWRamach = new Dictionary<int, ZgloszenieSerwisowe>();

        // asocjacja binarna
        private Klasa _zKlasy { get; set; }

        //asocjacja z atrybutem
        private List<PodzespolUrzadzenie> _skladaSieZ = new List<PodzespolUrzadzenie>();

        private int NumerSeryjny { get; set; }

        private string Model { get; set; }

        public DateTime DataZakupu { get; set; }

        protected Urzadzenie(string model, DateTime dataZakupu):base()
        {
            Model = model;
            DataZakupu = dataZakupu;
        }

        public void PrzypiszZgloszenie(ZgloszenieSerwisowe zgloszenie)
        {
            _zgloszoneWRamach.Add(zgloszenie.GetNumerZgloszenia(),zgloszenie);
        }
        public void UsunPowiazanieZeZgloszeniem(ZgloszenieSerwisowe zgloszenie)
        {
            _zgloszoneWRamach.Remove(zgloszenie.GetNumerZgloszenia());
        }


        //asocjacja z atrybutem
        public void DodajPodzespol(Podzespol podzespol, int ilosc)
        {
           var pu = new PodzespolUrzadzenie(ilosc);   
           pu.DodajPodzespolDoUrzadzenia(podzespol, this); 
           _skladaSieZ.Add(pu);
           podzespol.PowiazZUrzadzeniem(pu);
        }

        //asocjacja Kwalifikowana
        public ZgloszenieSerwisowe DajZgloszenieSerwisowe(int numerZgloszenia)
        {
            if (_zgloszoneWRamach.ContainsKey(numerZgloszenia))
            {
                return _zgloszoneWRamach[numerZgloszenia];
            }
           else throw new Exception("Brak takiego zgloszenia serwisowego");
        }    

        public override string ToString()
        {
            return "\nNumer seryjny: "+NumerSeryjny+"\nModel :" + Model + "\nData zakupu : [" + DataZakupu + "]\n";
        }
    }
}
