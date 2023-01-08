``` ini

BenchmarkDotNet=v0.13.3, OS=ubuntu 22.04
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|          Method |       Mean |     Error |    StdDev |     Median | Allocated |
|---------------- |-----------:|----------:|----------:|-----------:|----------:|
|       OrderByNC | 9,380.1 ns | 185.83 ns | 426.98 ns | 9,562.7 ns |    2024 B |
|         OrderNC | 8,878.8 ns | 174.26 ns | 260.83 ns | 8,818.1 ns |    1600 B |
|          SortNC | 3,740.4 ns |  74.75 ns | 114.15 ns | 3,703.4 ns |     576 B |
| ListOrderByNC_2 | 7,773.0 ns | 150.98 ns | 141.23 ns | 7,793.4 ns |    2352 B |
|       OrderNC_2 | 7,186.1 ns | 104.03 ns | 152.48 ns | 7,148.2 ns |    1928 B |
|        SortNC_2 | 1,820.6 ns |  25.45 ns |  22.56 ns | 1,814.0 ns |     904 B |
|         OrderBy | 6,361.4 ns |  97.15 ns |  86.12 ns | 6,337.7 ns |    1872 B |
|           Order | 6,105.8 ns |  69.05 ns | 103.35 ns | 6,083.5 ns |    1448 B |
|            Sort |   594.8 ns |  11.95 ns |  32.52 ns |   581.3 ns |         - |
