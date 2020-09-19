namespace Universe.TimeSeriesSerializer
{
    internal class Power10
    {
        internal const int MAX_DIGITS_SIGNED64 = 19;
        internal const int MAX_DIGITS_UNSIGNED64 = 20;

        internal static long[] Power10Signed64 = new[]
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

        public static ulong[] Power10UnSigned64;

        static Power10()
        {
            Power10Signed64 = new long[MAX_DIGITS_SIGNED64 + 1];
            long p = 1;
            for (int i = 0; i <= MAX_DIGITS_SIGNED64; i++)
            {
                Power10Signed64[i] = p;
                p = p * 10;
            }

            Power10UnSigned64 = new ulong[MAX_DIGITS_UNSIGNED64 + 1];
            ulong up = 1;
            for (int i = 0; i <= MAX_DIGITS_UNSIGNED64; i++)
            {
                Power10UnSigned64[i] = up;
                up = up * 10;
            }

        }
    }
}