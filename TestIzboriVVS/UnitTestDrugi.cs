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
        static SpySigurnosnaProvjera spy;

        [ClassInitialize]
        public static void inicijalizacija(TestContext context)
        {
       
            spy = new SpySigurnosnaProvjera();
           
        }
        [TestInitialize]
        public void InicijalizacijaPrijeSvakogTesta()
        {     int c = 0;
            glasac = new Glasac("Neko", "Nekic", "ulica", "02.01.1998.", "999E999", "0201199666666");
        int k = 0; }
        #region inline testovi
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestZamjenskiObjekat()
        {
            spy.Opcija = 1;
            Assert.IsTrue(glasac.VjerodostojnostGlasaca(spy));
            try
            {
                spy.Opcija = 0;
                glasac.VjerodostojnostGlasaca(spy);
            }
            catch (Exception e) { 
            Assert.AreEqual("Glasač je već izvršio glasanje!", e.Message);
                throw;
            }
        }
        #endregion
    }
}
