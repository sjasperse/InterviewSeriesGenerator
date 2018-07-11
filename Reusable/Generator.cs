using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusable
{
    public class Generator
    {
        public IEnumerable<string> GetNumberEnumerable(int upperBound = 100)
        {
            for (int i = 1; i <= 100; i++)
            {
                var result = "";
                if (i % 5 == 0 || i % 3 == 0)
                {
                    if (i % 3 == 0)
                    {
                        result += "Fizz";
                    }
                    if (i % 5 == 0)
                    {
                        result += "Buzz";
                    }
                }
                else
                {
                    result = i.ToString();
                }

                yield return result;
            }
        }
    }
}
