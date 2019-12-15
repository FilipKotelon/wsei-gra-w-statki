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

                        TextBlock textblock = new TextBlock();

                        if (pole.Zajete)
                        {
                            textblock.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ff7777"));
                        }
                        else
                        {
                            textblock.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#44FF99"));
                        }

                        textblock.Text = $"{i}_{j}";

                        Grid.SetRow(textblock, i);
                        Grid.SetColumn(textblock, j);
                        _grid.Children.Add(textblock);
                    }
                }
            }
        }

        /// <summary>
        /// Konstruktor Planszy Bitwy
        /// </summary>
        /// <param name="grid">Grid, w którym zostanie stworzona siatka 10x10</param>
        public G_PlanszaBitwy(Grid grid, L_PlanszaBitwy planszaLogiczna)
        {
            _grid = grid;
            _planszaLogiczna = planszaLogiczna;

            TworzSiatke();
            WypelnijPolami();
        }
    }
}
