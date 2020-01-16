using GraWStatkiLogika.PlanszaBitwy.BudowniczyStatkow;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy
{
    public enum Kierunki { Lewo, Gora, Prawo, Dol };

    public class L_PlanszaBitwy
    {
        private L_Pole[,] _pola = new L_Pole[10, 10];
        private L_BudowniczyStatkow budowniczy;
        private IStatek[] _statki;

        public L_Pole[,] Pola
        {
            get
            {
                return _pola;
            }
        }

        public IStatek[] Statki
        {
            get
            {
                return _statki;
            }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public L_PlanszaBitwy()
        {
            budowniczy = new L_BudowniczyStatkow(_pola);
            
            budowniczy.BudujStatkiLosowo();
            _pola = budowniczy.OddajPlansze();
            _statki = budowniczy.Statki;

            WypelnijPustePola();
        }

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
    }
}
