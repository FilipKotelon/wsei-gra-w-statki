using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.KontrolaGry
{
    public class L_Sedzia
    {
        private L_PlanszaBitwy _planszaGracza;
        private L_PlanszaBitwy _planszaKomputera;
        private L_Gra _gra;

        public L_Sedzia(L_Gra gra)
        {
            _gra = gra;
            _planszaGracza = _gra.PlanszaGracza;
            _planszaKomputera = _gra.PlanszaKomputera;
        }

        /// <summary>
        /// Funkcja sprawdzająca, czy gra zakończyła się po danym ruchu
        /// </summary>
        /// <returns>prawda/fałsz - czy gra została zakończona</returns>
        public bool SprawdzCzyKoniec(bool czyTuraGracza)
        {
            L_Pole[,] polaPrzeciwnika;
            List<L_Pole> zajetePolaPrzeciwnika = new List<L_Pole>();

            //Jeśli jest tura gracza, sprawdzane są pola komputera i na odwrót
            if (czyTuraGracza)
            {
                polaPrzeciwnika = _planszaKomputera.Pola;
            }
            else
            {
                polaPrzeciwnika = _planszaGracza.Pola;
            }

            for (int i = 0; i < polaPrzeciwnika.GetLength(0); i++)
            {
                for (int j = 0; j < polaPrzeciwnika.GetLength(1); j++)
                {
                    if (polaPrzeciwnika[i, j] != null)
                    {
                        L_Pole pole = polaPrzeciwnika[i, j];

                        if (pole.Zajete)
                        {
                            zajetePolaPrzeciwnika.Add(pole);
                        }
                    }
                }
            }

            bool koniecGry = true;

            foreach(L_Pole pole in zajetePolaPrzeciwnika)
            {
                if (!pole.Trafione)
                {
                    koniecGry = false;
                }
            }

            return koniecGry;
        }
    }
}
