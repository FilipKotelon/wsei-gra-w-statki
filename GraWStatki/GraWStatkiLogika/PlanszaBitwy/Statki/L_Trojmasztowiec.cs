using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    /// <summary>
    /// Statek posiadający trzy pola.
    /// </summary>
    public class L_Trojmasztowiec : L_Statek
    {
        /// <summary>
        /// Konstruktor statku.
        /// </summary>
        /// <param name="ID">Unikalny identyfikator statku.</param>
        public L_Trojmasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 3;
        }
    }
}
