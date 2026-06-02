namespace Ussimang
{
    public static class Edetabel
    {
        private static string failiTee = "skoorid.txt";

        public static void Salvesta(string nimi, int skoor)
        {
            File.AppendAllLines(failiTee, new[] { $"{nimi};{skoor}" });
        }

        public static void Kuva()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TOP 5 EDETABEL");
            Console.WriteLine();

            if (!File.Exists(failiTee) || File.ReadAllLines(failiTee).Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Tulemusi pole veel. Ole esimene!");
                Console.WriteLine();
                return;
            }

            var skoorid = File.ReadAllLines(failiTee)
                .Select(rida => rida.Split(';'))
                .Where(osad => osad.Length == 2 && int.TryParse(osad[1], out _))
                .Select(osad => new { Nimi = osad[0], Punktid = int.Parse(osad[1]) })
                .OrderByDescending(x => x.Punktid)
                .Take(5)
                .ToList();

            string[] medalid = { "1", "2", "3", "4.", "5." };

            for (int i = 0; i < skoorid.Count; i++)
            {
                Console.ForegroundColor = i == 0 ? ConsoleColor.Yellow  :
                                          i == 1 ? ConsoleColor.White   :
                                          i == 2 ? ConsoleColor.DarkYellow : ConsoleColor.Gray;
                Console.WriteLine($"  {medalid[i]} {skoorid[i].Nimi,-15} {skoorid[i].Punktid,6} punkti");
            }
            Console.WriteLine();
        }
    }
}
