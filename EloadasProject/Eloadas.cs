namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;

        public Eloadas(int sorokSzama, int helyekSzama)
        {
            if (sorokSzama < 1)
            {
                throw new ArgumentException("Pozitív egész számot kell megadni", nameof(sorokSzama));
            }
            if (helyekSzama < 1)
            {
                throw new ArgumentException("Pozitív egész számot kell megadni!", nameof(helyekSzama));
            }
            this.foglalasok = new bool[sorokSzama, helyekSzama];
        }


    }
}