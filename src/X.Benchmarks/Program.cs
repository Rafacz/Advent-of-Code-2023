﻿using BenchmarkDotNet.Running;

namespace X.Benchmarks
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//BenchmarkRunner.Run<D1Benchmarks>();
			//BenchmarkRunner.Run<D2Benchmarks>();
			//BenchmarkRunner.Run<D3Benchmarks>();
			//BenchmarkRunner.Run<D4Benchmarks>();
			//BenchmarkRunner.Run<D5Benchmarks>();
			//BenchmarkRunner.Run<D6Benchmarks>();
			//BenchmarkRunner.Run<D7Benchmarks>();
			BenchmarkRunner.Run<D8Benchmarks>();
		}
	}
}
