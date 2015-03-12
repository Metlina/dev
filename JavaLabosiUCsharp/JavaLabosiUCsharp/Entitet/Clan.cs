using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaLabosiUcsharpu.Entitet
{
    public class Clan
    {
        private string ime;
        private string prezime;
        private string OIB;

        public Clan(string ime, string prezime, string OIB)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.OIB = OIB;
        }

        public string GetIme()
        {
            return this.ime;
        }

        public string GetPrezime()
        {
            return this.prezime;
        }

        public string GetOIB()
        {
            return this.OIB;
        }
    }
}
