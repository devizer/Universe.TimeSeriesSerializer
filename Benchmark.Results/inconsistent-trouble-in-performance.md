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
|         Method |      Job |       Jit |       Runtime |       Kind |      Mean |     Error |           Method |      Job |       Jit |       Runtime |       Kind |       Mean |    Error |
|--------------- |--------- |---------- |-------------- |----------- |----------:|----------:|----------------- |--------- |---------- |-------------- |----------- |-----------:|---------:|
| long:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |      Array |  41.37 μs |  0.399 μs | double:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |      Array |   231.6 μs |  0.88 μs |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |      Array | 349.10 μs |  1.837 μs |   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |      Array |   937.0 μs |  1.99 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array |  43.41 μs |  0.312 μs | double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array |   261.4 μs |  0.53 μs |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array | 348.13 μs |  0.880 μs |   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |      Array |   852.1 μs |  1.34 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array |  45.01 μs |  0.244 μs | double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array |   247.6 μs |  0.57 μs |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array | 316.57 μs |  0.264 μs |   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |      Array |   757.5 μs |  9.19 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | LLVM Off | LegacyJit |          Mono |      Array | 121.84 μs |  0.251 μs | double:optimized | LLVM Off | LegacyJit |          Mono |      Array |   907.1 μs |  0.48 μs |
|   long:default | LLVM Off | LegacyJit |          Mono |      Array | 550.44 μs |  0.579 μs |   double:default | LLVM Off | LegacyJit |          Mono |      Array | 6,836.1 μs | 65.87 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized |  LLVM On |      Llvm |          Mono |      Array |  64.79 μs |  0.932 μs | double:optimized |  LLVM On |      Llvm |          Mono |      Array |   281.2 μs |  0.63 μs |
|   long:default |  LLVM On |      Llvm |          Mono |      Array | 441.20 μs |  0.343 μs |   double:default |  LLVM On |      Llvm |          Mono |      Array | 6,165.0 μs |  2.45 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |       List |  46.80 μs |  0.245 μs | double:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |       List | 1,144.1 μs |  8.35 μs |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |       List | 192.45 μs |  1.507 μs |   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |       List |   823.4 μs |  9.52 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |       List |  51.01 μs |  0.340 μs | double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |       List | 1,013.8 μs |  1.51 μs |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |       List | 197.18 μs |  0.170 μs |   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |       List |   720.9 μs |  2.10 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |       List |  45.32 μs |  0.785 μs | double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |       List |   705.4 μs |  1.34 μs |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |       List | 176.51 μs |  0.620 μs |   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |       List |   628.6 μs |  0.37 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | LLVM Off | LegacyJit |          Mono |       List | 130.66 μs |  0.924 μs | double:optimized | LLVM Off | LegacyJit |          Mono |       List | 7,071.5 μs | 24.30 μs |
|   long:default | LLVM Off | LegacyJit |          Mono |       List | 300.66 μs |  1.147 μs |   double:default | LLVM Off | LegacyJit |          Mono |       List | 6,497.4 μs |  3.49 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized |  LLVM On |      Llvm |          Mono |       List |  72.25 μs |  1.379 μs | double:optimized |  LLVM On |      Llvm |          Mono |       List | 6,436.2 μs | 32.68 μs |
|   long:default |  LLVM On |      Llvm |          Mono |       List | 192.96 μs |  0.382 μs |   double:default |  LLVM On |      Llvm |          Mono |       List | 5,948.4 μs |  6.05 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |     ROList | 122.88 μs |  0.372 μs | double:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |     ROList | 1,228.9 μs | 13.87 μs |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |     ROList | 263.24 μs |  0.626 μs |   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |     ROList |   882.8 μs |  4.08 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList | 123.61 μs |  0.549 μs | double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList | 1,080.9 μs |  1.53 μs |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList | 271.39 μs |  1.033 μs |   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |     ROList |   788.8 μs |  0.60 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList | 123.83 μs |  0.272 μs | double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList |   769.6 μs |  0.61 μs |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList | 252.05 μs |  1.056 μs |   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |     ROList |   694.0 μs |  0.40 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | LLVM Off | LegacyJit |          Mono |     ROList | 220.73 μs |  0.729 μs | double:optimized | LLVM Off | LegacyJit |          Mono |     ROList | 7,145.1 μs | 14.28 μs |
|   long:default | LLVM Off | LegacyJit |          Mono |     ROList | 422.31 μs |  3.151 μs |   double:default | LLVM Off | LegacyJit |          Mono |     ROList | 6,667.2 μs | 25.73 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized |  LLVM On |      Llvm |          Mono |     ROList | 138.44 μs |  1.772 μs | double:optimized |  LLVM On |      Llvm |          Mono |     ROList | 6,573.2 μs | 66.02 μs |
|   long:default |  LLVM On |      Llvm |          Mono |     ROList | 268.44 μs |  1.981 μs |   double:default |  LLVM On |      Llvm |          Mono |     ROList | 6,019.0 μs |  4.66 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |    ROArray |  56.36 μs |  0.141 μs | double:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 |    ROArray | 1,116.5 μs |  1.45 μs |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 |    ROArray | 189.82 μs |  0.391 μs |   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 |    ROArray |   794.5 μs |  0.99 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray |  59.09 μs |  0.175 μs | double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray | 1,005.4 μs |  0.57 μs |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray | 195.40 μs |  0.425 μs |   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 |    ROArray |   713.8 μs |  0.87 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray |  57.95 μs |  0.158 μs | double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray |   699.1 μs |  0.54 μs |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray | 167.97 μs |  0.554 μs |   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 |    ROArray |   621.3 μs |  0.47 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | LLVM Off | LegacyJit |          Mono |    ROArray | 135.04 μs |  0.213 μs | double:optimized | LLVM Off | LegacyJit |          Mono |    ROArray | 7,077.7 μs | 56.58 μs |
|   long:default | LLVM Off | LegacyJit |          Mono |    ROArray | 323.82 μs | 13.352 μs |   double:default | LLVM Off | LegacyJit |          Mono |    ROArray | 6,695.0 μs | 58.57 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized |  LLVM On |      Llvm |          Mono |    ROArray |  82.94 μs |  0.987 μs | double:optimized |  LLVM On |      Llvm |          Mono |    ROArray | 6,395.1 μs | 10.15 μs |
|   long:default |  LLVM On |      Llvm |          Mono |    ROArray | 188.26 μs |  0.403 μs |   double:default |  LLVM On |      Llvm |          Mono |    ROArray | 5,966.2 μs | 17.28 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 | Enumerable |  74.86 μs |  0.251 μs | double:optimized | Core 2.1 |    RyuJit | .NET Core 2.1 | Enumerable | 1,146.2 μs |  5.22 μs |
|   long:default | Core 2.1 |    RyuJit | .NET Core 2.1 | Enumerable | 207.79 μs |  4.897 μs |   double:default | Core 2.1 |    RyuJit | .NET Core 2.1 | Enumerable |   820.8 μs |  1.29 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable |  78.52 μs |  0.780 μs | double:optimized | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable | 1,019.5 μs |  1.82 μs |
|   long:default | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable | 200.36 μs |  0.597 μs |   double:default | Core 3.1 |    RyuJit | .NET Core 3.1 | Enumerable |   729.1 μs |  0.57 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable |  75.57 μs |  0.260 μs | double:optimized | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable |   718.5 μs |  1.24 μs |
|   long:default | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable | 178.66 μs |  0.174 μs |   double:default | Core 5.0 |    RyuJit | .NET Core 5.0 | Enumerable |   633.5 μs |  0.46 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized | LLVM Off | LegacyJit |          Mono | Enumerable | 164.19 μs |  0.255 μs | double:optimized | LLVM Off | LegacyJit |          Mono | Enumerable | 7,114.5 μs |  6.19 μs |
|   long:default | LLVM Off | LegacyJit |          Mono | Enumerable | 339.39 μs |  0.850 μs |   double:default | LLVM Off | LegacyJit |          Mono | Enumerable | 6,561.4 μs | 23.85 μs |
|                |          |           |               |            |           |           |                  |          |           |               |            |            |          |
| long:optimized |  LLVM On |      Llvm |          Mono | Enumerable | 100.64 μs |  1.321 μs | double:optimized |  LLVM On |      Llvm |          Mono | Enumerable | 6,404.4 μs |  3.42 μs |
|   long:default |  LLVM On |      Llvm |          Mono | Enumerable | 207.94 μs |  0.548 μs |   double:default |  LLVM On |      Llvm |          Mono | Enumerable | 5,951.9 μs |  2.21 μs |
