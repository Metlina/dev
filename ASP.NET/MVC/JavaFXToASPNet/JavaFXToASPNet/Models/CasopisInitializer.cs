using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFXToASPNet.Models
{
    public class CasopisInitializer : DropCreateDatabaseAlways<CasopisContext>
    {
        protected override void Seed(CasopisContext context)
        {
            context.Casopis.Add(new Casopis()
            {
                NazivPublikacije = "BUG",
                GodinaIzdanjaPublikacije = 2014,
                MjesecIzdavanjaCasopisa = 5,
                Vrsta = "Papirnata",
                BrojStanicaPublikacije = 200
            });

            context.Casopis.Add(new Casopis()
            {
                NazivPublikacije = "Java Magazine",
                GodinaIzdanjaPublikacije = 2014,
                MjesecIzdavanjaCasopisa = 5,
                Vrsta = "Papirnata",
                BrojStanicaPublikacije = 100
            });

            base.Seed(context);
        }
    }
}
