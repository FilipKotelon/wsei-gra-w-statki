using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    public class L_PoleZajete : L_Pole
    {
        public L_PoleZajete(int IDStatku)
        {
            this._zajete = true;
            this._trafione = false;
            this._IDStatku = IDStatku;
        }
    }
}
