using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusable
{
    public class Generator
    {
        private readonly IEnumerable<IMappingRule> mappingRules;

        public Generator()
            : this(new [] { new SimpleMappingRule(3, "Fizz"), new SimpleMappingRule(5, "Buzz") })
        { }

        public Generator(IEnumerable<IMappingRule> mappingRules)
        {
            this.mappingRules = mappingRules ?? throw new ArgumentNullException(nameof(mappingRules));
        }

        public IEnumerable<string> GenerateSeries(int upperBound = 100)
        {
            for (int i = 1; i <= upperBound; i++)
            {
                var result = "";
                var hasMatch = false;

                foreach (var rule in mappingRules)
                {
                    if (rule.IsApplicable(i))
                    {
                        hasMatch = true;
                        result += rule.ReplacementText(i);
                    }
                }

                if (!hasMatch)
                {
                    result = i.ToString();
                }

                yield return result;
            }
        }
    }

    public interface IMappingRule
    {
        bool IsApplicable(int i);
        string ReplacementText(int i);
    }

    public class SimpleMappingRule : IMappingRule
    {
        private readonly int divisibleBy;
        private readonly string word;

        public SimpleMappingRule(int divisibleBy, string word)
        {
            this.divisibleBy = divisibleBy;
            this.word = word;
        }

        public bool IsApplicable(int i)
        {
            return i % divisibleBy == 0;
        }

        public string ReplacementText(int i)
        {
            return word;
        }
    }
}
