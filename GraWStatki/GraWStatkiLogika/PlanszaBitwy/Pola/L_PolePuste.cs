using GraWStatkiLogika.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    public class L_PolePuste : IPole
    {
        private bool _zajete;
        private bool _trafione;

        public bool Zajete
        {
            get
            {
                return _zajete;
            }
        }

        public bool Trafione
        {
            get
            {
                return _trafione;
            }
            set
            {
                _trafione = value;
            }
        }

        public L_PolePuste()
        {
            _zajete = false;
            _trafione = false;
        }
    }
}
