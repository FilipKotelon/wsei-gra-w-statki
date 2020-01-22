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
using System.Windows.Controls.Primitives;
using GraWStatkiLogika.Komputer;

namespace GraWStatkiFront.KontrolaGry
{
    /// <summary>
    /// Tutaj znajduje się połączenie kontroli interfejsu użytkownika z kontrolą stanu gry
    /// </summary>
    public class G_KontrolaGry
    {
        /// <summary>
        /// Kontroler przechowujący stan gry
        /// </summary>
        private L_KontrolerGry _kontroler;

        /// <summary>
        /// Plansza logiczna gracza
        /// </summary>
        private L_PlanszaBitwy lPlanszaGracza;

        /// <summary>
        /// Plansza logiczna komputera
        /// </summary>
        private L_PlanszaBitwy lPlanszaKomputera;

        /// <summary>
        /// Plansza graficzna gracza powstała z elementów xamla
        /// </summary>
        private G_PlanszaBitwy gPlanszaGracza;

        /// <summary>
        /// Plansza graficzna komputera powstała z elementów xamla
        /// </summary>
        private G_PlanszaBitwy gPlanszaKomputera;

        /// <summary>
        /// Grid gracza
        /// </summary>
        private Grid xPlanszaGracza;

        /// <summary>
        /// Grid komputera
        /// </summary>
        private Grid xPlanszaKomputera;

        /// <summary>
        /// Komputer rywalizujący z graczem
        /// </summary>
        private G_Komputer _komputer;

        /// <summary>
        /// Przycisk odsłaniający popup z wyborem trudności
        /// </summary>
        private Button _przyciskNowejGry;

        /// <summary>
        /// Pole, w którym są wyświetlane komunikaty odnośnie obecnego stanu gry
        /// </summary>
        private TextBlock _komunikat;

        /// <summary>
        /// Popup z wyborem poziomu trudności
        /// </summary>
        private Popup _popupTrudnosci;

        /// <summary>
        /// Przyciski do wybrania poziomu trudności
        /// </summary>
        private List<Button> _przyciskiPoziomowTrudnosci;

        /// <summary>
        /// Flaga pozwalająca sprawdzić, czy obecna gra jest pierwszą grą. Sprawdzana przy czyszczeniu planszy i tworzeniu nowego grida.
        /// </summary>
        private bool _pierwszaGra = true;

        /// <summary>
        /// Flaga pozwalająca sprawdzić, czy obecny ruch jest pierwszym ruchem w grze.
        /// </summary>
        private bool _pierwszyRuch = true;

        /// <summary>
        /// Konstruktor kontrolera gry.
        /// </summary>
        /// <param name="xPlanszaGracza">Grid należący do gracza</param>
        /// <param name="xPlanszaKomputera">Grid należący do komputera</param>
        /// <param name="przyciskNowejGry">Przycisk, którym rozpoczyna się nową grę</param>
        /// <param name="komunikat">Miejsce, w którym będą wyświetlane komunikaty dla gracza</param>
        /// <param name="popupTrudnosci">Popup, w którym mozna wybrać poziom trudności rozgrywki</param>
        /// <param name="przyciskiPoziomowTrudnosci">Lista przycisków pozwalających na wybranie poziomu trudności</param>
        public G_KontrolaGry(Grid xPlanszaGracza, Grid xPlanszaKomputera, Button przyciskNowejGry, TextBlock komunikat, Popup popupTrudnosci, List<Button> przyciskiPoziomowTrudnosci)
        {
            _kontroler = new L_KontrolerGry();

            this.xPlanszaGracza = xPlanszaGracza;
            this.xPlanszaKomputera = xPlanszaKomputera;

            _przyciskNowejGry = przyciskNowejGry;
            _przyciskNowejGry.Click += KlikniecieNowejGry;

            _komunikat = komunikat;
            _popupTrudnosci = popupTrudnosci;
            _przyciskiPoziomowTrudnosci = przyciskiPoziomowTrudnosci;

            PodepnijWyborTrudnosci();
        }

        /// <summary>
        /// Rozpoczęcie nowej gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlikniecieNowejGry(Object sender, RoutedEventArgs e)
        {
            if (!_kontroler.CzyTuraGracza && !_kontroler.GraSkonczona && !_pierwszaGra) return;

            _popupTrudnosci.IsOpen = true;
        }

