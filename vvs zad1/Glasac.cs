using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_zad1
{
    internal class Glasac
    {
        bool glasao;
        string ime, prezime, adresa, identifikacijskiKod, datumRodjenja;
        public Glasac(string ime, string prezime, string adresa, string datumRodjenja, bool glasao=false)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.datumRodjenja = datumRodjenja;
            if(ime.Length>=2&&prezime.Length>=2&&adresa.Length>=2&&datumRodjenja.Length>=2) 
            this.identifikacijskiKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.Substring(0, 2) + datumRodjenja.Substring(0, 2);
            this.glasao = glasao;
        }
        public string getidentifikacijskiKod()
        {
            return identifikacijskiKod;
        }
        public void setGlasao(bool t)
        {
            glasao = t;
        }
        public bool getGlasao()
        {
            return glasao;
        }

    }
}