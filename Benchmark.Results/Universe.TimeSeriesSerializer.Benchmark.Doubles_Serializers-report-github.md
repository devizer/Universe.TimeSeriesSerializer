``` ini

BenchmarkDotNet=v0.12.1, OS=ubuntu 16.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
  [Host]   : Mono 6.12.0.90 (tarball Fri), X64 
  Core 2.1 : .NET Core 2.1.22 (CoreCLR 4.6.29220.03, CoreFX 4.6.29220.01), X64 RyuJIT
  Core 3.1 : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.45114, CoreFX 5.0.20.45114), X64 RyuJIT
  LLVM Off : Mono 6.12.0.90 (tarball Fri), X64 
  LLVM On  : Mono 6.12.0.90 (tarball Fri), X64 

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
|           Method |      Job |       Jit |       Runtime |       Kind |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD | Rank |   Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|----------------- |--------- |---------- |-------------- |----------- |-----------:|----------:|----------:|-----------:|------:|--------:|-----:|--------:|-------:|-------:|----------:|
| **double:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |      **Array** |   **118.7 μs** |   **1.20 μs** |   **1.72 μs** |   **118.4 μs** |  **0.13** |    **0.00** |    **1** | **21.4844** | **3.6621** |      **-** |  **139032 B** |
|   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |      Array |   922.3 μs |   9.06 μs |  13.00 μs |   924.3 μs |  1.00 |    0.00 |    2 | 30.2734 | 5.8594 |      - |  203384 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array |   130.4 μs |   1.60 μs |   2.34 μs |   129.9 μs |  0.16 |    0.00 |    1 |  7.3242 | 1.4648 |      - |  138891 B |
|   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array |   830.9 μs |   3.77 μs |   5.52 μs |   830.7 μs |  1.00 |    0.00 |    2 |  9.7656 | 1.9531 |      - |  194986 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array |   121.5 μs |   1.33 μs |   1.87 μs |   121.6 μs |  0.17 |    0.00 |    1 |  7.3242 | 1.4648 |      - |  138888 B |
|   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array |   721.0 μs |   8.10 μs |  11.88 μs |   720.3 μs |  1.00 |    0.00 |    2 |  9.7656 | 1.9531 |      - |  194985 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | LLVM Off | LegacyJit |          Mono |      Array |   456.8 μs |   3.81 μs |   5.22 μs |   457.7 μs |  0.07 |    0.00 |    1 | 22.9492 | 2.9297 | 2.9297 |         - |
|   double:default | LLVM Off | LegacyJit |          Mono |      Array | 6,584.9 μs |  70.42 μs | 103.22 μs | 6,566.7 μs |  1.00 |    0.00 |    2 | 23.4375 |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized |  LLVM On |      Llvm |          Mono |      Array |   148.0 μs |   5.60 μs |   8.21 μs |   147.2 μs |  0.02 |    0.00 |    1 |       - |      - |      - |         - |
|   double:default |  LLVM On |      Llvm |          Mono |      Array | 6,015.4 μs | 109.40 μs | 160.35 μs | 6,046.2 μs |  1.00 |    0.00 |    2 |       - |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| **double:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |       **List** |   **975.7 μs** |  **13.80 μs** |  **19.79 μs** |   **976.1 μs** |  **1.24** |    **0.03** |    **2** | **30.2734** | **5.8594** |      **-** |  **203672 B** |
|   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |       List |   788.0 μs |   7.25 μs |  10.85 μs |   786.9 μs |  1.00 |    0.00 |    1 | 30.2734 | 4.8828 |      - |  203544 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |       List |   880.4 μs |   7.92 μs |  11.35 μs |   882.6 μs |  1.24 |    0.02 |    2 |  9.7656 | 1.9531 |      - |  195257 B |
|   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |       List |   707.0 μs |   6.74 μs |  10.08 μs |   709.3 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  195136 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |       List |   668.7 μs |   5.97 μs |   8.93 μs |   667.5 μs |  1.09 |    0.02 |    2 |  9.7656 | 1.9531 |      - |  195255 B |
|   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |       List |   614.7 μs |   5.53 μs |   8.28 μs |   615.8 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  195136 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | LLVM Off | LegacyJit |          Mono |       List | 6,653.4 μs |  54.10 μs |  77.59 μs | 6,649.5 μs |  1.05 |    0.02 |    2 | 23.4375 |      - |      - |         - |
|   double:default | LLVM Off | LegacyJit |          Mono |       List | 6,339.0 μs |  51.08 μs |  76.45 μs | 6,341.6 μs |  1.00 |    0.00 |    1 | 23.4375 |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized |  LLVM On |      Llvm |          Mono |       List | 6,147.0 μs | 156.26 μs | 219.05 μs | 6,159.3 μs |  1.07 |    0.06 |    2 |       - |      - |      - |         - |
|   double:default |  LLVM On |      Llvm |          Mono |       List | 5,778.9 μs | 168.28 μs | 246.66 μs | 5,772.0 μs |  1.00 |    0.00 |    1 |       - |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| **double:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |     **ROList** | **1,054.8 μs** |   **9.29 μs** |  **13.61 μs** | **1,057.4 μs** |  **1.25** |    **0.03** |    **2** | **27.3438** | **3.9063** |      **-** |  **204312 B** |
|   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |     ROList |   844.1 μs |  10.02 μs |  14.68 μs |   842.2 μs |  1.00 |    0.00 |    1 | 30.2734 | 5.8594 |      - |  204184 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList |   940.7 μs |  12.03 μs |  17.64 μs |   939.8 μs |  1.22 |    0.02 |    2 |  9.7656 | 1.9531 |      - |  195888 B |
|   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList |   770.4 μs |   5.30 μs |   7.60 μs |   770.3 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  195785 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList |   724.7 μs |   4.07 μs |   6.10 μs |   724.5 μs |  1.04 |    0.01 |    2 |  9.7656 | 1.9531 |      - |  195896 B |
|   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList |   694.2 μs |   4.86 μs |   7.13 μs |   695.7 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  195783 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | LLVM Off | LegacyJit |          Mono |     ROList | 6,821.9 μs |  66.74 μs |  99.90 μs | 6,824.1 μs |  1.07 |    0.02 |    2 | 23.4375 |      - |      - |         - |
|   double:default | LLVM Off | LegacyJit |          Mono |     ROList | 6,370.2 μs |  42.16 μs |  63.10 μs | 6,378.2 μs |  1.00 |    0.00 |    1 | 23.4375 |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized |  LLVM On |      Llvm |          Mono |     ROList | 6,239.6 μs | 157.07 μs | 225.27 μs | 6,230.5 μs |  1.01 |    0.06 |    1 |       - |      - |      - |         - |
|   double:default |  LLVM On |      Llvm |          Mono |     ROList | 6,204.5 μs | 238.83 μs | 326.91 μs | 6,239.7 μs |  1.00 |    0.00 |    1 |       - |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| **double:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |    **ROArray** |   **972.5 μs** |   **8.34 μs** |  **12.23 μs** |   **973.9 μs** |  **1.24** |    **0.03** |    **2** | **27.3438** | **3.9063** |      **-** |  **203512 B** |
|   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |    ROArray |   784.8 μs |   8.57 μs |  12.57 μs |   781.5 μs |  1.00 |    0.00 |    1 | 30.2734 | 5.8594 |      - |  203384 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray |   858.8 μs |   6.19 μs |   9.26 μs |   860.9 μs |  1.23 |    0.03 |    2 |  9.7656 | 1.9531 |      - |  195088 B |
|   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray |   697.0 μs |   8.81 μs |  13.18 μs |   698.4 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  194976 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray |   653.8 μs |   5.55 μs |   8.31 μs |   654.7 μs |  1.07 |    0.02 |    2 |  9.7656 | 1.9531 |      - |  195096 B |
|   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray |   609.3 μs |   4.37 μs |   6.55 μs |   610.4 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  194977 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | LLVM Off | LegacyJit |          Mono |    ROArray | 6,600.7 μs |  88.22 μs | 129.31 μs | 6,652.4 μs |  1.04 |    0.02 |    2 | 23.4375 |      - |      - |         - |
|   double:default | LLVM Off | LegacyJit |          Mono |    ROArray | 6,324.7 μs |  52.23 μs |  78.18 μs | 6,311.6 μs |  1.00 |    0.00 |    1 | 23.4375 |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized |  LLVM On |      Llvm |          Mono |    ROArray | 6,188.7 μs | 140.39 μs | 196.81 μs | 6,183.3 μs |  1.07 |    0.05 |    2 |       - |      - |      - |         - |
|   double:default |  LLVM On |      Llvm |          Mono |    ROArray | 5,788.3 μs | 160.85 μs | 240.75 μs | 5,779.7 μs |  1.00 |    0.00 |    1 |       - |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| **double:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** | **Enumerable** |   **977.3 μs** |   **9.23 μs** |  **13.23 μs** |   **978.6 μs** |  **1.22** |    **0.02** |    **2** | **27.3438** | **5.8594** |      **-** |  **204632 B** |
|   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 | Enumerable |   799.5 μs |   6.47 μs |   9.68 μs |   800.0 μs |  1.00 |    0.00 |    1 | 30.2734 | 5.8594 |      - |  204504 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable |   871.8 μs |   6.05 μs |   9.05 μs |   872.4 μs |  1.24 |    0.02 |    2 |  9.7656 | 1.9531 |      - |  196208 B |
|   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable |   705.2 μs |   5.71 μs |   8.54 μs |   704.3 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  196105 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable |   667.1 μs |   3.88 μs |   5.81 μs |   667.8 μs |  1.08 |    0.02 |    2 |  9.7656 | 1.9531 |      - |  196215 B |
|   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable |   616.0 μs |   4.98 μs |   7.31 μs |   615.9 μs |  1.00 |    0.00 |    1 |  9.7656 | 1.9531 |      - |  196096 B |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized | LLVM Off | LegacyJit |          Mono | Enumerable | 6,816.1 μs |  51.09 μs |  74.88 μs | 6,831.2 μs |  1.04 |    0.05 |    2 | 23.4375 |      - |      - |         - |
|   double:default | LLVM Off | LegacyJit |          Mono | Enumerable | 6,569.9 μs | 168.46 μs | 246.92 μs | 6,720.4 μs |  1.00 |    0.00 |    1 | 23.4375 |      - |      - |         - |
|                  |          |           |               |            |            |           |           |            |       |         |      |         |        |        |           |
| double:optimized |  LLVM On |      Llvm |          Mono | Enumerable | 6,166.2 μs | 127.92 μs | 191.46 μs | 6,232.8 μs |  1.07 |    0.05 |    2 |       - |      - |      - |         - |
|   double:default |  LLVM On |      Llvm |          Mono | Enumerable | 5,784.6 μs | 154.04 μs | 225.79 μs | 5,781.3 μs |  1.00 |    0.00 |    1 |       - |      - |      - |         - |