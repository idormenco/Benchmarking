using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess;
using Benchmarking.BenchmarkDotNet.Benchmarks;
using Benchmarking.BenchmarkDotNet.WhatTheBenchmark;

namespace Benchmarking.BenchmarkDotNet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<BoolRqaceBenchmark>();
		}
	}
}
