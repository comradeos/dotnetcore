``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1413/22H2/2022Update/SunValley2)
Intel Core i9-9900KF CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|            Method |       Mean |    Error |   StdDev |
|------------------ |-----------:|---------:|---------:|
| WithStringBuilder |   151.5 ns |  2.27 ns |  2.01 ns |
| WithConcatenation |   177.7 ns |  3.58 ns |  3.68 ns |
| WithInterpolation | 1,111.7 ns | 21.15 ns | 23.50 ns |
