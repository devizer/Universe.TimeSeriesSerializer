using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Universe.TimeSeriesSerializer
{
    public enum DoubleArrayConverterVersion { V1, V2, V3}
    public class DoubleArrayConverter : JsonConverter
    {
        private static readonly Type ArrayType = typeof(double[]);
        private static readonly Type EnumerableType = typeof(IEnumerable<double>);
        
        // default: 6 digits
        public int Digits { get; }
        public DoubleArrayConverterVersion Version { get; } = DoubleArrayConverterVersion.V1;

        public DoubleArrayConverter() : this(6)
        {
        }

        // for caching
        protected DoubleArrayConverter(int digits)
        {
            Digits = digits;
        }


        public static DoubleArrayConverter Create(int digits)
        {
            return new DoubleArrayConverter(6); 
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var ver = Version;
                var digits = Digits;
                StringBuilder stringBuilder;
                if (value is double[] arr)
                {
                    int len = arr.Length;
                    stringBuilder = new StringBuilder(len << 1);
                    for (int pos = 0; pos < len; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        if (true || ver == DoubleArrayConverterVersion.V1)
                            DoubleFormatterV1.Optimized_N_Digits(stringBuilder, arr[pos], digits);
                    }
                }
                else if (value is IEnumerable<long> enumerable)
                {
                    stringBuilder = new StringBuilder();
                    int pos = 0;
                    foreach (double item in enumerable)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        if (true || ver == DoubleArrayConverterVersion.V1)
                            DoubleFormatterV1.Optimized_N_Digits(stringBuilder, item, digits);
                    }
                }
                else
                {
                    throw new InvalidOperationException("DoubleArrayConverter.CanConvert does not work properly. Report it.");
                }
                

                writer.WriteStartArray();
                writer.WriteRaw(stringBuilder.ToString());
                writer.WriteEndArray();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanRead
        {
            // Route to the default implementation
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == ArrayType || ReflectionHelper.IsAssignableFrom(EnumerableType, objectType);
        }
        
    }
}