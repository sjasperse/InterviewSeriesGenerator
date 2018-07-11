using System;
using System.Linq;
using NUnit.Framework;
using Reusable;

namespace Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void Generator_GenerateSeries_WillRespectUpperBoundsLimitOf0()
        {
            var length = 0;

            var generator = new Generator();
            var series = generator.GenerateSeries(length);

            Assert.AreEqual(length, series.Count());
        }

        [Test]
        public void Generator_GenerateSeries_WillRespectUpperBoundsLimitOf25()
        {
            var length = 100;

            var generator = new Generator();
            var series = generator.GenerateSeries(length);

            Assert.AreEqual(length, series.Count());
        }

        [Test]
        public void Generator_GenerateSeries_WillRespectUpperBoundsLimitOf100()
        {
            var length = 100;

            var generator = new Generator();
            var series = generator.GenerateSeries(length);

            Assert.AreEqual(length, series.Count());
        }

        [Test]
        public void Generator_Default_GenerateSeries_MultiplesOf15WillShowFizzBuzz()
        {
            var max = 100;
            var interval = 15;
            var generator = new Generator();
            var series = generator.GenerateSeries(100);

            for (int i = interval; i < max; i += interval)
            {
                Assert.AreEqual("FizzBuzz", series.ElementAt(i - 1));
            }
        }

        [Test]
        public void Generator_GenerateSeries_WillUseCustomMappingRules()
        {
            var generator = new Generator(new[] { new SimpleMappingRule(3, "Foo"), new SimpleMappingRule(5, "Bar") });
            var series = generator.GenerateSeries(100);

            Assert.AreEqual("Foo", series.ElementAt(3 - 1));
            Assert.AreEqual("Bar", series.ElementAt(5 - 1));
            Assert.IsTrue(series.ElementAt(15 - 1).Contains("Foo"));
            Assert.IsTrue(series.ElementAt(15 - 1).Contains("Bar"));
        }

        [Test]
        public void Generator_GenerateSeries_MultipleMatchingRulesWillAppend()
        {
            var generator = new Generator(new[] { new SimpleMappingRule(1, "Foo"), new SimpleMappingRule(1, "Bar") });
            var series = generator.GenerateSeries(1);

            Assert.AreEqual("FooBar", series.Single());
        }

        [Test]
        public void Generator_NullArgumentToConstructorShouldThrowException()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                var generator = new Generator(null);
            });
        }
    }
}
