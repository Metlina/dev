using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string sep = ",";
            //string number1 = "2,2345345 3,32423423";

            //string blabla = "34.2";
            ////Console.WriteLine(int.Parse(blabla));

            //string[] split = number1.Split(' ');

            ////Console.WriteLine(int.Parse(split[0]));
            ////Console.WriteLine(int.Parse(split[1]));

            //string[] tockaSplit = number2.Split(',');



            string number2 = "2.2345345,3.32423423";
            string[] tockaSplit = number2.Split(',');
            string pom = null;
            foreach (var s in tockaSplit)
            {
                pom = s.Replace(".", ",");
                Console.WriteLine(double.Parse(pom));
            }

            //var result = String.Join(sep, tockaSplit, 1, 1);
            //Console.WriteLine(double.Parse(result));

            //var result1 = String.Join(sep, tockaSplit, 2, 2);
            //Console.WriteLine(double.Parse(result1));

            Console.ReadKey();
        }
    }
}
