using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    public class L_Pole
    {
        protected bool _zajete;
        protected bool _trafione;

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
    }
}
