using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vvs_zad1;

namespace TestIzboriVVS
{
    [TestClass]
    public class UnitTestDrugi
    {
        static Glasac glasac;
        static StubSigurnosnaProvjeraFalse stubf;
        static StubSigurnosnaProvjeraTrue stubt;

        [ClassInitialize]
        public static void inicijalizacija(TestContext context)
        {
           stubf=new StubSigurnosnaProvjeraFalse();
            stubt=new StubSigurnosnaProvjeraTrue();
        }
        [TestInitialize]
        public void InicijalizacijaPrijeSvakogTesta()
        {
            glasac = new Glasac("Neko", "Nekic", "ulica", "02.01.1998.", "999E999", "0201199666666");
        }
        #region inline testovi
        [TestMethod]
        public void VjerodostojnostGlasacaTest()
        {
            Assert.IsTrue(glasac.VjerodostojnostGlasaca(stubf));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ProvjeraIspravneSifreTest()
        {
            try
            {
                glasac.VjerodostojnostGlasaca(stubt);
            }
            catch (Exception e) { 
            Assert.AreEqual("Glasač je već izvršio glasanje!", e.Message);
                throw;
            }
        }
        #endregion
    }
}
