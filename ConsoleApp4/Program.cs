using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reusable;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();
            var series = generator.GetNumberEnumerable(100);

            foreach (var i in series)
            {
                Console.WriteLine(i);
            }
        }

    }
}
