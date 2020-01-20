using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraWStatkiLogika.PlanszaBitwy.Statki;
using GraWStatkiLogika.PlanszaBitwy.Pola;

namespace GraWStatkiTesty.PlanszaBitwy
{
    /// <summary>
    /// Testy klasy L_Statek
    /// </summary>
    [TestClass]
    public class L_StatekTesty
    {
        #region DodajPole_Jednomasztowiec

        [TestMethod]
        public void DodajPole_JednomasztowiecBezPol_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Jednomasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_JednomasztowiecZJednymPolem_PoleNieZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Jednomasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);
            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            nowePole = new L_PoleZajete(IDStatku);

            //Działanie
            //Dodaję pole po raz drugi
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol == statek.Pola.Count);
        }

        #endregion

        #region DodajPole_Dwumasztowiec

        [TestMethod]
        public void DodajPole_DwumasztowiecBezPol_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Dwumasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_DwumasztowiecZJednymPolem_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Dwumasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);
            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_DwumasztowiecZDwomaPolami_PoleNieZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Dwumasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);

            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz trzeci
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol == statek.Pola.Count);
        }

        #endregion

        #region DodajPole_Trojmasztowiec

        [TestMethod]
        public void DodajPole_TrojmasztowiecBezPol_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Trojmasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_TrojmasztowiecZJednymPolem_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Trojmasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);
            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_TrojmasztowiecZDwomaPolami_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Trojmasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);

            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz trzeci
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_TrojmasztowiecZTrzemaPolami_PoleNieZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Trojmasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);

            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Dodaję pole po raz trzeci
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz czwarty
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol == statek.Pola.Count);
        }

        #endregion

        #region DodajPole_Czteromasztowiec

        [TestMethod]
        public void DodajPole_CzteromasztowiecBezPol_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Czteromasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_CzteromasztowiecZJednymPolem_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Czteromasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);
            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_CzteromasztowiecZDwomaPolami_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Czteromasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);

            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz trzeci
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_CzteromasztowiecZTrzemaPolami_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Czteromasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);

            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Dodaję pole po raz trzeci
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz czwarty
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_CzteromasztowiecZCzteremaPolami_PoleNieZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Czteromasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            //Dodaję pole po raz pierwszy
            statek.DodajPole(nowePole);

            //Dodaję pole po raz drugi
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Dodaję pole po raz trzeci
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Dodaję pole po raz czwarty
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            //Dodaję pole po raz piąty
            nowePole = new L_PoleZajete(IDStatku);
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol == statek.Pola.Count);
        }

        #endregion

        #region DodajPole_Ogolne

        [TestMethod]
        public void DodajPole_PolePuste_PoleNieZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Jednomasztowiec(IDStatku);
            L_Pole nowePole = new L_PolePuste();

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol == statek.Pola.Count);
        }

        [TestMethod]
        public void DodajPole_PoleZajete_PoleZostanieDodane()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Jednomasztowiec(IDStatku);
            L_Pole nowePole = new L_PoleZajete(IDStatku);

            List<L_Pole> listaPol = statek.Pola;
            int iloscPol = listaPol.Count;

            //Działanie
            statek.DodajPole(nowePole);

            //Sprawdzenie
            Assert.IsTrue(iloscPol < statek.Pola.Count);
        }

        #endregion

        #region SprawdzStan_Jednomasztowiec

        [TestMethod]
        public void SprawdzStan_JednomasztowiecIPolaNieTrafione_StatekNieJestZatopiony()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Jednomasztowiec(IDStatku);

            L_Pole pole = new L_PoleZajete(IDStatku);
            statek.DodajPole(pole);

            //Działanie
            statek.SprawdzStan();

            //Sprawdzenie
            Assert.IsTrue(statek.Zatopiony == false);
        }

        [TestMethod]
        public void SprawdzStan_JednomasztowiecIPolaTrafione_StatekJestZatopiony()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Jednomasztowiec(IDStatku);

            L_Pole pole = new L_PoleZajete(IDStatku);
            pole.Trafione = true;
            statek.DodajPole(pole);

            //Działanie
            statek.SprawdzStan();

            //Sprawdzenie
            Assert.IsTrue(statek.Zatopiony == true);
        }

        #endregion

        #region SprawdzStan_Dwumasztowiec

        [TestMethod]
        public void SprawdzStan_DwuMasztowiecIPolaNieTrafione_StatekNieJestZatopiony()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Dwumasztowiec(IDStatku);

            L_Pole pole = new L_PoleZajete(IDStatku);
            statek.DodajPole(pole);

            pole = new L_PoleZajete(IDStatku);
            statek.DodajPole(pole);

            //Działanie
            statek.SprawdzStan();

            //Sprawdzenie
            Assert.IsTrue(statek.Zatopiony == false);
        }

        [TestMethod]
        public void SprawdzStan_DwuMasztowiecIJednoPoleTrafione_StatekNieJestZatopiony()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Dwumasztowiec(IDStatku);

            L_Pole pole = new L_PoleZajete(IDStatku);
            pole.Trafione = true;
            statek.DodajPole(pole);

            pole = new L_PoleZajete(IDStatku);
            statek.DodajPole(pole);

            //Działanie
            statek.SprawdzStan();

            //Sprawdzenie
            Assert.IsTrue(statek.Zatopiony == false);
        }

        [TestMethod]
        public void SprawdzStan_DwumasztowiecIPolaTrafione_StatekJestZatopiony()
        {
            //Przygotowanie
            int IDStatku = 0;
            L_Statek statek = new L_Jednomasztowiec(IDStatku);

            L_Pole pole = new L_PoleZajete(IDStatku);
            pole.Trafione = true;
            statek.DodajPole(pole);

            pole = new L_PoleZajete(IDStatku);
            pole.Trafione = true;
            statek.DodajPole(pole);

            //Działanie
            statek.SprawdzStan();

            //Sprawdzenie
            Assert.IsTrue(statek.Zatopiony == true);
        }

        #endregion

        //Todo
        #region SprawdzStan_Trojmasztowiec

        #endregion

        //Todo
        #region SprawdzStan_Czteromasztowiec

        #endregion
    }
}
