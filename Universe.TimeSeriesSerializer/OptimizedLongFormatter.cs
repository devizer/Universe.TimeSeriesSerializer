using System.Runtime.CompilerServices;
using System.Text;

namespace Universe.TimeSeriesSerializer
{
    public static class OptimizedLongFormatter
    {

#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int GetDigitsCount(long arg)
        {
            if (arg < 0) arg = -arg;
            if (arg < 10) return 1;
            if (arg < 100) return 2;
            if (arg < 1000) return 3;
            if (arg < 10000) return 4;
            if (arg < 100000) return 5;
            if (arg < 1000000) return 6;
            if (arg < 10000000) return 7;
            if (arg < 100000000L) return 8;
            if (arg < 1000000000L) return 9;
            if (arg < 10000000000L) return 10;
            if (arg < 100000000000L) return 11;
            if (arg < 1000000000000L) return 12;
            if (arg < 10000000000000L) return 13;
            if (arg < 100000000000000L) return 14;
            if (arg < 1000000000000000L) return 15;
            if (arg < 10000000000000000L) return 16;
            if (arg < 100000000000000000L) return 17;
            if (arg < 1000000000000000000L) return 18;
            return 19;
        }

#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int GetDigitsCount(ulong arg)
        {
            if (arg >= 10000000000000000000UL) return 20;
            if (arg >= 1000000000000000000UL) return 19;
            if (arg >= 100000000000000000UL) return 18;
            return GetDigitsCount((long) arg);
        }
        
#if ! (NET40 || NET35 || NET30 || NET20)        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif        
        public static void HeaplessAppend(StringBuilder builder, long arg)
        {
            if (arg == 9223372036854775807L)
            {
                builder.Append("9223372036854775807");
                return;
            }

            if (arg == -9223372036854775808L)
            {
                builder.Append("-9223372036854775808");
                return;
            }

            if (arg < 0)
            {
                arg = -arg;
                builder.Append('-');
            }

            if (arg < 10)
            {
                builder.Append((char)(48 + arg));
            }
            else if (arg < 100)
            {
                builder.Append((char)(48 + (arg / 10)));
                builder.Append((char)(48 + (arg % 10)));
            }
            else if (arg < 1000)
            {
                builder.Append((char)(48 + arg / 100));
                builder.Append((char)(48 + (arg / 10) % 10));
                builder.Append((char)(48 + arg % 10));
            }
            else if (arg < 10000)
            {
                var p0 = arg % 10;
                var p1a = arg / 10;
                var p1 = p1a % 10;
                var p2a = p1a / 10;
                var p2 = p2a % 10;
                var p3 = p2a / 10;
                builder.Append((char)(48 + p3));
                builder.Append((char)(48 + p2));
                builder.Append((char)(48 + p1));
                builder.Append((char)(48 + p0));
            }
            else
            {
                
                byte p0 = (byte) (arg % 10);
                arg = arg / 10;
                
                if (arg != 0)
                {
                    byte p1 = (byte) (arg % 10);
                    arg = arg / 10;
                    
                    if (arg != 0)
                    {
                        byte p2 = (byte) (arg % 10);
                        arg = arg / 10;
                        
                        if (arg != 0)
                        {
                            byte p3 = (byte) (arg % 10);
                            arg = arg / 10;
                            
                            if (arg != 0)
                            {
                                byte p4 = (byte) (arg % 10);
                                arg = arg / 10;
                                
                                if (arg != 0)
                                {
                                    byte p5 = (byte) (arg % 10);
                                    arg = arg / 10;
                                    
                                    if (arg != 0)
                                    {
                                        byte p6 = (byte) (arg % 10);
                                        arg = arg / 10;
                                        
                                        if (arg != 0)
                                        {
                                            byte p7 = (byte) (arg % 10);
                                            arg = arg / 10;
                                            
                                            if (arg != 0)
                                            {
                                                byte p8 = (byte) (arg % 10);
                                                arg = arg / 10;
                                                
                                                if (arg != 0)
                                                {
                                                    byte p9 = (byte) (arg % 10);
                                                    arg = arg / 10;
                                                    
                                                    if (arg != 0)
                                                    {
                                                        byte p10 = (byte) (arg % 10);
                                                        arg = arg / 10;
                                                        
                                                        if (arg != 0)
                                                        {
                                                            byte p11 = (byte) (arg % 10);
                                                            arg = arg / 10;
                                                            
                                                            if (arg != 0)
                                                            {
                                                                byte p12 = (byte) (arg % 10);
                                                                arg = arg / 10;
                                                                
                                                                if (arg != 0)
                                                                {
                                                                    byte p13 = (byte) (arg % 10);
                                                                    arg = arg / 10;
                                                                    
                                                                    if (arg != 0)
                                                                    {
                                                                        byte p14 = (byte) (arg % 10);
                                                                        arg = arg / 10;
                                                                        
                                                                        if (arg != 0)
                                                                        {
                                                                            byte p15 = (byte) (arg % 10);
                                                                            arg = arg / 10;
                                                                            
                                                                            if (arg != 0)
                                                                            {
                                                                                byte p16 = (byte) (arg % 10);
                                                                                arg = arg / 10;
                                                                                
                                                                                if (arg != 0)
                                                                                {
                                                                                    byte p17 = (byte) (arg % 10);
                                                                                    arg = arg / 10;
                                                                                    
                                                                                    if (arg != 0)
                                                                                    {
                                                                                        byte p18 = (byte) (arg % 10);
                                                                                        arg = arg / 10;
                                                                                        
                                                                                        if (arg != 0)
                                                                                        {
                                                                                            byte p19 = (byte) (arg % 10);
                                                                                            builder.Append((char) (48 + p19));
                                                                                        }
                                                                                        builder.Append((char) (48 + p18));
                                                                                    }
                                                                                    builder.Append((char) (48 + p17));
                                                                                }
                                                                                builder.Append((char) (48 + p16));
                                                                            }
                                                                            builder.Append((char) (48 + p15));
                                                                        }
                                                                        builder.Append((char) (48 + p14));
                                                                    }
                                                                    builder.Append((char) (48 + p13));
                                                                }                                
                                                                builder.Append((char) (48 + p12));
                                                            }
                                                            builder.Append((char) (48 + p11));
                                                        }
                                                        builder.Append((char) (48 + p10));
                                                    }
                                                    builder.Append((char) (48 + p9));
                                                }
                                                builder.Append((char) (48 + p8));
                                            }
                                            builder.Append((char) (48 + p7));
                                        }
                                        builder.Append((char) (48 + p6));
                                    }
                                    builder.Append((char) (48 + p5));
                                }
                                builder.Append((char) (48 + p4));
                            }
                            builder.Append((char) (48 + p3));
                        }
                        builder.Append((char) (48 + p2));
                    }
                    builder.Append((char) (48 + p1));
                }
                builder.Append((char) (48 + p0));
            }
        }
        
    }
}