using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using vvs_zad1;

namespace TestIzboriVVS
{
    [TestClass]
    public class UnitTestFunkcionalnost6
    {
        [TestMethod]
        public void TestDaLiSeGlasaloZaKandidata()
        {
            Kandidat k = new Kandidat("Meho", "Mehic", true);
            Glasac g = new Glasac("Meho", "Mehic", "Dinina 12", "01.01.2001", "999J999", "0101200666666", false);

            k.dodaj_glas(g);

            Assert.AreEqual(k.getBroj_glasova(), 1);
        }

        [TestMethod]
        public void TestStrankaKonstruktor()
        {
            var kandidat1 = new Kandidat("Meho", "Mehic", true);
            var kandidat2 = new Kandidat("Ivo", "Ivic", false);
            List<Kandidat> listaKandidata = new List<Kandidat>();
            listaKandidata.Add(kandidat1);
            listaKandidata.Add(kandidat2);

            var stranka = new Stranka(listaKandidata);

            Assert.AreEqual(kandidat1.getIme(), "Meho");
            Assert.AreEqual(kandidat1.getPrezime(), "Mehic");
        }

        [TestMethod]
        public void TestStrankaGeteri()
        {
            var kandidat1 = new Kandidat("Meho", "Mehic", true);
            var kandidat2 = new Kandidat("Ivo", "Ivic", false);
            List<Kandidat> listaKandidata = new List<Kandidat>();
            listaKandidata.Add(kandidat1);
            listaKandidata.Add(kandidat2);

            var stranka = new Stranka(listaKandidata);

            Assert.AreEqual(kandidat1.getIme(), "Meho");
            Assert.AreEqual(kandidat1.getPrezime(), "Mehic");

            stranka.setNaziv("Nova stranka");
            Assert.AreEqual(stranka.getNaziv(), "Nova stranka");

            var kandidati = stranka.getKandidatList();
            Assert.AreEqual(stranka.getKandidatList().Count, 2);
        }

        [TestMethod]
        public void TestStrankaSeteri()
        {
            var kandidat1 = new Kandidat("Meho", "Mehic", true);
            var kandidat2 = new Kandidat("Ivo", "Ivic", false);
            List<Kandidat> listaKandidata = new List<Kandidat>();
            listaKandidata.Add(kandidat1);
            listaKandidata.Add(kandidat2);

            var stranka = new Stranka(listaKandidata);

            Assert.AreEqual(kandidat1.getIme(), "Meho");
            Assert.AreEqual(kandidat1.getPrezime(), "Mehic");

            stranka.setNaziv("Nova stranka");
            Assert.AreEqual(stranka.getNaziv(), "Nova stranka");

            var kandidati = stranka.getKandidatList();
            Assert.AreEqual(stranka.getKandidatList().Count, 2);

            var kandidat3 = new Kandidat("Dino", "Dinanovic", false);
            List<Kandidat> NovaListaKandidata = new List<Kandidat>();
            NovaListaKandidata.Add(kandidat3);
            NovaListaKandidata.Add(kandidat2);
            NovaListaKandidata.Add(kandidat1);

            stranka.setKandidatList(NovaListaKandidata);
            Assert.AreEqual(stranka.getKandidatList().Count, 3);
        }

