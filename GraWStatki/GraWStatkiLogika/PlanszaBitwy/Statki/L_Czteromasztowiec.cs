using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    /// <summary>
    /// Statek posiadający cztery pola.
    /// </summary>
    public class L_Czteromasztowiec : L_Statek
    {
        /// <summary>
        /// Konstruktor statku.
        /// </summary>
        /// <param name="ID">Unikalny identyfikator statku.</param>
        public L_Czteromasztowiec(int ID)
        {
            _ID = ID;
            _iloscPol = 4;
        }
    }
}
