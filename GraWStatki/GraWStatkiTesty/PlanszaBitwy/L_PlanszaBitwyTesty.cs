using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraWStatkiLogika.PlanszaBitwy;
using GraWStatkiLogika.PlanszaBitwy.Pola;
using GraWStatkiLogika.PlanszaBitwy.Statki;

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
        public void WypelnijPustePola_NieMaPolOwartosciNull()
        {
            //Przygotowanie
            L_PlanszaBitwy plansza = new L_PlanszaBitwy();
            L_Pole[,] pola = plansza.Pola;

            //Działanie
            bool polaSaPuste = true;

            for (int i = 0; i < pola.GetLength(0); i++)
            {
                for (int j = 0; j < pola.GetLength(1); j++)
                {
                    if (pola[i, j] == null)
                    {
                        polaSaPuste = false;
                    }
                }
            }

            //Sprawdzenie
            Assert.IsTrue(polaSaPuste);
        }

        //Todo
        [TestMethod]
        public void DodajStatek_DodanoJedenStatek()
        {
            //Przygotowanie
            L_PlanszaBitwy plansza = new L_PlanszaBitwy();
            List<L_Statek> listaStatkow = plansza.Statki;
            int poprzedniaDlugosc = listaStatkow.Count;

            L_Statek statek = new L_Statek();

            //Działanie
            plansza.DodajStatek(statek);

            //Sprawdzenie
            Assert.IsTrue(listaStatkow.Count > poprzedniaDlugosc);
        }
    }
}
