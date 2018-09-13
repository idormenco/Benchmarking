﻿using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using Benchmarking.SharedLibrary.Caching;

namespace Benchmarking.BenchmarkDotNet
{
	public class CacheRace
	{
		private BadCachingProvider _badCaching = BadCachingProvider.Instance;
		private GooderCachingProvider _gooderCaching = GooderCachingProvider.Instance;
		private GoodestCachingProvider _goodestCaching = GoodestCachingProvider.Instance;

		public CacheRace()
		{

		}

		// property with public setter
		[Params(nameof(Numbers))]
		public int ValuesForCache { get; set; }

		[Benchmark]
		public void BadCachingProviderGetValue()
		{
			_badCaching.GetValue(3, v => ValuesForCache);
		}

		[Benchmark]
		public void GooderCachingProviderGetValue()
		{
			_gooderCaching.GetValue(3, v => ValuesForCache);
		}
		[Benchmark]
		public void GoodestCachingProviderGetValue()
		{
			_goodestCaching.GetValue(3, v => ValuesForCache);
		}

		public IEnumerable<object[]> Numbers()
		{
			yield return new object[] { 1 };
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			// Use BenchmarkRunner.Run to Benchmark your code
			var summary = BenchmarkRunner.Run<StringCompareVsEquals>();
		}
	}

	// We are using .Net Core so add we are adding the CoreJobAttribute here.
	[CoreJob]
	[RPlotExporter, RankColumn]
	public class StringCompareVsEquals
	{
		private static Random random = new Random();
		private string s1;
		private string s2;

		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		// We wil run the the test for 2 diff string lengths: 10 & 100
		[Params(10, 100)]
		public int N;


		// Create two random strings for each set of params
		[Setup]
		public void Setup()
		{
			s1 = RandomString(N);
			s2 = RandomString(N);
		}

		// This is the slow way of comparing strings, so let's benchmark it.
		[Benchmark]
		public bool Slow() => s1.ToLower() == s2.ToLower();

		// This is the fast way of comparing strings, so let's benchmark it.
		[Benchmark]
		public bool Fast() => string.Compare(s1, s2, true) == 0;
	}
}
