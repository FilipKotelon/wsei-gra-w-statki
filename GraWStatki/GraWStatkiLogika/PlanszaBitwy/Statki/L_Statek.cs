using GraWStatkiLogika.PlanszaBitwy.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    public class L_Statek
    {
        protected int _ID;
        protected int _iloscPol;
        protected bool _zatopiony;
        protected List<L_Pole> _pola = new List<L_Pole>();

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public int IloscPol
        {
            get
            {
                return _iloscPol;
            }
        }

        public bool Zatopiony
        {
            get
            {
                return _zatopiony;
            }
        }

        public List<L_Pole> Pola
        {
            get
            {
                return _pola;
            }
        }

        public void DodajPole(L_Pole pole)
        {
            if (this._pola.Count < this._iloscPol)
            {
                this._pola.Add(pole);
            }
        }

        public void SprawdzStan()
        {
            bool zatopiony = true;

            for(int i = 0; i < this._pola.Count; i++)
            {
                if (!this._pola[i].Trafione)
                {
                    zatopiony = false;
                }
            }

            this._zatopiony = zatopiony;
            if (zatopiony)
            {
                Console.WriteLine("Tonę!");
            }
        }
    }
}
