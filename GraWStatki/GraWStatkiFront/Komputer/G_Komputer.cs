using GraWStatkiFront.KontrolaGry;
using GraWStatkiFront.PlanszaBitwy;
using GraWStatkiLogika.Komputer;
using GraWStatkiLogika.PlanszaBitwy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace GraWStatkiFront.Komputer
{
    class G_Komputer
    {
        private L_Komputer _lKomputer;
        private G_PlanszaBitwy _gPlanszaGracza;
        private G_KontrolaGry _kontroler;

        public G_Komputer(G_KontrolaGry kontroler, L_PlanszaBitwy lPlanszaGracza, G_PlanszaBitwy gPlanszaGracza, PoziomTrudnosci poziomTrudnosci)
        {
            _gPlanszaGracza = gPlanszaGracza;
            _lKomputer = new L_Komputer(lPlanszaGracza, poziomTrudnosci);
            _kontroler = kontroler;
        }

        private void KliknijPole(Button pole)
        {
            //pole.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            _kontroler.KliknieciePrzycisku(pole);
        }

        public async void WykonajRuch()
        {
            int[] indeksy = _lKomputer.LosujPole();

            Button pole = _gPlanszaGracza.PlanszaZPrzyciskami[indeksy[0], indeksy[1]];

            //Odczekaj przed ruchem
            await Task.Delay(1000);
            KliknijPole(pole);
            _lKomputer.SprawdzRuch();
        }
    }
}
