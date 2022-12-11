using Microsoft.VisualStudio.TestTools.UnitTesting;
using vvs_zad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ExceptionServices;
using CsvHelper;
using System.Globalization;

namespace TestIzboriVVS
{

    [TestClass()]
    public class UnitTestFunkcionalnost3
    {
        private static Program p;

        /// <summary>
        /// Inicijalizacija podataka koja se vrši samo jednom
        /// </summary>
        [ClassInitialize]
        public static void inicijalizacija(TestContext context)
        {
            p = new Program();
            Program.pod();
        }
        /// <summary>
        /// Inicijalizacija podataka koja se vrši prije svakog testa
        /// </summary>
        [TestInitialize]
        public void InicijalizacijaPrijeSvakogTesta()
        {
            p = new Program();
            Program.stranke = new System.Collections.Generic.List<System.Tuple<System.Collections.Generic.List<Kandidat>, string>>();
            Program.glasaci = new System.Collections.Generic.List<Glasac>();
            Program.pod();
        }

        /// <summary>
        /// Test provjere da li je iko glasao
        /// </summary>
        [TestMethod()]
        public void IspisStranakaTest()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Program.ispisStranaka();
            //cita sta se ispisalo u konzoli
            var sb = writer.GetStringBuilder();
            Assert.AreEqual("niko jos nije glasao", sb.ToString().Trim());
        }
        /// <summary>
        /// Test provjerava koliko je ukupno ljudi glasalo
        /// </summary>
        [TestMethod()]
        public void IspisStranakaTest1()
        {
            Program.glasaci[1].setGlasao(true);
            Program.stranke[1].Item1[1].dodaj_glas(Program.glasaci[1]);
            Program.glasaci[2].setGlasao(true);
            Program.stranke[1].Item1[1].dodaj_glas(Program.glasaci[2]);
            Program.glasaci[3].setGlasao(true);
            Program.stranke[1].Item1[1].dodaj_glas(Program.glasaci[3]);
            Program.glasaci[4].setGlasao(true);
            Program.stranke[1].Item1[1].dodaj_glas(Program.glasaci[4]);
            Program.ispisStranaka();
            Assert.AreEqual(4, Program.brojGlasova());
        }
        /// <summary>
        /// Test provjere koliko sda ima glasova
        /// </summary>
        [TestMethod()]
        public void IspisStranakaTest2()
        {
            Program.sdaIs = 0;
            Program.pomakIs = 0;
            Program.glasaci[1].setGlasao(true);
            Program.stranke[0].Item1[1].dodaj_glas(Program.glasaci[1]);
            Program.sdaIs++;
            Program.glasaci[2].setGlasao(true);
            Program.stranke[0].Item1[1].dodaj_glas(Program.glasaci[2]);
            Program.sdaIs++;
            Program.glasaci[3].setGlasao(true);
            Program.stranke[1].Item1[2].dodaj_glas(Program.glasaci[3]);
            Program.pomakIs++;
            Program.ispisStranaka();
            Assert.AreEqual(2, Program.sdaIs);
        }
        /// <summary>
        /// Test provjere koliki je postotak sovojenosti glasova glasaca
        /// </summary>
        [TestMethod()]
        public void IspisStranakaTest3()
        {
            Program.sdaIs = 0;
            Program.pomakIs = 0;
            Program.glasaci[1].setGlasao(true);
            Program.stranke[0].Item1[1].dodaj_glas(Program.glasaci[1]);
            Program.sdaIs++;
            Program.glasaci[2].setGlasao(true);
            Program.stranke[0].Item1[1].dodaj_glas(Program.glasaci[2]);
            Program.sdaIs++;
            Program.glasaci[3].setGlasao(true);
            Program.stranke[1].Item1[2].dodaj_glas(Program.glasaci[3]);
            Program.pomakIs++;
            Program.ispisStranaka();
            var postotak = (Program.stranke[0].Item1[1].getBroj_glasova() * 100) / Program.sdaIs;
            Assert.AreEqual(100, postotak);
        }
        /// <summary>
        /// Test provjere koliko je mandata u stranci
        /// </summary>
        [TestMethod()]
        public void IspisStranakaTest4()
        {
            Program.sdaIs = 0;
            Program.pomakIs = 0;
            Program.glasaci[1].setGlasao(true);
            Program.stranke[0].Item1[1].dodaj_glas(Program.glasaci[1]);
            Program.sdaIs++;
            Program.glasaci[3].setGlasao(true);
            Program.stranke[1].Item1[2].dodaj_glas(Program.glasaci[3]);
            Program.pomakIs++;
            Program.ispisStranaka();
            int mandata1 = 0;
            for (int i = 0; i < Program.stranke.Count; i++)
            {
                for (int j = 0; j < Program.stranke[i].Item1.Count; j++)
                {
                    if (((Program.stranke[i].Item1[j].getBroj_glasova() * 100) / 2) > 20)
                    {
                        mandata1++; ;
                    }
                }
            }
            Assert.AreEqual(2, mandata1);
        }
        public static IEnumerable<object[]> UčitajPodatkeCSV()
        {
            using (var reader = new StreamReader("Stranke.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    var t = elements[0].ToString().Split(" ").ToList().ConvertAll(new Converter<string, int>(toIn1t));
                    var t1 = elements[1].ToString().Split(" ").ToList().ConvertAll(new Converter<string, int>(toIn1t));
                    var t2 = elements[elements.Count - 1].ToString().Split(" ").ToList().ConvertAll(new Converter<string, int>(toIn1t));
                    yield return new object[] { t, t1 , t2 };
                }
            }
        }
        static int toIn1t(string t)
        {
            return Int32.Parse(t);
        }
        static IEnumerable<object[]> StrankeCSV
        {
            get
            {
                return UčitajPodatkeCSV();
            }
        }
        [TestMethod]
        [DynamicData("StrankeCSV")]
        public void IspisStranakaTest2Csv(List<int> stranka, List<int> glasac, List<int> kandidat)
        {
            Program.sdaIs = 0;
            for(int i=0; i<glasac.Count; i++)
            {
                Program.glasaci[i].setGlasao(true);
            }

            for(int i =0; i<stranka.Count; i++)
            {
                if (Program.stranke[stranka[i]].Item2.ToLower() == "sda")
                {
                    Program.sdaIs++;
                }
                for (int j=0; j< kandidat.Count; j++)
                {
                    for(int k=0; k<glasac.Count; k++)
                    {
                        Program.stranke[stranka[i]].Item1[kandidat[j]].dodaj_glas(Program.glasaci[glasac[k]]);
                        
                    }
                }    
            }
            Assert.AreEqual(stranka.FindAll(e => e==0).Count , Program.sdaIs++);
        }


    }
}