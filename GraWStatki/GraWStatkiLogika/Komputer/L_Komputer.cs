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
        #region Zmienne przechowujące informacje dla komputera

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

        #endregion

        /// <summary>
        /// Konstruktor komputera
        /// </summary>
        /// <param name="planszaGracza">Logiczna plansza gracza</param>
        /// <param name="poziomTrudnosci">Poziom trudności, na jakim będzie się odbywać rozgrywka</param>
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

                while ((i == _w_1 || j == _k_1) && polaPlanszy[i, j].Trafione)
                {
                    //Lewo
                    if (_ktoryStrzal == 1)
                    {
                        if (_k_1 > 0)
                        {
                            if (polaPlanszy[i, j - 1].Trafione)
                            {
                                _ktoryStrzal++;
                            }
                            else
                            {
                                j--;
                                _obranyKierunek = Kierunki.Lewo;
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
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
                            }
                            else
                            {
                                i--;
                                _obranyKierunek = Kierunki.Gora;
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
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
                            }
                            else
                            {
                                j++;
                                _obranyKierunek = Kierunki.Prawo;
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
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
                            }
                            else
                            {
                                i++;
                                _obranyKierunek = Kierunki.Dol;
                            }
                        }
                        else
                        {
                            _ktoryStrzal++;
                        }
                    }
                }
            }

            #endregion

            #region Szukanie pól statku w obranym kierunku

            else if (_komenda == Komendy.StrzelajWTymKierunku)
            {
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
                            }
                            else if (polaPlanszy[i, j - 1].Trafione && polaPlanszy[i, j - 1].Zajete)
                            {
                                j--;
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Prawo;
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Prawo;
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
                            }
                            else if (polaPlanszy[i - 1, j].Trafione && polaPlanszy[i - 1, j].Zajete)
                            {
                                i--;
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Dol;
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Dol;
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
                            }
                            else if (polaPlanszy[i, j + 1].Trafione && polaPlanszy[i, j + 1].Zajete)
                            {
                                j++;
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Lewo;
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Lewo;
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
                            }
                            else if (polaPlanszy[i + 1, j].Trafione && polaPlanszy[i + 1, j].Zajete)
                            {
                                i++;
                            }
                            else
                            {
                                _obranyKierunek = Kierunki.Gora;
                            }
                        }
                        else
                        {
                            _obranyKierunek = Kierunki.Gora;
                        }
                    }
                }
            }

            #endregion

            _wylosowanePole = polaPlanszy[i, j];
            _w = i;
            _k = j;

            int[] indeksy = new int[2] { i, j };

            return indeksy;
        }

        /// <summary>
        /// Komputer po każdym wykonanym ruchu sprawdza co ten ruch spowodował i zależnie od tego podejmuje kolejną akcję.
        /// </summary>
        public void SprawdzRuch()
        {
            //Jeśli poziom trudności jest ustawiony na łatwy, strzelaj na ślepo
            if (_poziomTrudnosci == PoziomTrudnosci.Latwy)
            {
                _komenda = Komendy.Losuj;
                return;
            }

            #region Trafione pole było zajęte

            if (_wylosowanePole.Zajete)
            {
                _wlasnieZatopilem = CzyZatopilemStatek(_wylosowanePole.IDStatku);

                //Jeżeli dany strzał zatopił statek
                if (_wlasnieZatopilem)
                {
                    _wlasnieTrafilem = false;
                    _ktoryStrzal = 1;
                    _komenda = Komendy.Losuj;
                }
                else
                {
                    //Jeżeli dany strzał trafił kolejne pole statku
                    if (_wlasnieTrafilem)
                    {
                        _komenda = Komendy.StrzelajWTymKierunku;
                        _ktoryStrzal = 1;
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
                    }
                }
            }

            #endregion

            #region Trafione pole było puste

            //Jeżeli trafiło się kolejne pole statku, po czym spudłowało, ale statek statek nie został zatopiony.
            //Np. Kiedy trafiono w lewą stronę 3 pola 4-masztowca, ale jego ostatnie pole jest po prawej.
            else if (_komenda == Komendy.StrzelajWTymKierunku)
            {
                _ktoryStrzal = 1;
                _wlasnieZatopilem = false;

                //Zamień obecny kierunek na przeciwny
                if (_obranyKierunek == Kierunki.Dol)
                {
                    _obranyKierunek = Kierunki.Gora;
                }
                else if (_obranyKierunek == Kierunki.Gora)
                {
                    _obranyKierunek = Kierunki.Dol;
                }
                else if (_obranyKierunek == Kierunki.Lewo)
                {
                    _obranyKierunek = Kierunki.Prawo;
                }
                else if (_obranyKierunek == Kierunki.Prawo)
                {
                    _obranyKierunek = Kierunki.Lewo;
                }
            }
            //Jeżeli komputer szuka kolejnego pola statku dookoła, to następnym razem strzeli w kolejnym kierunku
            else if (_komenda == Komendy.SzukajDookola)
            {
                _wlasnieZatopilem = false;
                _ktoryStrzal++;
            }
            //Jeżeli nie trafił losowo, strzela dalej
            else
            {
                _wlasnieTrafilem = false;
            }

            #endregion
        }

        /// <summary>
        /// Funkcja sprawdzająca, czy wszystkie pola statku są trafione. Jeśli tak, statek został zatopiony.
        /// </summary>
        /// <param name="IDStatku">ID Statku do sprawdzenia</param>
        /// <returns></returns>
        private bool CzyZatopilemStatek(int IDStatku)
        {
            List<L_Statek> statkiGracza = _planszaGracza.Statki;
            L_Statek trafionyStatek = statkiGracza[IDStatku];

            trafionyStatek.SprawdzStan();

            return trafionyStatek.Zatopiony;
        }
    }
}
