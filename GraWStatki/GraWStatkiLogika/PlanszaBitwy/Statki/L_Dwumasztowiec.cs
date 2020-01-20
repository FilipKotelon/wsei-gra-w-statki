using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    public class L_Dwumasztowiec : L_Statek
    {
        public L_Dwumasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 2;
        }
    }
}
