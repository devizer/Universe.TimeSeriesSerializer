using System.Text;
using NUnit.Framework;
using Universe.TimeSeriesSerializer;

namespace Tests
{
    [TestFixture]
    public class OptimizedDoubleFormatter_Tests
    {

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [Test]
        [TestCase(1.111111d, 4, "1.1111")]
        [TestCase(-1.111111d, 4, "-1.1111")]
        [TestCase(1.234567d, 4, "1.2346")]
        [TestCase(-1.234567d, 4, "-1.2346")]
        [TestCase(1.1d, 4, "1.1")]
        [TestCase(-1.1d, 4, "-1.1")]
        [TestCase(1.1000001d, 4, "1.1")]
        [TestCase(-1.1000001d, 4, "-1.1")]
        [TestCase(0.1d, 4, "0.1")]
        [TestCase(-0.1d, 4, "-0.1")]
        [TestCase(0d, 4, "0.0")]
        [TestCase(2d, 4, "2.0")]
        [TestCase(-2d, 4, "-2.0")]
        public void Test_V1(double arg, int digits, string expected)
        {
            StringBuilder builder = new StringBuilder();
            DoubleFormatterV1.Optimized_N_Digits(builder, arg, digits);
            var actual = builder.ToString();
            Assert.AreEqual(expected,actual);
        }

        [Test]
        [TestCase(1.111111d, 4, "1.1111")]
        [TestCase(-1.111111d, 4, "-1.1111")]
        [TestCase(1.234567d, 4, "1.2346")]
        [TestCase(-1.234567d, 4, "-1.2346")]
        [TestCase(1.1d, 4, "1.1")]
        [TestCase(-1.1d, 4, "-1.1")]
        [TestCase(1.1000001d, 4, "1.1")]
        [TestCase(-1.1000001d, 4, "-1.1")]
        [TestCase(0.1d, 4, "0.1000")]
        [TestCase(-0.1d, 4, "-0.1000")]
        [TestCase(0d, 4, "0")]
        [TestCase(2d, 4, "2.0000")]
        [TestCase(-2d, 4, "-2.0000")]

        public void Test_V2(double arg, int digits, string expected)
        {
            StringBuilder builder = new StringBuilder();
            DoubleFormatterV2.Optimized_N_Digits(builder, arg, digits);
            var actual = builder.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1.111111d, 4, "1.1111")]
        [TestCase(-1.111111d, 4, "-1.1111")]
        [TestCase(1.234567d, 4, "1.2346")]
        [TestCase(-1.234567d, 4, "-1.2346")]
        [TestCase(1.1d, 4, "1.1")]
        [TestCase(-1.1d, 4, "-1.1")]
        [TestCase(1.1000001d, 4, "1.1")]
        [TestCase(-1.1000001d, 4, "-1.1")]
        [TestCase(0.1d, 4, "0.1")]
        [TestCase(-0.1d, 4, "-0.1")]
        [TestCase(0d, 4, "0.0")]
        [TestCase(2d, 4, "2.0")]
        [TestCase(-2d, 4, "-2.0")]
        public void Test_V3(double arg, int digits, string expected)
        {
            StringBuilder builder = new StringBuilder();
            DoubleFormatterV3.Optimized_N_Digits(builder, arg, digits);
            var actual = builder.ToString();
            Assert.AreEqual(expected, actual);
        }


    }
}