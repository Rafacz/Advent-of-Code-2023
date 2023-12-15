using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D8Benchmarks
	{
		[Benchmark]
		public void Part1()
			=> Day8.Haunted_Wasteland.Program.Part1();
	}
}
