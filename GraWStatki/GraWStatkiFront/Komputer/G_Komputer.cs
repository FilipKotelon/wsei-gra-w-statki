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

        public G_Komputer(L_PlanszaBitwy lPlanszaGracza, G_PlanszaBitwy gPlanszaGracza)
        {
            _gPlanszaGracza = gPlanszaGracza;
            _lKomputer = new L_Komputer(lPlanszaGracza);
        }

        private void KliknijPole(Button pole)
        {
            pole.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        public async void WykonajRuch()
        {
            int[] indeksy = _lKomputer.LosujPole();

            Button pole = _gPlanszaGracza.PlanszaZPrzyciskami[indeksy[0], indeksy[1]];

            //Odczekaj pół sekundy przed ruchem
            await Task.Delay(1200);
            KliknijPole(pole);
        }
    }
}
