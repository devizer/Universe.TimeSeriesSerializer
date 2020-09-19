using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Universe.TimeSeriesSerializer
{
    // Doesn't trim useless zeros at the end
    public class DoubleFormatterV2
    {

#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void Optimized_N_Digits(StringBuilder b, double v, int decimals)
        {
            long power10 = Power10.Power10Signed64[decimals];
            
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
            else
            {
                b.Append(".0");
            }

        }
    }
}