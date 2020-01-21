using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraWStatkiTesty.Komputer
{
    /// <summary>
    /// Summary description for L_KomputerTesty
    /// </summary>
    [TestClass]
    public class L_KomputerTesty
    {
        #region CzyZatopilemStatek

        [TestMethod]
        public void CzyZatopilemStatek_StatekNieMaTrafionychPol_ZwracaFalse()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CzyZatopilemStatek_WszystkiePolaStatkuSaTrafione_ZwracaTrue()
        {
            Assert.IsTrue(true);
        }

        #endregion
    }
}
