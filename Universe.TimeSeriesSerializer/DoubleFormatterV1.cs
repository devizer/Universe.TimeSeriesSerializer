using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Universe.TimeSeriesSerializer
{
    public static class DoubleFormatterV1
    {
        
#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public unsafe static void Optimized_N_Digits(StringBuilder b, double v, int decimals)
        {
            long power10 = Power10.Power10Signed64[decimals];
            
            if (v < 0) {v = -v; b.Append('-');}
            var fv = Math.Floor(v); 
            long i = (long)fv;      
            long f = (long)Math.Floor((v - fv)*power10 + 0.5d);
            OptimizedLongFormatter.HeaplessAppend(b, i);
            if (decimals > 0 && f != 0)
            {
                b.Append('.');
                char* chars = stackalloc char[decimals];
                for (int pos = decimals - 1; pos >= 0; pos--)
                {
                    chars[pos] = (char) (f % 10 + 48);
                    f = f / 10;
                }

                if (false)
                {
                    for (int pos = 0; pos < decimals; pos++) b.Append(chars[pos]);
                }
                else
                {
                    int lastDecimal = decimals - 1;
                    while (lastDecimal > 0 && chars[lastDecimal] == '0') lastDecimal--;
                    for (int pos = 0; pos <= lastDecimal; pos++) b.Append(chars[pos]);
                }
            }
            else
            {
                b.Append(".0");
            }
        }

    }
}