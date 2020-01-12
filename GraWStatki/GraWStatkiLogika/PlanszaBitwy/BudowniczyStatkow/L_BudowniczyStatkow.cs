using GraWStatkiLogika.Interfejsy;  
using GraWStatkiLogika.PlanszaBitwy.Pola;
using GraWStatkiLogika.PlanszaBitwy.Statki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.BudowniczyStatkow
{
    class L_BudowniczyStatkow
    {
        private IPole[,] _polaPlanszy;
        private IStatek[] _statki;

        public IStatek[] Statki
        {
            get
            {
                return _statki;
            }
        }

        public L_BudowniczyStatkow(IPole[,] polaPlanszy)
        {
            _polaPlanszy = polaPlanszy;
        }

        /// <summary>
        /// Funkcja sprawdzająca, czy można budować statek w danym położeniu
        /// </summary>
        /// <param name="r">Rząd</param>
        /// <param name="k">Kolumna</param>
        /// <param name="kierunek">Kierunek budowania statku</param>
        /// <param name="statek">Statek</param>
        /// <returns></returns>
        private bool MoznaBudowac(int r, int k, Kierunki kierunek, IStatek statek)
        {
            // Sprawdza:
            #region 1. Czy statek wyjdzie poza grid

            if (kierunek == Kierunki.Lewo && k - statek.IloscPol + 1 < 0)
            {
                return false;
            }
            else if(kierunek == Kierunki.Gora && r - statek.IloscPol + 1 < 0)
            {
                return false;
            }
            else if (kierunek == Kierunki.Prawo && k + statek.IloscPol - 1 > 9)
            {
                return false;
            }
            else if (kierunek == Kierunki.Dol && r + statek.IloscPol - 1 > 9)
            {
                return false;
            }

            #endregion


            #region 2. Czy pola statku oraz pola dookoła są zajęte

            // Lista pól do sprawdzenia
            List<IPole> listaPol = new List<IPole>();

            #region Statek budowany w lewo

            if (kierunek == Kierunki.Lewo)
            {
                // ((statek.IloscPol - 1) + 1) == statek.IloscPol
                bool poleNaLewoIstnieje = k - statek.IloscPol >= 0;
                bool poleWyzejIstnieje = r - 1 >= 0;
                bool poleNaPrawoIstnieje = k + 1 <= 9;
                bool poleNizejIstnieje = r + 1 <= 9;

                //Sprzawdzenie pól na prawo od statku
                if (poleNaPrawoIstnieje)
                {
                    //Pole na wysokości statku
                    listaPol.Add(_polaPlanszy[r, k + 1]);

                    //Pole powyżej
                    if (poleWyzejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k + 1]);
                    }
                    //Pole poniżej
                    if (poleNizejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k + 1]);
                    }
                }

                //Petla sprawdzająca pola statku i pola powyżej i poniżej statku
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    //Pole, na którym będzie statek
                    listaPol.Add(_polaPlanszy[r, k - i]);

                    //Pola otaczające pole statku
                    //Pole powyżej
                    if(poleWyzejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k - i]);
                    }
                    //Pole poniżej
                    if (poleNizejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k - i]);
                    }
                }

                //Sprzawdzenie pól na lewo od statku
                if (poleNaLewoIstnieje)
                {
                    //Pole na wysokości statku
                    listaPol.Add(_polaPlanszy[r, k - statek.IloscPol]);

                    //Pole powyżej
                    if (poleWyzejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k - statek.IloscPol]);
                    }
                    //Pole poniżej
                    if (poleNizejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k - statek.IloscPol]);
                    }
                }
            }

            #endregion Statek budowany w lewo

            #region Statek budowany do góry

            else if (kierunek == Kierunki.Gora)
            {
                // ((statek.IloscPol - 1) + 1) == statek.IloscPol
                bool poleNaLewoIstnieje = k - 1 >= 0;
                bool poleWyzejIstnieje = r - statek.IloscPol >= 0;
                bool poleNaPrawoIstnieje = k + 1 <= 9;
                bool poleNizejIstnieje = r + 1 <= 9;

                //Sprzawdzenie pól powyżej statku
                if (poleWyzejIstnieje)
                {
                    //Pole na szerokości statku
                    listaPol.Add(_polaPlanszy[r - statek.IloscPol, k]);

                    //Pole na lewo
                    if (poleNaLewoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - statek.IloscPol, k - 1]);
                    }
                    //Pole na prawo
                    if (poleNaPrawoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - statek.IloscPol, k + 1]);
                    }
                }

                //Petla sprawdzająca pola statku i pola po bokach statku
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    //Pole, na którym będzie statek
                    listaPol.Add(_polaPlanszy[r - i, k]);

                    //Pola otaczające pole statku
                    //Pole na lewo
                    if (poleNaLewoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - i, k - 1]);
                    }
                    //Pole na prawo
                    if (poleNaPrawoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - i, k + 1]);
                    }
                }

                //Sprzawdzenie pól poniżej statku
                if (poleNizejIstnieje)
                {
                    //Pole na szerokości statku
                    listaPol.Add(_polaPlanszy[r + 1, k]);

                    //Pole na lewo
                    if (poleNaLewoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k - 1]);
                    }
                    //Pole na prawo
                    if (poleNaPrawoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k + 1]);
                    }
                }
            }

            #endregion Statek budowany do góry

            #region Statek budowany w prawo

            else if (kierunek == Kierunki.Prawo)
            {
                // ((statek.IloscPol - 1) + 1) == statek.IloscPol
                bool poleNaLewoIstnieje = k - 1 >= 0;
                bool poleWyzejIstnieje = r - 1 >= 0;
                bool poleNaPrawoIstnieje = k + statek.IloscPol <= 9;
                bool poleNizejIstnieje = r + 1 <= 9;

                //Sprzawdzenie pól na prawo od statku
                if (poleNaPrawoIstnieje)
                {
                    //Pole na wysokości statku
                    listaPol.Add(_polaPlanszy[r, k + statek.IloscPol]);

                    //Pole powyżej
                    if (poleWyzejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k + statek.IloscPol]);
                    }
                    //Pole poniżej
                    if (poleNizejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k + statek.IloscPol]);
                    }
                }

                //Petla sprawdzająca pola statku i pola powyżej i poniżej statku
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    //Pole, na którym będzie statek
                    listaPol.Add(_polaPlanszy[r, k + i]);

                    //Pola otaczające pole statku
                    //Pole powyżej
                    if (poleWyzejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k + i]);
                    }
                    //Pole poniżej
                    if (poleNizejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k + i]);
                    }
                }

                //Sprzawdzenie pól na lewo od statku
                if (poleNaLewoIstnieje)
                {
                    //Pole na wysokości statku
                    listaPol.Add(_polaPlanszy[r, k - 1]);

                    //Pole powyżej
                    if (poleWyzejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k - 1]);
                    }
                    //Pole poniżej
                    if (poleNizejIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + 1, k - 1]);
                    }
                }
            }

            #endregion Statek budowany w prawo

            #region Statek budowany w dół

            else if (kierunek == Kierunki.Dol)
            {
                // ((statek.IloscPol - 1) + 1) == statek.IloscPol
                bool poleNaLewoIstnieje = k - 1 >= 0;
                bool poleWyzejIstnieje = r - 1 >= 0;
                bool poleNaPrawoIstnieje = k + 1 <= 9;
                bool poleNizejIstnieje = r + statek.IloscPol <= 9;

                //Sprzawdzenie pól powyżej statku
                if (poleWyzejIstnieje)
                {
                    //Pole na szerokości statku
                    listaPol.Add(_polaPlanszy[r - 1, k]);

                    //Pole na lewo
                    if (poleNaLewoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k - 1]);
                    }
                    //Pole na prawo
                    if (poleNaPrawoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r - 1, k + 1]);
                    }
                }

                //Petla sprawdzająca pola statku i pola po bokach statku
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    //Pole, na którym będzie statek
                    listaPol.Add(_polaPlanszy[r + i, k]);

                    //Pola otaczające pole statku
                    //Pole na lewo
                    if (poleNaLewoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + i, k - 1]);
                    }
                    //Pole na prawo
                    if (poleNaPrawoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + i, k + 1]);
                    }
                }

                //Sprzawdzenie pól poniżej statku
                if (poleNizejIstnieje)
                {
                    //Pole na szerokości statku
                    listaPol.Add(_polaPlanszy[r + statek.IloscPol, k]);

                    //Pole na lewo
                    if (poleNaLewoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + statek.IloscPol, k - 1]);
                    }
                    //Pole na prawo
                    if (poleNaPrawoIstnieje)
                    {
                        listaPol.Add(_polaPlanszy[r + statek.IloscPol, k + 1]);
                    }
                }
            }

            #endregion Statek budowany w dół

            // Jeśli którekolwiek z zebranych pól jest zajęte, nie można budować
            foreach (IPole pole in listaPol)
            {
                if(pole != null)
                {
                    return false;
                }
            }

            #endregion 2. Czy pola statku oraz pola dookoła są zajęte


            // Jeśli żaden z powyższych warunków nie jest spełniony, można budować
            return true;
        }

        private void BudujStatek(int r, int k, Kierunki kierunek, IStatek statek)
        {
            if(kierunek == Kierunki.Lewo)
            {
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    _polaPlanszy[r, k - i] = statek.DodajPole();
                }
            }
            else if(kierunek == Kierunki.Gora)
            {
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    _polaPlanszy[r - i, k] = statek.DodajPole();
                }
            }
            else if(kierunek == Kierunki.Prawo)
            {
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    _polaPlanszy[r, k + i] = statek.DodajPole();
                }
            }
            else if(kierunek == Kierunki.Dol)
            {
                for (int i = 0; i < statek.IloscPol; i++)
                {
                    _polaPlanszy[r + i, k] = statek.DodajPole();
                }
            }
        }


        /// <summary>
        /// Funkcja budująca statki w losowych miejscach planszy
        /// </summary>
        /// <param name="r">Rząd</param>
        /// <param name="k">Kolumna</param>
        /// <param name="kierunek">Kierunek budowania statku</param>
        /// <param name="statek">Statek</param>
        /// <returns></returns>
        public void BudujStatkiLosowo()
        {
            IStatek[] tablicaStatkow = new IStatek[10];
            tablicaStatkow[0] = new L_Czteromasztowiec(0);
            tablicaStatkow[1] = new L_Trojmasztowiec(1);
            tablicaStatkow[2] = new L_Trojmasztowiec(2);
            tablicaStatkow[3] = new L_Dwumasztowiec(3);
            tablicaStatkow[4] = new L_Dwumasztowiec(4);
            tablicaStatkow[5] = new L_Dwumasztowiec(5);
            tablicaStatkow[6] = new L_Jednomasztowiec(6);
            tablicaStatkow[7] = new L_Jednomasztowiec(7);
            tablicaStatkow[8] = new L_Jednomasztowiec(8);
            tablicaStatkow[9] = new L_Jednomasztowiec(9);

            Random los = new Random(DateTime.Now.Millisecond);
            Random losKierunkow = new Random();

            Array tablicaKierunkow = Enum.GetValues(typeof(Kierunki));

            for(int i = 0; i < tablicaStatkow.Length; i++)
            {
                // Losowe liczby od 0 do 9 włącznie
                int losowyR = los.Next(0, 10);
                int losowaK = los.Next(0, 10);
                Kierunki losowyKierunek = (Kierunki)tablicaKierunkow.GetValue(losKierunkow.Next(tablicaKierunkow.Length));

                // Losuj pozycje, dopóki nie znajdziesz takiej, ktora spelnia warunki budowania
                while (!MoznaBudowac(losowyR, losowaK, losowyKierunek, tablicaStatkow[i]))
                {
                    losowyR = los.Next(0, 10);
                    losowaK = los.Next(0, 10);
                }

                BudujStatek(losowyR, losowaK, losowyKierunek, tablicaStatkow[i]);
            }

            _statki = tablicaStatkow;
        }

        public IPole[,] OddajPlansze()
        {
            return _polaPlanszy;
        }
    }
}
