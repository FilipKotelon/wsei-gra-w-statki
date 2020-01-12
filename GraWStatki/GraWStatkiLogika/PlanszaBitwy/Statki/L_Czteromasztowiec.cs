using GraWStatkiLogika.Interfejsy;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    class L_Czteromasztowiec : IStatek
    {
        private int _ID;
        private int _iloscPol;
        private bool _zatopiony;
        private List<IPole> _pola = new List<IPole>();

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

        public List<IPole> Pola
        {
            get
            {
                return _pola;
            }
        }

        public L_Czteromasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 4;
        }

        public IPole DodajPole()
        {
            IPole pole = new L_PoleZajete(_ID);
            _pola.Add(pole);

            return pole;
        }

        public void SprawdzStan()
        {
            bool zatopiony = true;
            foreach (IPole pole in _pola)
            {
                if (!pole.Trafione)
                {
                    zatopiony = false;
                    break;
                }
            }
            _zatopiony = zatopiony;
        }
    }
}
