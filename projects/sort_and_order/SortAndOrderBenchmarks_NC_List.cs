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
public class SortAndOrderBenchmarks_NC_List
{
    Random _random = new(420);

    public int N {get; set;} = 100;

    [Benchmark]
    public List<int> OrderByNC()
    {
        var items = Enumerable.Range(1, N).Select(_ => _random.Next());
        return items.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<int> OrderNC()
    {
        var items = Enumerable.Range(1, N).Select(_ => _random.Next());
        return items.Order().ToList();
    }

    [Benchmark]
    public List<int> SortNC()
    {
        var items = Enumerable.Range(1, N).Select(_ => _random.Next()).ToList();
        items.Sort();
        return items;
    } 

    [Benchmark]
    public List<int> OrderByNC_2()
    {
        Random random = new (420);
        var items = Enumerable.Range(1, N).Select(_ => random.Next());
        return items.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<int> OrderNC_2()
    {
        Random random = new (420);
        var items = Enumerable.Range(1, N).Select(_ => random.Next());
        return items.Order().ToList();
    }

    [Benchmark]
    public List<int> SortNC_2()
    {
        Random random = new (420);
        var items = Enumerable.Range(1, N).Select(_ => random.Next()).ToList();
        items.Sort();
        return items;
    }

    private int[]? source;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(420);
        source = Enumerable.Range(1, N).Select(_ => random.Next()).ToArray();
    }

    [Benchmark]
    public List<int> OrderBy()
    {
        var fresh = source!.ToList();
        return fresh.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<int> Order()
    {
        var fresh = source!.ToList();
        return fresh!.Order().ToList();
    }

    [Benchmark]
    public List<int> Sort()
    {
        var fresh = source!.ToList();
        fresh.Sort();
        return fresh;
    }
 
}