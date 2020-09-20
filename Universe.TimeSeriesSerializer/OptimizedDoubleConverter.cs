using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Universe.TimeSeriesSerializer
{
    class OptimizedDoubleConverter
    {
#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif        
        public static void ConvertToJson(StringBuilder b, double arg, int decimals, DoubleArrayConverterVersion ver)
        {
            if (ver == DoubleArrayConverterVersion.Default || !(arg < 9223372036854775807d && arg > -9223372036854775808d))
                b.Append(DefaultJsonImplementation(arg));
            else if (ver == DoubleArrayConverterVersion.V1)
                DoubleFormatterV1.Optimized_N_Digits(b, arg, decimals);
            else if (ver == DoubleArrayConverterVersion.V2)
                DoubleFormatterV2.Optimized_N_Digits(b, arg, decimals);
            else if (ver == DoubleArrayConverterVersion.V3)
                DoubleFormatterV3.Optimized_N_Digits(b, arg, decimals);
        }
        
#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif        
        public static void ConvertToJson(StringBuilder b, double? argNullable, int decimals, DoubleArrayConverterVersion ver)
        {
            if (argNullable == null)
                b.Append("null");
            else
                ConvertToJson(b, argNullable.Value, decimals, ver);
        }
        
#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif        
        public static string DefaultJsonImplementation(double arg)
        {
            var text = arg.ToString("R", CultureInfo.InvariantCulture);
            if (double.IsNaN(arg) || double.IsInfinity(arg) || text.IndexOf('.') != -1 || text.IndexOf('E') != -1 || text.IndexOf('e') != -1)
            {
                return text;
            }

            return text + ".0";
        }

    }
}