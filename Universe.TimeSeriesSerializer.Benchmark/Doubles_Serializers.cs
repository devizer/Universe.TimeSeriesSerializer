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
            List,
            ROList,
            ROArray,
            Enumerable,
        }
        
        private object[] Data;

        // [Params(20)]
        public int ArraysCount = 20;
        
        // [Params(true, false)]
        public bool Minify = true;

        [Params(CollectionFlavour.Array, CollectionFlavour.List, CollectionFlavour.ROArray, CollectionFlavour.ROList, CollectionFlavour.Enumerable)]
        public CollectionFlavour Kind;

        private static readonly DefaultContractResolver TheContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                OverrideSpecifiedNames = false,
                ProcessDictionaryKeys = true,
            }
        };

        private JsonSerializerSettings DefaultSettings, OptimizedSettings;

        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random(42);
            List<object> list = new List<object>();
            for (int i = 0; i < ArraysCount; i++)
            {
                var item = Enumerable.Range(1, 61).Select(x => rand.NextDouble() * 10000);
                if (Kind == CollectionFlavour.List) list.Add(item.ToList());
                else if (Kind == CollectionFlavour.Array) list.Add(item.ToArray());
                else if (Kind == CollectionFlavour.ROList) list.Add(item.ToList().ToImmutableList());
                else if (Kind == CollectionFlavour.ROArray) list.Add(item.ToList().ToImmutableArray());
                else if (Kind == CollectionFlavour.Enumerable) list.Add(AsEnumerable(item.ToArray()));
                else throw new InvalidOperationException($"Unknown flavour: {Kind}");
            }

            Data = list.ToArray();
            
            DefaultSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = TheContractResolver,
                Converters = new JsonConverterCollection(),
            };

            var optimizedConverters = new JsonConverterCollection();
            optimizedConverters.Add(DoubleArrayConverter.Create(6));
            OptimizedSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ContractResolver = TheContractResolver,
                Converters = optimizedConverters,
            };

        }

        [Benchmark(Description = "double:optimized")]
        public string Optimized()
        {
            // return Serialize(optionalConverter: DoubleArrayConverter.Create(6));
            return JsonConvert.SerializeObject(Data, OptimizedSettings);
        }

        [Benchmark(Baseline = true, Description = "double:default")]
        public string Default()
        {
            return JsonConvert.SerializeObject(Data, DefaultSettings);
        }

        private StringBuilder Serialize_Wrong_and_Slow(JsonConverter optionalConverter = null)
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
        
        static IEnumerable<double> AsEnumerable(IEnumerable<double> arg)
        {
            foreach (var l in arg)
            {
                yield return l;
            }
        }


    }
}