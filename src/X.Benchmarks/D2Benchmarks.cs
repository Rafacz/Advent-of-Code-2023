using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D2Benchmarks
	{
		[Benchmark]
		public void Part1()
			=> Day2.Cube_Conundrum.Program.Part1();

		[Benchmark]
		public void Part2()
			=> Day2.Cube_Conundrum.Program.Part2();

	}
}
