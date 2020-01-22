using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    /// <summary>
    /// Pole puste, którego trafienie powoduje zmianę tury.
    /// </summary>
    public class L_PolePuste : L_Pole
    {
        /// <summary>
        /// Konstruktor pola pustego.
        /// </summary>
        public L_PolePuste()
        {
            this._zajete = false;
            this._trafione = false;
        }
    }
}
