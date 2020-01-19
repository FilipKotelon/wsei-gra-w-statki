using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraWStatkiLogika.KontrolaGry;

namespace GraWStatkiTesty.KontrolaGry
{
    [TestClass]
    public class L_SedziaTesty
    {
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
            Assert.IsFalse(wynik);
        }

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
            Assert.IsFalse(wynik);
        }
    }
}
