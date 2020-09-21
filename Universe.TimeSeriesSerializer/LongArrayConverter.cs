using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Universe.TimeSeriesSerializer
{
    public class LongArrayConverter : JsonConverter
    {
        private static readonly Type
            ArrayType = typeof(long[]),
            EnumerableType = typeof(IEnumerable<long>),
            NullableArrayType = typeof(long?[]),
            NullableEnumerableType = typeof(IEnumerable<long?>);

        public static readonly LongArrayConverter Instance = new LongArrayConverter();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                StringBuilder stringBuilder;
                if (value is long[] arr)
                {
                    int len = arr.Length;
                    stringBuilder = new StringBuilder(len << 1);
                    // for (int pos = 0; pos < len; pos++)
                    for (int pos = 0; pos < arr.Length; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, arr[pos]);
                    }
                }
                else if (value is long?[] arrNullable)
                {
                    int len = arrNullable.Length;
                    stringBuilder = new StringBuilder(len << 1);
                    // for (int pos = 0; pos < len; pos++)
                    for (int pos = 0; pos < arrNullable.Length; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, arrNullable[pos]);
                    }
                }
                else if (value is List<long> list)
                {
                    int len = list.Count;
                    stringBuilder = new StringBuilder(len << 1);
                    for(int pos=0; pos < len; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, list[pos]);
                    }
                }
                else if (value is List<long?> listNullable)
                {
                    int len = listNullable.Count;
                    stringBuilder = new StringBuilder(len << 1);
                    for(int pos=0; pos < len; pos++)
                    {
                        if (pos != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, listNullable[pos]);
                    }
                }
                else if (value is ICollection<long> collection)
                {
                    int len = collection.Count;
                    stringBuilder = new StringBuilder(len << 1);
                    int pos = 0;
                    foreach (long item in collection)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, item);
                    }
                }
                else if (value is ICollection<long?> collectionNullable)
                {
                    int len = collectionNullable.Count;
                    stringBuilder = new StringBuilder(len << 1);
                    int pos = 0;
                    foreach (long? item in collectionNullable)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, item);
                    }
                }
                else if (value is IEnumerable<long> enumerable)
                {
                    stringBuilder = new StringBuilder();
                    int pos = 0;
                    foreach (long item in enumerable)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, item);
                    }
                }
                else if (value is IEnumerable<long?> enumerableNullable)
                {
                    stringBuilder = new StringBuilder();
                    int pos = 0;
                    foreach (long item in enumerableNullable)
                    {
                        if (pos++ != 0) stringBuilder.Append(',');
                        OptimizedLongFormatter.HeaplessAppend(stringBuilder, item);
                    }
                }
                else
                {
                    throw new InvalidOperationException("LongArrayConverter.CanConvert does not work properly. Report it.");
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

        // Route to the default implementation
        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == ArrayType 
                   || objectType == NullableArrayType
                   || ReflectionHelper.IsAssignableFrom(EnumerableType, objectType)
                   || ReflectionHelper.IsAssignableFrom(NullableEnumerableType, objectType);
        }
    }

}
