## Universe.TimeSeriesSerializer &nbsp;&nbsp;&nbsp; [![Nuget](https://img.shields.io/nuget/v/Universe.TimeSeriesSerializer?label=nuget.org)](https://www.nuget.org/packages/Universe.TimeSeriesSerializer/)
Serializer for time series kind of data, optimized for memory usage and performance

## Usage
The `LongArrayConverter` class is for collections of `long` and `long?` items 

The `DoubleArrayConverter` class is for collections of `double` and `double?` items

## Benchmark

| Collection | Job         | Method    |  | Long Mean | Speed up longs |  | Double Mean | Speed up for doubles |
| ---------- | ----------- | ----------|--| ---------:| --------:|--| -----------:| --------:|
| Array      | Core 2.1    | optimized |  | 33.12 μs  | 9.1      |  | 177.58 μs   | 4.0      |
| Array      | Core 2.1    | default   |  | 290.28 μs |          |  | 706.81 μs   |          |
| Array      | Core 3.1    | optimized |  | 32.95 μs  | 9.1      |  | 173.04 μs   | 3.8      |
| Array      | Core 3.1    | default   |  | 295.84 μs |          |  | 668.07 μs   |          |
| Array      | Core 5.0    | optimized |  | 31.65 μs  | 7.7      |  | 172.18 μs   | 3.3      |
| Array      | Core 5.0    | default   |  | 250.50 μs |          |  | 569.19 μs   |          |
| Array      | Mono        | optimized |  | 94.19 μs  | 4.5      |  | 667.74 μs   | 7.1      |
| Array      | Mono        | default   |  | 424.58 μs |          |  | 4,850.43 μs |          |
| Array      | Mono + LLVM | optimized |  | 48.13 μs  | 7.1      |  | 215.40 μs   | 20.0     |
| Array      | Mono + LLVM | default   |  | 343.92 μs |          |  | 4,347.88 μs |          |
| List       | Core 2.1    | optimized |  | 37.55 μs  | 4.3      |  | 97.62 μs    | 6.3      |
| List       | Core 2.1    | default   |  | 164.22 μs |          |  | 608.88 μs   |          |
| List       | Core 3.1    | optimized |  | 36.87 μs  | 4.5      |  | 102.11 μs   | 5.6      |
| List       | Core 3.1    | default   |  | 167.69 μs |          |  | 579.96 μs   |          |
| List       | Core 5.0    | optimized |  | 33.96 μs  | 4.0      |  | 96.75 μs    | 5.0      |
| List       | Core 5.0    | default   |  | 137.89 μs |          |  | 486.13 μs   |          |
| List       | Mono        | optimized |  | 99.21 μs  | 2.4      |  | 365.50 μs   | 12.5     |
| List       | Mono        | default   |  | 242.11 μs |          |  | 4,709.32 μs |          |
| List       | Mono + LLVM | optimized |  | 51.98 μs  | 2.9      |  | 126.65 μs   | 33.3     |
| List       | Mono + LLVM | default   |  | 151.25 μs |          |  | 4,193.28 μs |          |
| RO List    | Core 2.1    | optimized |  | 98.08 μs  | 2.3      |  | 155.36 μs   | 4.3      |
| RO List    | Core 2.1    | default   |  | 224.97 μs |          |  | 665.28 μs   |          |
| RO List    | Core 3.1    | optimized |  | 92.62 μs  | 2.4      |  | 166.23 μs   | 3.8      |
| RO List    | Core 3.1    | default   |  | 226.31 μs |          |  | 631.37 μs   |          |
| RO List    | Core 5.0    | optimized |  | 92.56 μs  | 2.1      |  | 149.73 μs   | 3.4      |
| RO List    | Core 5.0    | default   |  | 198.23 μs |          |  | 524.60 μs   |          |
| RO List    | Mono        | optimized |  | 172.60 μs | 2.0      |  | 432.21 μs   | 11.1     |
| RO List    | Mono        | default   |  | 342.30 μs |          |  | 4,822.20 μs |          |
| RO List    | Mono + LLVM | optimized |  | 113.32 μs | 1.9      |  | 179.07 μs   | 25.0     |
| RO List    | Mono + LLVM | default   |  | 216.21 μs |          |  | 4,270.80 μs |          |
| RO Array   | Core 2.1    | optimized |  | 47.98 μs  | 3.6      |  | 104.13 μs   | 5.9      |
| RO Array   | Core 2.1    | default   |  | 172.03 μs |          |  | 601.10 μs   |          |
| RO Array   | Core 3.1    | optimized |  | 44.06 μs  | 3.8      |  | 104.62 μs   | 5.6      |
| RO Array   | Core 3.1    | default   |  | 169.69 μs |          |  | 574.50 μs   |          |
| RO Array   | Core 5.0    | optimized |  | 42.93 μs  | 3.1      |  | 101.53 μs   | 4.8      |
| RO Array   | Core 5.0    | default   |  | 135.30 μs |          |  | 481.06 μs   |          |
| RO Array   | Mono        | optimized |  | 103.60 μs | 2.4      |  | 361.11 μs   | 12.5     |
| RO Array   | Mono        | default   |  | 247.40 μs |          |  | 4,733.06 μs |          |
| RO Array   | Mono + LLVM | optimized |  | 57.26 μs  | 2.6      |  | 130.33 μs   | 33.3     |
| RO Array   | Mono + LLVM | default   |  | 150.01 μs |          |  | 4,213.51 μs |          |
| Enumerable | Core 2.1    | optimized |  | 59.49 μs  | 3.0      |  | 123.89 μs   | 5.0      |
| Enumerable | Core 2.1    | default   |  | 183.41 μs |          |  | 612.47 μs   |          |
| Enumerable | Core 3.1    | optimized |  | 56.16 μs  | 3.0      |  | 124.19 μs   | 4.5      |
| Enumerable | Core 3.1    | default   |  | 169.47 μs |          |  | 577.31 μs   |          |
| Enumerable | Core 5.0    | optimized |  | 53.54 μs  | 2.6      |  | 117.50 μs   | 4.2      |
| Enumerable | Core 5.0    | default   |  | 142.29 μs |          |  | 483.76 μs   |          |
| Enumerable | Mono        | optimized |  | 121.84 μs | 2.2      |  | 389.42 μs   | 12.5     |
| Enumerable | Mono        | default   |  | 262.79 μs |          |  | 4,658.56 μs |          |
| Enumerable | Mono + LLVM | optimized |  | 71.10 μs  | 2.3      |  | 151.17 μs   | 25.0     |
| Enumerable | Mono + LLVM | default   |  | 163.97 μs |          |  | 4,219.17 μs |          |