        [TestMethod]
        public void TestFunkcionalnost6()
        {
            List<Glasac> glasaci = new List<Glasac>();
            List<Stranka> rukovodstvoStranke = new List<Stranka>();
            List<Tuple<List<Kandidat>, string>> stranke = new List<Tuple<List<Kandidat>, string>>();

            glasaci.Add(new Glasac("Fatih", "Fatic", "Tešanjska 12", "02.01.1998.", "999E999", "0201199666666"));
            glasaci.Add(new Glasac("Mujo", "Mujic", "Zmaja od Bosne 14", "05.01.1995.", "123J123", "0501199666666"));
            glasaci.Add(new Glasac("Huso", "Husic", "Novo Sarajevo", "14.02.1994.", "444K444", "1402199888888"));
            glasaci.Add(new Glasac("Pero", "Peric", "?engi? Vila", "02.04.1998.", "741E147", "0204199555555"));
            glasaci.Add(new Glasac("Hasnija", "Hasnic", "Stup", "02.01.2000.", "151M151", "0201200777777"));
            glasaci.Add(new Glasac("Esmeralda", "Kolasinac", "Fedhima bb", "15.05.1980.", "999J888", "1505198333333"));
            glasaci.Add(new Glasac("Lebron", "James", "Ozimice 2", "14.01.1994.", "515T515", "1401199777777"));
            glasaci.Add(new Glasac("Meho", "Mehic", "Grbavica", "02.01.1998.", "000T000", "0201199888888"));
            glasaci.Add(new Glasac("Benjamin", "Fehic", "Pofali?i", "02.01.1998.", "151T151", "0201199444444"));
            glasaci.Add(new Glasac("Vucko", "Vuckic", "Titova", "21.12.2001.", "444M444", "2112200787878"));
            glasaci.Add(new Glasac("Meho", "Puzic", "Odžak", "02.01.1937.", "999T999", "0201193555555"));
            glasaci.Add(new Glasac("Mahir", "Fatic", "Tešanjska 12", "02.06.2001.", "121J121", "0206200444444"));


            List<Kandidat> sda = new List<Kandidat>();
            List<Kandidat> sdp = new List<Kandidat>();
            List<Kandidat> hdz = new List<Kandidat>();
            List<Kandidat> asda = new List<Kandidat>();
            List<Kandidat> pomak = new List<Kandidat>();
            List<Kandidat> nezavisni = new List<Kandidat>();

            Kandidat sda1 = new Kandidat("Hasnija", "Buli?", true);
            sda1.setDodatniOpis("Kandidat je bio ?lan stranke asda od 01.01.2001 do 10.10.2010, ?lan stranke asda od 11.11.2011. do 12.12.2012, ?lan stranke pomak od 15.1.2015 do 17.02.2017");
            sda.Add(sda1);
            Kandidat sda2 = new Kandidat("Edin", "Ati?", false);
            sda2.setDodatniOpis("Kandidat je bio ?lan stranke asda od 25.5.2019 do 10.2.2021");
            sda.Add(sda2);
            sda.Add(new Kandidat("Aki", "Aki?", false));
            sda.Add(new Kandidat("Musa", "Nurki?", false));
            sda.Add(new Kandidat("Sulejman", "Halilovi?", false));

            sdp.Add(new Kandidat("Munja", "Munji?", true));
            sdp.Add(new Kandidat("Amar", "Gegi?", false));
            sdp.Add(new Kandidat("Kenan", "Kamenjaš", false));
            sdp.Add(new Kandidat("Edvin", "Kljalji?", false));
            sdp.Add(new Kandidat("Esad", "Plavi", false));

            Kandidat hdz1 = new Kandidat("Elon", "Musk", true);
            hdz1.setDodatniOpis("Kandidat je bio ?lan stranke pomak od 03.02.2007 do 09.05.2010");
            hdz.Add(hdz1);
            hdz.Add(new Kandidat("Rakan", "Muki?", false));
            hdz.Add(new Kandidat("Ela", "Makedonac", false));
            hdz.Add(new Kandidat("Ilija", "Nugato", false));
            hdz.Add(new Kandidat("Kakao", "Kamenjaš", false));

            Kandidat asda1 = new Kandidat("Fatka", "Fatki?", true);
            asda1.setDodatniOpis("Kandidat je bio ?lan stranke hdz od 20.3.2005 do 16.2.2008, ?lan stranke sdp od 25.2.2013 do 09.03.2019");
            asda.Add(asda1);
            asda.Add(new Kandidat("Frugi?", "Drugar", false));
            asda.Add(new Kandidat("Gospodar", "Fatki?", false));
            asda.Add(new Kandidat("Bilbo", "Bagins", false));
            asda.Add(new Kandidat("Edin", "Džeko", false));

            pomak.Add(new Kandidat("Romeo", "Lukaku", true));
            pomak.Add(new Kandidat("Cristiano", "Ronaldo", false));
            pomak.Add(new Kandidat("Tejt", "MegregoAr", false));
            pomak.Add(new Kandidat("Kanie", "West", false));
            pomak.Add(new Kandidat("Messi", "Ronaldo", false));

            nezavisni.Add(new Kandidat("Justin", "So", true));
            nezavisni.Add(new Kandidat("Angelina", "Boli", false));
            nezavisni.Add(new Kandidat("Marija", "Ana", false));
            nezavisni.Add(new Kandidat("Bull", "Pit", false));
            nezavisni.Add(new Kandidat("Vojage", "Breskvica", false));
            stranke.Add(new Tuple<List<Kandidat>, string>(sda, "sda"));
            stranke.Add(new Tuple<List<Kandidat>, string>(pomak, "Pomak"));
            stranke.Add(new Tuple<List<Kandidat>, string>(sdp, "Sdp"));
            stranke.Add(new Tuple<List<Kandidat>, string>(asda, "asda"));
            stranke.Add(new Tuple<List<Kandidat>, string>(hdz, "hdz"));
            stranke.Add(new Tuple<List<Kandidat>, string>(nezavisni, "nezavisni"));

            rukovodstvoStranke.Add(new Stranka(sdp, "sdp"));
            rukovodstvoStranke.Add(new Stranka(sda, "sda"));
            rukovodstvoStranke.Add(new Stranka(hdz, "hdz"));
            rukovodstvoStranke.Add(new Stranka(asda, "asda"));
            rukovodstvoStranke.Add(new Stranka(pomak, "pomak"));
            rukovodstvoStranke.Add(new Stranka(nezavisni, "nezavisni"));

            Program.ispisZaRukovodioca();

            Assert.AreEqual(nezavisni.Count, pomak.Count);
            Assert.AreEqual(glasaci.Count, 12);
            Assert.AreEqual(stranke.Count, 6);
            Assert.AreEqual(rukovodstvoStranke.Count, 6);
        }
    }
}
