using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraWStatkiLogika.KontrolaGry;

namespace GraWStatkiTesty.KontrolaGry
{
    [TestClass]
    public class L_KontrolerGryTesty
    {
        #region ZmienTure
        [TestMethod]
        public void ZmienTure_TuraZostalaZmienionaILicznikTurZostalPowiekszony()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            bool czyTuraGracza = kontroler.CzyTuraGracza;
            int poprzedniaTura = kontroler.LicznikTur;

            //Działanie
            kontroler.ZmienTure();

            //Sprawdzenie
            Assert.IsTrue(czyTuraGracza != kontroler.CzyTuraGracza && poprzedniaTura < kontroler.LicznikTur);
        }
        #endregion

        #region SprawdzRuch
        [TestMethod]
        public void SprawdzRuch_NieTrafionoStatku_TuraZostalaZmienionaILicznikTurZostalPowiekszony()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            kontroler.NowaGra();
            bool czyTuraGracza = kontroler.CzyTuraGracza;
            int poprzedniaTura = kontroler.LicznikTur;

            //Działanie
            kontroler.SprawdzRuch(false);

            //Sprawdzenie
            Assert.IsTrue(czyTuraGracza != kontroler.CzyTuraGracza && poprzedniaTura < kontroler.LicznikTur);
        }

        [TestMethod]
        public void SprawdzRuch_TrafionoStatek_TuraNieZostalaZmienionaILicznikTurNieZostalPowiekszony()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            kontroler.NowaGra();
            bool czyTuraGracza = kontroler.CzyTuraGracza;
            int poprzedniaTura = kontroler.LicznikTur;

            //Działanie
            kontroler.SprawdzRuch(true);

            //Sprawdzenie
            Assert.IsTrue(czyTuraGracza == kontroler.CzyTuraGracza && poprzedniaTura == kontroler.LicznikTur);
        }
        #endregion

        #region ZakonczGre
        [TestMethod]
        public void ZakonczGre_TuraGracza_ZwyciezcaToGracz()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            kontroler.NowaGra();

            //Działanie
            kontroler.ZakonczGre();

            //Sprawdzenie
            Assert.IsTrue(kontroler.ObecnaGra.zwyciezca == "Gracz");
        }

        //Todo
        [TestMethod]
        public void ZakonczGre_TuraKomputera_ZwyciezcaToKomputer()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            kontroler.NowaGra();
            //Zmiana tury na turę komputera
            kontroler.ZmienTure();

            //Działanie
            kontroler.ZakonczGre();

            //Sprawdzenie
            Assert.IsTrue(kontroler.ObecnaGra.zwyciezca == "Komputer");
        }
        #endregion
    }
}
