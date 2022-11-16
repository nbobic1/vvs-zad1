using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_zad1
{
    internal class Kandidat
    {
        private string ime;
        private string prezime;
        int broj_glasova;
        public Kandidat(string ime, string prezime)
        {
            broj_glasova = 0;
            this.ime = ime;
            this.prezime = prezime;
        }
        public int brojG()
        { return broj_glasova; }
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