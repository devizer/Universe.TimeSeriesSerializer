using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Universe.TimeSeriesSerializer
{
    public enum DoubleArrayConverterVersion : byte { V1 = 0, V2, V3, Default = 42 }
    
    public class DoubleArrayConverter : JsonConverter
    {
        private static readonly Type
            ArrayType = typeof(double[]),
            EnumerableType = typeof(IEnumerable<double>),
            NullableArrayType = typeof(double?[]),
            NullableEnumerableType = typeof(IEnumerable<double?>);
        
        // default: 6 digits
        public int Digits { get; }
        public DoubleArrayConverterVersion Version { get; } = DoubleArrayConverterVersion.V1;

        public DoubleArrayConverter() : this(6)
        {
        }

        // protected for caching
        protected DoubleArrayConverter(int digits)
        {
            if (digits < 0 || digits > 20) throw new ArgumentOutOfRangeException(nameof(digits));
            Digits = digits;
        }


        public static DoubleArrayConverter Create(int digits)
        {
            return new DoubleArrayConverter(digits); 
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
                    stringBuilder = new StringBuilder(len << 3);
                    // for (int pos = 0; pos < len; pos++)
                    for (int pos = 0; pos < arr.Length; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, arr[pos], digits, ver);
                    }
                }
                if (value is double?[] arrNullable)
                {
                    int len = arrNullable.Length;
                    stringBuilder = new StringBuilder(len << 3);
                    // for (int pos = 0; pos < len; pos++)
                    for (int pos = 0; pos < arrNullable.Length; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, arrNullable[pos], digits, ver);
                    }
                }
                else if (value is List<double> list)
                {
                    int len = list.Count;
                    stringBuilder = new StringBuilder(len << 3);
                    for(int pos=0; pos < len; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, list[pos], digits, ver);
                    }
                }
                else if (value is List<double?> listNullable)
                {
                    int len = listNullable.Count;
                    stringBuilder = new StringBuilder(len << 3);
                    for(int pos=0; pos < len; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, listNullable[pos], digits, ver);
                    }
                }
                else if (value is ICollection<double> collection)
                {
                    int len = collection.Count;
                    stringBuilder = new StringBuilder(len << 3);
                    int pos = 0;
                    foreach (double item in collection)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, item, digits, ver);
                    }
                }
                else if (value is ICollection<double?> collectionNullable)
                {
                    int len = collectionNullable.Count;
                    stringBuilder = new StringBuilder(len << 3);
                    int pos = 0;
                    foreach (double? item in collectionNullable)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, item, digits, ver);
                    }
                }
                else if (value is IEnumerable<double> enumerable)
                {
                    stringBuilder = new StringBuilder();
                    int pos = 0;
                    foreach (double item in enumerable)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, item, digits, ver);
                    }
                }
                else if (value is IEnumerable<double?> enumerableNullable)
                {
                    stringBuilder = new StringBuilder();
                    int pos = 0;
                    foreach (double? item in enumerableNullable)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedDoubleConverter.ConvertToJson(stringBuilder, item, digits, ver);
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
            return objectType == ArrayType 
                   || objectType == NullableArrayType
                   || ReflectionHelper.IsAssignableFrom(EnumerableType, objectType)
                   || ReflectionHelper.IsAssignableFrom(NullableEnumerableType, objectType);
        }
        
    }
}