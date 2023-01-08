
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run(
    types: new [] {
        typeof(SortAndOrderBenchmarkInt), 
        typeof(SortAndOrderBenchmarkString),
        typeof(SortAndOrderBenchmarkRecordStruct),
        typeof(SortAndOrderBenchmarkRecordClass)
        });


public class SortAndOrderBenchmarkInt: SortAndOrderBenchmarks<int>
{
    public SortAndOrderBenchmarkInt() : base((Random r) => r.Next()) {}
}

public class SortAndOrderBenchmarkString: SortAndOrderBenchmarks<string>
{
    public SortAndOrderBenchmarkString() : base((Random r) => r.Next().ToString()) {}
}

public record RClassInt(int I): IComparable<RClassInt>
{
    public int CompareTo(RClassInt? other) => I.CompareTo(other?.I);
}

public class SortAndOrderBenchmarkRecordClass: SortAndOrderBenchmarks<RClassInt>
{
    public SortAndOrderBenchmarkRecordClass() : base((Random r) => new RClassInt(r.Next())) {}
}

public record struct RStructInt(int I) : IComparable<RStructInt>
{
    public int CompareTo(RStructInt other) => I.CompareTo(other.I);
}
public class SortAndOrderBenchmarkRecordStruct: SortAndOrderBenchmarks<RStructInt>
{
    public SortAndOrderBenchmarkRecordStruct() : base((Random r) => new RStructInt(r.Next())) {}
}

