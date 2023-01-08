using BenchmarkDotNet.Attributes;

[MemoryDiagnoser(displayGenColumns: false)]
public class SortAndOrderBenchmarks<T>
{
    [Params(666, 6_660, 66_600)]
    public int N {get; set;}

    private List<T>? sourceList;
    private T[]? sourceArray;
    protected readonly Func<Random, T> f;

    public SortAndOrderBenchmarks(Func<Random, T> f)
    {
        this.f = f;
    }

    [GlobalSetup]
    public void GlobalSetup()
    {
        var r = new Random(666);
        sourceList = Enumerable.Range(1, N).Select(_ => f(r)).ToList();

        sourceArray = sourceList.ToArray();
    }

    [Benchmark]
    public List<T> ListOrderBy()
    {
        return sourceList!.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<T> ListOrder()
    {
        return sourceList!.Order().ToList();
    }

    [Benchmark]
    public List<T> ListSort()
    {
        var l = sourceList!.ToList();
        l.Sort();
        return l;
    }

    [Benchmark]
    public List<T> ArrayOrderBy()
    {
        return sourceArray!.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<T> ArrayOrder()
    {
        return sourceArray!.Order().ToList();
    }

    [Benchmark]
    public T[] ArraySort()
    {
        var a = sourceArray!.ToArray();
        Array.Sort(a);
        return a;
    }
}