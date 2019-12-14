using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika
{
    public interface IPole
    {
        bool Zajete
        {
            get;
        }

        bool Odsloniete
        {
            get;
            set;
        }
    }
}
