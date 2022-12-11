using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using vvs_zad1;

namespace TestIzboriVVS
{
    [TestClass]
    public class UnitTestFunkcionalnost2
    {
       
        private static Program p;

        [ClassInitialize]
        public static void inicijalizacija(TestContext context)
        {
            p = new Program();
            Program.pod();
        }
       

        [TestInitialize]
        public void Postavi()
        {
            p = new Program();
            Program.pod();
          
        }


        [TestMethod]
        public void pocetniTest()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Program.ispisiProsleStranke();
            var sb = writer.GetStringBuilder();
            Assert.AreEqual("Nijedan kandidat nije u prošlosti bio član drugih stranaka", sb.ToString().Trim());

        }
        [TestMethod]
        public void dodajStrankuKandidatu()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
           
            Program.listaKandidata[1].setDodatniOpis("Kandidat je bio član stranke asda od 25.5.2019 do 10.2.2021");
            Program.ispisiProsleStranke();
            var sb = writer.GetStringBuilder();
            Assert.AreEqual("Kandidat Edin Atić\r\nStranka: asda Clanstvo od: 25.5.2019 Clanstvo do: 10.2.2021", sb.ToString().Trim());
            Program.listaKandidata[1].setDodatniOpis(null);
        }
        [TestMethod]
        public void dodajViseStranakaKandidatu()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Program.listaKandidata[0].setDodatniOpis("Kandidat je bio član stranke asda od 01.01.2001 do 10.10.2010, član stranke asda od 11.11.2011. do 12.12.2012, član stranke pomak od 15.1.2015 do 17.02.2017");
            Program.ispisiProsleStranke();   
            var sb = writer.GetStringBuilder();
            Assert.AreEqual("Kandidat Hasnija Bulić\r\nStranka: asda Clanstvo od: 01.01.2001 Clanstvo do: 10.10.2010,\r\nStranka: asda Clanstvo od: 11.11.2011. Clanstvo do: 12.12.2012,\r\nStranka: pomak Clanstvo od: 15.1.2015 Clanstvo do: 17.02.2017", sb.ToString().Trim());
            Program.listaKandidata[0].setDodatniOpis(null);
        }


        public static IEnumerable<object[]> UčitajPodatkeCSV()
        {
            using (var reader = new StreamReader("Kandidat.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { Int32.Parse(elements[0]), elements[1] };
                }
            }
        }

        static IEnumerable<object[]> KandidatCSV
        {
            get
            {
                return UčitajPodatkeCSV();
            }
        }
        [TestMethod]
        [DynamicData("KandidatCSV")]
        public void TestKandidatCSV(int k,string dodatniOpis )
        {
          /*  var writer = new StringWriter();
            Console.SetOut(writer);
        
            Program.listaKandidata[k].setDodatniOpis(dodatniOpis);
            Program.ispisiProsleStranke();
            var sb = writer.GetStringBuilder();
            
            Assert.AreEqual("Kandidat" + Program.listaKandidata[k].getIme()+" "+ Program.listaKandidata[k].getPrezime() + "\r\nStranka: "+ Program.nadjiStranku(Program.listaKandidata[k]) , sb.ToString().Trim());
            Program.listaKandidata[k].setDodatniOpis(null);

            */
        }

    }
}
