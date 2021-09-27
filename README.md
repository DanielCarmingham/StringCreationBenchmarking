# DotNet String Creation Benchmarking

Benchmarks 4 different ways to create strings in .NET

To run:
```
dotnet run -c Release
```

## Some Results

### .NET 6.0.0 RC1

Dell i7559 laptop (2015 model)
```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT


|            Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
|------------------ |----------:|---------:|---------:|-------:|----------:|
|         MaskNaive | 131.38 ns | 2.711 ns | 5.091 ns | 0.1121 |     352 B |
| MaskStringBuilder |  54.82 ns | 1.174 ns | 1.098 ns | 0.0587 |     184 B |
|     MaskNewString |  36.59 ns | 0.833 ns | 1.222 ns | 0.0382 |     120 B |
|  MaskStringCreate |  15.93 ns | 0.412 ns | 0.722 ns | 0.0153 |      48 B |
```

Apple MacBook Air M1 (2020 model) - X64 (Rosetta Emulation)
```
BenchmarkDotNet=v0.13.1, OS=macOS Big Sur 11.6 (20G165) [Darwin 20.6.0]
Apple M1 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT


|            Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
|------------------ |----------:|---------:|---------:|-------:|----------:|
|         MaskNaive | 125.22 ns | 1.301 ns | 1.217 ns | 0.1683 |     352 B |
| MaskStringBuilder |  79.45 ns | 0.823 ns | 0.770 ns | 0.0880 |     184 B |
|     MaskNewString |  24.25 ns | 0.027 ns | 0.024 ns | 0.0573 |     120 B |
|  MaskStringCreate |  15.19 ns | 0.019 ns | 0.017 ns | 0.0229 |      48 B |
```

Apple MacBook Air M1 (2020 model) - Arm64 (Apple Silicon native)
```
BenchmarkDotNet=v0.13.1, OS=macOS Big Sur 11.6 (20G165) [Darwin 20.6.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 6.0.0 (6.0.21.45113), Arm64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.45113), Arm64 RyuJIT


|            Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------------------ |-----------:|----------:|----------:|-------:|----------:|
|         MaskNaive | 103.111 ns | 0.7313 ns | 0.6841 ns | 0.1683 |     352 B |
| MaskStringBuilder |  57.035 ns | 0.1281 ns | 0.1136 ns | 0.0880 |     184 B |
|     MaskNewString |  24.580 ns | 0.1311 ns | 0.1227 ns | 0.0574 |     120 B |
|  MaskStringCreate |   9.780 ns | 0.0395 ns | 0.0369 ns | 0.0229 |      48 B |
```

Dell XPS 13 9310 (2021 model) - i7-1185g7 - Power manager set to "Ultra Performance"

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1237 (20H2/October2020Update)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-rc.1.21463.6
  [Host]     : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT


|            Method |      Mean |    Error |    StdDev |    Median |  Gen 0 | Allocated |
|------------------ |----------:|---------:|----------:|----------:|-------:|----------:|
|         MaskNaive | 120.04 ns | 4.602 ns | 13.056 ns | 116.89 ns | 0.0560 |     352 B |
| MaskStringBuilder |  68.05 ns | 1.659 ns |  4.707 ns |  67.29 ns | 0.0293 |     184 B |
|     MaskNewString |  38.08 ns | 1.923 ns |  5.669 ns |  38.74 ns | 0.0191 |     120 B |
|  MaskStringCreate |  19.37 ns | 0.586 ns |  1.717 ns |  18.87 ns | 0.0076 |      48 B |
```
