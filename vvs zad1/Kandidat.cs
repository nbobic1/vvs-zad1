using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_zad1
{
    public class Kandidat
    {
        private string ime;
        private string prezime;
        int broj_glasova;
        private List<Glasac> glasaci = new List<Glasac>() ;
        private bool rukovodilacStranke;
        private string identifikacijskiKod;
        private string dodatniOpis;
        public Kandidat(string ime, string prezime, bool rukovodilacStranke)
        {
            broj_glasova = 0;
            this.ime = ime;
            this.prezime = prezime;
            if (ime.Length >= 2 && prezime.Length >= 2)
                this.identifikacijskiKod = ime.Substring(0, 2) + prezime.Substring(0, 2);
            this.rukovodilacStranke = rukovodilacStranke;
        }
        
        public void setDodatniOpis(string opis) {
            this.dodatniOpis = opis;
        }
        public string? getDodatniOpis() { return dodatniOpis; }

        
        public int getBroj_glasova()
        { 
            return broj_glasova; 
        }
        public List<Glasac> getGlasaci()
        {
            return glasaci;
        }
        public void setGlasaci(List<Glasac> glasaci1)
        {
            glasaci = glasaci1;
        }
        public string getIme()
        {

            return ime;
        }
        public string getPrezime()
        {
            return prezime;
        }
        public void dodaj_glas(Glasac glas)
        {
            if (glasaci == null) glasaci = new List<Glasac>();
            glasaci.Add(glas);
            broj_glasova++;
        }

        public string getKod()
        {
            return identifikacijskiKod;
        }

        public void dodajKod(string kod)
        {
            this.identifikacijskiKod = kod;
        }

        public bool getRukovodilac()
        {
            return rukovodilacStranke;
        }

        public void dodajRukovodioca(bool rukovodilac)
        {
            this.rukovodilacStranke = rukovodilac;
        }

    }
}