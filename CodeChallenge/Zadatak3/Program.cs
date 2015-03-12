using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
 * Putujete automobilom s jedne na drugu obalu SAD-a, i jedino što želite osigurati je da u svakom trenutku čujete svoju omiljenu radio postaju
 * - Radio America. Da bi to osigurali, istražili ste gdje se blizu ceste nalaze svi odašiljači koji emitiraju tu frekvenciju - i s obzirom na te
 * informacije, zanima vas koliko mora biti jak radio prijemnik da bi uspjeli kroz cijelo vrijeme putovanja uloviti željenu frekvenciju. 
 * No, ipak ne želite potrošiti previše novca na prejaki radio prijemnik, pa vas zanima koliki je minimalni domet radio prijemnika koji će 
 * uspješno uhvatiti signal u svakom dijelu ceste.

Udaljenost od New Yorka do Los Angelesa je 4493km (četiri i pol tisuće kilometara). Kako bi pojednostavili priču, možemo zamisliti da se cesta 
 * proteže od koordinata (0,0) do koordinata (4493, 0). Podaci o odašiljačima su također koordinate -10,000 <= Ox, Oy <= 10,000. 

Na početku je potrebno učitati prirodni broj 1 <= N <= 100,000, koji označava broj odašiljača. Nakon toga slijedi N redaka, u svakom se nalaze
 * koordinate -10,000 <= Ox, Oy <= 10,000 pojedinog odašiljača. Ox i Oy su cijeli brojevi.

Kao rezultat je potrebno ispisati koji je minimalni domet radio prijemnika da bi uspio "uloviti" signal u svakom dijelu ceste. Potrebno je 
 * izračunati domet s preciznošću od 5 decimala (zaokruženo).

Napomena: test primjeri će biti takvi da:

    postoje sigurno 2 test primjera gdje vrijedi N <= 10 
    postoji sigurno 5 test primjera gdje vrijedi N <= 100
    postoji sigurno 7 test primjera gdje vrijedi N <= 1000


*/

namespace Zadatak3
{
    public class Koordinate
    {
        private double Ox;
        private double Oy;

        public Koordinate(double ox, double oy)
        {
            this.Ox = ox;
            this.Oy = oy;
        }

        public double GetOsX()
        {
            return Ox;
        }

        public double GetOsY()
        {
            return Oy;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var broj = Console.ReadLine();
            var brojOdasiljaca = int.Parse(broj);

            if (brojOdasiljaca < 0 || brojOdasiljaca > 1000000)
            {
                Console.WriteLine("Krivi broj je unesen");
            }

            Koordinate koordinate = null;
            List<Koordinate> listaKoordinata = new List<Koordinate>();

            for (int i = 1; i <= brojOdasiljaca; i++)
            {
                var line = Console.ReadLine();
                var ordinataX = double.Parse(line.Split(' ')[0]);
                var ordinataY = double.Parse(line.Split(' ')[1]);

                if (ordinataX < -10000 || ordinataX > 10000)
                {
                    Console.WriteLine("Ordinata x je kriva!");
                }
                else if (ordinataY < -10000 || ordinataY > 10000)
                {
                    Console.WriteLine("Ordinata y je kriva!");
                }

                koordinate = new Koordinate(ordinataX, ordinataY);
                listaKoordinata.Add(koordinate);
            }

            double domet = 0, dometKvadrat;
            double najveciDomet = 110000;

            foreach (Koordinate k in listaKoordinata)
            {
                for (int i = 1; i <= brojOdasiljaca; i++)
                {
                    if (k.GetOsX() > 0 && k.GetOsY() > 0)
                    {
                        dometKvadrat = Math.Pow(k.GetOsX(), 2) + Math.Pow(k.GetOsY(), 2);
                        domet = Math.Sqrt(dometKvadrat);
                        if (domet <= najveciDomet)
                        {
                            najveciDomet = domet;
                        }
                    }
                    else if (k.GetOsY() == 0)
                    {
                        domet = k.GetOsX();
                        if (domet <= najveciDomet)
                        {
                            najveciDomet = domet;
                        }
                    }
                    else if (k.GetOsX() == 0 || k.GetOsX() == 4450)
                    {
                        dometKvadrat = Math.Pow(4450, 2) + Math.Pow(k.GetOsY(), 2);
                        domet = Math.Sqrt(dometKvadrat);
                        if (domet <= najveciDomet)
                        {
                            najveciDomet = domet;
                        }
                    }
                }
            }

            var fmt = new System.Globalization.NumberFormatInfo();
            fmt.NumberDecimalSeparator = ".";
            fmt.NumberGroupSeparator = "";

            string rjesenje = string.Format(fmt, "{0:N5}", najveciDomet);
            
            Console.WriteLine(rjesenje);
        }
    }
}
