namespace Ussimang
{
    public class Kaart
    {
        public List<Punkt> Takistused { get; private set; } = new List<Punkt>();
        public int Laius  { get; private set; }
        public int Korgus { get; private set; }

        public Kaart(int laius, int korgus)
        {
            Laius  = laius;
            Korgus = korgus;

            for (int x = 0; x < laius; x++)
            {
                Takistused.Add(new Punkt(x, 0, '#'));
                Takistused.Add(new Punkt(x, korgus - 1, '#'));
            }

            for (int y = 1; y < korgus - 1; y++)
            {
                Takistused.Add(new Punkt(0, y, '#'));
                Takistused.Add(new Punkt(laius - 1, y, '#'));
            }
        }

        public void Joonista()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var p in Takistused)
                p.Joonista();
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public bool OnTakistus(int x, int y)
        {
            return Takistused.Any(t => t.X == x && t.Y == y);
        }
    }
}
