using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTut
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            for (int i = 1; i < 12; i++)
            {
                lista.Add(i);
            }

            var x = lista.Select(l => l)
                .Where(l => l % 2 == 0)
                .Sum(l => l);


            var numQuery =
                from num in lista
                where (num % 2) == 0
                select num;

            Console.WriteLine("Query kao sql");
            foreach (var num in numQuery)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Query nastavak na listi");
            //foreach (var num in x)
            //{
            //    Console.WriteLine(num);
            //}

            Console.WriteLine(x);

            var parent = new List<Person>();

            var children1 = new Person("Iva", 3);
            parent.Add(new Person("Marko", 32, children1));
            parent.Add(new Person("Ana", 30, children1));

            var children2 = new Person("Ante", 5);
            parent.Add(new Person("Marko", 32, children2));
            parent.Add(new Person("Ana", 30, children2));

            var children3 = new Person("Ivan", 1);
            parent.Add(new Person("Dzivo", 32, children3));
            parent.Add(new Person("Kata", 30, children3));

            var children4 = new Person("Marta", 3);
            parent.Add(new Person("Dzivo", 32, children4));
            parent.Add(new Person("Kata", 30, children4));

            var children5 = new Person("Slovo", 7);
            parent.Add(new Person("Dzivo", 32, children5));
            parent.Add(new Person("Kata", 30, children5));

            var children6 = new Person("Mara", 10);
            parent.Add(new Person("Tino", 32, children6));
            parent.Add(new Person("Lara", 30, children6));

            var children7 = new Person("Bruno", 15);
            parent.Add(new Person("Tino", 32, children7));
            parent.Add(new Person("Lara", 30, children7));

            var children8 = new Person("Lovro", 3);
            parent.Add(new Person("Toni", 32, children8));
            parent.Add(new Person("Kiki", 30, children8));

            var children9 = new Person("Ivan", 1);
            parent.Add(new Person("Frana", 32, children9));
            parent.Add(new Person("Tomo", 30, children9));

            var children10 = new Person("Petra", 8);
            parent.Add(new Person("Frana", 32, children10));
            parent.Add(new Person("Tomo", 30, children10));

            var children11 = new Person("Iva", 10);
            parent.Add(new Person("Frana", 32, children11));
            parent.Add(new Person("Tomo", 30, children11));

            //a
            var allChildren = parent
                .SelectMany(person => person.Children)
                .ToList();

            Console.WriteLine("Sva djeca");
            foreach (var child in allChildren)
            {
                Console.WriteLine(child.Name);
            }

            //b
            var allChildrenAlphabetical = parent
                .SelectMany(person => person.Children)
                .OrderBy(person => person.Name)
                .ToList();

            Console.WriteLine("Djeca po abecednom redu");
            foreach (var child in allChildrenAlphabetical)
            {
                Console.WriteLine(child.Name);
            }

            //c
            var allNames2 = parent
                .SelectMany(p =>
                    new[]
                    {
                        p.Name
                    }.Union(p.Children
                             .Select(i => i.Name)))
                .Distinct()
                .ToList();

            var allNames = parent
                .SelectMany(p =>
                {
                    var names = new List<string>
                    {
                        p.Name
                    };
                    names.AddRange(p.Children.Select(c => c.Name));
                    return names;
                })
                .Distinct()
                .ToList();

            var childByAge = parent
                .SelectMany(p => p.Children)
                .Where(g => g.Age > 5)
                .GroupBy(g => g.Age)
                //.Where(g => g.)
                .ToDictionary(g => g.Key, g => g.ToList());

            Console.WriteLine("Sva imena");
            foreach (var name in allNames)
            {
                Console.WriteLine(name);
            }

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<Person> Children { get; set; }

        public Person()
        {
        }

        public Person(string n, int a)
        {
            Name = n;
            Age = a;
            Children = new List<Person>();
        }

        public Person(string n, int a, Person ch)
        {
            Name = n;
            Age = a;
            Children = new List<Person>();
            Children.Add(ch);
        }
    }
}
