using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvs_zad1;

namespace WhiteBox
{
    [TestClass]
    public class WhiteBoxTestovi
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
        //Benjamin Azman 18789
        [TestMethod]
        public void TestPut6()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Muri", "Bobi", "Asw", "12.12.2000", "", ""));
        }
        [TestMethod]
        public void TestPut7()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Benjamin", "Azman", "ES11", "24.12.1999", "", ""));
        }
        //Benjamin Azman 18789
        [TestMethod]
        public void TestPut8()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Benjo", "Azma", "Ferhadija 11", "24.12.1999", "", ""));
        }

        //Dervišević Esma, 18923
        [TestMethod]
        public void TestPut9()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Esma", "Dervisevic", "Visoko bb", "28.11.2000", "999T999", "28112005"));
        }

        //Dervišević Esma, 18923
        [TestMethod]
        public void TestPut10()
        {
            Assert.IsFalse(Glasac.validirajPodatke("Esma", "Dervisevic", "Visoko bb", "28.11.2000", "999A999", "1234567891111"));
        }
    }
}
