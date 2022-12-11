using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvs_zad1;

namespace TestnaKlasa
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDaLiSeGlasaloZaKandidata()
        {
            Kandidat k = new Kandidat("Meho", "Mehic", true);
            Glasac g = new Glasac("Meho", "Mehic", "Dinina 12", "1.1.2001", false);

            k.dodaj_glas(g);

            Assert.AreEqual(k.getBroj_glasova(), 1);
        }
    }
}
