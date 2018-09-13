using BenchmarkDotNet.Attributes;
using System;
using System.Linq;

namespace Benchmarking.BenchmarkDotNet
{
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
		public int StringLength;

		// Create two random strings for each set of params
		[GlobalSetup]
		public void Setup()
		{
			s1 = RandomString(StringLength);
			s2 = RandomString(StringLength);
		}

		[Benchmark]
		public bool DoubleEqual() => s1.ToLower() == s2.ToLower();

		[Benchmark]
		public bool StringCompare() => string.Compare(s1, s2, true) == 0;
	}
}
