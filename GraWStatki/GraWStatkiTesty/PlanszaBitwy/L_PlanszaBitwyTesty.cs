using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraWStatkiTesty.PlanszaBitwy
{
    /// <summary>
    /// Summary description for L_PlanszaBitwyTesty
    /// </summary>
    [TestClass]
    public class L_PlanszaBitwyTesty
    {
        //Todo
        [TestMethod]
        public void WypelnijPustePola_NieMaPustychPol()
        {
            //Przygotowanie
            //Zrób sobie nową L_PlanszaBitwy i pobierz jej pola, np pola = plansza.Pola
            //Potem w działaniu sprawdź czy wszystkie pola są puste

            //Działanie
            //Daj flagę przed, np. bool polaSaPuste = true;
            //Przy kazdym przejsciu petli, jesli plansza.Pola[i, j] != null to polaSaPuste = false

            //Sprawdzenie
            //Assert czy polaSaPuste to true
        }

        //Todo
        [TestMethod]
        public void DodajStatek_DodanoJedenStatek()
        {
            //Przygotowanie
            //Zrób sobie nową L_PlanszaBitwy i pobierz jej statki
            //Pobierz długość listy ze statkami (obecnaDlugosc = lista.Count)
            //Stwórz nowy statek (np. w pliku L_BudowniczyStatków, linia 399)

            //Działanie
            //Dodaj statek funkcją

            //Sprawdzenie
            //Assert czy długość listy statków się powiększyła
        }
    }
}
