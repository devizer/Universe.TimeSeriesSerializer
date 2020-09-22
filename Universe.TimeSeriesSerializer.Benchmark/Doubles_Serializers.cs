using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

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
        
        private IEnumerable<double>[] Data;

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
        JsonSerializerOptions SystemSettings = new JsonSerializerOptions
        {
            WriteIndented = false,
        };


        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random(42);
            List<IEnumerable<double>> list = new List<IEnumerable<double>>();
            for (int i = 0; i < ArraysCount; i++)
            {
                var item = Enumerable.Range(1, 61).Select(x => rand.NextDouble() * 10000);
                if (Kind == CollectionFlavour.List) list.Add(item.ToList());
                else if (Kind == CollectionFlavour.Array) list.Add(item.ToArray());
                else if (Kind == CollectionFlavour.ROList) list.Add(item.ToList().ToImmutableList());
                else if (Kind == CollectionFlavour.ROArray) list.Add(item.ToList().ToImmutableArray());
                else if (Kind == CollectionFlavour.Enumerable) list.Add(AsEnumerable(item.ToArray()));
                else throw new InvalidOperationException($"Unknown flavor: {Kind}");
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

            {
                var json = JsonConvert.SerializeObject(Data, DefaultSettings);
                Console.WriteLine($"// DOUBLES-DATA-LENGTH[json.net]: {json.Length} chars");
            }
            {
                var json = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(Data, SystemSettings);
                Console.WriteLine($"// DOUBLES-DATA-LENGTH[system]: {json.Length} bytes");
            }
            {
                var json = JsonConvert.SerializeObject(Data, OptimizedSettings);
                Console.WriteLine($"// DOUBLES-DATA-LENGTH[optimized]: {json.Length} chars");
            }
        }

        [Benchmark(Baseline = true, Description = "double:json.net")]
        public string Default()
        {
            return JsonConvert.SerializeObject(Data, DefaultSettings);
        }

        [Benchmark(Description = "double:system")]
        public byte[] SystemText()
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(Data, SystemSettings);
        }

        [Benchmark(Description = "double:optimized")]
        public string Optimized()
        {
            // return Serialize(optionalConverter: DoubleArrayConverter.Create(6));
            return JsonConvert.SerializeObject(Data, OptimizedSettings);
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