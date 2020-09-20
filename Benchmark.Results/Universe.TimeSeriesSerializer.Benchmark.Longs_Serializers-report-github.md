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
|         Method |      Job |       Jit |       Runtime |       Kind |      Mean |     Error |    StdDev | Ratio | RatioSD | Rank |   Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|--------------- |--------- |---------- |-------------- |----------- |----------:|----------:|----------:|------:|--------:|-----:|--------:|-------:|-------:|----------:|
| **long:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |      **Array** |  **39.32 μs** |  **0.328 μs** |  **0.470 μs** |  **0.11** |    **0.00** |    **1** |  **8.3008** | **0.5493** |      **-** |   **53392 B** |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |      Array | 342.23 μs |  2.421 μs |  3.393 μs |  1.00 |    0.00 |    2 |  8.7891 | 0.4883 |      - |   63192 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array |  41.67 μs |  0.426 μs |  0.638 μs |  0.12 |    0.00 |    1 |  2.8076 | 0.2441 |      - |   53192 B |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array | 341.83 μs |  2.876 μs |  4.305 μs |  1.00 |    0.00 |    2 |  2.9297 |      - |      - |   63173 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array |  43.00 μs |  0.583 μs |  0.872 μs |  0.14 |    0.00 |    1 |  2.8076 | 0.2441 |      - |   53193 B |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array | 304.34 μs |  3.855 μs |  5.770 μs |  1.00 |    0.00 |    2 |  2.9297 |      - |      - |   63173 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | LLVM Off | LegacyJit |          Mono |      Array | 121.38 μs |  1.016 μs |  1.520 μs |  0.23 |    0.00 |    1 |  9.8877 | 1.0986 | 1.0986 |         - |
|   long:default | LLVM Off | LegacyJit |          Mono |      Array | 524.33 μs |  4.645 μs |  6.952 μs |  1.00 |    0.00 |    2 | 10.7422 | 0.9766 | 0.9766 |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized |  LLVM On |      Llvm |          Mono |      Array |  62.00 μs |  1.580 μs |  2.163 μs |  0.14 |    0.01 |    1 |       - |      - |      - |         - |
|   long:default |  LLVM On |      Llvm |          Mono |      Array | 436.47 μs | 15.884 μs | 23.775 μs |  1.00 |    0.00 |    2 |       - |      - |      - |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| **long:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |       **List** |  **43.43 μs** |  **0.501 μs** |  **0.735 μs** |  **0.23** |    **0.01** |    **1** |  **8.3008** | **0.5493** |      **-** |   **53392 B** |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |       List | 189.74 μs |  2.592 μs |  3.879 μs |  1.00 |    0.00 |    2 |  9.5215 | 0.7324 |      - |   63352 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |       List |  46.28 μs |  0.554 μs |  0.795 μs |  0.24 |    0.00 |    1 |  2.8076 | 0.1831 |      - |   53193 B |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |       List | 191.71 μs |  1.673 μs |  2.505 μs |  1.00 |    0.00 |    2 |  3.1738 | 0.2441 |      - |   63328 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |       List |  43.25 μs |  0.690 μs |  1.032 μs |  0.26 |    0.01 |    1 |  2.8076 | 0.2441 |      - |   53193 B |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |       List | 168.96 μs |  2.089 μs |  3.063 μs |  1.00 |    0.00 |    2 |  3.1738 | 0.2441 |      - |   63330 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | LLVM Off | LegacyJit |          Mono |       List | 128.89 μs |  1.060 μs |  1.586 μs |  0.44 |    0.01 |    1 |  9.7656 | 0.9766 | 0.9766 |         - |
|   long:default | LLVM Off | LegacyJit |          Mono |       List | 292.95 μs |  2.074 μs |  2.974 μs |  1.00 |    0.00 |    2 | 10.7422 | 0.9766 | 0.9766 |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized |  LLVM On |      Llvm |          Mono |       List |  70.08 μs |  2.873 μs |  3.932 μs |  0.36 |    0.03 |    1 |       - |      - |      - |         - |
|   long:default |  LLVM On |      Llvm |          Mono |       List | 196.24 μs |  7.566 μs | 11.089 μs |  1.00 |    0.00 |    2 |       - |      - |      - |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| **long:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |     **ROList** | **117.91 μs** |  **0.874 μs** |  **1.196 μs** |  **0.44** |    **0.01** |    **1** |  **8.4229** | **0.6104** |      **-** |   **54832 B** |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |     ROList | 266.58 μs |  2.761 μs |  4.133 μs |  1.00 |    0.00 |    2 |  8.7891 | 0.4883 |      - |   63992 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList | 125.64 μs |  1.221 μs |  1.828 μs |  0.47 |    0.01 |    1 |  2.6855 | 0.2441 |      - |   54632 B |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList | 266.80 μs |  2.128 μs |  3.185 μs |  1.00 |    0.00 |    2 |  3.4180 |      - |      - |   63970 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList | 117.82 μs |  1.199 μs |  1.794 μs |  0.48 |    0.01 |    1 |  2.8076 | 0.2441 |      - |   54632 B |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList | 243.43 μs |  1.875 μs |  2.806 μs |  1.00 |    0.00 |    2 |  3.4180 |      - |      - |   63968 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | LLVM Off | LegacyJit |          Mono |     ROList | 215.41 μs |  1.478 μs |  2.166 μs |  0.54 |    0.01 |    1 |  9.7656 | 0.9766 | 0.9766 |         - |
|   long:default | LLVM Off | LegacyJit |          Mono |     ROList | 402.12 μs |  3.068 μs |  4.592 μs |  1.00 |    0.00 |    2 | 10.7422 | 0.9766 | 0.9766 |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized |  LLVM On |      Llvm |          Mono |     ROList | 139.41 μs |  5.667 μs |  8.306 μs |  0.51 |    0.04 |    1 |       - |      - |      - |         - |
|   long:default |  LLVM On |      Llvm |          Mono |     ROList | 272.05 μs |  9.685 μs | 12.593 μs |  1.00 |    0.00 |    2 |       - |      - |      - |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| **long:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** |    **ROArray** |  **55.82 μs** |  **0.609 μs** |  **0.912 μs** |  **0.30** |    **0.01** |    **1** |  **8.4229** | **0.6714** |      **-** |   **54032 B** |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |    ROArray | 184.68 μs |  1.500 μs |  2.245 μs |  1.00 |    0.00 |    2 |  9.5215 | 0.7324 |      - |   63192 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray |  55.56 μs |  0.850 μs |  1.272 μs |  0.30 |    0.01 |    1 |  2.8687 | 0.2441 |      - |   53833 B |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray | 187.42 μs |  1.537 μs |  2.301 μs |  1.00 |    0.00 |    2 |  3.1738 | 0.2441 |      - |   63171 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray |  55.42 μs |  0.798 μs |  1.194 μs |  0.33 |    0.01 |    1 |  2.8687 | 0.2441 |      - |   53832 B |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray | 167.98 μs |  2.118 μs |  3.169 μs |  1.00 |    0.00 |    2 |  3.1738 | 0.2441 |      - |   63170 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | LLVM Off | LegacyJit |          Mono |    ROArray | 135.17 μs |  1.377 μs |  2.060 μs |  0.45 |    0.01 |    1 |  9.7656 | 0.9766 | 0.9766 |         - |
|   long:default | LLVM Off | LegacyJit |          Mono |    ROArray | 300.11 μs |  2.703 μs |  4.045 μs |  1.00 |    0.00 |    2 | 10.7422 | 0.9766 | 0.9766 |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized |  LLVM On |      Llvm |          Mono |    ROArray |  81.03 μs |  1.812 μs |  2.481 μs |  0.42 |    0.03 |    1 |       - |      - |      - |         - |
|   long:default |  LLVM On |      Llvm |          Mono |    ROArray | 193.86 μs |  5.970 μs |  8.369 μs |  1.00 |    0.00 |    2 |       - |      - |      - |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| **long:optimized** | **Core 2.1** |    **RyuJit** | **.NET Core 2.1** | **Enumerable** |  **69.92 μs** |  **0.895 μs** |  **1.339 μs** |  **0.36** |    **0.01** |    **1** |  **8.9111** | **0.7324** |      **-** |   **58192 B** |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 | Enumerable | 192.10 μs |  1.169 μs |  1.750 μs |  1.00 |    0.00 |    2 |  9.5215 | 0.7324 |      - |   64312 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable |  75.27 μs |  0.821 μs |  1.230 μs |  0.37 |    0.01 |    1 |  3.0518 | 0.2441 |      - |   57992 B |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable | 200.93 μs |  1.545 μs |  2.264 μs |  1.00 |    0.00 |    2 |  3.4180 | 0.2441 |      - |   64288 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable |  68.11 μs |  0.661 μs |  0.990 μs |  0.39 |    0.01 |    1 |  3.0518 | 0.2441 |      - |   57992 B |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable | 176.53 μs |  1.854 μs |  2.776 μs |  1.00 |    0.00 |    2 |  3.4180 | 0.2441 |      - |   64290 B |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized | LLVM Off | LegacyJit |          Mono | Enumerable | 157.95 μs |  1.298 μs |  1.943 μs |  0.49 |    0.01 |    1 | 10.7422 | 0.9766 | 0.9766 |         - |
|   long:default | LLVM Off | LegacyJit |          Mono | Enumerable | 323.28 μs |  2.859 μs |  4.279 μs |  1.00 |    0.00 |    2 | 11.7188 | 0.9766 | 0.9766 |         - |
|                |          |           |               |            |           |           |           |       |         |      |         |        |        |           |
| long:optimized |  LLVM On |      Llvm |          Mono | Enumerable |  96.01 μs |  3.331 μs |  4.447 μs |  0.46 |    0.03 |    1 |       - |      - |      - |         - |
|   long:default |  LLVM On |      Llvm |          Mono | Enumerable | 211.24 μs |  7.458 μs | 10.455 μs |  1.00 |    0.00 |    2 |       - |      - |      - |         - |
