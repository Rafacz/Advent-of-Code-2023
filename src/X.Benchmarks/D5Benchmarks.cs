using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D5Benchmarks
	{
		//[Benchmark]
		//public void Part1()
		//	=> Day5.If_20You_Give_A_Seed_A_Fertilizer.Program.Part1();

		//[Benchmark]
		//public void Part2()
		//	=> Day4.Scratchcards.Program.Part2();

	}
}
