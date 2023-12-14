using BenchmarkDotNet.Attributes;

namespace X.Benchmarks
{
	[MemoryDiagnoser]
	[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]
	public class D6Benchmarks
	{
		[Benchmark]
		public void Part1()
			=> Day6.Wait_For_It.Program.Part1();

		[Benchmark]
		public void Part2()
			=> Day6.Wait_For_It.Program.Part2();

	}
}
