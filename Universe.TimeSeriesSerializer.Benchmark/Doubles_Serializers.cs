using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Universe.TimeSeriesSerializer.Benchmark
{
    [RankColumn, MemoryDiagnoser]
    public class Doubles_Serializers
    {
        public enum CollectionFlavour
        {
            Array,
            ROList,
        }
        
        private object[] Data;

        // [Params(20)]
        public int ArraysCount = 20;
        
        // [Params(true, false)]
        public bool Minify = true;

        [Params(CollectionFlavour.Array, CollectionFlavour.ROList)]
        public CollectionFlavour Kind;

        private static readonly DefaultContractResolver TheContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                OverrideSpecifiedNames = false,
                ProcessDictionaryKeys = true,
            }
        };

        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random(42);
            List<object> list = new List<object>();
            for (int i = 0; i < ArraysCount; i++)
            {
                var item = Enumerable.Range(1, 61).Select(x => rand.NextDouble() * 10000);
                if (Kind == CollectionFlavour.Array) list.Add(item.ToArray());
                else if (Kind == CollectionFlavour.ROList) list.Add(item.ToList().ToImmutableList());
                else throw new InvalidOperationException($"Unknown flavour: {Kind}");
            }

            Data = list.ToArray();
        }

        [Benchmark(Description = "double[]:Optimized")]
        public StringBuilder Optimized()
        {
            return Serialize(optionalConverter: DoubleArrayConverter.Create(6));
        }

        [Benchmark(Baseline = true, Description = "double[]:Default")]
        public StringBuilder Default()
        {
            return Serialize();
        }

        private StringBuilder Serialize(JsonConverter optionalConverter = null)
        {
            JsonSerializer ser = new JsonSerializer()
            {
                Formatting = !Minify ? Formatting.Indented : Formatting.None,
            };

            if (optionalConverter != null) ser.Converters.Add(optionalConverter);
            ser.ContractResolver = TheContractResolver;

            StringBuilder json = new StringBuilder();
            StringWriter jwr = new StringWriter(json);
            ser.Serialize(jwr, Data);
            jwr.Flush();

            return json;
        }

    }
}