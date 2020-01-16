using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    class L_Trojmasztowiec : L_Statek
    {
        public L_Trojmasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 3;
        }
    }
}
