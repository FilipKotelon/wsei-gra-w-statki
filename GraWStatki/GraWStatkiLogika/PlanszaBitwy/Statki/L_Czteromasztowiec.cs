using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    public class L_Czteromasztowiec : L_Statek
    {
        /// <summary>
        /// Statek posiadający cztery pola.
        /// </summary>
        /// <param name="ID"></param>
        public L_Czteromasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 4;
        }
    }
}
