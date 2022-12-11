using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System;
using vvs_zad1;
using CsvHelper;
using System.Linq;
using System.Collections;
using System.Runtime.InteropServices;
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
        #region inline testovi
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
        #endregion
        #region csv testovi
        [TestMethod]
        [DynamicData("SifreCSV")]
        public void TestProvjeraNeispravneSifreCSV(string sifra)
        {
            Assert.IsFalse(Program.provjeraSifre(sifra));
        }

        [TestMethod]
        [DynamicData("GlasoviCSV")]
        public void TestRestartovanjGlasaCSV(int glas, int starn, List<int> glasi)
        {
            Program.glasaci[glas].setGlasao(true);
            for (int i = 0; i < glasi.Count; i++)
            {
                Program.stranke[starn].Item1[glasi[i]].dodaj_glas(Program.glasaci[glas]);
            }
            int z = Program.brojZaokruzeni();
            Program.restartGlasanje(Program.glasaci[glas], glas);
            Assert.AreEqual(z-glasi.Count,Program.brojZaokruzeni());
           
        }
        #endregion
        public static IEnumerable<object[]> UčitajPodatkeCSV(string k)
        {
            using (var reader = new StreamReader(k))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0] };
                }
            }
        }
        public static IEnumerable<object[]> UčitajGlasoveCSV(string k)
        {
            using (var reader = new StreamReader(k))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                   var t = elements[elements.Count - 1].ToString().Split(" ").ToList().ConvertAll(new Converter<string, int>(toIn1t));
                   int t1 = toIn1t(elements[0]);
                    int t2= toIn1t(elements[1]);
                    yield return new object[] { t1, t2,t };
                }
            }
        }
        static int toIn1t(string t)
        {
            return Int32.Parse(t);
        }
        static IEnumerable<object[]> SifreCSV
        {
            get
            {
                return UčitajPodatkeCSV("Sifre.csv");
            }
        }
        static IEnumerable<object[]> GlasoviCSV
        {
            get
            {
                return UčitajGlasoveCSV("Glasovi.csv");
            }
        }
    }
}
