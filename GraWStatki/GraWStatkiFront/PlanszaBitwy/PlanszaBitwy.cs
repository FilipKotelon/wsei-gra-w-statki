using GraWStatkiLogika;
using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GraWStatkiFront.PlanszaBitwy
{
    /// <summary>
    /// Graficzne przedstawienie planszy wygenerowanej w postaci logicznej.
    /// </summary>
    public class G_PlanszaBitwy
    {
        private Grid _grid;
        private L_PlanszaBitwy _planszaLogiczna;
        private bool _czyPlanszaGracza;
        private Button[,] _planszaZPrzyciskami = new Button[10, 10];

        /// <summary>
        /// Tablica dwuwymiarowa przechowująca przyciski
        /// </summary>
        public Button[,] PlanszaZPrzyciskami
        {
            get
            {
                return _planszaZPrzyciskami;
            }
        }

        /// <summary>
        /// Funkcja zwracająca nową kolumnę o relatywnej szerokości
        /// </summary>
        /// <returns>ColumnDefinition</returns>
        private ColumnDefinition GetKolumna(int iterator)
        {
            ColumnDefinition kolumna = new ColumnDefinition();
            kolumna.Width = new GridLength(1, GridUnitType.Star);
            kolumna.Name = $"Kolumna_{iterator.ToString()}";

            return kolumna;
        }

        /// <summary>
        /// Funkcja zwracająca nowy wiersz o relatywnej wysokości
        /// </summary>
        /// <returns>ColumnDefinition</returns>
        private RowDefinition GetWiersz(int iterator)
        {
            RowDefinition wiersz = new RowDefinition();
            wiersz.Height = new GridLength(1, GridUnitType.Star);
            wiersz.Name = $"Wiersz_{iterator.ToString()}";

            return wiersz;
        }

        /// <summary>
        /// Funkcja tworząca siatkę 10x10
        /// </summary>
        private void TworzSiatke()
        {
            //Dodanie kolumn
            for(int i = 0; i < 10; i++)
            {
                ColumnDefinition kolumna = GetKolumna(i);
                _grid.ColumnDefinitions.Add(kolumna);
            }

            //Dodanie wierszy
            for (int i = 0; i < 10; i++)
            {
                RowDefinition wiersz = GetWiersz(i);
                _grid.RowDefinitions.Add(wiersz);
            }
        }

        /// <summary>
        /// Funkcja wypełniająca planszę polami
        /// </summary>
        private void WypelnijPolami()
        {
            //Dla pól pustych zrobić puste po kliknięciu, dla zajętych wypełnione
            L_Pole[,] polaPlanszy = _planszaLogiczna.Pola;

            for (int i = 0; i < polaPlanszy.GetLength(0); i++)
            {
                for(int j = 0; j < polaPlanszy.GetLength(1); j++)
                {
                    if(polaPlanszy[i, j] != null)
                    {
                        L_Pole pole = polaPlanszy[i, j];
                        
                        Button button = new Button();
                        if (_czyPlanszaGracza)
                        {
                            if (pole.Zajete)
                            {
                                button.Background = KolorZHex("#000000", 0.75);
                                //AnimacjaKoloru(button, KolorZHex("#000000", 0.5), KolorZHex("#000000", 0.75));
                            }
                            else
                            {
                                button.Background = KolorZHex("#FFFFFF", 0.5);
                            }
                        }
                        else
                        {
                            button.Background = KolorZHex("#FFFFFF", 0.2);
                        }

                        button.BorderBrush = KolorZHex("#FFFFFF", .9);
                        button.Cursor = Cursors.Hand;

                        Grid.SetRow(button, i);
                        Grid.SetColumn(button, j);
                        _grid.Children.Add(button);
                        _planszaZPrzyciskami[i, j] = button;
                    }
                }
            }
        }

        /// <summary>
        /// Funkcja zwracająca kolor z kodu heksadecymalnego, który można przypisać do tła przycisku
        /// </summary>
        /// <param name="hex">kod heksadecymaalny</param>
        /// <returns>SolidColorBrush</returns>
        public static SolidColorBrush KolorZHex(string hex, double opacity)
        {
            SolidColorBrush kolor = (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
            kolor.Opacity = opacity;
            return kolor;
        }

        public static void AnimacjaKoloru(Button button, SolidColorBrush kolor1, SolidColorBrush kolor2)
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = kolor1.Color;
            animation.To = kolor2.Color;
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            button.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        /// <summary>
        /// Konstruktor Planszy Bitwy
        /// </summary>
        /// <param name="grid">Grid, w którym zostanie stworzona siatka 10x10</param>
        public G_PlanszaBitwy(Grid grid, L_PlanszaBitwy planszaLogiczna, bool czyPlanszaGracza, bool czyPierwszaGra)
        {
            _grid = grid;
            _planszaLogiczna = planszaLogiczna;
            _czyPlanszaGracza = czyPlanszaGracza;

            if (czyPierwszaGra)
            {
                TworzSiatke();
            }

            WypelnijPolami();
        }
    }
}
