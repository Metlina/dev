using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var brojevi = Enumerable.Range(1, 100)
                .Select(i => random.Next(1, 100))
                .ToList();

            brojevi.ForEach(Console.WriteLine);

            var grupe = brojevi
                .GroupBy(i => i / 10)
                .ToDictionary(g => g.Key.ToString(),
                    g => g.Select(i => "Hello " + i)
                        .Distinct()
                        .ToList());

            Console.ReadKey();
        }
    }
}
