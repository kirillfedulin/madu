namespace Ussimang
{
    public class Toit
    {
        private Random juhuslik = new Random();
        private int ekraaniLaius;
        private int ekraaniKorgus;

        public Punkt Asukoht { get; private set; }

        public Toit(int laius, int korgus)
        {
            ekraaniLaius = laius;
            ekraaniKorgus = korgus;
            LooUusToit();
        }

        public void LooUusToit()
        {
            int x = juhuslik.Next(2, ekraaniLaius - 2);
            int y = juhuslik.Next(2, ekraaniKorgus - 2);
            Asukoht = new Punkt(x, y, '@');
            Console.ForegroundColor = ConsoleColor.Red;
            Asukoht.Joonista();
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
