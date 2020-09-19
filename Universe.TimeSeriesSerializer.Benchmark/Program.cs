using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Universe.TimeSeriesSerializer.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = Job.MediumRun;
            Job jobCore21 = run.With(Jit.RyuJit).With(CoreRuntime.Core21).WithId($"Core 2.1");
            Job jobCore31 = run.With(Jit.RyuJit).With(CoreRuntime.Core31).WithId($"Core 3.1");
            Job jobCore50 = run.With(Jit.RyuJit).With(CoreRuntime.Core50).WithId($"Core 5.0");
            
            IConfig config = ManualConfig.Create(DefaultConfig.Instance);
            config = config.With(new[] {jobCore21, jobCore31, jobCore50});
            
            MonoRuntime monoRuntime = MonoRuntime.Default;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                config = config.With(run.With(ClrRuntime.Net48).WithId("FW 4.8"));
            }
            else
            {
                config = config.With(new[] {run.With(Jit.Llvm).With(monoRuntime).WithId("LLVM On")});
                config = config.With(new[] {run.With(monoRuntime).WithId("LLVM Off")});
            }
            
            config = config.With(JsonExporter.Custom(fileNameSuffix: "-full", indentJson: true, excludeMeasurements: false));
            config = config.With(JsonExporter.Custom(fileNameSuffix: "-brief", indentJson: true, excludeMeasurements: true));
            config = config.With(MarkdownExporter.Default);
            config = config.With(HtmlExporter.Default);
            config = config.With(CsvExporter.Default);

            var summary = BenchmarkRunner.Run(typeof(Program).Assembly, config);
        }
    }
}