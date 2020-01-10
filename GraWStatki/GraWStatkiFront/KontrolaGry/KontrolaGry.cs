using GraWStatkiLogika;
using GraWStatkiLogika.KontrolaGry;
using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiFront.PlanszaBitwy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using GraWStatkiLogika.Interfejsy;
using System.Windows.Input;
using System.Windows;
using GraWStatkiFront.Komputer;

namespace GraWStatkiFront.KontrolaGry
{
    public class G_KontrolaGry
    {
        private L_KontrolerGry _kontroler;

        //Plansze logiczne
        private L_PlanszaBitwy lPlanszaGracza;
        private L_PlanszaBitwy lPlanszaKomputera;

        //Plansze graficzne powstałe z elementów xamla
        private G_PlanszaBitwy gPlanszaGracza;
        private G_PlanszaBitwy gPlanszaKomputera;

        //Gridy z xamla
        private Grid xPlanszaGracza;
        private Grid xPlanszaKomputera;

        //Komputer
        private G_Komputer _komputer;

        public G_KontrolaGry(Grid xPlanszaGracza, Grid xPlanszaKomputera)
        {
            _kontroler = new L_KontrolerGry();

            this.xPlanszaGracza = xPlanszaGracza;
            this.xPlanszaKomputera = xPlanszaKomputera;

            NowaGra(xPlanszaGracza, xPlanszaKomputera, true);
        }

        private void NowaGra(Grid xPlanszaGracza, Grid xPlanszaKomputera, bool czyPierwszaGra)
        {
            lPlanszaGracza = _kontroler.ObecnaGra.PlanszaGracza;
            lPlanszaKomputera = _kontroler.ObecnaGra.PlanszaKomputera;

            gPlanszaGracza = new G_PlanszaBitwy(xPlanszaGracza, lPlanszaGracza, true, czyPierwszaGra);
            gPlanszaKomputera = new G_PlanszaBitwy(xPlanszaKomputera, lPlanszaKomputera, false, czyPierwszaGra);

            _komputer = new G_Komputer(lPlanszaGracza, gPlanszaGracza);

            NasluchujKlikniec(gPlanszaGracza.PlanszaZPrzyciskami, gPlanszaKomputera.PlanszaZPrzyciskami);
        }

        private void NasluchujKlikniec(Button[,] planszaZPrzyciskamiGracza, Button[,] planszaZPrzyciskamiKomputera)
        {
            Button[,] planszaGracza = gPlanszaGracza.PlanszaZPrzyciskami;
            Button[,] planszaKomputera = gPlanszaKomputera.PlanszaZPrzyciskami;

            for (int i = 0; i < planszaGracza.GetLength(0); i++)
            {
                for (int j = 0; j < planszaGracza.GetLength(1); j++)
                {
                    Button buttonGracza = planszaGracza[i, j];
                    buttonGracza.Click += (sender, e) => KliknieciePrzycisku(sender, e);

                    Button buttonKomputera = planszaKomputera[i, j];
                    buttonKomputera.Click += (sender, e) => KliknieciePrzycisku(sender, e);
                }
            }
        }

        private void WyczyscPlansze()
        {
            Button[,] planszaGracza = gPlanszaGracza.PlanszaZPrzyciskami;
            Button[,] planszaKomputera = gPlanszaKomputera.PlanszaZPrzyciskami;

            for (int i = 0; i < planszaGracza.GetLength(0); i++)
            {
                for (int j = 0; j < planszaGracza.GetLength(1); j++)
                {
                    xPlanszaGracza.Children.Remove(planszaGracza[i, j]);
                    xPlanszaKomputera.Children.Remove(planszaKomputera[i, j]);
                }
            }
        }

        public void KliknieciePrzycisku(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            int i = Grid.GetRow(button);
            int j = Grid.GetColumn(button);

            Grid buttonParent = (Grid)button.Parent;

            IPole[,] polaPlanszy;

            //Tura gracza
            if (_kontroler.CzyTuraGracza)
            {
                if(buttonParent == xPlanszaGracza)
                {
                    return;
                }
                else
                {
                    polaPlanszy = lPlanszaKomputera.Pola;
                }
            }
            //Tura komputera
            else
            {
                if (buttonParent == xPlanszaKomputera)
                {
                    return;
                }
                else
                {
                    polaPlanszy = lPlanszaGracza.Pola;
                }
            }

            bool trafionoPole = false;
            IPole pole = polaPlanszy[i, j];
            //Jeżeli pole już zostało trafione, nic się nie dzieje
            if (pole.Trafione)
            {
                return;
            }

            if (pole.Zajete)
            {
                button.Background = G_PlanszaBitwy.KolorZHex("#990000");
                pole.Trafione = true;
                trafionoPole = true;
            }
            else
            {
                button.Background = G_PlanszaBitwy.KolorZHex("#CCCCCC");
                pole.Trafione = true;
            }

            _kontroler.SprawdzRuch(trafionoPole);

            if (_kontroler.GraSkonczona)
            {
                _kontroler.ZakonczGre();

                WyczyscPlansze();
                _kontroler.NowaGra();
                NowaGra(xPlanszaGracza, xPlanszaKomputera, false);
            }
            else if (!_kontroler.CzyTuraGracza)
            {
                _komputer.WykonajRuch();
            }
        }
    }
}
