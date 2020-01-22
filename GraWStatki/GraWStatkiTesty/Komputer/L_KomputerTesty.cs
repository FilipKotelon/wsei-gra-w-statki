using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiLogika.Komputer;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using GraWStatkiLogika.PlanszaBitwy.Statki;

namespace GraWStatkiTesty.Komputer
{
    /// <summary>
    /// Testy logiki komputera
    /// </summary>
    [TestClass]
    public class L_KomputerTesty
    {
        #region LosujPole

        [TestMethod]
        public void LosujPole_KomputerStrzelaLosowo_KolejneLosowanieZwracaInneMiejsceNaPlanszyPoTrafieniu()
        {
            //Przygotowanie

            L_PlanszaBitwy plansza = new L_PlanszaBitwy();
            //Na poziomie łatwym komputer będzie cały czas strzelał losowo
            PoziomTrudnosci poziomTrudnosci = PoziomTrudnosci.Latwy;
            L_Komputer komputer = new L_Komputer(plansza, poziomTrudnosci);

            int[] ostatnieIndeksy = new int[2];
            int[] noweIndeksy;
            bool kazdeLosowanieJestUnikalne = true;

            //Działanie
            //Wylosowanie 100 pól powinno za każdym kolejnym razem zwrócić inne pole, jeśli pole wylosowane wcześniej zostało trafione
            for(int i = 0; i < plansza.Pola.GetLength(0); i++)
            {
                for (int j = 0; j < plansza.Pola.GetLength(1); j++)
                {
                    noweIndeksy = komputer.LosujPole();

                    if (i == 0 && j == 0)
                    {
                        ostatnieIndeksy = noweIndeksy;
                        //Trafienie wylosowanego pola
                        plansza.Pola[noweIndeksy[0], noweIndeksy[1]].Trafione = true;
                    }
                    else
                    {
                        //Jeśli zostały wylosowane te same indeksy, test nie zostanie zdany
                        if (ostatnieIndeksy[0] == noweIndeksy[0] && ostatnieIndeksy[1] == noweIndeksy[1])
                        {
                            kazdeLosowanieJestUnikalne = false;
                            break;
                        }
                        else
                        {
                            ostatnieIndeksy = noweIndeksy;
                            //Trafienie wylosowanego pola
                            plansza.Pola[noweIndeksy[0], noweIndeksy[1]].Trafione = true;
                        }
                    }
                }
            }

            //Sprawdzenie
            Assert.IsTrue(kazdeLosowanieJestUnikalne);
        }


        [TestMethod]
        public void LosujPole_KomputerStrzelaDookolaPoTrafieniu_PoTrafieniuKolejneLosowanePoleZnajdujeSieWBezposrednimSasiedztwie()
        {
            //Przygotowanie

            L_PlanszaBitwy plansza = new L_PlanszaBitwy();
            //Na poziomie zaawansowanym i trudnym komputer będzie strzelał dookoła po trafieniu pola zajętego.
            //Tutaj wybrałem poziom trudny, ponieważ daje to większą szansę na trafienie pól zajętych.
            PoziomTrudnosci poziomTrudnosci = PoziomTrudnosci.Trudny;
            L_Komputer komputer = new L_Komputer(plansza, poziomTrudnosci);

            int[] indeksy = new int[2];
            L_Pole trafionePole;
            L_Statek trafionyStatek;

            //Działanie

            //Komputer losuje pola dopóki nie trafi w pole zajęte
            for (int i = 0; i < plansza.Pola.GetLength(0); i++)
            {
                for (int j = 0; j < plansza.Pola.GetLength(1); j++)
                {
                    indeksy = komputer.LosujPole();
                    trafionePole = plansza.Pola[indeksy[0], indeksy[1]];
                    trafionePole.Trafione = true;

                    //Po trafieniu w pole zajęte trzeba sprawdzic, czy to pole nie należy do jednomasztowca, czyli czy statek nie został zatopiony od razu
                    if (trafionePole.Zajete)
                    {
                        trafionyStatek = plansza.Statki[trafionePole.IDStatku];
                        trafionyStatek.SprawdzStan();

                        //Jeśli statek nie jest zatopiony, komputer będzie strzelał dookoła
                        if (!trafionyStatek.Zatopiony)
                        {
                            komputer.SprawdzRuch();
                            break;
                        }
                    }

                    komputer.SprawdzRuch();
                }
            }

            //Indeksy po wykonaniu pętli są indeksami pierwszego pola trafionego statku
            //W tablicy poniżej przechowujemy kolejne indeksy z następnego losowania
            int[] kolejneIndeksy = komputer.LosujPole();

            //Indeksy pierwszego pola
            int i_1 = indeksy[0];
            int j_1 = indeksy[1];

            //Indeksy kolejnego pola
            int i_2 = kolejneIndeksy[0];
            int j_2 = kolejneIndeksy[1];

            //Sprawdzenie
            //Sprawdzamy czy kolejne wylosowane pole znajduje się w bezpośrednim sąsiedztwie poprzedniego pola. (lewo, góra, prawo, dół)
            //Komputer najpierw strzela w lewo, ale pole po lewej stronie może nie istnieć bądź może być już pustym polem trafionym.
            //W takim przypadku komputer strzeli w kolejnym kierunku, który, w sytuacji jak wyżej, może zostać zmieniony.
            Assert.IsTrue(
                j_2 < j_1 //Lewo
                || i_2 < i_1 //Góra
                || j_2 > j_1 //Prawo
                || i_2 > i_1 //Dół
            );
        }

        #endregion
    }
}
