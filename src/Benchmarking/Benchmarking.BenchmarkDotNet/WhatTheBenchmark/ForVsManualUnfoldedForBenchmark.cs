using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;
using Benchmarking.SharedLibrary.Math;

namespace Benchmarking.BenchmarkDotNet.WhatTheBenchmark
{
	//[Config(typeof(Config))]
	[RankColumn]
	[ClrJob]
	//[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
	public class ForVsManualUnfoldedForBenchmark
	{
		private int[] intArray;

		private readonly Sums _sumClass = new Sums();

		[Params("10", "1101001001", "rand")]
		public string BenchPattern;

		[GlobalSetup]
		public void Setup()
		{
			//intArray = Utils.RandomIntArray(2048);

			#region uncommentThis

			if (BenchPattern == "rand")
			{
				intArray = Utils.Random10IntArray(2048);
			}
			else
			{
				intArray = Utils.FillWithPattern(2048, BenchPattern);
			}

			#endregion
		}


		[Benchmark]
		public int ForSum()
		{
			return _sumClass.SumArrayWithFor(intArray);
		}

		[Benchmark]
		public int SumArrayWithForWithIf()
		{
			return _sumClass.SumArrayWithForWithIf(intArray);
		}


	}
}
