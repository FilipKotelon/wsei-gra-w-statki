using GraWStatkiLogika;
using GraWStatkiLogika.KontrolaGry;
using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiFront.PlanszaBitwy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GraWStatkiFront.KontrolaGry
{
    public class G_KontrolaGry
    {
        private L_KontrolerGry _kontroler;

        //Plansze logiczne
        private L_PlanszaBitwy lPlanszaGracza;
        private L_PlanszaBitwy lPlanszaKomputera;

        //Plansze graficzne powstałe z elementów xamla
        private G_PlanszaBitwy xPlanszaGracza;
        private G_PlanszaBitwy xPlanszaKomputera;

        public G_KontrolaGry(Grid xPlanszaGracza, Grid xPlanszaKomputera)
        {
            _kontroler = new L_KontrolerGry();

            lPlanszaGracza = _kontroler.ObecnaGra.PlanszaGracza;
            lPlanszaKomputera = _kontroler.ObecnaGra.PlanszaKomputera;

            this.xPlanszaGracza = new G_PlanszaBitwy(xPlanszaGracza, lPlanszaGracza, true);
            this.xPlanszaKomputera = new G_PlanszaBitwy(xPlanszaKomputera, lPlanszaKomputera, false);
        }
    }
}
