using GraWStatkiLogika.Interfejsy;
using GraWStatkiLogika.PlanszaBitwy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.KontrolaGry
{
    public class L_Sedzia
    {
        public string zwyciezca;
        private L_PlanszaBitwy _planszaGracza;
        private L_PlanszaBitwy _planszaKomputera;

        public L_Sedzia(L_PlanszaBitwy planszaGracza, L_PlanszaBitwy planszaKomputera)
        {
            _planszaGracza = planszaGracza;
            _planszaKomputera = planszaKomputera;
        }

        /// <summary>
        /// Funkcja sprawdzająca, czy ktoś wygrał grę, wywoływana po każdym ruchu gracza lub komputera
        /// </summary>
        public void Sprawdz()
        {
            IPole[, ] polaGracza = _planszaGracza.Pola;
            List<IPole> zajetePolaGracza = new List<IPole>();

            for (int i = 0; i < polaGracza.GetLength(0); i++)
            {
                for (int j = 0; j < polaGracza.GetLength(1); j++)
                {
                    if (polaGracza[i, j] != null)
                    {
                        IPole pole = polaGracza[i, j];

                        if (pole.Zajete)
                        {
                            zajetePolaGracza.Add(pole);
                        }
                    }
                }
            }
        }
    }
}
