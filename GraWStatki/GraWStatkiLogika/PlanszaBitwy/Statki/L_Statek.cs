using GraWStatkiLogika.PlanszaBitwy.Pola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Statki
{
    public class L_Statek
    {
        protected int _ID;
        protected int _iloscPol;
        protected bool _zatopiony;
        protected List<L_Pole> _pola;

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public int IloscPol
        {
            get
            {
                return _iloscPol;
            }
        }

        public bool Zatopiony
        {
            get
            {
                return _zatopiony;
            }
        }

        public List<L_Pole> Pola
        {
            get
            {
                return _pola;
            }
        }
    }
}
