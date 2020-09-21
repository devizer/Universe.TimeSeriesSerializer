## Universe.TimeSeriesSerializer &nbsp;&nbsp;&nbsp; [![Nuget](https://img.shields.io/nuget/v/Universe.TimeSeriesSerializer?label=nuget.org)](https://www.nuget.org/packages/Universe.TimeSeriesSerializer/)
Serializer for time series kind of data, optimized for memory usage and performance

## Usage
The `LongArrayConverter` class is for collections of `long` and `long?` items 

The `DoubleArrayConverter` class is for collections of `double` and `double?` items

## Benchmark

| Collection | Job         |  | Method         |  |  |  | Mean      | Speed up |  |  |  |  | Method           |  | Mean        | Speed up |  |
| ---------- | ----------- |  | -------------- |  |  |  | --------- | -------- |  |  |  |  | ---------------- |  | ----------- | -------- |  |
| Array      | Core 2.1    |  | long:optimized |  |  |  | 33.12 μs  | 9.1      |  |  |  |  | double:optimized |  | 177.58 μs   | 4.0      |  |
| Array      | Core 2.1    |  | long:default   |  |  |  | 290.28 μs |          |  |  |  |  | double:default   |  | 706.81 μs   |          |  |
| Array      | Core 3.1    |  | long:optimized |  |  |  | 32.95 μs  | 9.1      |  |  |  |  | double:optimized |  | 173.04 μs   | 3.8      |  |
| Array      | Core 3.1    |  | long:default   |  |  |  | 295.84 μs |          |  |  |  |  | double:default   |  | 668.07 μs   |          |  |
| Array      | Core 5.0    |  | long:optimized |  |  |  | 31.65 μs  | 7.7      |  |  |  |  | double:optimized |  | 172.18 μs   | 3.3      |  |
| Array      | Core 5.0    |  | long:default   |  |  |  | 250.50 μs |          |  |  |  |  | double:default   |  | 569.19 μs   |          |  |
| Array      | Mono        |  | long:optimized |  |  |  | 94.19 μs  | 4.5      |  |  |  |  | double:optimized |  | 667.74 μs   | 7.1      |  |
| Array      | Mono        |  | long:default   |  |  |  | 424.58 μs |          |  |  |  |  | double:default   |  | 4,850.43 μs |          |  |
| Array      | Mono + LLVM |  | long:optimized |  |  |  | 48.13 μs  | 7.1      |  |  |  |  | double:optimized |  | 215.40 μs   | 20.0     |  |
| Array      | Mono + LLVM |  | long:default   |  |  |  | 343.92 μs |          |  |  |  |  | double:default   |  | 4,347.88 μs |          |  |
| List       | Core 2.1    |  | long:optimized |  |  |  | 37.55 μs  | 4.3      |  |  |  |  | double:optimized |  | 97.62 μs    | 6.3      |  |
| List       | Core 2.1    |  | long:default   |  |  |  | 164.22 μs |          |  |  |  |  | double:default   |  | 608.88 μs   |          |  |
| List       | Core 3.1    |  | long:optimized |  |  |  | 36.87 μs  | 4.5      |  |  |  |  | double:optimized |  | 102.11 μs   | 5.6      |  |
| List       | Core 3.1    |  | long:default   |  |  |  | 167.69 μs |          |  |  |  |  | double:default   |  | 579.96 μs   |          |  |
| List       | Core 5.0    |  | long:optimized |  |  |  | 33.96 μs  | 4.0      |  |  |  |  | double:optimized |  | 96.75 μs    | 5.0      |  |
| List       | Core 5.0    |  | long:default   |  |  |  | 137.89 μs |          |  |  |  |  | double:default   |  | 486.13 μs   |          |  |
| List       | Mono        |  | long:optimized |  |  |  | 99.21 μs  | 2.4      |  |  |  |  | double:optimized |  | 365.50 μs   | 12.5     |  |
| List       | Mono        |  | long:default   |  |  |  | 242.11 μs |          |  |  |  |  | double:default   |  | 4,709.32 μs |          |  |
| List       | Mono + LLVM |  | long:optimized |  |  |  | 51.98 μs  | 2.9      |  |  |  |  | double:optimized |  | 126.65 μs   | 33.3     |  |
| List       | Mono + LLVM |  | long:default   |  |  |  | 151.25 μs |          |  |  |  |  | double:default   |  | 4,193.28 μs |          |  |
| RO List    | Core 2.1    |  | long:optimized |  |  |  | 98.08 μs  | 2.3      |  |  |  |  | double:optimized |  | 155.36 μs   | 4.3      |  |
| RO List    | Core 2.1    |  | long:default   |  |  |  | 224.97 μs |          |  |  |  |  | double:default   |  | 665.28 μs   |          |  |
| RO List    | Core 3.1    |  | long:optimized |  |  |  | 92.62 μs  | 2.4      |  |  |  |  | double:optimized |  | 166.23 μs   | 3.8      |  |
| RO List    | Core 3.1    |  | long:default   |  |  |  | 226.31 μs |          |  |  |  |  | double:default   |  | 631.37 μs   |          |  |
| RO List    | Core 5.0    |  | long:optimized |  |  |  | 92.56 μs  | 2.1      |  |  |  |  | double:optimized |  | 149.73 μs   | 3.4      |  |
| RO List    | Core 5.0    |  | long:default   |  |  |  | 198.23 μs |          |  |  |  |  | double:default   |  | 524.60 μs   |          |  |
| RO List    | Mono        |  | long:optimized |  |  |  | 172.60 μs | 2.0      |  |  |  |  | double:optimized |  | 432.21 μs   | 11.1     |  |
| RO List    | Mono        |  | long:default   |  |  |  | 342.30 μs |          |  |  |  |  | double:default   |  | 4,822.20 μs |          |  |
| RO List    | Mono + LLVM |  | long:optimized |  |  |  | 113.32 μs | 1.9      |  |  |  |  | double:optimized |  | 179.07 μs   | 25.0     |  |
| RO List    | Mono + LLVM |  | long:default   |  |  |  | 216.21 μs |          |  |  |  |  | double:default   |  | 4,270.80 μs |          |  |
| RO Array   | Core 2.1    |  | long:optimized |  |  |  | 47.98 μs  | 3.6      |  |  |  |  | double:optimized |  | 104.13 μs   | 5.9      |  |
| RO Array   | Core 2.1    |  | long:default   |  |  |  | 172.03 μs |          |  |  |  |  | double:default   |  | 601.10 μs   |          |  |
| RO Array   | Core 3.1    |  | long:optimized |  |  |  | 44.06 μs  | 3.8      |  |  |  |  | double:optimized |  | 104.62 μs   | 5.6      |  |
| RO Array   | Core 3.1    |  | long:default   |  |  |  | 169.69 μs |          |  |  |  |  | double:default   |  | 574.50 μs   |          |  |
| RO Array   | Core 5.0    |  | long:optimized |  |  |  | 42.93 μs  | 3.1      |  |  |  |  | double:optimized |  | 101.53 μs   | 4.8      |  |
| RO Array   | Core 5.0    |  | long:default   |  |  |  | 135.30 μs |          |  |  |  |  | double:default   |  | 481.06 μs   |          |  |
| RO Array   | Mono        |  | long:optimized |  |  |  | 103.60 μs | 2.4      |  |  |  |  | double:optimized |  | 361.11 μs   | 12.5     |  |
| RO Array   | Mono        |  | long:default   |  |  |  | 247.40 μs |          |  |  |  |  | double:default   |  | 4,733.06 μs |          |  |
| RO Array   | Mono + LLVM |  | long:optimized |  |  |  | 57.26 μs  | 2.6      |  |  |  |  | double:optimized |  | 130.33 μs   | 33.3     |  |
| RO Array   | Mono + LLVM |  | long:default   |  |  |  | 150.01 μs |          |  |  |  |  | double:default   |  | 4,213.51 μs |          |  |
| Enumerable | Core 2.1    |  | long:optimized |  |  |  | 59.49 μs  | 3.0      |  |  |  |  | double:optimized |  | 123.89 μs   | 5.0      |  |
| Enumerable | Core 2.1    |  | long:default   |  |  |  | 183.41 μs |          |  |  |  |  | double:default   |  | 612.47 μs   |          |  |
| Enumerable | Core 3.1    |  | long:optimized |  |  |  | 56.16 μs  | 3.0      |  |  |  |  | double:optimized |  | 124.19 μs   | 4.5      |  |
| Enumerable | Core 3.1    |  | long:default   |  |  |  | 169.47 μs |          |  |  |  |  | double:default   |  | 577.31 μs   |          |  |
| Enumerable | Core 5.0    |  | long:optimized |  |  |  | 53.54 μs  | 2.6      |  |  |  |  | double:optimized |  | 117.50 μs   | 4.2      |  |
| Enumerable | Core 5.0    |  | long:default   |  |  |  | 142.29 μs |          |  |  |  |  | double:default   |  | 483.76 μs   |          |  |
| Enumerable | Mono        |  | long:optimized |  |  |  | 121.84 μs | 2.2      |  |  |  |  | double:optimized |  | 389.42 μs   | 12.5     |  |
| Enumerable | Mono        |  | long:default   |  |  |  | 262.79 μs |          |  |  |  |  | double:default   |  | 4,658.56 μs |          |  |
| Enumerable | Mono + LLVM |  | long:optimized |  |  |  | 71.10 μs  | 2.3      |  |  |  |  | double:optimized |  | 151.17 μs   | 25.0     |  |
| Enumerable | Mono + LLVM |  | long:default   |  |  |  | 163.97 μs |          |  |  |  |  | double:default   |  | 4,219.17 μs |          |  |
Clear




