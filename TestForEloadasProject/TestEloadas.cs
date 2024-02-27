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
            Assert.That(eloadas.Lefoglal(), Is.True, "Az els� hely foglal�sa nem siker�lt.");
        }

        [Test]
        public void UtolsoHelyLefoglalhato()
        {
            OsszesHelyLefoglalKiveveEgy();
            Assert.That(eloadas.Lefoglal(), Is.True, "Az utols� hely nem foglalhat�.");
        }

        [Test]
        public void UtolsoHelyLefoglalNincsTobbHely()
        {
            MindenHelyLefoglal();
            Assert.That(eloadas.Lefoglal(), Is.False, "Az utols� hely foglal�sa sikeres, de nem lenne szabad.");
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
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(49), "A szabad helyek sz�ma nem cs�kkent eggyel a foglal�s ut�n.");
        }

        [Test]
        public void SzabadHelyekTobbFoglalassalMegfelelonCsokken()
        {
            eloadas.Lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(49), "A szabad helyek sz�ma nem cs�kkent megfelel�en az els� foglal�s ut�n.");
            eloadas.Lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(48), "A szabad helyek sz�ma nem cs�kkent megfelel�en a m�sodik foglal�s ut�n.");
            eloadas.Lefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(47), "A szabad helyek sz�ma nem cs�kkent megfelel�en a harmadik foglal�s ut�n.");
        }

        [Test]
        public void SzabadHelyekOsszesHelyFogalasaUtan0()
        {
            MindenHelyLefoglal();
            Assert.That(eloadas.SzabadHelyek, Is.EqualTo(0), "Az �sszes hely foglal�sa ut�n a szabad helyek sz�ma nem 0.");
        }

        [Test]
        public void FoglaltElsoParameter0()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(0, 3), "Az els� param�ter nem lehet 0.");
        }

        [Test]
        public void FoglaltElsoParameterNegativ()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(-1, 3), "Az els� param�ter nem lehet negat�v.");
        }

        [Test]
        public void FoglaltElsoParameter1()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(1, 3), "Az els� param�ter 1 lehet.");
        }

        [Test]
        public void FoglaltElsoParameterMax()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(5, 3), "Az els� param�ter a maximum �rt�k lehet.");
        }

        [Test]
        public void FoglaltElsoParameterNagyobbMintMax()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(6, 3), "Az els� param�ter nem lehet nagyobb, mint a maximum �rt�k.");
        }

        [Test]
        public void FoglaltMasodikParameter0()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(3, 0), "A m�sodik param�ter nem lehet 0.");
        }

        [Test]
        public void FoglaltMasodikParameterNegativ()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(3, -1), "A m�sodik param�ter nem lehet negat�v.");
        }

        [Test]
        public void FoglaltMasodikParameterNagyobbMintMax()
        {
            Assert.Throws<ArgumentException>(() => eloadas.Foglalt(3, 11), "A m�sodik param�ter nem lehet nagyobb, mint a maximum �rt�k.");
        }

        [Test]
        public void FoglaltMasodikParameter1()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(3, 1), "A m�sodik param�ter 1 lehet.");
        }

        [Test]
        public void FoglaltMasodikParametermMax()
        {
            Assert.DoesNotThrow(() => eloadas.Foglalt(3, 10), "A m�sodik param�ter a maximum �rt�k lehet.");
        }

        [Test]
        public void TeliEgyHelyFogalalasUtan()
        {
            eloadas.Lefoglal();
            Assert.That(eloadas.Teli, Is.False, "Az el�ad�s nem lehetne teli egy foglal�s ut�n.");
        }

        [Test]
        public void TeliEgyHelySzabad()
        {
            OsszesHelyLefoglalKiveveEgy();
            Assert.That(eloadas.Teli, Is.False, "Az el�ad�s nem lehetne teli egy hely foglal�sa ut�n sem.");
        }

        [Test]
        public void TeliMindenFoglalt()
        {
            MindenHelyLefoglal();
            Assert.That(eloadas.Teli, Is.True, "Az el�ad�s teli, pedig m�g mindig lenne szabad hely.");
        }

        [Test]
        public void FoglaltFoglalasSorfolytonossag()
        {
            eloadas.Lefoglal();
            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(1, 2), Is.True, "Az els� sor foglalts�ga nem megfelel�.");
            Assert.That(eloadas.Foglalt(2, 1), Is.False, "A m�sodik sor foglalts�ga nem megfelel�.");
        }

        [Test]
        public void FoglaltElsoSorUtanMasodikSorFogalodik()
        {
            for (int i = 0; i < 10; i++)
            {
                eloadas.Lefoglal();
            }
            Assert.That(eloadas.Foglalt(1, 10), Is.True, "Az els� sor foglalts�ga nem megfelel�.");
            Assert.That(eloadas.Foglalt(2, 1), Is.False, "A m�sodik sor foglalts�ga nem megfelel�.");

            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(2, 1), Is.True, "A m�sodik sor foglalts�ga nem megfelel�.");
        }

        [Test]
        public void FoglaltUtosoHelyVegenLeszCsakFoglalt()
        {
            OsszesHelyLefoglalKiveveEgy();
            Assert.That(eloadas.Foglalt(5, 10), Is.False, "Az utols� hely v�g�n nem foglalhat�.");
            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(5, 10), Is.True, "Az utols� hely v�g�n foglalhat�, pedig nem lenne szabad.");
        }

        [Test]
        public void FoglaltElsoHelyFoglalhato()
        {
            eloadas.Lefoglal();
            Assert.That(eloadas.Foglalt(1, 1), Is.True, "Az els� hely nem lett foglalva.");
        }

        [Test]
        public void FoglaltElsoHelyNemFoglalt()
        {
            Assert.That(eloadas.Foglalt(1, 1), Is.False, "Az els� hely nem lett volna szabad.");
        }
    }
}
