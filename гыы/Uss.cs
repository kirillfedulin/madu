namespace Ussimang
{
    public class Uss
    {
        private List<Punkt> keha = new List<Punkt>();
        public Suund PraeguneSuund { get; set; }
        public int Pikkus => keha.Count;

        public Uss(int algX, int algY, int pikkus)
        {
            PraeguneSuund = Suund.Paremale;
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < pikkus; i++)
            {
                Punkt p = new Punkt(algX - i, algY, i == 0 ? '0' : '*');
                keha.Add(p);
                p.Joonista();
            }
        }

        public void Liigu()
        {
            Punkt pea = keha.First();
            Punkt uusPea = new Punkt(pea.X, pea.Y, '0');

            switch (PraeguneSuund)
            {
                case Suund.Paremale: uusPea.X++; break;
                case Suund.Vasakule: uusPea.X--; break;
                case Suund.Alla:     uusPea.Y++; break;
                case Suund.Ules:     uusPea.Y--; break;
            }

            pea.Symbolid = '*';

            keha.Insert(0, uusPea);
            Console.ForegroundColor = ConsoleColor.Cyan;
            uusPea.Joonista();

            Console.ForegroundColor = ConsoleColor.Green;
            pea.Joonista();

            Punkt saba = keha.Last();
            saba.Kustuta();
            keha.Remove(saba);
        }

        public Punkt HangiPea() => keha.First();

        public IEnumerable<Punkt> HangiKeha() => keha.Skip(1);

        public void Kasva()
        {
            Punkt viimane = keha.Last();
            keha.Add(new Punkt(viimane.X, viimane.Y, '*'));
        }
    }
}
