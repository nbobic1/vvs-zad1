using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using vvs_zad1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int c = 0;
            for(int i = 0; i < 30002500; i++)
            Glasac.validirajPodatke("Meho", "Mahic", "Dinina", "01.01.2001", "999J999", "101200666666");
              int u = 0;
        
        }
    }
}
