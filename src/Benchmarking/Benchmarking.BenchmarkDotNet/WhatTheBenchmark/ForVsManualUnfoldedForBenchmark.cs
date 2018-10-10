using BenchmarkDotNet.Attributes;
using Benchmarking.SharedLibrary.Math;

namespace Benchmarking.BenchmarkDotNet.WhatTheBenchmark
{
	[RPlotExporter, RankColumn]
	class ForVsManualUnfoldedForBenchmark
	{
		private int[] intArray;
		
		private Sums sumClass = new Sums();

		[Params("10","1101001001")]
		public string BenchPattern;

		[GlobalSetup]
		public void Setup()
		{
			intArray = Utils.RandomIntArray(2048);

			#region uncommentThis
			intArray = Utils.FillWithPattern(2048, BenchPattern);

			#endregion
		}


		[Benchmark]
		public int ForSum()
		{
			return sumClass.SumArrayWithFor(intArray);
		}
		[Benchmark]
		public int UnfoldedForSum()
		{
			return sumClass.SumArrayUnfolded(intArray);
		}


	}
}
