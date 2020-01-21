using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    public class L_Jednomasztowiec : L_Statek
    {
        /// <summary>
        /// Statek posiadający jedno pole.
        /// </summary>
        /// <param name="ID"></param>
        public L_Jednomasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 1;
        }
    }
}
