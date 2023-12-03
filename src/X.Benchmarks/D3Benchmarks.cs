using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D3Benchmarks
	{
		[Benchmark]
		public void Part1()
			=> Day3.Gear_Ratios.Program.Part1();

		[Benchmark]
		public void Part2()
			=> Day3.Gear_Ratios.Program.Part2();

	}
}
