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
        string ime, prezime, adresa, jik;
        DateTime datumRodjenja;
        public Glasac(string ime, string prezime, string adresa, DateTime datumRodjenja,bool glasao)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.datumRodjenja = datumRodjenja;
            this.jik = ime.Substring(0,2)+prezime.Substring(0,2)+adresa.Substring(0,2)+datumRodjenja.ToShortDateString().Substring(0,2);
            this.glasao = glasao;
        }
        public string getJik()
        {
            return jik;
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
