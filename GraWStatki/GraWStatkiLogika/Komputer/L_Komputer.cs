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
    /// Komputer, grający z graczem
    /// </summary>
    public class L_Komputer
    {
        //Poziom trudności
        private enum PoziomTrudnosci { Latwy, Trudny }
        private PoziomTrudnosci _poziomTrudnosci;

        //Komputer przechowuje planszę gracza, żeby wiedzieć, w które pola już trafił
        private L_PlanszaBitwy _planszaGracza;

        //Sprawdza, czy właśnie trafił pole jakiegoś statku
        private bool _wlasnieTrafilem;

        //Sprawdza, czy właśnie zatopił jakiś statek
        private bool _wlasnieZatopilem;

        //Wylosowane w danej turze pole
        private L_Pole _wylosowanePole;

        //Wiersz, w którym znajduje się wylosowane pole
        private int _w;

        //Kolumna, w której znajduje się wylosowane pole
        private int _k;

        //Pole, dookoła którego należy strzelać
        private L_Pole _trafionePierwszePole;

        //Wiersz, w którym znajduje się pole, dookoła którego należy strzelać
        private int _w_1;

        //Kolumna, w której znajduje się pole, dookoła którego należy strzelać
        private int _k_1;


        //Obrany kierunek trafiania w pola gracza
        //Wykorzystywany po trafieniu
        private Kierunki? _obranyKierunek;

        //Sprawdza, który raz strzela dookola statku w poszukiwaniu jego pól
        //1 - strzel w lewo, 2 - góra, 3 - prawo, 4 - dół
        private int _ktoryStrzal;

        //Tutaj komputer przechowuje swoją kolejną akcję do wykonania
        private enum Komendy { StrzelajWTymKierunku, Losuj, SzukajDookola }
        private Komendy _komenda;

        public L_Komputer(L_PlanszaBitwy planszaGracza)
        {
            _poziomTrudnosci = PoziomTrudnosci.Trudny;
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
        /// Funkcja zwracająca tablicę z losowym indeksem tablicy
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

                //Dopóki losowe pole jest polem już trafionym, szukaj innego pola
                while (polaPlanszy[i, j].Trafione)
                {
                    i = los.Next(0, 10);
                    j = los.Next(0, 10);
                }
            }
            #endregion

            #region Szukanie pól statku dookoła trafionego pola
            else if (_komenda == Komendy.SzukajDookola)
            {
                i = _w_1;
                j = _k_1;

                while (i == _w_1 && j == _k_1 && polaPlanszy[i, j].Trafione)
                {
                    //Lewo
                    if (_ktoryStrzal == 1)
                    {
                        if (_k_1 > 0)
                        {
                            j = _k_1 - 1;
                            _obranyKierunek = Kierunki.Lewo;

                            if(polaPlanszy[i, j].Trafione)
                            {
                                _ktoryStrzal++;
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
                            i = _w_1 - 1;
                            _obranyKierunek = Kierunki.Gora;

                            if (polaPlanszy[i, j].Trafione)
                            {
                                _ktoryStrzal++;
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
                            j = _k_1 + 1;
                            _obranyKierunek = Kierunki.Prawo;

                            if (polaPlanszy[i, j].Trafione)
                            {
                                _ktoryStrzal++;
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
                            i = _w_1 + 1;
                            _obranyKierunek = Kierunki.Dol;

                            if (polaPlanszy[i, j].Trafione)
                            {
                                _ktoryStrzal++;
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
                            j--;
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
                            i--;
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
                            j++;
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
                            i++;
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

        public void SprawdzRuch()
        {
            //Jeśli poziom trudności jest ustawiony na łatwy, strzelaj na ślepo
            if (_poziomTrudnosci == PoziomTrudnosci.Latwy)
            {
                _komenda = Komendy.Losuj;
                return;
            }


            if (_wylosowanePole.Zajete)
            {
                _wlasnieZatopilem = CzyZatopilemStatek(_wylosowanePole.IDStatku);

                //Jeżeli dany strzał zatopił statek
                if (_wlasnieZatopilem)
                {
                    _komenda = Komendy.Losuj;
                }
                else
                {
                    _wlasnieZatopilem = false;

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
            //Jeżeli trafiło się kolejne pole statku, po czym spudłowało, ale statek statek nie został zatopiony
            //Np. Kiedy trafiono w lewą stronę 3 pola 4-masztowca, ale jego ostatnie pole jest po prawej
            else if (_komenda == Komendy.StrzelajWTymKierunku)
            {
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
            else if (_komenda == Komendy.SzukajDookola)
            {
                _wlasnieZatopilem = false;
                _obranyKierunek = null;
                _ktoryStrzal++;
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
