using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

namespace vvs_zad1
{
    internal class Program
    {
        static List<Glasac> glasaci = new List<Glasac>();
        static List<Kandidat> pobjedniciK = new List<Kandidat>();
        static List<Kandidat> sda = new List<Kandidat>();
        static List<Kandidat> sdp = new List<Kandidat>();
        static List<Kandidat> hdz = new List<Kandidat>();
        static List<Kandidat> asda = new List<Kandidat>();
        static List<Kandidat> pomak = new List<Kandidat>();
        static List<Kandidat> nezavisni = new List<Kandidat>();
        static List<Tuple<List<Kandidat>, string>> stranke = new List<Tuple<List<Kandidat>, string>>();
        static List<Tuple<List<Kandidat>, string>> pobjedniciS = new List<Tuple<List<Kandidat>, string>>();
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
                    stat.Add(new Tuple<string, int>(ert, (t[j].brojG() * 100) / g));
                    z += t[j].brojG();
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
                    z += t[j].brojG();
                for (int j = 0; j < t.Count; j++)
                {
                    string ert = s + "-" + t[j].getIme() + " " + t[j].getPrezime();


                    if (t[j].brojG() / z > 0.2)
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
                    z += t[j].brojG();
                for (int j = 0; j < t.Count; j++)
                {
                    string ert = s + "-" + t[j].getIme() + " " + t[j].getPrezime();
                    if (t[j].brojG() / z > 0.2)
                        Console.WriteLine(ert + " " + ((t[j].brojG() * 100) / z) + "% -osvaja mandat");
                    else
                        Console.WriteLine(ert + " " + ((t[j].brojG() * 100) / z) + "%");

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


            glasaci.Add(new Glasac("Fatih", "Fatić", "Tešanjska 12", "02.01.1998.", false));
            glasaci.Add(new Glasac("Mujo", "Mujić", "Zmaja od Bosne 14", "05.01.1995.", false));
            glasaci.Add(new Glasac("Huso", "Husić", "Novo Sarajevo", "14.02.1994.", false));
            glasaci.Add(new Glasac("Pero", "Perić", "Čengić Vila", "02.04.1998.", false));
            glasaci.Add(new Glasac("Hasnija", "Hasnić", "Stup", "02.01.2000.", false));
            glasaci.Add(new Glasac("Esmeralda", "Kolašinac", "Fedhima bb", "15.05.1980.", false));
            glasaci.Add(new Glasac("Lebron", "James", "Ozimice 2", "14.01.1994.", false));
            glasaci.Add(new Glasac("Meho", "Mehić", "Grbavica", "02.01.1998.", false));
            glasaci.Add(new Glasac("Benjamin", "Fehić", "Pofalići", "02.01.1998.", false));
            glasaci.Add(new Glasac("Vučko", "Vučkić", "Titova", "21.12.2001.", false));
            glasaci.Add(new Glasac("Meho", "Puzić", "Odžak", "02.01.1937.", false));
            glasaci.Add(new Glasac("Mahir", "Fatić", "Tešanjska 12", "02.06.2001.", false));



            sda.Add(new Kandidat("Hasnija", "Bulić"));
            sda.Add(new Kandidat("Aki", "Akić"));
            sda.Add(new Kandidat("Musa", "Nurkić"));
            sda.Add(new Kandidat("Edin", "Atić"));
            sda.Add(new Kandidat("Sulejman", "Halilovič"));

            sdp.Add(new Kandidat("Munja", "Munjić"));
            sdp.Add(new Kandidat("Amar", "Gegić"));
            sdp.Add(new Kandidat("Kenan", "Kamenjaš"));
            sdp.Add(new Kandidat("Edvin", "Kljaljić"));
            sdp.Add(new Kandidat("Esad", "Plavi"));

            hdz.Add(new Kandidat("Elon", "Musk"));
            hdz.Add(new Kandidat("Rakan", "Mukič"));
            hdz.Add(new Kandidat("Ela", "Makedonac"));
            hdz.Add(new Kandidat("Ilija", "Nugato"));
            hdz.Add(new Kandidat("Kakao", "Kamenjaš"));

            asda.Add(new Kandidat("Fatka", "Fatkić"));
            asda.Add(new Kandidat("Frugić", "Drugar"));
            asda.Add(new Kandidat("Gospodar", "Fatkić"));
            asda.Add(new Kandidat("Bilbo", "Bagins"));
            asda.Add(new Kandidat("Edin", "Džeko"));

            pomak.Add(new Kandidat("Romeo", "Lukaku"));
            pomak.Add(new Kandidat("Cristiano", "Ronaldo"));
            pomak.Add(new Kandidat("Tejt", "MegregoAr"));
            pomak.Add(new Kandidat("Kanie", "West"));
            pomak.Add(new Kandidat("Messi", "Ronaldo"));

            nezavisni.Add(new Kandidat("Justin", "So"));
            nezavisni.Add(new Kandidat("Angelina", "Boli"));
            nezavisni.Add(new Kandidat("Marija", "Ana"));
            nezavisni.Add(new Kandidat("Bull", "Pit"));
            nezavisni.Add(new Kandidat("Vojage", "Breskvica"));
            stranke.Add(new Tuple<List<Kandidat>, string>(sda, "sda"));
            stranke.Add(new Tuple<List<Kandidat>, string>(nezavisni, "nezavisni"));
            stranke.Add(new Tuple<List<Kandidat>, string>(pomak, "Pomak"));
            stranke.Add(new Tuple<List<Kandidat>, string>(sdp, "Sdp"));
            stranke.Add(new Tuple<List<Kandidat>, string>(asda, "asda"));
            stranke.Add(new Tuple<List<Kandidat>, string>(hdz, "hdz"));

        }
        static void Main(string[] args)
        {
            pod();
            while (true)
            {
                Console.WriteLine("Ako želite glasati unesite 1");
                Console.WriteLine("Ako želite vidjeti statistiku unesite 2");
                Console.WriteLine("Ako želite izaci iz app unesite 3");
                int k = Convert.ToInt32(Console.ReadLine());
                if (k == 1)
                {
                    Console.WriteLine("Unesite Vaš jedinstveni identifikacioni kod: ");
                    string s = Console.ReadLine();
                    int t = glasaci.FindIndex(gl => gl.getJik() == s);
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
                                    for (int t3 = i; t3 < stranke[i].Item1.Count + i; t3 += i)
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
                                    break;
                                }
                            }
                            if (zu >= stranke.Count - 1)
                            {
                                stranke[stranke.Count - 1].Item1[zu - stranke.Count + 1].dodaj_glas();
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
                                        stranke[zu].Item1[zr].dodaj_glas();
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
                else if (k == 3)
                    break;
                else
                    continue;
            }
        }
    }
}