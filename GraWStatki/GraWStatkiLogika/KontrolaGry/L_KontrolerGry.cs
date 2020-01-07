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
        private L_Sedzia _sedzia;

        public L_Gra ObecnaGra
        {
            get
            {
                return _obecnaGra;
            }
        }
        public L_KontrolerGry()
        {
            NowaGra();
        }

        public void NowaGra()
        {
            _obecnaGra = new L_Gra();
            _sedzia = new L_Sedzia(_obecnaGra);
        }
    }
}
