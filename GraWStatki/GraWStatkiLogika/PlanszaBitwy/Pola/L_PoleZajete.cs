using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    /// <summary>
    /// Pole zajęte, którego trafienie powoduje dodanie ruchu temu, kto obecnie posiada turę, bądź zakończenie gry po trafieniu wszystkich pól zajętych na planszy.
    /// </summary>
    public class L_PoleZajete : L_Pole
    {
        /// <summary>
        /// Konstruktor pola zajętego.
        /// </summary>
        public L_PoleZajete(int IDStatku)
        {
            this._zajete = true;
            this._trafione = false;
            this._IDStatku = IDStatku;
        }
    }
}
