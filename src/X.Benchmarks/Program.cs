using BenchmarkDotNet.Running;

namespace X.Benchmarks
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//BenchmarkRunner.Run<D1Benchmarks>();
			//BenchmarkRunner.Run<D2Benchmarks>();
			//BenchmarkRunner.Run<D3Benchmarks>();
			BenchmarkRunner.Run<D4Benchmarks>();
		}
	}
}
