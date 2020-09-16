using System;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Universe.TimeSeriesSerializer.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<StandardVsCustomSerializer>();
        }
    }
}