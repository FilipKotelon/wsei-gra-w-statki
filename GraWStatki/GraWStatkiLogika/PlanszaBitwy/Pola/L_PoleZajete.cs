﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.PlanszaBitwy.Pola
{
    public class L_PoleZajete : L_Pole
    {
        private int _IDStatku;

<<<<<<< HEAD
        public bool Zajete
        {
            get
            {
                return _zajete;
            }
        }

        public bool Trafione
        {
            get
            {
                return _trafione;
            }
            set
            {
                _trafione = value;
            }
        }

        public int IDStatku
        {
            get
            {
                return _IDStatku;
            }
        }

=======
>>>>>>> 695bd256381ddbf7704ffcd953e0147b61d041b0
        public L_PoleZajete(int IDStatku)
        {
            this._zajete = true;
            this._trafione = false;
            this._IDStatku = IDStatku;
        }
    }
}
