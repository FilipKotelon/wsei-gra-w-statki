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


        //Todo
        [TestMethod]
        public void SprawdzRuch_NieTrafionoStatku_TuraZostalaZmienionaILicznikTurZostalPowiekszony()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            bool czyTuraGracza = kontroler.CzyTuraGracza;
            int poprzedniaTura = kontroler.LicznikTur;

            //Działanie
            //SprawdzRuch

            //Sprawdzenie
            Assert.IsTrue(czyTuraGracza != kontroler.CzyTuraGracza && poprzedniaTura < kontroler.LicznikTur);
        }

        //Todo
        [TestMethod]
        public void SprawdzRuch_TrafionoStatek_TuraNieZostalaZmienionaILicznikTurNieZostalPowiekszony()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            bool czyTuraGracza = kontroler.CzyTuraGracza;
            int poprzedniaTura = kontroler.LicznikTur;

            //Działanie
            //SprawdzRuch

            //Sprawdzenie
            //Sprawdź czy są równe temu co było
            //Assert.IsTrue();
        }

        //Todo
        [TestMethod]
        public void ZakonczGre_TuraGracza_ZwyciezcaToGracz()
        {
            //Przygotowanie
            L_KontrolerGry kontroler = new L_KontrolerGry();
            //Tworzysz nową grę kontroler.NowaGra()
            //Na początku jest tura gracza więc tu jest ok

            //Działanie
            //ZakonczGre

            //Sprawdzenie
            //Assert czy zwyciezca == "Gracz"
        }

        //Todo
        [TestMethod]
        public void ZakonczGre_TuraKomputera_ZwyciezcaToKomputer()
        {
            //Przygotowanie
            //To samo co wyżej, tylko w działaniu najpierw zmieniasz turę, żeby była komputera

            //Działanie
            //A potem kończysz

            //Sprawdzenie
            //Assert czy zwyciezca == "Komputer"
        }
    }
}
