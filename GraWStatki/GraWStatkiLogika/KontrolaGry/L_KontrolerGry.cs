using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.KontrolaGry
{
    public class L_KontrolerGry
    {
        private L_Gra _obecnaGra;
        public L_Gra ObecnaGra
        {
            get
            {
                return _obecnaGra;
            }
        }
        public L_KontrolerGry()
        {
            _obecnaGra = new L_Gra();
        }
    }
}
