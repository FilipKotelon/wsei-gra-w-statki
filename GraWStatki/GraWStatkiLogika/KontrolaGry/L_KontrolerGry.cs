using GraWStatkiLogika.Interfejsy;
using GraWStatkiLogika.PlanszaBitwy;
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
        private bool _graSkonczona;
        private bool _czyTuraGracza;
        private int _licznikTur;

        public L_Gra ObecnaGra
        {
            get
            {
                return _obecnaGra;
            }
        }

        public bool CzyTuraGracza
        {
            get
            {
                return _czyTuraGracza;
            }
        }

        public bool GraSkonczona
        {
            get
            {
                return _graSkonczona;
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
            _czyTuraGracza = true;
            _licznikTur = 1;
            _graSkonczona = false;
        }

        public void ZmienTure()
        {
            _czyTuraGracza = !_czyTuraGracza;
            _licznikTur++;
        }

        public void ZakonczGre()
        {
            if (_czyTuraGracza)
            {
                _obecnaGra.zwyciezca = _obecnaGra.Gracz;
            }
            else
            {
                _obecnaGra.zwyciezca = _obecnaGra.Komputer;
            }

            Console.WriteLine($"Grę wygrał {_obecnaGra.zwyciezca} w ciągu {_licznikTur} tur!");
        }

        /// <summary>
        /// Funkcja wywoływana po kliknięciu któregoś z pól
        /// </summary>
        public void SprawdzRuch(bool trafionoStatek, IPole pole)
        {
            //Jeżeli nie trafiono w żaden statek, tylko zmień turę
            if (!trafionoStatek)
            {
                ZmienTure();
                return;
            }

            _graSkonczona = _sedzia.SprawdzCzyKoniec(_czyTuraGracza);

            //Jeżeli gra się nie skończyła a żaden statek nie został trafiony, zmień turę
            if (!_graSkonczona && !trafionoStatek)
            {
                ZmienTure();
                return;
            }

            if(!_graSkonczona && trafionoStatek)
            {
                if (pole.Zajete)
                {
                    IStatek[] statki;
                    IStatek statek;

                    if (_czyTuraGracza)
                    {
                        statki = _obecnaGra.PlanszaGracza.Statki;
                    }
                    else
                    {
                        statki = _obecnaGra.PlanszaKomputera.Statki;
                    }

                    statek = statki[pole.IDStatku];

                    statek.SprawdzStan();
                }
            }
        }

        //W graficznej kontroli po logicznym sprawdzeniu ruchu będzie sprawdzane, czy gra się zakończyła
        //Potem nastąpi zakończenie gry najpierw logiczne, a potem graficzne
        //Na koniec gra zapyta, czy rozpocząć grę od nowa
    }
}
