using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    class L_Czteromasztowiec : L_Statek
    {
        public L_Czteromasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 4;
        }
    }
}
