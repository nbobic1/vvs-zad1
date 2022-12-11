using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_zad1
{
    public class StubSigurnosnaProvjeraTrue : IProvjera
    {
        public bool DaLiJeVecGlasao(string IDBroj)
        {
            return true;
        }
    }
    public class StubSigurnosnaProvjeraFalse : IProvjera
    {
        public bool DaLiJeVecGlasao(string IDBroj)
        {
            return false;
        }
    }
}
