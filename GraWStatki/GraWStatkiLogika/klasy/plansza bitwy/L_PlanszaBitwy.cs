using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.klasy.plansza_bitwy
{
    public class L_PlanszaBitwy
    {
        private IPole[,] _pola = new IPole[10, 10];

        public IPole[,] Pola
        {
            get
            {
                return _pola;
            }
        }

        public L_PlanszaBitwy()
        {
            _pola[0, 5] = new L_PolePuste();
            _pola[3, 4] = new L_PolePuste();
            _pola[2, 9] = new L_PoleZajete();
            _pola[8, 4] = new L_PoleZajete();
        }
    }
}
