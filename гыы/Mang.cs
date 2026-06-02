namespace Ussimang
{
    public class Mang
    {
        private ManguSeaded seaded;
        private Kaart kaart;
        private Uss uss;
        private Toit toit;
        private int skoor;
        private int soodudToit;
        private int praeguneKiirus;

        public Mang(int tase)
        {
            seaded = new ManguSeaded(tase);
        }

        public void Algusta()
        {
            try
            {
                Console.SetWindowSize(seaded.Laius + 2, seaded.Korgus + 4);
                Console.SetBufferSize(seaded.Laius + 2, seaded.Korgus + 4);
            }
            catch { }

            Console.Clear();
            Console.CursorVisible = false;

            kaart = new Kaart(seaded.Laius, seaded.Korgus);
            uss   = new Uss(seaded.Laius / 2, seaded.Korgus / 2, 4);
            toit  = new Toit(seaded.Laius, seaded.Korgus);

            skoor         = 0;
            soodudToit    = 0;
            praeguneKiirus = seaded.KiirusMS;

            kaart.Joonista();
            JoonistaNaitaja();
            ManguTsükkel();
        }

        private void ManguTsükkel()
        {
            bool mangLabi = false;

            while (!mangLabi)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klahv = Console.ReadKey(true);

                    switch (klahv.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (uss.PraeguneSuund != Suund.Alla)
                                uss.PraeguneSuund = Suund.Ules;
                            break;
                        case ConsoleKey.DownArrow:
                            if (uss.PraeguneSuund != Suund.Ules)
                                uss.PraeguneSuund = Suund.Alla;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (uss.PraeguneSuund != Suund.Paremale)
                                uss.PraeguneSuund = Suund.Vasakule;
                            break;
                        case ConsoleKey.RightArrow:
                            if (uss.PraeguneSuund != Suund.Vasakule)
                                uss.PraeguneSuund = Suund.Paremale;
                            break;
                        case ConsoleKey.Escape:
                            mangLabi = true;
                            break;
                    }
                }

                if (mangLabi) break;

                uss.Liigu();
                Punkt pea = uss.HangiPea();

                if (kaart.OnTakistus(pea.X, pea.Y))
                {
                    mangLabi = true;
                    break;
                }

                if (uss.HangiKeha().Any(k => k.X == pea.X && k.Y == pea.Y))
                {
                    mangLabi = true;
                    break;
                }

                if (pea.X == toit.Asukoht.X && pea.Y == toit.Asukoht.Y)
                {
                    soodudToit++;
                    skoor += 10;
                    uss.Kasva();
                    toit.LooUusToit();
                    Heliefektid.MängiSöömist();

                    if (soodudToit % 5 == 0 && praeguneKiirus > 40)
                        praeguneKiirus -= 10;

                    JoonistaNaitaja();
                }

                Thread.Sleep(praeguneKiirus);
            }

            LopetaMang();
        }

        private void LopetaMang()
        {
            Heliefektid.MängiKaotust();
            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.Red;
            int cx = seaded.Laius / 2 - 6;
            int cy = seaded.Korgus / 2;
            Console.SetCursorPosition(cx, cy);
            Console.WriteLine("MÄNG ON LÄBI");
            Console.SetCursorPosition(cx, cy + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"     Skoor: {skoor} punkti     ");
            Thread.Sleep(1500);

            Console.SetCursorPosition(0, seaded.Korgus + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
            Console.Write("Sisesta oma nimi: ");
            string nimi = Console.ReadLine() ?? "Anonüüm";
            if (string.IsNullOrWhiteSpace(nimi)) nimi = "Anonüüm";

            Edetabel.Salvesta(nimi, skoor);
            Edetabel.Kuva();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  Vajuta suvalist klahvi...");
            Console.ReadKey(true);
            Console.CursorVisible = false;
        }

        private void JoonistaNaitaja()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            string info = $" Skoor: {skoor}   Kiirus: {seaded.KiirusMS - praeguneKiirus + seaded.KiirusMS} ";
            Console.Write(info.PadRight(seaded.Laius));
        }
    }
}
