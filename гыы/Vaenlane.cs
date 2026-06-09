namespace Ussimang
{
    public class Vaenlane
    {
        private Punkt asukoht;
        private Random juhuslik = new Random();
        private int kaartLaius;
        private int kaartKorgus;
        private int sammLoendurid = 0;
        private int sammPiir;

        public Punkt Asukoht => asukoht;

        public Vaenlane(int laius, int korgus, int raskus)
        {
            kaartLaius = laius;
            kaartKorgus = korgus;
            sammPiir = raskus switch
            {
                1 => 3,
                2 => 2,
                3 => 1,
                _ => 3
            };

            asukoht = new Punkt(2, 2, 'X');
            Console.ForegroundColor = ConsoleColor.Magenta;
            asukoht.Joonista();
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Liigu(Punkt ussipea, Kaart kaart)
        {
            sammLoendurid++;
            if (sammLoendurid < sammPiir)
                return;

            sammLoendurid = 0;

            asukoht.Kustuta();

            int uusX = asukoht.X;
            int uusY = asukoht.Y;

            int dx = ussipea.X - asukoht.X;
            int dy = ussipea.Y - asukoht.Y;

            bool liikusX = false;
            bool liikusY = false;

            if (Math.Abs(dx) >= Math.Abs(dy) && dx != 0)
            {
                uusX += dx > 0 ? 1 : -1;
                liikusX = true;
            }
            else if (dy != 0)
            {
                uusY += dy > 0 ? 1 : -1;
                liikusY = true;
            }

            if (kaart.OnTakistus(uusX, uusY))
            {
                uusX = asukoht.X;
                uusY = asukoht.Y;

                if (liikusX && dy != 0)
                    uusY = asukoht.Y + (dy > 0 ? 1 : -1);
                else if (liikusY && dx != 0)
                    uusX = asukoht.X + (dx > 0 ? 1 : -1);
            }

            if (!kaart.OnTakistus(uusX, uusY))
            {
                asukoht.X = uusX;
                asukoht.Y = uusY;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            asukoht.Joonista();
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public bool PuutubKokku(Punkt teinePunkt)
        {
            return asukoht.X == teinePunkt.X && asukoht.Y == teinePunkt.Y;
        }

        public bool PuutubKokkuUssiga(IEnumerable<Punkt> ussKeha)
        {
            return ussKeha.Any(k => k.X == asukoht.X && k.Y == asukoht.Y);
        }
    }
}
