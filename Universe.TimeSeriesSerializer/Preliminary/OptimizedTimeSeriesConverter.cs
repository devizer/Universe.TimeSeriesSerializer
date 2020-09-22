// https://github.com/dotnet/runtime/issues/1784
#if HAS_SYSTEM_TEXT_JSON    

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{

    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            DateTimeOffset.ParseExact(reader.GetString(),
                "MM/dd/yyyy", CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTimeOffset dateTimeValue,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(dateTimeValue.ToString(
                "MM/dd/yyyy", CultureInfo.InvariantCulture));
    }

    public class OptimizedTimeSeriesConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert == typeof(IEnumerable<long>))
            {
                return true;
            }

            return false;
        }
        
        public override JsonConverter CreateConverter(
            Type type,
            JsonSerializerOptions options)
        {

            return new OptimizedTimeSeriesConverterLong(options);
        }

        private class OptimizedTimeSeriesConverterLong : JsonConverter<IEnumerable<long>>
        {
            private readonly static JsonConverter<IEnumerable<long>> PrevConverter;

            static OptimizedTimeSeriesConverterLong()
            {
                PrevConverter = null;
            }

            internal OptimizedTimeSeriesConverterLong(JsonSerializerOptions options)
            {
                
            }

            public override IEnumerable<long> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override void Write(Utf8JsonWriter writer, IEnumerable<long> value, JsonSerializerOptions options)
            {
                if (value == null)
                    writer.WriteNullValue();
                else
                {
                    writer.WriteStartArray();
                    foreach (var item in value)
                    {
                        writer.WriteNumberValue(item);
                    }
                    
                    writer.WriteEndArray();
                }
            }
        }
    }


}
#endif
