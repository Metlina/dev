using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaLabosiUCsharp.Entitet
{
    public class Izdavac
    {
        private string nazivIzdavaca;
        private string drzavaIzdavaca;

        public Izdavac(string nazivIzdavaca, string drzavaIzdavaca)
        {
            this.nazivIzdavaca = nazivIzdavaca;
            this.drzavaIzdavaca = drzavaIzdavaca;
        }

        public string GetNazivIzdavaca()
        {
            return this.nazivIzdavaca;
        }

        public string GetDrzavaIzdavaca()
        {
            return this.drzavaIzdavaca;
        }
    }
}
