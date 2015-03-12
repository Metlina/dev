using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaLabosiUCsharp.Entitet
{
    public class Knjiga
    {
        private string nazivKnjige;
        private string jezikKnjige;
        private Izdavac izdavac;

        public Knjiga(string nazivKnjige, string jezikKnjige, Izdavac izdavac)
        {
            this.nazivKnjige = nazivKnjige;
            this.jezikKnjige = jezikKnjige;
            this.izdavac = izdavac;
        }

        public string GetNazivKnjige()
        {
            return this.nazivKnjige;
        }

        public string GetJezikKnjige()
        {
            return this.jezikKnjige;
        }

        public Izdavac GetIzdavac()
        {
            return this.izdavac;
        }
    }
}
