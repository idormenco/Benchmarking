using BenchmarkDotNet.Attributes;
using Benchmarking.SharedLibrary.Math;
using System;

namespace Benchmarking.BenchmarkDotNet.WhatTheBenchmark
{
	[RPlotExporter, RankColumn]
	class ForVsForeachBenchmark
	{
		private int[] array;

		[Params(10, 100, 1000)]
		public int ArrayLength;
		private Sums sumClass = new Sums();

		[GlobalSetup]
		public void Setup()
		{
			array = Utils.RandomIntArray(ArrayLength);
		}


		[Benchmark]
		public int ForeachSum()
		{
			return sumClass.SumArrayWithForeach(array);
		}

		[Benchmark]
		public int ForSum()
		{
			return sumClass.SumArrayWithFor(array);
		}
	}
}
