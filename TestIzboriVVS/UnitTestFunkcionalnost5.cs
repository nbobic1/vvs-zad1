using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvs_zad1;
//Nail Bobić 18854
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
            Program.stranke = new System.Collections.Generic.List<System.Tuple<System.Collections.Generic.List<Kandidat>, string>>();
            Program.glasaci = new System.Collections.Generic.List<Glasac>();
            Program.pod();
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
            Program.restartGlasanje(Program.glasaci[1], 1);
            Assert.AreEqual(0, Program.brojGlasova());
        }
        [TestMethod]
        public void RestartGlasanja2Test()
        {
            Program.glasaci[1].setGlasao(true);
            Program.stranke[1].Item1[1].dodaj_glas(Program.glasaci[1]);
            Program.pomakIs++;
            Program.glasaci[2].setGlasao(true);
            Program.stranke[1].Item1[1].dodaj_glas(Program.glasaci[2]);
            Program.pomakIs++;
            Program.restartGlasanje(Program.glasaci[1], 1);
            Assert.AreEqual(1, Program.brojGlasova());
        }
    }    
}
