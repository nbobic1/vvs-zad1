using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_zad1
{
    internal class Kandidat
    {
        string ime, prezime;
        int broj_glasova;
        public Kandidat(string ime, string prezime)
        {
            broj_glasova = 0;
            this.ime = ime;
            this.prezime = prezime;
        }   
        public string getIme()
        {
            return ime;
        }
        public string getPrezime()
        {
            return prezime;
        }
        public void dodaj_glas()
        {
            broj_glasova++;
        }
    }
}
