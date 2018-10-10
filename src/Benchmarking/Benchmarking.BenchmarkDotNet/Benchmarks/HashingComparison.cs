using BenchmarkDotNet.Attributes;
using Benchmarking.SharedLibrary.Hashing;
using System;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;

namespace Benchmarking.BenchmarkDotNet.Benchmarks
{
	[Config(typeof(Config))]
	[RankColumn]
	public class HashingComparison
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

		private static readonly Random Random = new Random();

		private string _toHash;
		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[Random.Next(s.Length)]).ToArray());
		}

		// Create two random strings for each set of params
		[GlobalSetup]
		public void Setup()
		{
			_toHash = RandomString(1024);
		}
		[Params(4, 8)]
		public int WorkFactor;

		[Benchmark]
		public string Sha256Hash() => Hashing.Sha256(_toHash);

		[Benchmark]
		public string BlowfishHash() => Hashing.BlowFish(_toHash, WorkFactor);
	}
}
