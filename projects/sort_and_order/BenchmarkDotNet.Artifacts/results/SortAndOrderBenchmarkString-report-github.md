``` ini

BenchmarkDotNet=v0.13.3, OS=ubuntu 22.04
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|       Method |     N |        Mean |       Error |      StdDev |      Median | Allocated |
|------------- |------ |------------:|------------:|------------:|------------:|----------:|
|  **ListOrderBy** |   **666** |    **422.5 μs** |     **4.69 μs** |     **4.16 μs** |    **421.6 μs** |   **18984 B** |
|    ListOrder |   666 |    421.1 μs |     1.89 μs |     1.76 μs |    421.0 μs |   13632 B |
|     ListSort |   666 |    283.9 μs |     1.73 μs |     1.53 μs |    283.9 μs |         - |
| ArrayOrderBy |   666 |    410.4 μs |     8.13 μs |    16.05 μs |    417.0 μs |   18984 B |
|   ArrayOrder |   666 |    386.1 μs |     7.04 μs |    18.16 μs |    381.7 μs |   13632 B |
|    ArraySort |   666 |    272.0 μs |     2.06 μs |     1.61 μs |    272.1 μs |         - |
|  **ListOrderBy** |  **6660** |  **5,621.8 μs** |    **29.98 μs** |    **26.58 μs** |  **5,624.0 μs** |  **186823 B** |
|    ListOrder |  6660 |  5,559.2 μs |    86.72 μs |    72.41 μs |  5,538.8 μs |  133519 B |
|     ListSort |  6660 |  3,925.8 μs |    20.61 μs |    22.91 μs |  3,919.8 μs |       7 B |
| ArrayOrderBy |  6660 |  5,603.8 μs |    22.67 μs |    20.10 μs |  5,609.5 μs |  186823 B |
|   ArrayOrder |  6660 |  5,595.3 μs |    70.98 μs |    66.39 μs |  5,609.0 μs |  133519 B |
|    ArraySort |  6660 |  3,992.5 μs |    29.65 μs |    26.28 μs |  3,996.1 μs |       7 B |
|  **ListOrderBy** | **66600** | **79,120.5 μs** |   **488.45 μs** |   **456.89 μs** | **79,139.2 μs** | **1865270 B** |
|    ListOrder | 66600 | 85,656.3 μs | 1,709.01 μs | 4,192.22 μs | 87,436.6 μs | 1332468 B |
|     ListSort | 66600 | 52,718.8 μs |   481.28 μs |   426.64 μs | 52,743.8 μs |      94 B |
| ArrayOrderBy | 66600 | 78,244.8 μs |   412.48 μs |   365.65 μs | 78,159.6 μs | 1865270 B |
|   ArrayOrder | 66600 | 76,669.2 μs |   658.76 μs |   616.21 μs | 76,582.6 μs | 1332446 B |
|    ArraySort | 66600 | 53,915.7 μs |   422.99 μs |   374.97 μs | 53,865.9 μs |      94 B |