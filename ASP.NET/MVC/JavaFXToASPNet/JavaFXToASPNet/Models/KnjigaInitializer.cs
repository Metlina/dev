using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFXToASPNet.Models
{
    public class KnjigaInitializer : DropCreateDatabaseAlways<KnjigaContext>
    {
        protected override void Seed(KnjigaContext context)
        {
            context.Knjigas.Add(new Knjiga()
            {
                NazivPublikacije = "Programiranje u Javi",
                Vrsta = "Elektronicka",
                GodinaIzdanjaPublikacije = 2014,
                JezikProp = "Hrvatski",
                BrojStanicaPublikacije = 400,
                NazivIzdavaca = "Skolska Knjiga"
            });
            context.Knjigas.Add(new Knjiga()
            {
                NazivPublikacije = "Java web applications",
                Vrsta = "Papirnata",
                GodinaIzdanjaPublikacije = 2014,
                JezikProp = "Engleski",
                BrojStanicaPublikacije = 600,
                NazivIzdavaca = "Packt Publishing"
            });

            base.Seed(context);
        }
    }
}
