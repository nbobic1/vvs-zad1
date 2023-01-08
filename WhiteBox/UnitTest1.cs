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
    }
}
