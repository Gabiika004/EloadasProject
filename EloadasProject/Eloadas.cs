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

        public bool Lefoglal()
        {
            bool sikeres = false;
            int i = 0;
            while (i < this.foglalasok.GetLength(0) && !sikeres)
            {
                int j = 0;
                while (j < this.foglalasok.GetLength(1) && !sikeres)
                {
                    if (!this.foglalasok[i, j])
                    {
                        this.foglalasok[i, j] = true;
                        sikeres = true;
                    }
                    j++;
                }
                i++;
            }
            return sikeres;
        }


        public int SzabadHelyek
        {
            get
            {
                int db = 0;
                foreach (bool hely in this.foglalasok)
                {
                    if (!hely)
                    {
                        db++;
                    }
                }
                return db;
            }
        }

        public bool Teli
        {
            get
            {
                bool teli = true;
                int i = 0;
                while (i < this.foglalasok.GetLength(0) && teli)
                {
                    int j = 0;
                    while (j < this.foglalasok.GetLength(1) && teli)
                    {
                        if (!this.foglalasok[i, j])
                        {
                            teli = false;
                        }
                        j++;
                    }
                    i++;
                }
                return teli;
            }
        }

        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam < 1)
            {
                throw new ArgumentException("Pozitív egész számot kell megadni!", nameof(sorSzam));
            }
            if (sorSzam > this.foglalasok.GetLength(0))
            {
                throw new ArgumentException("A sorszám nem lehet nagyobb, mint a sorok száma", nameof(sorSzam));
            }
            if (helySzam < 1)
            {
                throw new ArgumentException("Pozitív egész számot kell megadni!", nameof(helySzam));
            }
            if (helySzam > this.foglalasok.GetLength(1))
            {
                throw new ArgumentException("A helyszám nem lehet nagyobb, mint a helyek száma a sorokban", nameof(helySzam));
            }
            return this.foglalasok[sorSzam - 1, helySzam - 1];
        }


    }
}