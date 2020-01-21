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

        /// <summary>
        /// Identyfikator Statku, nadawany również jego polom.
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }
        }

        /// <summary>
        /// Ilość pól statku.
        /// </summary>
        public int IloscPol
        {
            get
            {
                return _iloscPol;
            }
        }

        /// <summary>
        /// Zwraca true, jeśli wszystkie pola statku są trafione.
        /// </summary>
        public bool Zatopiony
        {
            get
            {
                return _zatopiony;
            }
        }

        /// <summary>
        /// Lista pól należących do danego statku.
        /// </summary>
        public List<L_Pole> Pola
        {
            get
            {
                return _pola;
            }
        }

        /// <summary>
        /// Funkcja dodająca nowe pole do statku.
        /// </summary>
        public void DodajPole(L_Pole pole)
        {
            if (this._pola.Count < this._iloscPol && pole.Zajete)
            {
                this._pola.Add(pole);
            }
        }

        /// <summary>
        /// Funkcja sprawdzająca stan statku. Jeśli wszystkie pola statku są trafione, statek zmienia status na zatopiony.
        /// </summary>
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
        }
    }
}
