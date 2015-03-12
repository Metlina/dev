using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
Zadani su brojevi 0 < A <= B < 264-1. Osim njih, zadan je i broj 1 < X < 264-1. Koliko je brojeva u intervalu [A, B], koji među svojim djeliteljima imaju broj X?

U svakom test primjeru unose se 3 prirodna broja ovim redoslijedom: A, B, X.

Napomena: Svi ulazni parametri će biti u gore definiranim intervalima, te ih nije potrebno provjeravati.
*/

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //long a, b, x;

            var line = Console.ReadLine();
            var a = int.Parse(line.Split(' ')[0]);
            var b = int.Parse(line.Split(' ')[1]);
            var x = int.Parse(line.Split(' ')[2]);

            if (a < 0 || a > (Math.Pow(2, 64) - 1))
            {
                Console.WriteLine("Broj nije u trazenom intervalu!");
            }

            if (b < 0 || b > (Math.Pow(2, 64) - 1))
            {
                Console.WriteLine("Broj nije u trazenom intervalu!");
            }

            if (x < 0 || x > (Math.Pow(2, 64) - 1))
            {
                Console.WriteLine("Broj nije u trazenom intervalu!");
            }
            int brojac = 0;

            for (int i = a; i <= b; i++)
            {
                if ((i%x) == 0)
                {
                    brojac++;
                }
            }

            Console.WriteLine(brojac);
        }
    }
}
