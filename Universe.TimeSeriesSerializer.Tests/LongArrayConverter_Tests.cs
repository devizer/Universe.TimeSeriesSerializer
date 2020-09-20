using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Universe.TimeSeriesSerializer.Tests
{
    [TestFixture]
    public class LongArrayConverter_Tests
    {

        static List<long> BuildTestArguments()
        {
            List<long> cases = new List<long>() { 0, long.MinValue, long.MinValue + 1, long.MaxValue, long.MaxValue - 1, };
            decimal cur = 1m;
            while (cur <= (decimal)long.MaxValue)
            {
                var next = (long)cur;
                if (next != cases.Last())
                {
                    cases.Add(-next + (next % 10));
                    cases.Add(-next + 1);
                    cases.Add(-next);
                    cases.Add(next - (next % 10));
                    cases.Add(next - 1);
                    cases.Add(next);
                }
                cur *= 1.01m;
            }

            return cases;
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [Test]
        public void Test_Null_Object()
        {
            ActAndAssert(null, "Null object");
        }

        public class TypedCollection
        {
            public long[] Content = null;
        }

        [Test]
        public void Test_Null_Array_Property()
        {
            ActAndAssert(new TypedCollection(), "Null property");
        }

        [Test]
        public void Test_Full_Set_of_Longs()
        {
            var fullSet = BuildTestArguments().ToArray();
            FiveActsAndAsserts(fullSet, $"Full set of longs, {fullSet.Length} total");
        }

        [Test]
        public void Test_Zero_Length_Collection()
        {
            FiveActsAndAsserts(new long[0], $"Zero length collection (empty)");
        }

        [Test]
        public void Test_Full_Set_With_Different_Lengths()
        {
            List<long> cases = BuildTestArguments();

            for (int len = 1; len <= 2; len++)
            {
                foreach (long testCase in cases)
                {
                    long[] src = Enumerable.Range(1, len).Select(x => testCase).ToArray();
                    FiveActsAndAsserts(src.ToArray(), $"{testCase} * {len} times");
                }
            }
        }

        static void FiveActsAndAsserts(long[] src, string arrayDescription)
        {
            ActAndAssert(src, $"Array: {arrayDescription}");
            ActAndAssert(src.ToList(), $"List: {arrayDescription}");
            ActAndAssert(src.ToList().ToImmutableArray(), $"ImmutableArray: {arrayDescription}");
            ActAndAssert(src.ToList().ToImmutableList(), $"ImmutableArray: {arrayDescription}");
            ActAndAssert(AsEnumerable(src), $"Enumerable: {arrayDescription}");
        }

        static void ActAndAssert(object src, string testDescription)
        {
            string original = Serialize(src, null);
            string optimized = Serialize(src, LongArrayConverter.Instance);
            Assert.AreEqual(original, optimized, testDescription);
        }


        private static string Serialize(object data, JsonConverter optionalConverter = null)
        {
            JsonSerializer ser = new JsonSerializer()
            {
                Formatting = Formatting.None,
            };

            if (optionalConverter != null)
                ser.Converters.Add(optionalConverter);

            StringBuilder json = new StringBuilder();
            StringWriter jwr = new StringWriter(json);
            ser.Serialize(jwr, data);
            jwr.Flush();

            return json.ToString();
        }

        static IEnumerable<long> AsEnumerable(IEnumerable<long> arg)
        {
            foreach (var l in arg)
            {
                yield return l;
            }
        }
    }
}