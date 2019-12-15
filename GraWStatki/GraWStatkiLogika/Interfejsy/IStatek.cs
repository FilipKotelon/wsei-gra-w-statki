using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWStatkiLogika.Interfejsy
{
    interface IStatek
    {
        int ID { get; }

        int IloscPol { get; }

        bool Zatopiony { get; }

        List<IPole> Pola { get; }
    }
}
