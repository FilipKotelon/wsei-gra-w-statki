using GraWStatkiFront;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika
{
    class Gra
    {
        public string zwyciezca;
        private string _gracz;
        private string _komputer = "Komputer";

        private PlanszaBitwy _planszaGracza;
        private PlanszaBitwy _planszaKomputera;

        public Gra()
        {
            _gracz = "Gracz";
        }
    }
}
