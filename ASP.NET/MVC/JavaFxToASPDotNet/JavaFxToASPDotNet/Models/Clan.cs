using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFxToASPDotNet.Models
{
    public class Clan
    {
        public int ID { get; set; }

        public string Ime { get; private set; }

        public string Prezime { get; private set; }

        public string Oib { get; private set; }

        public Clan()
        {
            
        }

        public Clan(string ime, string prezime, string oib)
        {
            Ime = ime;
            Prezime = prezime;
            Oib = oib;
        }
    }
}
