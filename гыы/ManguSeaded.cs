namespace Ussimang
{
    public class ManguSeaded
    {
        public int Laius    { get; set; }
        public int Korgus   { get; set; }
        public int KiirusMS { get; set; }
        public int Tase     { get; set; }

        public ManguSeaded(int tase)
        {
            Tase = tase;
            switch (tase)
            {
                case 1:  KiirusMS = 200; Laius = 50; Korgus = 22; break;
                case 2:  KiirusMS = 120; Laius = 50; Korgus = 22; break;
                case 3:  KiirusMS = 60;  Laius = 50; Korgus = 22; break;
                default: KiirusMS = 200; Laius = 50; Korgus = 22; break;
            }
        }
    }
}
