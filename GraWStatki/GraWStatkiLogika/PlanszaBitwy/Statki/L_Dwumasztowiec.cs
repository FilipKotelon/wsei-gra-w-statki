using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    /// <summary>
    /// Statek posiadający dwa pola.
    /// </summary>
    public class L_Dwumasztowiec : L_Statek
    {
        /// <summary>
        /// Konstruktor statku.
        /// </summary>
        /// <param name="ID">Unikalny identyfikator statku.</param>
        public L_Dwumasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 2;
        }
    }
}
