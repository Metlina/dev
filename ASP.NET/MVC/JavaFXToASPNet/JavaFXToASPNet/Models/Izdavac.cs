using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JavaFXToASPNet.Models
{
    public class Izdavac
    {
        public string NazivIzdavaca { get; private set; }
        public string DrzavaIzdavaca { get; private set; }

        public Izdavac()
        {

        }

        public Izdavac(string naziv, string drzava)
        {
            NazivIzdavaca = naziv;
            DrzavaIzdavaca = drzava;
        }
    }
}