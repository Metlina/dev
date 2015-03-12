using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Planirate putovanje jadranskom magistralom. Slušajući vijesti, zabrinuli ste se jer ste čuli da postoje odroni stijena na cesti. 
 * Štoviše, kako je tehnologija napredovala, moguće je točno predvidjeti gdje će biti odron i kada. S obzirom na te informacije, 
 * trebate izračunati kada morate krenuti i kojom brzinom voziti kako bi izbjegli sve odrone.

Na početku je potrebno unijeti broj 0 <= N <= 100,000 koji označava ukupan broj informacija o odronima. Nakon toga slijedi N redaka,
 * gdje se svaki redak sastoji od 4 broja: 0 <= h <= 23, 0 <= m <= 59, 0 <= s <= 59 i 0 < km < 1,000,000. Brojevi h, m i s označavaju sat,
 * minutu i sekundu poojedinog odrona, a broj km označava na kojem kilometru će se dogoditi odron.

Putovanje počinje točno u ponoć, i kao rezultat je potrebno ispisati koja je minimalna brzina kojom je potrebno voziti kako bi se izbjegli 
 * svi odroni (u km/h, zaokruženo na 2 decimale).

Napomena: Svi ulazni podaci će biti u gore definiranim intervalima te niije potrebno to provjeravati. Dodatno, ulazni podaci o vremenima 
 * i lokacijama odrona ne moraju biti sortirani po nikakvom redoslijedu.
 */
namespace Zadatak2
{
    public class Podaci
    {
        private int h, m, s, km;

        public Podaci(int h, int m, int s, int km)
        {
            this.h = h;
            this.m = m;
            this.s = s;
            this.km = km;
        }

        public int GetSati()
        {
            return h;
        }

        public int GetMinute()
        {
            return m;
        }

        public int GetSekunde()
        {
            return s;
        }

        public int GetKilometre()
        {
            return km;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var line = Console.ReadLine();
            //var a = int.Parse(line.Split(' ')[0]);
            //var b = int.Parse(line.Split(' ')[1]);
            //var x = int.Parse(line.Split(' ')[2]);

            var broj = Console.ReadLine();
            var brojInformacija = int.Parse(broj);

            if (brojInformacija < 0 || brojInformacija > 100000)
            {
                Console.WriteLine("Krivi broj je unesen");
            }


            Podaci podaci = null;

            List<Podaci> listaPodataka = new List<Podaci>();

            for (int i = 0; i < brojInformacija; i++)
            {
                var line = Console.ReadLine();
                var h = int.Parse(line.Split(' ')[0]);
                var m = int.Parse(line.Split(' ')[1]);
                var s = int.Parse(line.Split(' ')[2]);
                var km = int.Parse(line.Split(' ')[3]);

                if (h < 0 || h > 24)
                {
                    Console.WriteLine("Sat nemoze biti manji od 0 i veci od 24!");
                }
                else if (m < 0 || m > 60)
                {
                    Console.WriteLine("Minuta nemoze biti manja od 0 i veca od 60!"); 
                }
                else if (s < 0 || s > 60)
                {
                    Console.WriteLine("Sekunda nemoze biti manja od 0 i veca od 60!"); 
                }
                else if (km < 0 || km > 1000000)
                {
                    Console.WriteLine("Kilometar nemoze biti manji od 0 i veci od 1 000 000!");
                }

                podaci = new Podaci(h, m, s, km);
                
                listaPodataka.Add(podaci);
            }

            double brzinaSati = 0, brzinaMinute = 0, brzinaSekunde = 0;
            double najvecaBrzina = 0;

            foreach (Podaci p in listaPodataka)
            {
                for (int i = 1; i <= brojInformacija; i++)
                {
                    if (p.GetSati() > 0)
                    {
                        brzinaSati = (24) / ((double)(p.GetKilometre() + p.GetMinute() + p.GetSekunde()) / p.GetKilometre());
                        if (brzinaSati > najvecaBrzina)
                            najvecaBrzina = brzinaSati;
                    }
                    else if (p.GetSati() == 0)
                    {
                        brzinaMinute = (60) / ((double)(p.GetMinute() / p.GetKilometre()));
                        if (brzinaMinute > najvecaBrzina)
                            najvecaBrzina = brzinaMinute;
                    }
                    else if (p.GetMinute() == 0)
                    {
                        brzinaSekunde = (60) / ((double)(p.GetSekunde() / p.GetKilometre()));
                        if (brzinaSekunde > najvecaBrzina)
                            najvecaBrzina = brzinaSekunde;
                    }
                }
            }

            var fmt = new System.Globalization.NumberFormatInfo();
            fmt.NumberDecimalSeparator = ".";

            najvecaBrzina = Math.Truncate(najvecaBrzina * 100) / 100;
            string rjesenje = string.Format(fmt, "{0:N2}", najvecaBrzina);

            //string rjesenje = string.Format("{0:N" + Math.Abs(2) + "}", najvecaBrzina);

            Console.WriteLine(rjesenje);
        }
    }
}
