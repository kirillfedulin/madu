namespace Ussimang
{
    public class Menuu
    {
        public void Kuvaa()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("USSIMÄNG");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Juhtimine: nooleklahvid");
                Console.WriteLine("  Eesmärk: söö nii palju toitu (@) kui võimalik");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  Vali raskusaste:");
                Console.WriteLine("    1 — Lihtne   (aeglane)");
                Console.WriteLine("    2 — Keskmine (normaalne)");
                Console.WriteLine("    3 — Raske    (kiire)");
                Console.WriteLine();
                Console.WriteLine("  5 — Vaata edetabelit");
                Console.WriteLine("  0 — Välju");
                Console.WriteLine();
                Console.Write("  Sinu valik: ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string? sisend = Console.ReadLine();

                if (sisend == "0") break;

                if (sisend == "5")
                {
                    Edetabel.Kuva();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("  Vajuta suvalist klahvi...");
                    Console.ReadKey(true);
                    continue;
                }

                if (!int.TryParse(sisend, out int tase) || tase < 1 || tase > 3)
                    tase = 1;

                Mang mang = new Mang(tase);
                mang.Algusta();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Head aega! 🐍\n");
            Console.ResetColor();
        }
    }
}
