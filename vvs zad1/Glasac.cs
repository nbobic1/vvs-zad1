﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace vvs_zad1
{



    public class Glasac
    {
        bool glasao;
        string ime, prezime, adresa, identifikacijskiKod, datumRodjenja, brojLicneKarte, maticniBroj;

        public bool VjerodostojnostGlasaca(IProvjera sigurnosnaProvjera)
        {
            if (sigurnosnaProvjera.DaLiJeVecGlasao(identifikacijskiKod))
                throw new Exception("Glasač je već izvršio glasanje!");
            return true;
        }

        //Esma Dervisevic, 18923
        public static bool validirajPodatke(string ime, string prezime, string adresa, string datumRodjenja, string brojLicneKarte, string maticniBroj)
        {
            /*Ime i prezime smiju sadržavati samo slova i crticu, a ostale vrste karaktera nisu dozvoljene. */
            var vrati = false;
            var regexIme = @"^[A-Za-z]+$";
            var regexPrezime = @"^[A-Za-z]+[-]*[A-Za-z]+$";

            var matchIme = Regex.Match(ime, regexIme, RegexOptions.IgnoreCase);
            if (!matchIme.Success) return vrati;

            var matchPrezime = Regex.Match(prezime, regexPrezime, RegexOptions.IgnoreCase);
            if (!matchPrezime.Success) return vrati;

            /*Ime se sastoji od minimalno 2, a maksimalno 40 slova,*/
            if (ime.Length < 2 || ime.Length > 40)
                return vrati;
            /*dok se prezime sastoji od minimalno 3, a maksimalno 50 slova. */
            if (!Enumerable.Range(3, 50).Contains(prezime.Length))
                return vrati;
            /*Ime, prezime i adresa ne smiju biti prazni. */
            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime))
                return vrati;

            /*Svaki glasač mora biti punoljetan i njegov datum rođenja ne može biti u budućnosti. */
            var godinaString = datumRodjenja.Substring(6, 4);
            var godinaInt = Int32.Parse(godinaString);
            DateTime now = DateTime.Today;
            var godinePunoljetstva = now.ToString("yyyy");
            var godinKojomPoredimo = Int32.Parse(godinePunoljetstva) - 18;
            if (godinaInt > godinKojomPoredimo)
                return vrati;

            /*Broj lične karte uvijek se sastoji od tačno 7 karaktera u formatu 999A999, pri čemu 9 može biti bilo koji broj, a A bilo koje slovo iz skupa (E, J, K, M, T).*/
            if (brojLicneKarte.Length == 7)
                return vrati;
            var regex = @"^[0-9]{3}[EJKMT][0-9]{3}$";
            var match = Regex.Match(brojLicneKarte, regex, RegexOptions.IgnoreCase);
            if (!match.Success) return vrati;

            /*Matični broj se mora sastojati od 13 brojeva, pri čemu prva dva broja odgovaraju danu, sljedeća dva broja mjesecu, a sljedeća tri broja godini rođenja glasača.*/
            if (maticniBroj.Length != 13) return vrati;

            if (!Regex.IsMatch(maticniBroj.ToString(), @"^[\d\s]+$")) return vrati;

            var dijeloviDatuma = datumRodjenja.Substring(0, 2) + datumRodjenja.Substring(3, 2) + datumRodjenja.Substring(6, 3);

            if (!maticniBroj.Contains(dijeloviDatuma))
                return vrati;
            else
            {
                vrati = true;
                return vrati;

            }
        }


        public Glasac(string ime, string prezime, string adresa, string datumRodjenja, string brojLicneKarte, string maticniBroj, bool glasao = false)
        {

            Boolean validacija = validirajPodatke(ime, prezime, adresa, datumRodjenja, brojLicneKarte, maticniBroj);

            var idKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.Substring(0, 2) + datumRodjenja.Substring(0, 2) + brojLicneKarte.Substring(0, 2) + maticniBroj.Substring(0, 2);


            if (validacija == false)
                throw new Exception("Pogrešno uneseni podaci");
            //            glasaci.Add(new Glasac("Fatih", "Fatic", "Tešanjska 12", "02.01.1998.", "999E999", "0201199666666"));

            /*Validacijom se treba pokriti i jedinstveni identifikacioni broj glasača.*/
            if (idKod.Length == 12)
                this.identifikacijskiKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.Substring(0, 2) + datumRodjenja.Substring(0, 2) + brojLicneKarte.Substring(0, 2) + maticniBroj.Substring(0, 2);
            else
                throw new Exception("Pogrešno uneseni podaci OVDJE");


            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.datumRodjenja = datumRodjenja;
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