using BenchmarkDotNet.Running;

namespace Benchmarking.BenchmarkDotNet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Use BenchmarkRunner.Run to Benchmark your code
			var summary = BenchmarkRunner.Run<StringCompareVsEquals>();
		}
	}
}
