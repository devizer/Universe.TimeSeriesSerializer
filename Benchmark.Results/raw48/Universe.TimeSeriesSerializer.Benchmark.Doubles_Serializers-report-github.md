``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1339 (1809/October2018Update/Redstone5)
Intel Xeon CPU E3-1270 V2 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-rc.1.20452.10
  [Host] : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  FW 4.8 : .NET Framework 4.8 (4.8.4220.0), X64 RyuJIT

Job=FW 4.8  Runtime=.NET 4.8  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
|           Method |       Kind |       Mean |    Error |   StdDev | Ratio | Rank |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------- |----------- |-----------:|---------:|---------:|------:|-----:|--------:|-------:|------:|----------:|
| **double:optimized** |      **Array** |   **197.7 μs** | **10.33 μs** | **15.46 μs** |  **0.12** |    **1** | **43.4570** |      **-** |     **-** | **179.22 KB** |
|   double:default |      Array | 1,667.8 μs | 39.05 μs | 54.74 μs |  1.00 |    2 | 46.8750 | 1.9531 |     - | 199.08 KB |
|                  |            |            |          |          |       |      |         |        |       |           |
| **double:optimized** |       **List** |   **116.4 μs** |  **2.76 μs** |  **4.13 μs** |  **0.08** |    **1** | **33.4473** |      **-** |     **-** | **137.54 KB** |
|   double:default |       List | 1,460.1 μs | 21.95 μs | 30.77 μs |  1.00 |    2 | 46.8750 |      - |     - | 199.25 KB |
|                  |            |            |          |          |       |      |         |        |       |           |
| **double:optimized** |     **ROList** |   **226.4 μs** |  **5.18 μs** |  **7.75 μs** |  **0.13** |    **1** | **33.6914** | **5.6152** |     **-** | **138.95 KB** |
|   double:default |     ROList | 1,752.7 μs | 45.91 μs | 67.30 μs |  1.00 |    2 | 46.8750 |      - |     - | 199.87 KB |
|                  |            |            |          |          |       |      |         |        |       |           |
| **double:optimized** |    **ROArray** |   **122.6 μs** |  **6.63 μs** |  **9.93 μs** |  **0.08** |    **1** | **33.6914** |      **-** |     **-** | **138.17 KB** |
|   double:default |    ROArray | 1,561.3 μs | 17.50 μs | 26.20 μs |  1.00 |    2 | 46.8750 | 1.9531 |     - | 199.09 KB |
|                  |            |            |          |          |       |      |         |        |       |           |
| **double:optimized** | **Enumerable** |   **141.3 μs** |  **9.00 μs** | **13.47 μs** |  **0.09** |    **1** | **36.1328** |      **-** |     **-** | **148.19 KB** |
|   double:default | Enumerable | 1,515.2 μs | 50.37 μs | 73.83 μs |  1.00 |    2 | 46.8750 |      - |     - | 200.19 KB |
