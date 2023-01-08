using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvs_zad1;

namespace WhiteBox
{
    [TestClass]
    public class UnitTest1
    {
        //Nail Bobić 18854
        [TestMethod]
        public void TestPut1()
        {
            Assert.IsFalse(Glasac.validirajPodatke("1","","","","",""));
        }
        //Nail Bobić 18854
        [TestMethod]
        public void TestPut2()
        {

            Assert.IsFalse(Glasac.validirajPodatke("Nail", "1", "", "", "", ""));
        }

        //Dina Kurtalić 18917
        [TestMethod]
        public void TestPut3()
        {
            Assert.IsFalse(Glasac.validirajPodatke("a", "Kurtalic", "", "", "", ""));
        }

        //Dina Kurtalić 18917
        [TestMethod]
        public void TestPut4()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Dina", "Ku", "", "", "", ""));
        }
        //Bobic Muris18769
        [TestMethod]
        public void TestPut5()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Muris", "Bo", "SA12", "", "", ""));
        }
        //Muris Bobic 18769
        [TestMethod]
        public void TestPut6()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Muri", "Bobi", "Asw", "12.12.2000", "", ""));
        }
    }
}
