using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_zad1
{
    public class Stranka
    {
        private string naziv;
        private List<Kandidat> kandidatList=new List<Kandidat>();

        public Stranka(List<Kandidat> kandidatList, string naziv)
        {
            this.kandidatList = kandidatList;
            this.naziv = naziv;
        }

        public Stranka(List<Kandidat> kandidatList)
        {
            this.kandidatList = kandidatList;
            this.naziv = "nezavisna lista";
        }

        public string getNaziv()
        {
            return this.naziv;
        }

        public void setNaziv(string stranka)
        {
            this.naziv = stranka;
        }

        public List<Kandidat> getKandidatList()
        {
            return this.kandidatList;
        }

        public void setKandidatList(List<Kandidat> kandidatList)
        {
            this.kandidatList = kandidatList;
        }

    }
}
