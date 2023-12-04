using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D4Benchmarks
	{
		[Benchmark]
		public void Part1()
			=> Day4.Scratchcards.Program.Part1();

		[Benchmark]
		public void Part2()
			=> Day4.Scratchcards.Program.Part2();

	}
}
