using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D1Benchmarks
	{
		[Benchmark]
		public void Part1()
			=> Day1.Trebuchet.Program.Part1();

		[Benchmark]
		public void Part2()
			=> Day1.Trebuchet.Program.Part2();

	}
}
