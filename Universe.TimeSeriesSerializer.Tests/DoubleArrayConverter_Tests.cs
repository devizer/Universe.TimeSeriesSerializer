using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Universe.TimeSeriesSerializer.Tests
{
    // TODO: Different Double Formatters
    [TestFixture]
    public class DoubleArrayConverter_Tests
    {
        static Random Rand = new Random(42);
        static double[] GetRandomArgs(int length) => Enumerable.Range(1, length).Select(x => Rand.NextDouble() * 10000).ToArray();

        private JsonSerializerSettings DefaultSettings, OptimizedSettings;

        [Test]
        public void Test_Null()
        {
            ActAndAssert(null, 1e-6d, "Null Array");
        }

        [Test]
        public void Test_Empty()
        {
            ActAndAssert(new double[0], 1e-6d, "Empty Array");
        }

        [Test]
        [TestCase(1d)]
        [TestCase(-1d)]
        [TestCase(1.1111111111d)]
        [TestCase(-1.1111111111d)]
        [TestCase(1.23456789d)]
        [TestCase(-1.23456789d)]
        public void Test_Single(double arg)
        {
            ActAndAssert(new[] { arg}, 1e-6d, "Empty Array");
        }
        
        [Test]
        [TestCase(1.12345e23d, 1E1d)]
        [TestCase(-1.12345e23d, 1E1d)]
        [TestCase(double.NaN, 1E1d)]
        [TestCase(double.PositiveInfinity, 1E1d)]
        [TestCase(double.NegativeInfinity, 1E1d)]
        [TestCase(double.MaxValue, 1E1d)]
        [TestCase(double.MinValue, 1E1d)]
        public void Test_TheLarge(double arg, double precision)
        {
            var json = ActAndAssert(new[] {arg}, precision, $"Large decimal {arg}");
            Console.WriteLine($"JSON for [{arg}] is '{json}'");
        }


        [Test]
        public void Test()
        {
            ActAndAssert(GetRandomArgs(61), 1e-6d, "Null Array");
        }


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false,
                    ProcessDictionaryKeys = true,
                }
            };

            DefaultSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = contractResolver,
                Converters = new JsonConverterCollection(),
            };

            var optimizedConverters = new JsonConverterCollection();
            optimizedConverters.Add(DoubleArrayConverter.Create(6));
            OptimizedSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = contractResolver,
                Converters = optimizedConverters,
            };
        }


        string ActAndAssert(IEnumerable<double> src, double precision, string testDescription)
        {
            string originalJson = JsonConvert.SerializeObject(src, DefaultSettings);
            string optimizedJson = JsonConvert.SerializeObject(src, OptimizedSettings);

            if (src == null)
            {
                Assert.AreEqual(originalJson, optimizedJson, $"Null argument for {testDescription}");
                return optimizedJson;
            }

            double[] expected = JsonConvert.DeserializeObject<double[]>(originalJson);
            double[] actual = JsonConvert.DeserializeObject<double[]>(optimizedJson);

            Assert.AreEqual(expected.Length, actual.Length, $"Deserialized length for {testDescription}");

            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], precision, $"Deserialized item[{i}] for {testDescription}");
            }

            return optimizedJson;
        }
    }

}