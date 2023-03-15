``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1344/22H2/2022Update/SunValley2)
Intel Core i9-9900KF CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|            Method |       Mean |    Error |   StdDev |
|------------------ |-----------:|---------:|---------:|
| WithStringBuilder |   143.2 ns |  1.62 ns |  1.35 ns |
| WithConcatenation |   173.4 ns |  2.06 ns |  1.93 ns |
| WithInterpolation | 1,090.1 ns | 16.54 ns | 13.81 ns |
