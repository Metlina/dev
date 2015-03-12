using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFxToASPDotNet.Models
{
    public class Knjiga : Publikacija
    {
        public int ID { get; set; }

        public Izdavac Izdavac { get; private set; }
        public Jezik Jezik { get; private set; }
        public bool Raspolozivost { get; private set; }

        public Knjiga()
        {
            
        }

        public Knjiga(Izdavac izdavac, Jezik jezik, bool raspolozivost, string naziv, int godina, int broj, VrstaPublikacije vrsta, double cijenaPoStranici)
            : base(naziv, godina, broj, vrsta, cijenaPoStranici)
        {
            Izdavac = izdavac;
            this.Jezik = jezik;
            this.Raspolozivost = true;
        }

        
    }
}
