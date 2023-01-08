``` ini

BenchmarkDotNet=v0.13.3, OS=ubuntu 22.04
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|       Method |     N |        Mean |     Error |      StdDev |      Median | Allocated |
|------------- |------ |------------:|----------:|------------:|------------:|----------:|
|  ListOrderBy | 66600 | 12,638.5 μs | 233.96 μs |   218.85 μs | 12,652.9 μs | 1066617 B |
|    ListOrder | 66600 | 13,422.0 μs | 357.42 μs | 1,036.95 μs | 12,970.6 μs |  800391 B |
|     ListSort | 66600 |    404.9 μs |   8.01 μs |    22.60 μs |    393.7 μs |         - |
| ArrayOrderBy | 66600 | 13,439.6 μs | 256.00 μs |   251.43 μs | 13,315.2 μs | 1067142 B |
|   ArrayOrder | 66600 | 14,073.9 μs | 306.93 μs |   900.18 μs | 13,759.3 μs |  800401 B |
|    ArraySort | 66600 |    414.7 μs |   9.18 μs |    27.07 μs |    402.4 μs |         - |
