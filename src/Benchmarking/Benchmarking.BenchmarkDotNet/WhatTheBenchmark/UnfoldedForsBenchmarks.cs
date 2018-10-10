using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;
using Benchmarking.SharedLibrary.Math;

namespace Benchmarking.BenchmarkDotNet.WhatTheBenchmark
{
	[Config(typeof(Config))]
	[RankColumn]
	public class UnfoldedForsBenchmarks
	{
		private class Config : ManualConfig
		{
			public Config()
			{
				Add(Job.Clr
					.With(InProcessToolchain.Instance)
					.WithId("InProcess"));
			}
		}

		private int[] intArray;

		private Sums sumClass = new Sums();

		//[Params("10", "1101001001", "rand")]
		//public string BenchPattern;

		[GlobalSetup]
		public void Setup()
		{
			intArray = Utils.RandomIntArray(1024);

			#region uncommentThis

			//if (BenchPattern == "rand")
			//{
			//	intArray = Utils.Random10IntArray(2048);
			//}
			//else
			//{
			//	intArray = Utils.FillWithPattern(2048, BenchPattern);
			//}

			#endregion
		}

		[Benchmark]
		public int SumArrayWithFor()
		{
			return sumClass.SumArrayWithFor(intArray);
		}

		[Benchmark]
		public int SumArrayWithForeach()
		{
			return sumClass.SumArrayWithForeach(intArray);
		}

		[Benchmark]
		public int SumArrayUnfolded()
		{
			return sumClass.SumArrayUnfolded(intArray);
		}

		[Benchmark]
		public int SumArray2Sums()
		{
			return sumClass.SumArray2Sums(intArray);
		}

		[Benchmark]
		public int SumArray4Sums()
		{
			return sumClass.SumArray4Sums(intArray);
		}

		[Benchmark]
		public int SumArray8Sums()
		{
			return sumClass.SumArray8Sums(intArray);
		}

		[Benchmark]
		public int LinqSum()
		{
			return sumClass.LinqSum(intArray);
		}

	}
}
