using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_zad1
{
    public class SpySigurnosnaProvjera : IProvjera
    { 
        public int Opcija { get; set; }

        public bool DaLiJeVecGlasao(string IDBroj)
        {
            if (Opcija == 0)
            return true;
        else 
            return false;
        }
    }
}
