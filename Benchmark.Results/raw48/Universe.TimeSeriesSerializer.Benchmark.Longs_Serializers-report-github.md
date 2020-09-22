``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1339 (1809/October2018Update/Redstone5)
Intel Xeon CPU E3-1270 V2 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-rc.1.20452.10
  [Host] : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  FW 4.8 : .NET Framework 4.8 (4.8.4220.0), X64 RyuJIT

Job=FW 4.8  Runtime=.NET 4.8  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
|         Method |       Kind |      Mean |    Error |   StdDev | Ratio | RatioSD | Rank |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |----------- |----------:|---------:|---------:|------:|--------:|-----:|--------:|------:|------:|----------:|
| **long:optimized** |      **Array** |  **38.85 μs** | **2.091 μs** | **3.130 μs** |  **0.15** |    **0.01** |    **1** | **12.7563** |     **-** |     **-** |  **52.32 KB** |
|   long:default |      Array | 264.42 μs | 6.258 μs | 9.367 μs |  1.00 |    0.00 |    2 | 14.6484 |     - |     - |  61.92 KB |
|                |            |           |          |          |       |         |      |         |       |       |           |
| **long:optimized** |       **List** |  **43.76 μs** | **2.384 μs** | **3.569 μs** |  **0.26** |    **0.02** |    **1** | **12.7563** |     **-** |     **-** |  **52.32 KB** |
|   long:default |       List | 169.39 μs | 2.311 μs | 3.240 μs |  1.00 |    0.00 |    2 | 15.1367 |     - |     - |  62.08 KB |
|                |            |           |          |          |       |         |      |         |       |       |           |
| **long:optimized** |     **ROList** | **147.38 μs** | **4.673 μs** | **6.994 μs** |  **0.54** |    **0.02** |    **1** | **12.9395** |     **-** |     **-** |  **53.74 KB** |
|   long:default |     ROList | 274.35 μs | 6.239 μs | 9.338 μs |  1.00 |    0.00 |    2 | 15.1367 |     - |     - |  62.71 KB |
|                |            |           |          |          |       |         |      |         |       |       |           |
| **long:optimized** |    **ROArray** |  **51.81 μs** | **1.444 μs** | **2.117 μs** |  **0.31** |    **0.02** |    **1** | **12.8784** |     **-** |     **-** |  **52.95 KB** |
|   long:default |    ROArray | 169.04 μs | 3.683 μs | 5.399 μs |  1.00 |    0.00 |    2 | 14.8926 |     - |     - |  61.92 KB |
|                |            |           |          |          |       |         |      |         |       |       |           |
| **long:optimized** | **Enumerable** |  **66.52 μs** | **0.714 μs** | **1.069 μs** |  **0.39** |    **0.01** |    **1** | **13.8550** |     **-** |     **-** |  **57.02 KB** |
|   long:default | Enumerable | 172.09 μs | 2.446 μs | 3.348 μs |  1.00 |    0.00 |    2 | 15.3809 |     - |     - |  63.02 KB |
