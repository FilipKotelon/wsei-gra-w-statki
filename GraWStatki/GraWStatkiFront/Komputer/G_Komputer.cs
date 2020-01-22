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
    /// <summary>
    /// Komputer, grający z przeciwnikiem. Wykonując ruch, otrzymuje wylosowane pole i strzela w przycisk z nim powiązany na planszy graficznej.
    /// </summary>
    class G_Komputer
    {
        private L_Komputer _lKomputer;
        private G_PlanszaBitwy _gPlanszaGracza;
        private G_KontrolaGry _kontroler;

        /// <summary>
        /// Konstruktor komputera.
        /// </summary>
        /// <param name="kontroler">Kontroler graficzny gry</param>
        /// <param name="lPlanszaGracza">Plansza logiczna gracza</param>
        /// <param name="gPlanszaGracza">Plansza graficzna gracza</param>
        /// <param name="poziomTrudnosci">Poziom trudnościu komputera logicznego</param>
        public G_Komputer(G_KontrolaGry kontroler, L_PlanszaBitwy lPlanszaGracza, G_PlanszaBitwy gPlanszaGracza, PoziomTrudnosci poziomTrudnosci)
        {
            _gPlanszaGracza = gPlanszaGracza;
            _lKomputer = new L_Komputer(lPlanszaGracza, poziomTrudnosci);
            _kontroler = kontroler;
        }

        /// <summary>
        /// Kliknięcie przycisku odpowiadającego danemu polu na planszy logicznej.
        /// </summary>
        /// <param name="pole"></param>
        private void KliknijPole(Button pole)
        {
            _kontroler.KliknieciePrzycisku(pole);
        }

        /// <summary>
        /// Wylosowanie pola i strzelenie w odpowiadający mu na gridzie przycisk.
        /// </summary>
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
