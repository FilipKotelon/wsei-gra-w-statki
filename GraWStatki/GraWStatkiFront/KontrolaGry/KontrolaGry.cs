using GraWStatkiLogika;
using GraWStatkiLogika.KontrolaGry;
using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiFront.PlanszaBitwy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using GraWStatkiFront.Komputer;
using System.Threading.Tasks;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using GraWStatkiLogika.PlanszaBitwy.Statki;

namespace GraWStatkiFront.KontrolaGry
{
    //TODO
    //1. Uniemożliwić graczowi kliknięcie planszy komputera w trakcie jego tury
    //2. Prześledzić wszystkie możliwe przypadki wywalenia się komputera podczas szukania pól do trafienia
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

        //Przycisk nowej gry
        private Button _przyciskNowejGry;

        //TextBlock z komunikatami
        private TextBlock _komunikat;

        private bool _pierwszaGra = true;
        private bool _pierwszyRuch = true;

        public G_KontrolaGry(Grid xPlanszaGracza, Grid xPlanszaKomputera, Button przyciskNowejGry, TextBlock komunikat)
        {
            _kontroler = new L_KontrolerGry();

            this.xPlanszaGracza = xPlanszaGracza;
            this.xPlanszaKomputera = xPlanszaKomputera;

            _przyciskNowejGry = przyciskNowejGry;
            _przyciskNowejGry.Click += KlikniecieNowejGry;

            _komunikat = komunikat;
        }

        /// <summary>
        /// Rozpoczęcie nowej gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlikniecieNowejGry(Object sender, RoutedEventArgs e)
        {
            if (!_kontroler.CzyTuraGracza && !_kontroler.GraSkonczona) return;

            NowaGra(xPlanszaGracza, xPlanszaKomputera, _pierwszaGra);
        }

        private void NowaGra(Grid xPlanszaGracza, Grid xPlanszaKomputera, bool czyPierwszaGra)
        {
            _kontroler.NowaGra();
            if (_pierwszaGra)
            {
                _pierwszaGra = false;
            }
            else
            {
                WyczyscPlansze();
            }
            _komunikat.Text = $"Rozpocznij!";

            lPlanszaGracza = _kontroler.ObecnaGra.PlanszaGracza;
            lPlanszaKomputera = _kontroler.ObecnaGra.PlanszaKomputera;

            gPlanszaGracza = new G_PlanszaBitwy(xPlanszaGracza, lPlanszaGracza, true, czyPierwszaGra);
            gPlanszaKomputera = new G_PlanszaBitwy(xPlanszaKomputera, lPlanszaKomputera, false, czyPierwszaGra);

            _komputer = new G_Komputer(lPlanszaGracza, gPlanszaGracza, this);

            _pierwszyRuch = true;

            ZmienAktywnaPlansze(_kontroler.CzyTuraGracza);

            NasluchujKlikniec();
        }

        private void NasluchujKlikniec()
        {
            Button[,] planszaKomputera = gPlanszaKomputera.PlanszaZPrzyciskami;

            for (int i = 0; i < planszaKomputera.GetLength(0); i++)
            {
                for (int j = 0; j < planszaKomputera.GetLength(1); j++)
                {
                    Button buttonKomputera = planszaKomputera[i, j];
                    buttonKomputera.Click += KlikniecieGracza;
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

        private void ZmienKomunikat(bool czyTrafiono, bool zatopionoStatek)
        {
            if (czyTrafiono && zatopionoStatek)
            {
                _komunikat.Text = "Trafiony zatopiony!";
            }
            else if (czyTrafiono)
            {
                _komunikat.Text = "Trafiony!";
            }
            else if(!czyTrafiono)
            {
                _komunikat.Text = "Pudło!";
            }
        }

        private async void ZmienAktywnaPlansze(bool czyTuraGracza)
        {
            if (czyTuraGracza)
            {
                if (!_pierwszyRuch)
                {
                    await Task.Delay(1000);
                    _pierwszyRuch = false;
                }
                xPlanszaGracza.Opacity = 0.5;
                xPlanszaKomputera.Opacity = 1;
            }
            else
            {
                xPlanszaGracza.Opacity = 1;
                xPlanszaKomputera.Opacity = 0.5;
            }
        }

        private void KlikniecieGracza(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.Source;

            KliknieciePrzycisku(button);
        }

        public async void KliknieciePrzycisku(Button button)
        {
            //Jeśli gra jest skończona, zablokuj klikanie
            if (_kontroler.GraSkonczona)
            {
                return;
            }

            int i = Grid.GetRow(button);
            int j = Grid.GetColumn(button);

            Grid buttonParent = (Grid)button.Parent;

            L_Pole[,] polaPlanszy;
            L_PlanszaBitwy plansza;

            //Tura gracza
            if (_kontroler.CzyTuraGracza)
            {
                if(buttonParent == xPlanszaGracza)
                {
                    return;
                }
                else
                {
                    plansza = lPlanszaKomputera;
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
                    plansza = lPlanszaGracza;
                }
            }

            polaPlanszy = plansza.Pola;

            bool trafionoStatek = false;
            bool zatopionoStatek = false;
            L_Pole pole = polaPlanszy[i, j];

            //Jeżeli pole już zostało trafione, nic się nie dzieje
            if (pole.Trafione)
            {
                return;
            }

            if (pole.Zajete)
            {
                button.Background = G_PlanszaBitwy.KolorZHex("#AA0000", 0.9);
                pole.Trafione = true;
                trafionoStatek = true;
                L_Statek statek = plansza.Statki[pole.IDStatku];
                statek.SprawdzStan();

                if (statek.Zatopiony)
                {
                    zatopionoStatek = true;
                }
            }
            else
            {
                button.Background = G_PlanszaBitwy.KolorZHex("#AAAAAA", 0.9);
                pole.Trafione = true;
            }

            _kontroler.SprawdzRuch(trafionoStatek);


            ZmienKomunikat(trafionoStatek, zatopionoStatek);

            if (_kontroler.GraSkonczona)
            {
                _kontroler.ZakonczGre();

                _komunikat.Text = $"Grę wygrał {_kontroler.ObecnaGra.zwyciezca} w {_kontroler.LicznikTur} turach!";
            }
            else if (!_kontroler.CzyTuraGracza)
            {
                await Task.Delay(1000);
                _komputer.WykonajRuch();
            }

            if (!_kontroler.GraSkonczona)
            {
                ZmienAktywnaPlansze(_kontroler.CzyTuraGracza);
                _pierwszyRuch = false;
            }
        }
    }
}
