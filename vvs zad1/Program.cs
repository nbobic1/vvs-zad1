using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace vvs_zad1
{
    internal class Program
    {
        static List<Glasac> glasaci = new List<Glasac>();
        static void Main(string[] args)
        {
            glasaci.Add(new Glasac("Cigarettes", "After", "Keks", "Sweet", false));

            while (true)
            {
                Console.WriteLine("Ako želite glasati unesite 1");
                Console.WriteLine("Ako želite vidjeti statistiku unesite 2");
                Console.WriteLine("Ako želite izaci iz app unesite 3");
                int k = Convert.ToInt32(Console.ReadLine());
                if (k == 1)
                {
                    Console.WriteLine("Unesite Vaš jedinstveni identifikacioni kod: ");
                    string s=Console.ReadLine();
                    int t = glasaci.FindIndex(gl => gl.getJik()==s );
                    if(t==-1)
                    {
                        Console.WriteLine("Niste registrirani u ovom biračkom mjestu");
                        continue;
                    }
                    else
                    {
                        if (!glasaci[t].getGlasao())
                        {
                            //glasaj
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

                }
                else if (k == 3)
                {
                    break;
                }
                else
                    continue;
            }
        }
    }
}