        /// <summary>
        /// Funkcja rozpoczynająca nową grę.
        /// Najpierw tworzy nową grę w kontrolerze logicznym, a potem pobiera z niego plansze logiczne i na ich podstawie buduje plansze z przycisków.
        /// </summary>
        /// <param name="xPlanszaGracza"></param>
        /// <param name="xPlanszaKomputera"></param>
        /// <param name="czyPierwszaGra"></param>
        /// <param name="poziomTrudnosci"></param>
        private void NowaGra(Grid xPlanszaGracza, Grid xPlanszaKomputera, bool czyPierwszaGra, PoziomTrudnosci poziomTrudnosci)
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

            _komputer = new G_Komputer(this, lPlanszaGracza, gPlanszaGracza, poziomTrudnosci);

            _pierwszyRuch = true;

            ZmienAktywnaPlansze(_kontroler.CzyTuraGracza);

            NasluchujKlikniec();
        }

        /// <summary>
        /// Funkcja ustalająca poziom trudności rozgrywki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="poziomTrudnosci">Jeden z trzech poziomów: Latwy, Zaawansowany, Trudny</param>
        private void WybierzPoziomTrudnosci(Object sender, RoutedEventArgs e, PoziomTrudnosci poziomTrudnosci)
        {
            NowaGra(xPlanszaGracza, xPlanszaKomputera, _pierwszaGra, poziomTrudnosci);
            _popupTrudnosci.IsOpen = false;
        }

        /// <summary>
        /// Dodanie event listenerów dla przycisków pozwalających wybrać poziom trudności
        /// </summary>
        private void PodepnijWyborTrudnosci()
        {
            for(int i = 0; i < _przyciskiPoziomowTrudnosci.Count; i++)
            {
                Button przycisk = _przyciskiPoziomowTrudnosci[i];

                if (przycisk.Name == "PoziomLatwy")
                {
                    przycisk.Click += (sender, e) => WybierzPoziomTrudnosci(sender, e, PoziomTrudnosci.Latwy);
                }
                else if (przycisk.Name == "PoziomZaawansowany")
                {
                    przycisk.Click += (sender, e) => WybierzPoziomTrudnosci(sender, e, PoziomTrudnosci.Zaawansowany);
                }
                else if (przycisk.Name == "PoziomTrudny")
                {
                    przycisk.Click += (sender, e) => WybierzPoziomTrudnosci(sender, e, PoziomTrudnosci.Trudny);
                }
            }
        }

        /// <summary>
        /// Dodanie event listenerów dla pól komputera.
        /// </summary>
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


        /// <summary>
        /// Wyczyszczenie obu plansz z przycisków.
        /// </summary>
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

        /// <summary>
        /// Zmiana komunikatu zależnie od tego, czy trafiono lub zatopiono statek.
        /// </summary>
        /// <param name="czyTrafiono"></param>
        /// <param name="zatopionoStatek"></param>
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

        /// <summary>
        /// Zmiana aktywnej planszy zależnie od obecnej tury.
        /// Plansza nieaktywna jest półprzezroczysta.
        /// </summary>
        /// <param name="czyTuraGracza"></param>
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

        /// <summary>
        /// Funkcja pobierająca kliknięty przez gracza przycisk i przekazująca go funkcji KliknieciePrzycisku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlikniecieGracza(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.Source;

            KliknieciePrzycisku(button);
        }

        /// <summary>
        /// Funkcja obsługująca kliknięcie przycisku i zaznaczająca trafienie na planszy logicznej.
        /// </summary>
        /// <param name="button">Trafiony przycisk</param>
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

            //Oznaczenie pola w zależności od tego czy jest zajęte, czy nie
            if (pole.Zajete)
            {
                button.Background = G_PlanszaBitwy.KolorZHex("#AA0000", 0.9);
                pole.Trafione = true;
                trafionoStatek = true;

                //Sprawdzenie stanu statku po trafieniu
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

            //Kontroler sprawdza stan gry po trafieniu pola
            _kontroler.SprawdzRuch(trafionoStatek);

            ZmienKomunikat(trafionoStatek, zatopionoStatek);

            //Zakończenie gry
            if (_kontroler.GraSkonczona)
            {
                _kontroler.ZakonczGre();

                _komunikat.Text = $"Grę wygrał {_kontroler.ObecnaGra.zwyciezca} w {_kontroler.LicznikTur} turach!";
            }
            //Komputer wykonuje ruch, jeśli właśnie kończy się tura gracza
            else if (!_kontroler.CzyTuraGracza)
            {
                await Task.Delay(1000);
                _komputer.WykonajRuch();
            }

            //Jeżeli gra nie jest skończona, zmień aktywną planszę
            if (!_kontroler.GraSkonczona)
            {
                ZmienAktywnaPlansze(_kontroler.CzyTuraGracza);
                _pierwszyRuch = false;
            }
        }
    }
}
