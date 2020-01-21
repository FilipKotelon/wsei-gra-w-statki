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

        /// <summary>
        /// Instancja obecnej gry.
        /// </summary>
        public L_Gra ObecnaGra
        {
            get
            {
                return _obecnaGra;
            }
        }

        /// <summary>
        /// Flaga zmieniana co turę.
        /// </summary>
        public bool CzyTuraGracza
        {
            get
            {
                return _czyTuraGracza;
            }
        }

        /// <summary>
        /// Gra jest uznana za skończoną, gdy wszystkie pola zajęte jednego z graczy zostały trafione.
        /// </summary>
        public bool GraSkonczona
        {
            get
            {
                return _graSkonczona;
            }
        }

        /// <summary>
        /// Ilość tur, powiększana z każdą turą.
        /// </summary>
        public int LicznikTur
        {
            get
            {
                return _licznikTur;
            }
        }

        public L_KontrolerGry() { }

        /// <summary>
        /// Stworzenie nowej gry i zresetowanie danych poprzednich gier.
        /// </summary>
        public void NowaGra()
        {
            _obecnaGra = new L_Gra();
            _sedzia = new L_Sedzia(_obecnaGra);
            _czyTuraGracza = true;
            _licznikTur = 1;
            _graSkonczona = false;
        }

        /// <summary>
        /// Zmiana tury z tury gracza na komputera i odwrotnie.
        /// </summary>
        public void ZmienTure()
        {
            _czyTuraGracza = !_czyTuraGracza;
            _licznikTur++;
        }

        /// <summary>
        /// Funkcja kończąca rozgrywkę i wyłaniająca zwycięzcę.
        /// </summary>
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
        }

        /// <summary>
        /// Funkcja wywoływana po kliknięciu któregoś z pól, sprawdza, czy należy zmienić turę lub zakończyć rozgrywkę.
        /// </summary>
        public void SprawdzRuch(bool trafionoStatek)
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
        }
    }
}
