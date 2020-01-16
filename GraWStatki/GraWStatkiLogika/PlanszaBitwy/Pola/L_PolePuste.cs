using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    public class L_PolePuste : L_Pole
    {
        public L_PolePuste()
        {
            this._zajete = false;
            this._trafione = false;
        }
    }
}
