using BenchmarkDotNet.Attributes;



/// <summary>
/// Benchmark based on Stop using LINQ to order your primitive collections in C#
/// by Nick Chapsas
/// at https://www.youtube.com/watch?v=K1Ye_QEpAq8
/// too show the impact of:
/// a) reusing _random
//  b) cost of .Next() and reallocating the source data
/// </summary>
[MemoryDiagnoser(displayGenColumns: false)]
public class SortAndOrderBenchmarks_NC_Array
{
    Random _random = new(420);

    public int N {get; set;} = 100;

    [Benchmark]
    public int[] OrderByNC()
    {
        var items = Enumerable.Range(1, N).Select(_ => _random.Next());
        return items.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public int[] OrderNC()
    {
        var items = Enumerable.Range(1, N).Select(_ => _random.Next());
        return items.Order().ToArray();
    }

    [Benchmark]
    public int[] SortNC()
    {
        var items = Enumerable.Range(1, N).Select(_ => _random.Next()).ToArray();
        Array.Sort(items);
        return items;
    } 

    [Benchmark]
    public int[] ListOrderByNC_2()
    {
        Random random = new (420);
        var items = Enumerable.Range(1, N).Select(_ => random.Next());
        return items.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public int[] OrderNC_2()
    {
        Random random = new (420);
        var items = Enumerable.Range(1, N).Select(_ => random.Next());
        return items.Order().ToArray();
    }

    [Benchmark]
    public int[] SortNC_2()
    {
        Random random = new (420);
        var items = Enumerable.Range(1, N).Select(_ => random.Next()).ToArray();
        Array.Sort(items);
        return items;
    }

    private int[]? source;

    private int[] tested = new int[100];

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(420);
        source = Enumerable.Range(1, N).Select(_ => random.Next()).ToArray();
    }

    [Benchmark]
    public int[] OrderBy()
    {
        Array.Copy(source!, tested, source!.Length);
        return tested.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public int[] Order()
    {
        Array.Copy(source!, tested, source!.Length);
        return tested.Order().ToArray();
    }

    [Benchmark]
    public int[] Sort()
    {
        Array.Copy(source!, tested, source!.Length);
        Array.Sort(tested);
        return tested;
    }
 
}

// Exmaple results: 
// |          Method |       Mean |     Error |    StdDev |     Median | Allocated |
// |---------------- |-----------:|----------:|----------:|-----------:|----------:|
// |       OrderByNC | 9,380.1 ns | 185.83 ns | 426.98 ns | 9,562.7 ns |    2024 B |
// |         OrderNC | 8,878.8 ns | 174.26 ns | 260.83 ns | 8,818.1 ns |    1600 B |
// |          SortNC | 3,740.4 ns |  74.75 ns | 114.15 ns | 3,703.4 ns |     576 B |
// | ListOrderByNC_2 | 7,773.0 ns | 150.98 ns | 141.23 ns | 7,793.4 ns |    2352 B |
// |       OrderNC_2 | 7,186.1 ns | 104.03 ns | 152.48 ns | 7,148.2 ns |    1928 B |
// |        SortNC_2 | 1,820.6 ns |  25.45 ns |  22.56 ns | 1,814.0 ns |     904 B |
// |         OrderBy | 6,361.4 ns |  97.15 ns |  86.12 ns | 6,337.7 ns |    1872 B |
// |           Order | 6,105.8 ns |  69.05 ns | 103.35 ns | 6,083.5 ns |    1448 B |
// |            Sort |   594.8 ns |  11.95 ns |  32.52 ns |   581.3 ns |         - |