using GraWStatkiLogika.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    class L_Trojmasztowiec : IStatek
    {
        private int _ID;
        private int _iloscPol;
        private bool _zatopiony;
        private List<IPole> _pola;

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

        public L_Trojmasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 3;
        }
    }
}
