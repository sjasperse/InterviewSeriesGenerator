using System.Linq;
using NUnit.Framework;
using Reusable;

namespace Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void Generator_Generate_MultiplesOf15WillShowFizzBuzz()
        {
            var max = 100;
            var generator = new Generator();
            var series = generator.GetNumberEnumerable(100);

            for (int i = 1; i < max; i += 15)
            {
                Assert.AreEqual(series.ElementAt(i), 0);
            }
        }
    }
}
