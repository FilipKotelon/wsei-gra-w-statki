using GraWStatkiLogika.PlanszaBitwy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.KontrolaGry
{
    /// <summary>
    /// Instancja obecnej gry, zawierająca w sobie plansze gracza i komputera oraz zwycięzcę gry.
    /// </summary>
    public class L_Gra
    {
        public string zwyciezca;
        private string _gracz = "Gracz";
        private string _komputer = "Komputer";

        private L_PlanszaBitwy _planszaGracza;
        private L_PlanszaBitwy _planszaKomputera;

        /// <summary>
        /// Dane o planszy gracza.
        /// </summary>
        public L_PlanszaBitwy PlanszaGracza
        {
            get
            {
                return _planszaGracza;
            }
        }

        /// <summary>
        /// Dane o planszy komputera.
        /// </summary>
        public L_PlanszaBitwy PlanszaKomputera
        {
            get
            {
                return _planszaKomputera;
            }
        }

        /// <summary>
        /// String z nazwą gracza == "Gracz"
        /// </summary>
        public string Gracz
        {
            get
            {
                return _gracz;
            }
        }

        /// <summary>
        /// String z nazwą komputera == "Komputer"
        /// </summary>
        public string Komputer
        {
            get
            {
                return _komputer;
            }
        }

        /// <summary>
        /// Konstruktor nowej gry.
        /// </summary>
        public L_Gra()
        {
            _planszaGracza = new L_PlanszaBitwy();
            _planszaKomputera = new L_PlanszaBitwy();
        }
    }
}
