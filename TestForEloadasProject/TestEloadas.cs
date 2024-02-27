using EloadasProject;
using NUnit.Framework;

namespace TestForEloadasProject
{
    public class TestEloadas
    {
        Eloadas eloadas;

        [SetUp]
        public void Setup()
        {
            eloadas = new Eloadas(5, 10);
        }

        private void MindenHelyLefoglal()
        {
            for (int i = 0; i < 50; i++)
            {
                eloadas.Lefoglal();
            }
        }

        private void OsszesHelyLefoglalKiveveEgy()
        {
            for (int i = 0; i < 49; i++)
            {
                eloadas.Lefoglal();
            }
        }

        [Test]
        public void KonstruktorHelyesParameterekkelNoError()
        {
            Assert.DoesNotThrow(() => new Eloadas(5, 10));
        }

        [Test]
        public void KonstruktorElsoParameterNegativ()
        {
            Assert.Throws<ArgumentException>(() => new Eloadas(-1, 10));
        }

        [Test]
        public void KonstruktorElsoParameter0()
        {
            Assert.Throws<ArgumentException>(() => new Eloadas(0, 10));
        }

        [Test]
        public void KonstruktorMasodikParameterNegativ()
        {
            Assert.Throws<ArgumentException>(() => new Eloadas(5, -1));
        }

        [Test]
        public void KonstruktorMasodikParameter0()
        {
            Assert.Throws<ArgumentException>(() => new Eloadas(5, 0));
        }

        [Test]
        public void ElsoSikeresLefoglalasa()
        {
            Assert.That(eloadas.Lefoglal(), Is.True, "Az elsõ hely foglalása nem sikerült.");
        }

        [Test]
        public void UtolsoHelyLefoglalhato()
        {
            OsszesHelyLefoglalKiveveEgy();
            Assert.That(eloadas.Lefoglal(), Is.True, "Az utolsó hely nem foglalható.");
        }

        [Test]
        public void UtolsoHelyLefoglalNincsTobbHely()
        {
            MindenHelyLefoglal();
            Assert.That(eloadas.Lefoglal(), Is.False, "Az utolsó hely foglalása sikeres, de nem lenne szabad.");
        }

        [Test]
        public void SzabadHelyekElosszorOsszeshelySzama()
        {
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(50));
        }

        [Test]
        public void SzabadHelyekFoglalassalEgyelCsokken()
        {
            eloadas.Lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(49), "A szabad helyek száma nem csökkent eggyel a foglalás után.");
        }

        [Test]
        public void SzabadHelyekTobbFoglalassalMegfelelonCsokken()
        {
            eloadas.Lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(49), "A szabad helyek száma nem csökkent megfelelõen az elsõ foglalás után.");
            eloadas.Lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(48), "A szabad helyek száma nem csökkent megfelelõen a második foglalás után.");
            eloadas.Lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(47), "A szabad helyek száma nem csökkent megfelelõen a harmadik foglalás után.");
        }

        [Test]
        public void SzabadHelyekOsszesHelyFogalasaUtan0()
        {
            MindenHelyLefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(0), "Az összes hely foglalása után a szabad helyek száma nem 0.");
        }

        [Test]
        public void FoglaltElsoParameter0()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(0, 3), "Az elsõ paraméter nem lehet 0.");
        }

        [Test]
        public void FoglaltElsoParameterNegativ()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(-1, 3), "Az elsõ paraméter nem lehet negatív.");
        }

        [Test]
        public void FoglaltElsoParameter1()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(1, 3), "Az elsõ paraméter 1 lehet.");
        }

        [Test]
        public void FoglaltElsoParameterMax()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(5, 3), "Az elsõ paraméter a maximum érték lehet.");
        }

        [Test]
        public void FoglaltElsoParameterNagyobbMintMax()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(6, 3), "Az elsõ paraméter nem lehet nagyobb, mint a maximum érték.");
        }

        [Test]
        public void FoglaltMasodikParameter0()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(3, 0), "A második paraméter nem lehet 0.");
        }

        [Test]
        public void FoglaltMasodikParameterNegativ()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(3, -1), "A második paraméter nem lehet negatív.");
        }

        [Test]
        public void FoglaltMasodikParameterNagyobbMintMax()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(3, 11), "A második paraméter nem lehet nagyobb, mint a maximum érték.");
        }

        [Test]
        public void FoglaltMasodikParameter1()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(3, 1), "A második paraméter 1 lehet.");
        }

        [Test]
        public void FoglaltMasodikParametermMax()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(3, 10), "A második paraméter a maximum érték lehet.");
        }

        [Test]
        public void TeliEgyHelyFogalalasUtan()
        {
            eloadas.Lefoglal();
            Assert.That(eloadas.Teli, Is.False, "Az elõadás nem lehetne teli egy foglalás után.");
        }

        [Test]
        public void TeliEgyHelySzabad()
        {
            OsszesHelyLefoglalKiveveEgy();
            Assert.That(eloadas.Teli, Is.False, "Az elõadás nem lehetne teli egy hely foglalása után sem.");
        }

        [Test]
        public void TeliMindenFoglalt()
        {
            MindenHelyLefoglal();
            Assert.That(eloadas.Teli, Is.True, "Az elõadás teli, pedig még mindig lenne szabad hely.");
        }

        [Test]
        public void FoglaltFoglalasSorfolytonossag()
        {
            eloadas.Lefoglal();
            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(1, 2), Is.True, "Az elsõ sor foglaltsága nem megfelelõ.");
            Assert.That(eloadas.Foglalt(2, 1), Is.False, "A második sor foglaltsága nem megfelelõ.");
        }

        [Test]
        public void FoglaltElsoSorUtanMasodikSorFogalodik()
        {
            for (int i = 0; i < 10; i++)
            {
                eloadas.Lefoglal();
            }
            Assert.That(eloadas.Foglalt(1, 10), Is.True, "Az elsõ sor foglaltsága nem megfelelõ.");
            Assert.That(eloadas.Foglalt(2, 1), Is.False, "A második sor foglaltsága nem megfelelõ.");

            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(2, 1), Is.True, "A második sor foglaltsága nem megfelelõ.");
        }

        [Test]
        public void FoglaltUtosoHelyVegenLeszCsakFoglalt()
        {
            OsszesHelyLefoglalKiveveEgy();
            Assert.That(eloadas.Foglalt(5, 10), Is.False, "Az utolsó hely végén nem foglalható.");
            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(5, 10), Is.True, "Az utolsó hely végén foglalható, pedig nem lenne szabad.");
        }

        [Test]
        public void FoglaltElsoHelyFoglalhato()
        {
            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(1, 1), Is.True, "Az elsõ hely nem lett foglalva.");
        }

        [Test]
        public void FoglaltElsoHelyNemFoglalt()
        {
            Assert.That(eloadas.Foglalt(1, 1), Is.False, "Az elsõ hely nem lett volna szabad.");
        }
    }
}
