using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.klasy.plansza_bitwy
{
    public class L_PolePuste : IPole
    {
        private bool _zajete;
        private bool _odsloniete;

        public bool Zajete
        {
            get
            {
                return _zajete;
            }
        }

        public bool Odsloniete
        {
            get
            {
                return _odsloniete;
            }
            set
            {
                _odsloniete = value;
            }
        }

        public L_PolePuste()
        {
            _zajete = false;
            _odsloniete = false;
        }
    }
}
