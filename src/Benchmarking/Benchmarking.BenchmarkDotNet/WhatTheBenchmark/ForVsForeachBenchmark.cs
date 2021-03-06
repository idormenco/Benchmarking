﻿using BenchmarkDotNet.Attributes;
using Benchmarking.SharedLibrary.Math;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;

namespace Benchmarking.BenchmarkDotNet.WhatTheBenchmark
{
	[Config(typeof(Config))]
	[RankColumn]
	//[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
	public class ForVsForeachBenchmark
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
