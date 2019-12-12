using System;
using System.Windows;
using System.Windows.Controls;

namespace GraWStatkiFront
{
    public class GeneratorPol
    {
        private Grid _grid;

        /// <summary>
        /// Konstruktor Generatora Pol
        /// </summary>
        /// <param name="grid">Grid, w którym zostanie stworzona siatka 10x10</param>
        public GeneratorPol(Grid grid)
        {
            _grid = grid;
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
        public void TworzSiatke()
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
    }
}
