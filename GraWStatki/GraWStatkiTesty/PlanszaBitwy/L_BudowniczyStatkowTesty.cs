using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraWStatkiLogika.PlanszaBitwy.BudowniczyStatkow;
using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using GraWStatkiLogika.PlanszaBitwy.Statki;

namespace GraWStatkiTesty.PlanszaBitwy
{
    /// <summary>
    /// Testy klasy L_Budowniczy
    /// </summary>
    [TestClass]
    public class L_BudowniczyStatkowTesty
    {
        [TestMethod]
        public void BudujStatkiLosowo_Zbudowano10Statkow()
        {
            //Przygotowanie
            L_Pole[,] tablicaPol = new L_Pole[10, 10];
            L_BudowniczyStatkow budowniczy = new L_BudowniczyStatkow(tablicaPol);

            //Działanie
            budowniczy.BudujStatkiLosowo();

            //Sprawdzenie
            Assert.IsTrue(budowniczy.OddajStatki().Count == 10);
        }

        [TestMethod]
        public void OddajPlansze_ZwroconoTablice2DTypuL_Pole()
        {
            //Przygotowanie
            L_Pole[,] tablicaPol = new L_Pole[10, 10];
            L_BudowniczyStatkow budowniczy = new L_BudowniczyStatkow(tablicaPol);

            //Działanie
            var zwroconaWartosc = budowniczy.OddajPlansze();

            //Sprawdzenie
            Assert.IsTrue(zwroconaWartosc is L_Pole[,]);
        }

        [TestMethod]
        public void OddajStatki_ZwroconoListeTypuL_Statek()
        {
            //Przygotowanie
            L_Pole[,] tablicaPol = new L_Pole[10, 10];
            L_BudowniczyStatkow budowniczy = new L_BudowniczyStatkow(tablicaPol);

            //Działanie
            var zwroconaWartosc = budowniczy.OddajStatki();

            //Sprawdzenie
            Assert.IsTrue(zwroconaWartosc is List<L_Statek>);
        }
    }
}
