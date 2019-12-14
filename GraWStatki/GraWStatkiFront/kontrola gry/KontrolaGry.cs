using GraWStatkiLogika;
using GraWStatkiLogika.klasy.plansza_bitwy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GraWStatkiFront.kontrola_gry
{
    public class KontrolaGry
    {
        private L_KontrolerGry _kontroler;

        //Plansze logiczne
        private L_PlanszaBitwy lPlanszaGracza;
        private L_PlanszaBitwy lPlanszaKomputera;

        //Plansze graficzne powstałe z elementów xamla
        private PlanszaBitwy xPlanszaGracza;
        private PlanszaBitwy xPlanszaKomputera;

        public KontrolaGry(Grid xPlanszaGracza, Grid xPlanszaKomputera)
        {
            _kontroler = new L_KontrolerGry();

            lPlanszaGracza = _kontroler.ObecnaGra.PlanszaGracza;
            lPlanszaKomputera = _kontroler.ObecnaGra.PlanszaKomputera;

            this.xPlanszaGracza = new PlanszaBitwy(xPlanszaGracza, lPlanszaGracza);
            this.xPlanszaKomputera = new PlanszaBitwy(xPlanszaKomputera, lPlanszaKomputera);
        }
    }
}
