using GraWStatkiLogika.PlanszaBitwy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.KontrolaGry
{
    public class L_Gra
    {
        public string zwyciezca;
        private string _gracz;
        private string _komputer = "Komputer";

        private L_PlanszaBitwy _planszaGracza;
        private L_PlanszaBitwy _planszaKomputera;

        public L_PlanszaBitwy PlanszaGracza
        {
            get
            {
                return _planszaGracza;
            }
        }

        public L_PlanszaBitwy PlanszaKomputera
        {
            get
            {
                return _planszaKomputera;
            }
        }

        public L_Gra()
        {
            _gracz = "Gracz";
            _planszaGracza = new L_PlanszaBitwy();
            _planszaKomputera = new L_PlanszaBitwy();
        }
    }
}
