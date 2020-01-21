using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using GraWStatkiLogika.PlanszaBitwy.Statki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.Komputer
{
    /// <summary>
    /// Enum z poziomem trudności.
    /// </summary>
    public enum PoziomTrudnosci { Latwy, Zaawansowany, Trudny }

    /// <summary>
    /// Komputer, grający z graczem.
    /// </summary>
    public class L_Komputer
    {
        /// <summary>
        /// Poziom trudności
        /// </summary>
        private PoziomTrudnosci _poziomTrudnosci;

        /// <summary>
        /// Komputer przechowuje planszę gracza, żeby wiedzieć, w które pola już trafił.
        /// </summary>
        private L_PlanszaBitwy _planszaGracza;

        /// <summary>
        /// Sprawdza, czy właśnie trafił pole jakiegoś statku.
        /// </summary>
        private bool _wlasnieTrafilem;

        /// <summary>
        /// Sprawdza, czy właśnie zatopił jakiś statek.
        /// </summary>
        private bool _wlasnieZatopilem;

        /// <summary>
        /// Wylosowane w danej turze pole.
        /// </summary>
        private L_Pole _wylosowanePole;

        /// <summary>
        /// Wiersz, w którym znajduje się wylosowane pole.
        /// </summary>
        private int _w;

        /// <summary>
        /// Kolumna, w której znajduje się wylosowane pole.
        /// </summary>
        private int _k;

        /// <summary>
        /// Pierwsze napotkane pole statku, dookoła którego należy strzelać, by znaleźć następne.
        /// </summary>
        private L_Pole _trafionePierwszePole;

        /// <summary>
        /// Wiersz, w którym znajduje się pierwsze napotkane pole statku, dookoła którego należy strzelać, by znaleźć następne.
        /// </summary>
        private int _w_1;

        /// <summary>
        /// Kolumna, w której znajduje się pierwsze napotkane pole statku, dookoła którego należy strzelać, by znaleźć następne.
        /// </summary>
        private int _k_1;


        /// <summary>
        /// Obrany kierunek trafiania w pola gracza.
        /// Wykorzystywany po trafieniu.
        /// </summary>
        private Kierunki? _obranyKierunek;

        /// <summary>
        /// Sprawdza, który raz strzela dookola statku w poszukiwaniu jego pól.
        /// 1 - strzel w lewo, 2 - góra, 3 - prawo, 4 - dół.
        /// </summary>
        private int _ktoryStrzal;

        /// <summary>
        /// Enum z możliwymi komendami komputera
        /// </summary>
        private enum Komendy { StrzelajWTymKierunku, Losuj, SzukajDookola }

        /// <summary>
        /// Tutaj komputer przechowuje swoją kolejną akcję do wykonania
        /// </summary>
        private Komendy _komenda;

        public L_Komputer(L_PlanszaBitwy planszaGracza, PoziomTrudnosci poziomTrudnosci)
        {
            _poziomTrudnosci = poziomTrudnosci;
            _planszaGracza = planszaGracza;

            _wlasnieTrafilem = false;
            _wlasnieZatopilem = false;

            _wylosowanePole = null;
            _trafionePierwszePole = null;
            _w = -1;
            _k = -1;

            _obranyKierunek = null;
            _ktoryStrzal = 1;

            _komenda = Komendy.Losuj;
        }

        /// <summary>
        /// Funkcja zwracająca tablicę z losowym indeksem tablicy.
        /// </summary>
        /// <returns>tablica z numerami wiersza i kolumny, w których znajduje się pole</returns>
        public int[] LosujPole()
        {
            L_Pole[,] polaPlanszy = _planszaGracza.Pola;
            int i = _w;
            int j = _k;
            //Console.WriteLine($"Początkowe {i}, {j}");

            #region Losowe wybranie pola

            if (_komenda == Komendy.Losuj)
            {
                // Losowe liczby od 0 do 9 włącznie
                Random los = new Random(DateTime.Now.Millisecond);
                i = los.Next(0, 10);
                j = los.Next(0, 10);

                Random losTrudnosci = new Random(DateTime.Now.Millisecond);

                //Szansa na trafienie prosto w statek wynosi 20% - tylko dla poziomu trudnego
                int losowaLiczba = losTrudnosci.Next(0, 5);
                bool czyStrzelicWStatek = losowaLiczba == 0;
                //Console.WriteLine($"{losowaLiczba}");

                if (czyStrzelicWStatek && _poziomTrudnosci == PoziomTrudnosci.Trudny)
                {
                    //Dopóki losowe pole jest polem już trafionym i nie jest pole zajętym przez statek, szukaj dalej
                    while ((polaPlanszy[i, j].Trafione && !polaPlanszy[i, j].Zajete) || (!polaPlanszy[i, j].Trafione && !polaPlanszy[i, j].Zajete) || (polaPlanszy[i, j].Trafione && polaPlanszy[i, j].Zajete))
                    {
                        i = los.Next(0, 10);
                        j = los.Next(0, 10);
                    }
                }
                else
                {
                    //Dopóki losowe pole jest polem już trafionym, szukaj innego pola
                    while (polaPlanszy[i, j].Trafione)
                    {
                        i = los.Next(0, 10);
                        j = los.Next(0, 10);
                    }
                }
            }

            #endregion

            #region Szukanie pól statku dookoła trafionego pola

            else if (_komenda == Komendy.SzukajDookola)
            {
                i = _w_1;
                j = _k_1;
                //Console.WriteLine($"Strzelam dookoła");

                while ((i == _w_1 || j == _k_1) && polaPlanszy[i, j].Trafione)
                {
                    //Console.WriteLine($"Strzelam {_ktoryStrzal} raz");
                    //Lewo
                    if (_ktoryStrzal == 1)
                    {
                        if (_k_1 > 0)
                        {
                            if (polaPlanszy[i, j - 1].Trafione)
                            {
                                _ktoryStrzal++;
                                //Console.WriteLine("Zajęte, jeszcze raz");
                            }
                            else
                            {
                                j--;
                                _obranyKierunek = Kierunki.Lewo;
                                //Console.WriteLine("Strzelam w lewo");
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
                            //Console.WriteLine("Pudło, jeszcze raz");
                        }
                    }
                    //Góra
                    else if (_ktoryStrzal == 2)
                    {
                        if (_w_1 > 0)
                        {
                            if (polaPlanszy[i - 1, j].Trafione)
                            {
                                _ktoryStrzal++;
                                //Console.WriteLine("Zajęte, jeszcze raz");
                            }
                            else
                            {
                                i--;
                                _obranyKierunek = Kierunki.Gora;
                                //Console.WriteLine("Strzelam w górę");
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
                            //Console.WriteLine("Pudło, jeszcze raz");
                        }
                    }
                    //Prawo
                    else if (_ktoryStrzal == 3)
                    {
                        if (_k_1 < 9)
                        {
                            if (polaPlanszy[i, j + 1].Trafione)
                            {
                                _ktoryStrzal++;
                                //Console.WriteLine("Zajęte, jeszcze raz");
                            }
                            else
                            {
                                j++;
                                _obranyKierunek = Kierunki.Prawo;
                                //Console.WriteLine("Strzelam w prawo");
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
                            //Console.WriteLine("Pudło, jeszcze raz");
                        }
                    }
                    //Dół
                    else if (_ktoryStrzal == 4)
                    {
                        if (_w_1 < 9)
                        {
                            if (polaPlanszy[i + 1, j].Trafione)
                            {
                                _ktoryStrzal++;
                                //Console.WriteLine("Zajęte, jeszcze raz");
                            }
                            else
                            {
                                i++;
                                _obranyKierunek = Kierunki.Dol;
                                //Console.WriteLine("Strzelam w dół");
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
                            //Console.WriteLine("Pudło, jeszcze raz");
                        }
                    }
                    //Console.WriteLine($"{i}, {j}");
                }
            }

            #endregion

            #region Szukanie pól statku w obranym kierunku

            else if (_komenda == Komendy.StrzelajWTymKierunku)
            {
                //Console.WriteLine($"Strzelam w jednym kierunku: {_obranyKierunek}");

                while (polaPlanszy[i, j].Trafione)
                {
                    //Lewo
                    if (_obranyKierunek == Kierunki.Lewo)
                    {
                        if (_k > 0)
                        {
                            if(!(polaPlanszy[i, j - 1].Trafione && !polaPlanszy[i, j - 1].Zajete))
                            {
                                j--;
                                //Console.WriteLine("Strzelam w lewo");
                            }
                            else if (polaPlanszy[i, j - 1].Trafione && polaPlanszy[i, j - 1].Zajete)
                            {
                                j--;
                                //Console.WriteLine("Omijam pole w lewo");
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Prawo;
                                //Console.WriteLine("Zawracam w prawo");
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Prawo;
                            //Console.WriteLine("Zawracam w prawo");
                        }
                    }
                    //Góra
                    else if (_obranyKierunek == Kierunki.Gora)
                    {
                        if (_w > 0)
                        {
                            if (!(polaPlanszy[i - 1, j].Trafione && !polaPlanszy[i - 1, j].Zajete))
                            {
                                i--;
                                //Console.WriteLine("Strzelam w górę");
                            }
                            else if (polaPlanszy[i - 1, j].Trafione && polaPlanszy[i - 1, j].Zajete)
                            {
                                i--;
                                //Console.WriteLine("Omijam pole w górę");
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Dol;
                                //Console.WriteLine("Zawracam w dół");
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Dol;
                            //Console.WriteLine("Zawracam w dół");
                        }
                    }
                    //Prawo
                    else if (_obranyKierunek == Kierunki.Prawo)
                    {
                        if (_k < 9)
                        {
                            if (!(polaPlanszy[i, j + 1].Trafione && !polaPlanszy[i, j + 1].Zajete))
                            {
                                j++;
                                //Console.WriteLine("Strzelam w prawo");
                            }
                            else if (polaPlanszy[i, j + 1].Trafione && polaPlanszy[i, j + 1].Zajete)
                            {
                                j++;
                                //Console.WriteLine("Omijam pole w prawo");
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Lewo;
                                //Console.WriteLine("Zawracam w lewo");
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Lewo;
                            //Console.WriteLine("Zawracam w lewo");
                        }
                    }
                    //Dół
                    else if (_obranyKierunek == Kierunki.Dol)
                    {
                        if (_w < 9)
                        {
                            if (!(polaPlanszy[i + 1, j].Trafione && !polaPlanszy[i + 1, j].Zajete))
                            {
                                i++;
                                //Console.WriteLine("Strzelam w dół");
                            }
                            else if (polaPlanszy[i + 1, j].Trafione && polaPlanszy[i + 1, j].Zajete)
                            {
                                i++;
                                //Console.WriteLine("Omijam pole w dół");
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Gora;
                                //Console.WriteLine("Zawracam w górę");
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Gora;
                            //Console.WriteLine("Zawracam w górę");
                        }
                    }
                }
            }

            #endregion

            //Console.WriteLine($"Ostateczne {i}, {j}");

            _wylosowanePole = polaPlanszy[i, j];
            _w = i;
            _k = j;

            int[] indeksy = new int[2] { i, j };

            return indeksy;
        }

        public void SprawdzRuch()
        {
            //Jeśli poziom trudności jest ustawiony na łatwy, strzelaj na ślepo
            if (_poziomTrudnosci == PoziomTrudnosci.Latwy)
            {
                _komenda = Komendy.Losuj;
                return;
            }

            //Console.WriteLine($"Oceniam mój ruch!");

            if (_wylosowanePole.Zajete)
            {
                _wlasnieZatopilem = CzyZatopilemStatek(_wylosowanePole.IDStatku);

                //Jeżeli dany strzał zatopił statek
                if (_wlasnieZatopilem)
                {
                    _wlasnieTrafilem = false;
                    _ktoryStrzal = 1;
                    _komenda = Komendy.Losuj;
                    //Console.WriteLine($"Zatopiłem statek!");
                }
                else
                {
                    //Jeżeli dany strzał trafił kolejne pole statku
                    if (_wlasnieTrafilem)
                    {
                        _komenda = Komendy.StrzelajWTymKierunku;
                        _ktoryStrzal = 1;
                        //Console.WriteLine($"Trafiłem statek drugi raz! Teraz strzelam w jednym kierunku!");
                    }
                    else
                    {
                        //Jeżeli dany strzał trafił pierwsze pole statku
                        _wlasnieTrafilem = true;
                        _obranyKierunek = null;
                        _ktoryStrzal = 1;
                        _trafionePierwszePole = _wylosowanePole;
                        _w_1 = _w;
                        _k_1 = _k;

                        _komenda = Komendy.SzukajDookola;
                        //Console.WriteLine($"Trafiłem statek pierwszy raz! Teraz strzelam dookoła!");
                    }
                }
            }
            //Jeżeli trafiło się kolejne pole statku, po czym spudłowało, ale statek statek nie został zatopiony
            //Np. Kiedy trafiono w lewą stronę 3 pola 4-masztowca, ale jego ostatnie pole jest po prawej
            else if (_komenda == Komendy.StrzelajWTymKierunku)
            {
                _ktoryStrzal = 1;
                _wlasnieZatopilem = false;
                //Zamień obecny kierunek na przeciwny
                if (_obranyKierunek == Kierunki.Dol)
                {
                    _obranyKierunek = Kierunki.Gora;
                    //Console.WriteLine($"Zawracam do góry!");
                }
                else if (_obranyKierunek == Kierunki.Gora)
                {
                    _obranyKierunek = Kierunki.Dol;
                    //Console.WriteLine($"Zawracam w dół!");
                }

                else if (_obranyKierunek == Kierunki.Lewo)
                {
                    _obranyKierunek = Kierunki.Prawo;
                    //Console.WriteLine($"Zawracam w prawo!");
                }
                else if (_obranyKierunek == Kierunki.Prawo)
                {
                    _obranyKierunek = Kierunki.Lewo;
                    //Console.WriteLine($"Zawracam w lewo!");
                }
            }
            else if (_komenda == Komendy.SzukajDookola)
            {
                _wlasnieZatopilem = false;
                _ktoryStrzal++;
                //Console.WriteLine($"Strzelam dookoła i spudłowałem, teraz czas na kolejny kierunek!");
            }
            else
            {
                _wlasnieTrafilem = false;
                //Console.WriteLine($"Spudłowałem losowo, teraz strzelam gdzie indziej!");
            }
        }

        private bool CzyZatopilemStatek(int IDStatku)
        {
            List<L_Statek> statkiGracza = _planszaGracza.Statki;
            L_Statek trafionyStatek = statkiGracza[IDStatku];

            trafionyStatek.SprawdzStan();

            return trafionyStatek.Zatopiony;
        }
    }
}
