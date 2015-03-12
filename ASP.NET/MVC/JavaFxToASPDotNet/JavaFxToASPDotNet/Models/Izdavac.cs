using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JavaFxToASPDotNet.Models
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

        //public string GetNazivIzdavaca()
        //{
        //    return NazivIzdavaca;
        //}

        //private void SetNazivIzdavaca(string naziv)
        //{
        //    NazivIzdavaca = naziv;
        //}

        //public string GetDrzavaIzdavaca()
        //{
        //    return DrzavaIzdavaca;
        //}

        //private void SetDrzavaIzdavaca(string drzava)
        //{
        //    DrzavaIzdavaca = drzava;
        //}
    }
}