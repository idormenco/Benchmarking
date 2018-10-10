using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;
using Benchmarking.SharedLibrary.Math;

namespace Benchmarking.BenchmarkDotNet.WhatTheBenchmark
{
	[Config(typeof(Config))]
	public class BoolRqaceBenchmark
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

		private bool[] array1;
		private bool[] array2;

		[Params(10, 100, 1000)]
		public int ArrayLength;
	

		[GlobalSetup]
		public void Setup()
		{
			array1= Utils.RandomBoolArray(ArrayLength);
			array2= Utils.RandomBoolArray(ArrayLength);
		}

		[Benchmark]
		public int CountConditional()
		{
			return BooleanCounts.CountConditional(array1,array2);
		}

		[Benchmark]
		public int CountLogical()
		{
			return BooleanCounts.CountLogical(array1, array2);
		}
	}
}