# DotNet String Creation Benchmarking

Benchmarks 4 different ways to create strings in .NET

To run:
```
dotnet run -c Release
```

## Some Results

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


