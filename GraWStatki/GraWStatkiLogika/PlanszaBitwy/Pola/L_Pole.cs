using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    /// <summary>
    /// Logiczne przedstawienie pola na planszy.
    /// </summary>
    public class L_Pole
    {
        protected bool _zajete;
        protected bool _trafione;
        protected int _IDStatku;

        /// <summary>
        /// Pola zajęte należą do statków i trafienie ich decyduje o wygraniu gry.
        /// </summary>
        public bool Zajete
        {
            get
            {
                return _zajete;
            }
        }

        /// <summary>
        /// Pola trafione są odsłonięte graficznie.
        /// </summary>
        public bool Trafione
        {
            get
            {
                return _trafione;
            }
            set
            {
                _trafione = value;
            }
        }

        /// <summary>
        /// ID statku, do którego należy dane pole. Jeśli wszystkie pola o danym ID są trafione, to znaczy, że statek o tym samym ID został zatopiony.
        /// </summary>
        public int IDStatku
        {
            get
            {
                return _IDStatku;
            }
        }
    }
}
