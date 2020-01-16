using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.Komputer
{
    /// <summary>
    /// Komputer, grający z graczem
    /// </summary>
    public class L_Komputer
    {
        //Komputer przechowuje planszę gracza, żeby wiedzieć, w które pola już trafił
        private L_PlanszaBitwy _planszaGracza;

        public L_Komputer(L_PlanszaBitwy planszaGracza)
        {
            _planszaGracza = planszaGracza;
        }

        /// <summary>
        /// Funkcja zwracająca tablicę z losowym indeksem tablicy
        /// </summary>
        /// <returns>tablica z numerami wiersza i kolumny, w których znajduje się pole</returns>
        public int[] LosujPole()
        {
            L_Pole[,] polaPlanszy = _planszaGracza.Pola;

            // Losowe liczby od 0 do 9 włącznie
            Random los = new Random(DateTime.Now.Millisecond);
            int i = los.Next(0, 10);
            int j = los.Next(0, 10);

            //Dopóki losowe pole jest polem już trafionym, szukaj innego pola
            while (polaPlanszy[i, j].Trafione)
            {
                i = los.Next(0, 10);
                j = los.Next(0, 10);
            }

            int[] indeksy = new int[2] { i, j };

            return indeksy;
        }
    }
}
