﻿using System;
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

        private bool rukovodilacStranke;
        private string identifikacijskiKod;
        public Kandidat(string ime, string prezime, bool rukovodilacStranke)
        {
            broj_glasova = 0;
            this.ime = ime;
            this.prezime = prezime;
            if (ime.Length >= 2 && prezime.Length >= 2)
                this.identifikacijskiKod = ime.Substring(0, 2) + prezime.Substring(0, 2);
            this.rukovodilacStranke = rukovodilacStranke;
        }
        public int getBroj_glasova()
        { 
            return broj_glasova; 
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