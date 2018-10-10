using BenchmarkDotNet.Attributes;
using Benchmarking.SharedLibrary.Hashing;
using System;
using System.Linq;

namespace Benchmarking.BenchmarkDotNet.Benchmarks
{
	[RPlotExporter, RankColumn]
	class HashingComparison
	{
		private static Random random = new Random();

		private string toHash;
		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		// Create two random strings for each set of params
		[GlobalSetup]
		public void Setup()
		{
			toHash = RandomString(1024);
			
		}

		[Benchmark]
		public string Sha256Hash() => Hashing.Sha256(toHash);

		[Benchmark]
		public string BlowfishHash() => Hashing.BlowFish(toHash);
	}
}
