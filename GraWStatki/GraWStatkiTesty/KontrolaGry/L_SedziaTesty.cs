using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraWStatkiLogika.KontrolaGry;
using GraWStatkiLogika.PlanszaBitwy.Pola;

namespace GraWStatkiTesty.KontrolaGry
{
    [TestClass]
    public class L_SedziaTesty
    {
        #region SprawdzCzyKoniec_TuraGracza

        [TestMethod]
        public void SprawdzCzyKoniec_TuraGraczaIPolaKomputeraNieSaTrafione_ZwracaFalse()
        {
            //Przygotowanie
            //Nowa gra z polami nietrafionymi
            L_Gra gra = new L_Gra();
            L_Sedzia sedzia = new L_Sedzia(gra);

            //Działanie
            bool wynik = sedzia.SprawdzCzyKoniec(true);

            //Sprawdzenie
            Assert.IsTrue(wynik == false);
        }

        [TestMethod]
        public void SprawdzCzyKoniec_TuraGraczaIPolaKomputeraSaTrafione_ZwracaTrue()
        {
            //Przygotowanie
            //Nowa gra z polami nietrafionymi
            L_Gra gra = new L_Gra();
            L_Pole[,] polaKomputera = gra.PlanszaKomputera.Pola;

            for (int i = 0; i < polaKomputera.GetLength(0); i++)
            {
                for (int j = 0; j < polaKomputera.GetLength(1); j++)
                {
                    //Trafienie każdego zajętego pola
                    if (polaKomputera[i, j].Zajete)
                    {
                        polaKomputera[i, j].Trafione = true;
                    }
                }
            }

            L_Sedzia sedzia = new L_Sedzia(gra);

            //Działanie
            bool wynik = sedzia.SprawdzCzyKoniec(true);

            //Sprawdzenie
            Assert.IsTrue(wynik);
        }

        #endregion

        #region SprawdzCzyKoniec_TuraKomputera
        [TestMethod]
        public void SprawdzCzyKoniec_TuraKomputeraIPolaGraczaNieSaTrafione_ZwracaFalse()
        {
            //Przygotowanie
            //Nowa gra z polami nietrafionymi
            L_Gra gra = new L_Gra();
            L_Sedzia sedzia = new L_Sedzia(gra);

            //Działanie
            bool wynik = sedzia.SprawdzCzyKoniec(false);

            //Sprawdzenie
            Assert.IsTrue(wynik == false);
        }

        [TestMethod]
        public void SprawdzCzyKoniec_TuraKomputeraIPolaGraczaSaTrafione_ZwracaTrue()
        {
            //Przygotowanie
            //Nowa gra z polami nietrafionymi
            L_Gra gra = new L_Gra();
            L_Pole[,] polaGracza = gra.PlanszaGracza.Pola;

            for (int i = 0; i < polaGracza.GetLength(0); i++)
            {
                for (int j = 0; j < polaGracza.GetLength(1); j++)
                {
                    //Trafienie każdego zajętego pola
                    if (polaGracza[i, j].Zajete)
                    {
                        polaGracza[i, j].Trafione = true;
                    }
                }
            }

            L_Sedzia sedzia = new L_Sedzia(gra);

            //Działanie
            bool wynik = sedzia.SprawdzCzyKoniec(false);

            //Sprawdzenie
            Assert.IsTrue(wynik);
        }

        #endregion
    }
}
