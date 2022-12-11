using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

namespace vvs_zad1
{
    public class Program
    {
        public static int sdaIs = 0;
        public static int sdpIs = 0;
        public static int hdzIs = 0;
        static int nezavisniIs = 0;
        public static int asdaIs = 0;
        public static int pomakIs = 0;
        public  static List<Glasac> glasaci = new List<Glasac>();
        static List<Kandidat> pobjedniciK = new List<Kandidat>();
        public static List<Tuple<List<Kandidat>, string>> stranke = new List<Tuple<List<Kandidat>, string>>();
        static List<Tuple<List<Kandidat>, string>> pobjedniciS = new List<Tuple<List<Kandidat>, string>>();
        static List<Kandidat> listaKandidata= new List<Kandidat>();
        static List<Stranka> rukovodstvoStranke= new List<Stranka>();
        public static bool provjeraSifre(String a)
        {
            return (a == "VVS20222023");
        }
        public static void restartGlasanje(Glasac glasac, int hj)
        {
            glasaci[hj].setGlasao(false);
            int per = 0;
            for (int i = 0; i < stranke.Count; i++)
            {
                for (int j = 0; j < stranke[i].Item1.Count; j++)
                {
                    for (int u = 0; u < stranke[i].Item1[j].getGlasaci().Count; u++)
                    {
                        if (stranke[i].Item1[j].getGlasaci()[u].getidentifikacijskiKod() == glasac.getidentifikacijskiKod())
                        {
                            if (per == 0)
                            {
                                if (stranke[i].Item2 == "hdz")
                                    hdzIs--;
                                else if (stranke[i].Item2 == "Sdp")
                                    sdpIs--;
                                else if (stranke[i].Item2 == "sda")
                                    sdaIs--;
                                else if (stranke[i].Item2 == "asda")
                                    asdaIs--;
                                else if (stranke[i].Item2 == "Pomak")
                                    pomakIs--;
                            }
                            per = 1;
                            List<Glasac> pr = stranke[i].Item1[j].getGlasaci();
                            pr.RemoveAt(u);
                            stranke[i].Item1[j].setGlasaci(pr);
                        }
                    }
                }
            }
        }
        public static int brojGlasova()
        {
            return glasaci.FindAll(x => x.getGlasao()).Count;
        }
        public static int brojZaokruzeni()
        {int z = 0;
            for (int i = 0; i < stranke.Count; i++)
            {
                List<Kandidat> t = stranke[i].Item1;
                string s = stranke[i].Item2;
                
                for (int j = 0; j < t.Count; j++)
                {
                    z += t[j].getGlasaci().Count;
                }
            }
            return z;
        }
        public static List<Tuple<String, int>> statistika()
        {
            List<Tuple<String, int>> stat = new List<Tuple<String, int>>();

            int g = glasaci.Count;

            for (int i = 0; i < stranke.Count; i++)
            {
                List<Kandidat> t = stranke[i].Item1;
                string s = stranke[i].Item2;
                int z = 0;
                for (int j = 0; j < t.Count; j++)
                {
                    string ert = s + "-" + t[j].getIme() + " " + t[j].getPrezime();
                    stat.Add(new Tuple<string, int>(ert, (t[j].getBroj_glasova() * 100) / g));
                    z += t[j].getBroj_glasova();
                }
                stat.Add(new Tuple<string, int>(stranke[i].Item2, (z * 100) / g));
            }
            return stat;
        }
        public static void pobjednici()
        {
            int g = brojGlasova();
            for (int i = 0; i < stranke.Count; i++)
            {
                List<Kandidat> t = stranke[i].Item1;
                string s = stranke[i].Item2;
                int z = 0;
                for (int j = 0; j < t.Count; j++)
                    z += t[j].getBroj_glasova();
                for (int j = 0; j < t.Count; j++)
                {
                    string ert = s + "-" + t[j].getIme() + " " + t[j].getPrezime();

                    
                    if (z!=0&&t[j].getBroj_glasova() / z > 0.2)
                        pobjedniciK.Add(t[j]);

                }
                if (z / g > 0.02)
                    pobjedniciS.Add(stranke[i]);
            }
        }
        public static void statistikaIspis()
        {
            if (brojGlasova() == 0)
            {
                Console.WriteLine("niko jos nije glasao");
                return;
            }
            int g = brojGlasova();
            for (int i = 0; i < stranke.Count; i++)
            {
                List<Kandidat> t = stranke[i].Item1;
                string s = stranke[i].Item2;
                int z = 0;
                for (int j = 0; j < t.Count; j++)
                    z += t[j].getBroj_glasova();
                for (int j = 0; j < t.Count; j++)
                {
                    string ert = s + "-" + t[j].getIme() + " " + t[j].getPrezime();
                    
                    if (t[j].getBroj_glasova() / z > 0.2)
                        Console.WriteLine(ert + " " + ((t[j].getBroj_glasova() * 100) / z) + "% -osvaja mandat");
                    else
                        Console.WriteLine(ert + " " + ((t[j].getBroj_glasova() * 100) / z) + "%");

                }
                if (z / g > 0.02)
                    Console.WriteLine(stranke[i].Item2 + " " + ((z * 100) / g) + "% - osvaja mandat");
                else
                    Console.WriteLine(stranke[i].Item2 + " " + ((z * 100) / g) + "%");
            }
            Console.WriteLine("Ukupna izlaznost: " + ((brojGlasova() * 100) / glasaci.Count));

        }
        public static void pod()
        {


            glasaci.Add(new Glasac("Fatih", "Fatic", "Tešanjska 12", "02.01.1998.", "999E999", "0201199666666"));
            glasaci.Add(new Glasac("Mujo", "Mujic", "Zmaja od Bosne 14", "05.01.1995.", "123J123", "0501199666666"));
            glasaci.Add(new Glasac("Huso", "Husic", "Novo Sarajevo", "14.02.1994.", "444K444", "1402199888888"));
            glasaci.Add(new Glasac("Pero", "Peric", "Čengić Vila", "02.04.1998.", "741E147", "0204199555555"));
            glasaci.Add(new Glasac("Hasnija", "Hasnic", "Stup", "02.01.2000.", "151M151", "0201200777777"));
            glasaci.Add(new Glasac("Esmeralda", "Kolasinac", "Fedhima bb", "15.05.1980.", "999J888", "1505198333333"));
            glasaci.Add(new Glasac("Lebron", "James", "Ozimice 2", "14.01.1994.", "515T515", "1401199777777"));
            glasaci.Add(new Glasac("Meho", "Mehic", "Grbavica", "02.01.1998.", "000T000", "0201199888888"));
            glasaci.Add(new Glasac("Benjamin", "Fehic", "Pofalići", "02.01.1998.", "151T151", "0201199444444"));
            glasaci.Add(new Glasac("Vucko", "Vuckic", "Titova", "21.12.2001.", "444M444", "2112200787878"));
            glasaci.Add(new Glasac("Meho", "Puzic", "Odžak", "02.01.1937.", "999T999", "0201193555555"));
            glasaci.Add(new Glasac("Mahir", "Fatic", "Tešanjska 12", "02.06.2001.", "121J121", "0206200444444"));


            List<Kandidat> sda = new List<Kandidat>();
            List<Kandidat> sdp = new List<Kandidat>();
            List<Kandidat> hdz = new List<Kandidat>();
            List<Kandidat> asda = new List<Kandidat>();
            List<Kandidat> pomak = new List<Kandidat>();
            List<Kandidat> nezavisni = new List<Kandidat>();

            Kandidat sda1 = new Kandidat("Hasnija", "Bulić", true);
            sda1.setDodatniOpis("Kandidat je bio član stranke asda od 01.01.2001 do 10.10.2010, član stranke asda od 11.11.2011. do 12.12.2012, član stranke pomak od 15.1.2015 do 17.02.2017");
            sda.Add(sda1);
            Kandidat sda2 = new Kandidat("Edin", "Atić", false);
            sda2.setDodatniOpis("Kandidat je bio član stranke asda od 25.5.2019 do 10.2.2021");
            sda.Add(sda2);
            sda.Add(new Kandidat("Aki", "Akić", false));
            sda.Add(new Kandidat("Musa", "Nurkić", false));
            sda.Add(new Kandidat("Sulejman", "Halilovič", false));

            sdp.Add(new Kandidat("Munja", "Munjić", true));
            sdp.Add(new Kandidat("Amar", "Gegić", false));
            sdp.Add(new Kandidat("Kenan", "Kamenjaš", false));
            sdp.Add(new Kandidat("Edvin", "Kljaljić", false));
            sdp.Add(new Kandidat("Esad", "Plavi", false));

            Kandidat hdz1=new Kandidat("Elon", "Musk", true);
            hdz1.setDodatniOpis("Kandidat je bio član stranke pomak od 03.02.2007 do 09.05.2010");
            hdz.Add(hdz1);
            hdz.Add(new Kandidat("Rakan", "Mukič", false));
            hdz.Add(new Kandidat("Ela", "Makedonac", false));
            hdz.Add(new Kandidat("Ilija", "Nugato", false));
            hdz.Add(new Kandidat("Kakao", "Kamenjaš", false));

            Kandidat asda1 = new Kandidat("Fatka", "Fatkić", true);
            asda1.setDodatniOpis("Kandidat je bio član stranke hdz od 20.3.2005 do 16.2.2008, član stranke sdp od 25.2.2013 do 09.03.2019");
            asda.Add(asda1);
            asda.Add(new Kandidat("Frugić", "Drugar", false));
            asda.Add(new Kandidat("Gospodar", "Fatkić", false));
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

        }

