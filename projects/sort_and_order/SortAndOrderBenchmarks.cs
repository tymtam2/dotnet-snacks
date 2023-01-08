using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;




[MemoryDiagnoser(displayGenColumns: false)]
public class SortAndOrderBenchmarks<T>
{
    [Params(666, 6_660, 66_600)]
    public int N {get; set;}

    private List<T>? dataListOrderBy;
    private List<T>? dataListOrder;
    private List<T>? dataListSort;
    private T[]? dataArrayOrderBy;
    private T[]? dataArrayOrder;
    private T[]? dataArraySort;
    protected readonly Func<Random, T> f;

    public SortAndOrderBenchmarks(Func<Random, T> f)
    {
        this.f = f;
    }

    [GlobalSetup]
    public void GlobalSetup()
    {
        IEnumerable<T> Randoms ()
        {
            var r = new Random(666);
            return Enumerable.Range(1, N).Select(_ => f(r));
        }
        dataListOrderBy = Randoms().ToList();
        dataListOrder = Randoms().ToList();
        dataListSort = Randoms().ToList();

        dataArrayOrderBy = Randoms().ToArray();
        dataArrayOrder = Randoms().ToArray();
        dataArraySort = Randoms().ToArray();
    }

    [Benchmark]
    public List<T> ListOrderBy()
    {
        return dataListOrderBy!.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<T> ListOrder()
    {
        return dataListOrder!.Order().ToList();
    }

    [Benchmark]
    public List<T> ListSort()
    {
        dataListSort!.Sort();
        return dataListSort;
    }

    [Benchmark]
    public List<T> ArrayOrderBy()
    {
        return dataArrayOrderBy!.OrderBy(x => x).ToList();
    }

    [Benchmark]
    public List<T> ArrayOrder()
    {
        return dataArrayOrder!.Order().ToList();
    }

    [Benchmark]
    public T[] ArraySort()
    {
        Array.Sort(dataArraySort!);
        return dataArraySort!;
    }
}