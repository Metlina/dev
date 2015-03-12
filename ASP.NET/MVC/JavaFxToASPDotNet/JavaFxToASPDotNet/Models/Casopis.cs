using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFxToASPDotNet.Models
{
    public class Casopis : Publikacija
    {
        public int ID { get; set; }

        public int MjesecIzdavanjaCasopisa { get; private set; }

        private const double CijenaPoPrimjerku = 12.50;

        public Casopis()
        {
            
        }

        public Casopis(int mjesecIzdavanjaCasopisa, string naziv, int godina, int broj, VrstaPublikacije vrsta)
            : base(naziv, godina, broj, vrsta, CijenaPoPrimjerku/broj)
        {
            MjesecIzdavanjaCasopisa = mjesecIzdavanjaCasopisa;
        }
    }
}
