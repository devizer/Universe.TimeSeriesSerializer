using System;
using System.Collections.Generic;
using System.Reflection;

namespace Universe.TimeSeriesSerializer
{
    internal class ReflectionHelper
    {
        public static bool IsAssignableFrom(Type baseType, Type candidate)
        {
#if NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6
            return baseType.GetTypeInfo().IsAssignableFrom(candidate.GetTypeInfo());
#else
            return baseType.IsAssignableFrom(candidate);
#endif
        }
        
    }
}