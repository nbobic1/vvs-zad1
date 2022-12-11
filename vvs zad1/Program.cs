using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

namespace vvs_zad1
{
    internal class Program
    {
        static int sdaIs = 0;
        static int sdpIs = 0;
        static int hdzIs = 0;
        static int nezavisniIs = 0;
        static int asdaIs = 0;
        static int pomakIs = 0;
        static List<Glasac> glasaci = new List<Glasac>();
        static List<Kandidat> pobjedniciK = new List<Kandidat>();
        static List<Tuple<List<Kandidat>, string>> stranke = new List<Tuple<List<Kandidat>, string>>();
        static List<Tuple<List<Kandidat>, string>> pobjedniciS = new List<Tuple<List<Kandidat>, string>>();
        static List<Kandidat> listaKandidata= new List<Kandidat>();
        static List<Stranka> rukovodstvoStranke= new List<Stranka>();
        public static bool provjeraSifre(String a)
        {
            return (a == "");
        }
        public static int brojGlasova()
        {
            return glasaci.FindAll(x => x.getGlasao()).Count;
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


            glasaci.Add(new Glasac("Fatih", "Fatić", "Tešanjska 12", "02.01.1998."));
            glasaci.Add(new Glasac("Mujo", "Mujić", "Zmaja od Bosne 14", "05.01.1995."));
            glasaci.Add(new Glasac("Huso", "Husić", "Novo Sarajevo", "14.02.1994."));
            glasaci.Add(new Glasac("Pero", "Perić", "Čengić Vila", "02.04.1998."));
            glasaci.Add(new Glasac("Hasnija", "Hasnić", "Stup", "02.01.2000."));
            glasaci.Add(new Glasac("Esmeralda", "Kolašinac", "Fedhima bb", "15.05.1980."));
            glasaci.Add(new Glasac("Lebron", "James", "Ozimice 2", "14.01.1994."));
            glasaci.Add(new Glasac("Meho", "Mehić", "Grbavica", "02.01.1998."));
            glasaci.Add(new Glasac("Benjamin", "Fehić", "Pofalići", "02.01.1998."));
            glasaci.Add(new Glasac("Vučko", "Vučkić", "Titova", "21.12.2001."));
            glasaci.Add(new Glasac("Meho", "Puzić", "Odžak", "02.01.1937."));
            glasaci.Add(new Glasac("Mahir", "Fatić", "Tešanjska 12", "02.06.2001."));


            List<Kandidat> sda = new List<Kandidat>();
            List<Kandidat> sdp = new List<Kandidat>();
            List<Kandidat> hdz = new List<Kandidat>();
            List<Kandidat> asda = new List<Kandidat>();
            List<Kandidat> pomak = new List<Kandidat>();
            List<Kandidat> nezavisni = new List<Kandidat>();

            sda.Add(new Kandidat("Hasnija", "Bulić", true));
            sda.Add(new Kandidat("Aki", "Akić", false));
            sda.Add(new Kandidat("Musa", "Nurkić", false));
            sda.Add(new Kandidat("Edin", "Atić", false));
            sda.Add(new Kandidat("Sulejman", "Halilovič", false));

            sdp.Add(new Kandidat("Munja", "Munjić", true));
            sdp.Add(new Kandidat("Amar", "Gegić", false));
            sdp.Add(new Kandidat("Kenan", "Kamenjaš", false));
            sdp.Add(new Kandidat("Edvin", "Kljaljić", false));
            sdp.Add(new Kandidat("Esad", "Plavi", false));

            hdz.Add(new Kandidat("Elon", "Musk", true));
            hdz.Add(new Kandidat("Rakan", "Mukič", false));
            hdz.Add(new Kandidat("Ela", "Makedonac", false));
            hdz.Add(new Kandidat("Ilija", "Nugato", false));
            hdz.Add(new Kandidat("Kakao", "Kamenjaš", false));

            asda.Add(new Kandidat("Fatka", "Fatkić", true));
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

        public static void IspisStranaka()
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
                    IspisStranaka();
                }

                else if (k == 6)
                {
                    //uradio Benjamin Ažman
                    ispisZaRukovodioca();
                }

                else if (k == 3)
                    break;
                else
                    continue;
            }
        }

        private static void restartGlasanje(Glasac glasac,int hj)
        {
            glasaci[hj].setGlasao(false);
            for (int i = 0; i < stranke.Count; i++)
            {
                  for(int j = 0; j < stranke[i].Item1.Count;j++)
                {
                    for(int u = 0; u < stranke[i].Item1[j].getGlasaci().Count;u++)
                    {
                        if (stranke[i].Item1[j].getGlasaci()[u].getidentifikacijskiKod()==glasac.getidentifikacijskiKod())
                        {
                            List<Glasac> pr = stranke[i].Item1[j].getGlasaci();
                            pr.RemoveAt(u);
                            stranke[i].Item1[j].setGlasaci(pr);
                        }
                    }
                }
            }
        }
    }
}