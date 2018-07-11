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
            var interval = 15;
            var generator = new Generator();
            var series = generator.GetNumberEnumerable(100);

            for (int i = interval; i < max; i += interval)
            {
                Assert.AreEqual("FizzBuzz", series.ElementAt(i - 1));
            }
        }
    }
}
