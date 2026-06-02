namespace Ussimang
{
    public static class Heliefektid
    {
        public static void MängiSöömist()
        {
            Task.Run(() => { try { Console.Beep(800, 80); } catch { } });
        }

        public static void MängiKaotust()
        {
            Task.Run(() =>
            {
                try
                {
                    Console.Beep(400, 200);
                    Thread.Sleep(50);
                    Console.Beep(300, 200);
                    Thread.Sleep(50);
                    Console.Beep(200, 400);
                }
                catch { }
            });
        }
    }
}
