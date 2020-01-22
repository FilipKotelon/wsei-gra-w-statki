using GraWStatkiLogika.PlanszaBitwy.BudowniczyStatkow;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using GraWStatkiLogika.PlanszaBitwy.Statki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy
{
    /// <summary>
    /// Enum kierunków, w które można wybudować statki.
    /// </summary>
    public enum Kierunki { Lewo, Gora, Prawo, Dol };

    public class L_PlanszaBitwy
    {
        private L_Pole[,] _pola = new L_Pole[10, 10];
        private List<L_Statek> _statki = new List<L_Statek>();
        private L_BudowniczyStatkow budowniczy;

        /// <summary>
        /// Tablica dwuwymiarowa ze wszystkimi polami planszy.
        /// </summary>
        public L_Pole[,] Pola
        {
            get
            {
                return _pola;
            }
        }

        /// <summary>
        /// Lista ze statkami znajdującymi się na planszy.
        /// </summary>
        public List<L_Statek> Statki
        {
            get
            {
                return _statki;
            }
        }

        /// <summary>
        /// Konstruktor, uruchamia budowniczego i wypełnia planszę statkami w postaci pól zajętych, a w pozostałe miejsce wstawia pola puste.
        /// </summary>
        public L_PlanszaBitwy()
        {
            budowniczy = new L_BudowniczyStatkow(_pola);
            
            budowniczy.BudujStatkiLosowo();
            _pola = budowniczy.OddajPlansze();
            _statki = budowniczy.OddajStatki();

            WypelnijPustePola();
        }

        /// <summary>
        /// Funkcja wypełniająca pola planszy niezajęte przez statki polami pustymi.
        /// </summary>
        private void WypelnijPustePola()
        {
            for (int i = 0; i < _pola.GetLength(0); i++)
            {
                for (int j = 0; j < _pola.GetLength(1); j++)
                {
                    if (_pola[i, j] == null)
                    {
                        _pola[i, j] = new L_PolePuste();
                    }
                }
            }
        }

        /// <summary>
        /// Funkcja dodająca statek do listy statków na planszy.
        /// </summary>
        /// <param name="statek">L_Statek do dodania do planszy</param>
        public void DodajStatek(L_Statek statek)
        {
            _statki.Add(statek);
        }
    }
}
