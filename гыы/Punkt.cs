namespace Ussimang
{
    public class Punkt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbolid { get; set; }

        public Punkt(int x, int y, char symbolid)
        {
            X = x;
            Y = y;
            Symbolid = symbolid;
        }

        public void Joonista()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbolid);
        }

        public void Kustuta()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
