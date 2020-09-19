using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Universe.TimeSeriesSerializer
{
    public class DoubleFormatterV2
    {
        private const int MAX_DIGITS_SIGNED = 19;
        private const int MAX_DIGITS_UNSIGNED = 20;

        private static long[] Power10Signed = new[]
        {
            1L, 
            10, 
            100, 
            1000, 
            10000, 
            100000,
            1000000,
            10000000,
            100000000,
            1000000000,
            10000000000,
            100000000000,
            1000000000000,
            10000000000000,
            100000000000000,
            1000000000000000,
            10000000000000000,
            100000000000000000,
            1000000000000000000,
        };
        
        private static ulong[] Power10UnSigned;

        static DoubleFormatterV2()
        {
            Power10Signed = new long[MAX_DIGITS_SIGNED + 1];
            long p = 1;
            for (int i = 0; i <= MAX_DIGITS_SIGNED; i++)
            {
                Power10Signed[i] = p;
                p = p * 10;
            }
            
            Power10UnSigned = new ulong[MAX_DIGITS_UNSIGNED + 1];
            ulong up = 1;
            for (int i = 0; i <= MAX_DIGITS_UNSIGNED; i++)
            {
                Power10UnSigned[i] = up;
                up = up * 10;
            }

        }
        
#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void Optimized_N_Digits(StringBuilder b, double v, int decimals)
        {
            long power10 = Power10Signed[decimals];
            
            if (v < 0) {v = -v; b.Append('-');} // make v >= 0
            var fv = Math.Floor(v); 
            long i = (long)fv;      
            long f = (long)Math.Floor((v - fv)*power10 + 0.5);
            OptimizedLongFormatter.HeaplessAppend(b, i);
            if (decimals > 0 && f != 0)
            {
                b.Append('.');
                for (int d = decimals - OptimizedLongFormatter.GetDigitsCount(f); d > 0; d--)
                    b.Append('0');
                
                OptimizedLongFormatter.HeaplessAppend(b, f);
            }
        }
    }
}