        //funkcionalnost 3 Bbic Muris
        public static void ispisStranaka()
        {
            int brojMandata = 0;
            if (brojGlasova() == 0)
            {
                Console.WriteLine("niko jos nije glasao");
                return;
            }
            int brojUkupnihGlasova = brojGlasova();
            Console.WriteLine("GLasano do ovog trenutka: " + brojUkupnihGlasova + " puta.");
            Console.WriteLine("Statistika stranaka: ");
            Console.WriteLine();
            for (int i = 0; i < stranke.Count; i++)
            {
                brojMandata = 0;
                string imeStranke = stranke[i].Item2;
                int glasoviZaKandidata = 0;
                List<Kandidat> kandidatiStranke = stranke[i].Item1;
                
                for (int j = 0; j < kandidatiStranke.Count; j++)
                {
                    glasoviZaKandidata += kandidatiStranke[j].getBroj_glasova();
                }
                //ispisujem za stranke
                if (imeStranke.ToLower() == "sda")
                {
                    Console.WriteLine(stranke[i].Item2 + " osvojenih glasova: " + sdaIs + " , a to je " + (sdaIs*100)/brojUkupnihGlasova + "%.");
                }
                else if (imeStranke.ToLower() == "sdp")
                {
                    Console.WriteLine(stranke[i].Item2 + " osvojenih glasova: " + sdpIs + " , a to je " + (sdpIs * 100) / brojUkupnihGlasova + "%.");
                }
                else if (imeStranke.ToLower() == "hdz")
                {
                    Console.WriteLine(stranke[i].Item2 + " osvojenih glasova: " + hdzIs + " , a to je " + (hdzIs * 100) / brojUkupnihGlasova + "%.");
                }
                else if (imeStranke.ToLower() == "pomak")
                {
                    Console.WriteLine(stranke[i].Item2 + " osvojenih glasova: " + pomakIs+ " , a to je " + (pomakIs * 100) / brojUkupnihGlasova + "%.");
                }
                else if (imeStranke.ToLower() == "nezavisni")
                {
                    Console.WriteLine(stranke[i].Item2 +": ");
                }
                else if (imeStranke.ToLower() == "asda")
                {
                    Console.WriteLine(stranke[i].Item2 + " osvojenih glasova: " + asdaIs + " , a to je " + (asdaIs * 100) / brojUkupnihGlasova + "%.");
                }
                for (int j = 0; j < kandidatiStranke.Count; j++)
                {
                    string ert = imeStranke + "-" + kandidatiStranke[j].getIme() + " " + kandidatiStranke[j].getPrezime();
                    if (glasoviZaKandidata == 0)
                    {
                        Console.WriteLine(ert + " osvojio je " + kandidatiStranke[j].getBroj_glasova() + " glasova ,a to je: 0%.");
                    } 
                    else if (((kandidatiStranke[j].getBroj_glasova() * 100) / glasoviZaKandidata) > 20)
                    {
                        Console.WriteLine(ert + " osvojio je " + kandidatiStranke[j].getBroj_glasova() + " glasova ,a to je: " + ((kandidatiStranke[j].getBroj_glasova() * 100) / glasoviZaKandidata) + "% -osvaja mandat");
                        brojMandata += 1;

                    }
                    else
                        Console.WriteLine(ert + " osvojio je " + kandidatiStranke[j].getBroj_glasova() + " glasova ,a to je: " + ((kandidatiStranke[j].getBroj_glasova() * 100) / glasoviZaKandidata) + "%");
                }
                Console.WriteLine("Stranka je osvojila: " + brojMandata + " mandata.");
                Console.WriteLine();

            }
        }
        //Funkcionalnost 2 Dina Kurtalić
        public static void ispisiProsleStranke() {
            List<Kandidat> kandidatiSaProslimStrankama = new List<Kandidat>();
            List<Kandidat> sviKandidati = new List<Kandidat>();

            for (int i=0; i<stranke.Count; i++) {
                List<Kandidat> kandidatiStranke= stranke[i].Item1;
                for (int j=0; j<kandidatiStranke.Count;j++) {
                    sviKandidati.Add(kandidatiStranke[j]);
                }
            }

            for (int i=0; i<sviKandidati.Count; i++) {
                if (sviKandidati[i].getDodatniOpis()!=null) {
                    Kandidat k=sviKandidati[i];
                    Console.WriteLine("Kandidat " + k.getIme() + " " + k.getPrezime());
                    String dodatniOpis = sviKandidati[i].getDodatniOpis().ToString();
                    var rijeci = dodatniOpis.Split(" ");
                    string stranka, pocetak, kraj;
                    for (int j=0; j<rijeci.Length; j++) {
                        if (rijeci[j]=="stranke") {
                            stranka = rijeci[j + 1];
                            pocetak= rijeci[j + 3];
                            kraj = rijeci[j + 5];
                            Console.WriteLine("Stranka: " + stranka + " Clanstvo od: " + pocetak + " Clanstvo do: " + kraj);
                        }     
                    }
                    Console.WriteLine("\n");
                }
            }


        }

