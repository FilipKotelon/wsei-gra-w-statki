using GraWStatkiLogika;
using GraWStatkiLogika.Interfejsy;
using GraWStatkiLogika.PlanszaBitwy;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraWStatkiFront.PlanszaBitwy
{
    public class G_PlanszaBitwy
    {
        private Grid _grid;
        private L_PlanszaBitwy _planszaLogiczna;
        private bool _czyPlanszaGracza;
        private Button[,] _planszaZPrzyciskami = new Button[10, 10];

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
            IPole[,] polaPlanszy = _planszaLogiczna.Pola;

            for (int i = 0; i < polaPlanszy.GetLength(0); i++)
            {
                for(int j = 0; j < polaPlanszy.GetLength(1); j++)
                {
                    if(polaPlanszy[i, j] != null)
                    {
                        IPole pole = polaPlanszy[i, j];
                        //Podpiąć funkcję która będzię się wykonywała po kliknięciu, prywatna; private void nazwa;
                        //po kliknieciu jezeli pole jest zajete to pole.Trafiony=true
                        //jeżeli plansza jest planszą gracza to zmienia sie kolor na niebieski, jeżeli komptera to pokazuje jakie pole
                        
                        Button button = new Button();
                        if (_czyPlanszaGracza)
                        {
                            if (pole.Zajete)
                            {
                                button.Background = KolorZHex("#000000");
                            }
                            else
                            {
                                button.Background = KolorZHex("#FFFFFF");
                            }
                        }
                        else
                        {
                            button.Background = KolorZHex("#0399C4");
                        }

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
        public static SolidColorBrush KolorZHex(string hex)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
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
