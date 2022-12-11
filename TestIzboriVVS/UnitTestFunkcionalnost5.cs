using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvs_zad1;

namespace TestIzboriVVS
{
    [TestClass]
    public class UnitTestFunkcionalnost5
    {
        private static Program p;

        [ClassInitialize]
        public static void inicijalizacija(TestContext context)
        {
            p = new Program();
            Program.pod();
        }
        [TestInitialize]
        public void InicijalizacijaPrijeSvakogTesta()
        {
            p = new Program();
        }
        [TestMethod]
        public void ProvjeraPogresneSifreTest()
        {
            Assert.IsFalse(Program.provjeraSifre("bezveze"));
        }

        [TestMethod]
        public void ProvjeraIspravneSifreTest()
        {
            Assert.IsTrue(Program.provjeraSifre("VVS20222023"));
        }
        [TestMethod]
        public void RestartGlasanjaTest()
        {
            Program.glasaci[1].setGlasao(true);
            Program.stranke[1].Item1[1].dodaj_glas(Program.glasaci[1]);
            Program.pomakIs++;
            Assert.AreEqual("Pomak", Program.stranke[1].Item2);
        }
    }    
}
