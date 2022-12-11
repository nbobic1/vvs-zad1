using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using vvs_zad1;

//Esma Dervisevic, 18923
namespace TestGlasac
{
    [TestClass]
    public class UnitTestFunkcionalnost1
    {
        private Glasac glasac;

        [TestInitialize]
        public void Postavi()
        {
            glasac = new Glasac("Vucko", "Vuckic", "Titova", "21.12.2001.", "444M444", "2112200787878");
        }


        [TestMethod]
        public void TestInLineIDKod()
        {
            var idKod = glasac.getidentifikacijskiKod();
            Assert.IsTrue(idKod.Equals("VuVuTi214421"));
        }


        public static IEnumerable<object[]> UčitajPodatkeCSV()
        {
            using (var reader = new StreamReader("Glasac.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2], elements[3],
                    elements[4], elements[5], elements[6]};
                }
            }
        }

        static IEnumerable<object[]> GlasacCSV
        {
            get
            {
                return UčitajPodatkeCSV();
            }
        }
        [TestMethod]
        [DynamicData("GlasacCSV")]
        public void TestKonstruktoraGlasacaCSV(string ime, string prezime, string adresa, string datumRodjenja, string brojLicneKarte, string maticniBroj, string idKod)
        {
            Glasac g = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
            var identifikacijskiKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.Substring(0, 2) + datumRodjenja.Substring(0, 2) + brojLicneKarte.Substring(0, 2) + maticniBroj.Substring(0, 2);
            Assert.AreEqual(identifikacijskiKod, idKod);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPredugoIme()
        {
            Glasac g = new Glasac("MehoMehoMehoMehoMehoMehoMehoMehoMehoMehoo", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPrekratkoIme()
        {
            Glasac g = new Glasac("M", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPrekratkoPrezime()
        {
            Glasac g = new Glasac("Meho", "Me", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPredugoPrezime()
        {
            Glasac g = new Glasac("Meho", "MehicMehicMehicMehicMehicMehicMehicMehicMehicMehiccc", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestImePrazanString()
        {
            Glasac g = new Glasac("", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPrezimePrazanString()
        {
            Glasac g = new Glasac("Meho", "", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestImeNull()
        {
            Glasac g = new Glasac(null, "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPrezimeNull()
        {
            Glasac g = new Glasac("Meho", null, "Dinina", "01.01.2001", "999J999", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestBrojLicneKarte()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999A999", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestBrojLicneKarte2()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999A99", "0101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestBrojLicneKarte3()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999", "0101200666666", false);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMaticniBroj()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "101200666666", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMaticniBroj2()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "ABCDABCDABCDE", false);
        }



        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMaticniBroj3()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "1414-5", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMaticniBroj4()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "@@@@@@@@@@@@@", false);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestNevalidanDatum()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2007", "999J999", "ABCDABCDABCDE", false);
        }

        [TestMethod]
        public void TestIdentifikacioniKod()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
            var idKod = "MeMeDi019901";
            Assert.IsTrue(idKod.Equals(g.getidentifikacijskiKod()));
        }


        [TestMethod]
        public void TestIdentifikacioniKod2()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
            var idKod = "MeMeDi111111";
            Assert.IsFalse(idKod.Equals(g.getidentifikacijskiKod()));
        }

        [TestMethod]
        public void TestIdentifikacioniKod3()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
            var idKod = "MeMeDi111";
            Assert.IsFalse(idKod.Length == g.getidentifikacijskiKod().Length);
        }


        [TestMethod]
        public void TestPostaviVrijednosti()
        {
            var ime = "Meho";
            var prezime = "Mehic";
            var adresa = "Dinina";
            var datumRodjenja = "01.01.2001";
            var brojLicneKarte = "999J999";
            var maticniBroj = "0101200666666";
            var dijeloviDatuma = datumRodjenja.Substring(0, 2) + datumRodjenja.Substring(3, 2) + datumRodjenja.Substring(6, 3);

            Glasac g = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
            Assert.IsTrue(maticniBroj.Contains(dijeloviDatuma));
        }


        [TestMethod]
        public void TestDaLiJeGlasao()
        {
            var ime = "Meho";
            var prezime = "Mehic";
            var adresa = "Dinina";
            var datumRodjenja = "01.01.2001";
            var brojLicneKarte = "999J999";
            var maticniBroj = "0101200666666";
            var dijeloviDatuma = datumRodjenja.Substring(0, 2) + datumRodjenja.Substring(3, 2) + datumRodjenja.Substring(6, 3);

            Glasac g = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);
            var glasao = g.getGlasao();
            Assert.IsTrue(glasao == false);
        }

        [TestMethod]
        public void TestDaLiJeGlasao2()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
            g.setGlasao(true);
            Assert.IsTrue(g.getGlasao() == true);
        }

        [TestMethod]
        public void TestDuzinaIdentifikacijskogKoda()
        {
            Glasac g = new Glasac("Meho", "Mehic", "Dinina", "01.01.2001", "999J999", "0101200666666", false);
            Assert.IsTrue(g.getidentifikacijskiKod().Length == 12);
        }
    }
}
