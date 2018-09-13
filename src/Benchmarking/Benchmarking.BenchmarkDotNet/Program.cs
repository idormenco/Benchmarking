using BenchmarkDotNet.Running;

namespace Benchmarking.BenchmarkDotNet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<StringCompareVsEquals>();
		}
	}
}