        //Funkcionalnost 6 Benjamin Ažman
        public static void ispisZaRukovodioca()
        {
            for (int i = 0; i < rukovodstvoStranke.Count; i++)
            {
                int brojGlasova = 0;
                var ispisIme = rukovodstvoStranke[i].getKandidatList();

                for (int j = 0; j < ispisIme.Count; j++)
                {
                    if (ispisIme[j].getRukovodilac() == true)
                    {
                        brojGlasova+= ispisIme[j].getBroj_glasova();
                    }
                }

                Console.WriteLine("Ukupan broj glasova: " + brojGlasova + "; Kandidati: ");
                for (int j=0; j<ispisIme.Count; j++)
                {
                    if (ispisIme[j].getRukovodilac() == true)
                    {
                        if (j == ispisIme.Count - 1)
                        {
                            Console.Write("Identifikacioni broj: " + ispisIme[j].getKod());
                        }
                        else
                        {
                            Console.Write("Identifikacioni broj: " + ispisIme[j].getKod() + ", ");
                        }
                    }

                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            pod();
            while (true)
            {
                Console.WriteLine("Ako želite glasati unesite 1");
                Console.WriteLine("Ako želite vidjeti statistiku unesite 2");
                Console.WriteLine("Ako želite izaci iz app unesite 3");
                Console.WriteLine("Ako želite restartovati glasanje za glasaca unesite 4");
                Console.WriteLine("Ako želite vidjeti trenutno stanje glasnja za stranke unesite 5 ");
                Console.WriteLine("Ako želite vidjeti rukovodstvo stranaka unesite 6 ");
                Console.WriteLine("Ako želite vidjeti kandidate koji su bili članovi drugih stranaka u prošlosti unesite 7 ");
                int k = Convert.ToInt32(Console.ReadLine());
                if (k == 1)
                {
                    Console.WriteLine("Unesite Vaš jedinstveni identifikacioni kod: ");
                    string s = Console.ReadLine();
                    int t = glasaci.FindIndex(gl => gl.getidentifikacijskiKod() == s);
                    if (t == -1)
                    {
                        Console.WriteLine("Niste registrirani u ovom biračkom mjestu");
                        continue;
                    }
                    else
                    {
                        if (!glasaci[t].getGlasao())
                        {
                            Console.WriteLine("Unesite broj pored stranke ili nezavisnog kandidata za kojeg zelite glasati");
                            for (int i = 0; i < stranke.Count; i++)
                            {
                                if (stranke[i].Item2.Equals("nezavisni"))
                                {

                                    Console.WriteLine("Nezavisni kadnidati:");
                                    for (int t3 = i; t3 < stranke[i].Item1.Count + i; t3 += 1)
                                    {
                                        Console.WriteLine(t3 + " " + stranke[i].Item1[t3 - i].getIme() + " " + stranke[i].Item1[t3 - i].getPrezime());
                                    }
                                }
                                else
                                    Console.WriteLine(i + " " + stranke[i].Item2);
                            }
                            int zu = -1;
                            while (true)
                            {
                                zu = Convert.ToInt32(Console.ReadLine());
                                if (zu < 0 || zu > stranke.Count - 1 + stranke[stranke.Count - 1].Item1.Count)
                                {
                                    Console.WriteLine("Neispravan broj, unesite ponovo");
                                }
                                else
                                {
                                    if(zu >= stranke.Count)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        string imeStranke = stranke[zu].Item2;
                                        if (imeStranke.ToLower() == "sda")
                                        {
                                            sdaIs++;
                                        }
                                        else if (imeStranke.ToLower() == "sdp")
                                        {
                                            sdpIs++;
                                        }
                                        else if (imeStranke.ToLower() == "hdz")
                                        {
                                            hdzIs++;
                                        }
                                        else if (imeStranke.ToLower() == "pomak")
                                        {
                                            pomakIs++;
                                        }
                                        else if (imeStranke.ToLower() == "asda")
                                        {
                                            asdaIs++;
                                        }
                                    }
                                    
                                    break;
                                }
                            }
                            if (zu >= stranke.Count - 1)
                            {
                                stranke[stranke.Count - 1].Item1[zu - stranke.Count + 1].dodaj_glas(glasaci[t]);
                                glasaci[t].setGlasao(true);
                                Console.WriteLine("Uspjesno ste glasali!");
                                if (glasaci.Count == brojGlasova())
                                {
                                    pobjednici();
                                }
                                continue;
                            }
                            else
                            {
                                //ispis kandidata stranke
                                Console.WriteLine("Unesite broj pored kandidata kako bi glasali za istog, a -1 za izlaz");
                                for (int w = 0; w < stranke[zu].Item1.Count; w++)
                                {
                                    Console.WriteLine(w + " " + stranke[zu].Item1[w].getIme() + " " + stranke[zu].Item1[w].getPrezime());
                                }
                                //glasanje za iste
                                int zr = -2;
                                while (true)
                                {
                                    zr = Convert.ToInt32(Console.ReadLine());
                                    if (zr == -1)
                                        break;
                                    else if (zr < -1 || zr > stranke[zu].Item1.Count - 1)
                                    {
                                        Console.WriteLine("Neispravan unos, unesite ponovo");
                                        continue;
                                    }
                                    else
                                    {
                                        stranke[zu].Item1[zr].dodaj_glas(glasaci[t]);
                                    }
                                    Console.WriteLine("Unesite broj pored kandidata kako bi glasali za istog, a -1 za izlaz");
                                }
                                glasaci[t].setGlasao(true);
                                pobjednici();
                                Console.WriteLine("Uspjesno ste galsali za kandidate stranke: " + stranke[zu].Item2);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Već ste glasali!");
                            continue;
                        }
                    }
                }
                else if (k == 2)
                {
                    statistikaIspis();
                }
                //Uradio Nail Bobić 18854
                else if (k == 4)
                {
                    Console.WriteLine("Unesite jedinstveni identifikacioni kod glasaca za kojeg zelite restartovati glasanje: ");
                    string s = Console.ReadLine();
                    int t = glasaci.FindIndex(gl => gl.getidentifikacijskiKod() == s);
                    if (t == -1)
                    {
                        Console.WriteLine("Niste registrirani u ovom biračkom mjestu");
                    }
                    else if (glasaci[t].getGlasao() == false)
                    {
                        Console.WriteLine("Glasac nije glasao");
                    }
                    else
                    {
                        for (int zc = 0; zc < 3; zc++)
                        {

                            Console.WriteLine("Unesite sifru za restart:");
                            if ( provjeraSifre(Console.ReadLine()))
                            {
                                restartGlasanje(glasaci[t],t);
                                break;
                            }
                            else
                                Console.WriteLine("Neispravna sifra");
                            if (zc == 2)
                            {
                                Console.WriteLine("Tri puta unesena pogresna sifra, GRESKA!!");
                                return;
                            }
                        }
                    }
                }

                else if (k == 5)
                {
                    //uradio Muris Bobić
                    ispisStranaka();
                }

                else if (k == 6)
                {
                    //uradio Benjamin Ažman
                    ispisZaRukovodioca();
                }
                else if (k==7) {
                    //uradila Dina Kurtalić
                    ispisiProsleStranke();
                }

                else if (k == 3)
                    break;
                else
                    continue;
            }
        }

       
    }
}