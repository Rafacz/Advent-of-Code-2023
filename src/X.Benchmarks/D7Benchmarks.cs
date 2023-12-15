using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D7Benchmarks
	{
		[Benchmark]
		public void Part1()
			=> Day7.Camel_Cards.Program.Part1();

		[Benchmark]
		public void Part2()
			=> Day7.Camel_Cards.Program.Part2();

	}
}
