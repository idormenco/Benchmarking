using System.Linq;

namespace Benchmarking.SharedLibrary.Math
{
	public class Sums
	{
		public int SumArrayWithForWithIf(int[] numbers)
		{
			int sum = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] > 0)
				{
					sum += numbers[i];
				}

			}
			return sum;
		}
		public int SumArrayWithFor(int[] numbers)
		{
			int sum = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				sum += numbers[i];
			}
			return sum;
		}

		public int SumArrayWithForeach(int[] numbers)
		{
			int sum = 0;
			foreach (var nr in numbers)
			{
				sum += nr;
			}
			return sum;
		}

		public int SumArrayUnfolded(int[] numbers)
		{
			int sum = 0;
			for (int i = 0; i < numbers.Length; i += 4)
			{
				sum += numbers[i] + numbers[i + 1] + numbers[i + 2] + numbers[i + 3];
			}
			return sum;
		}

		public int SumArray2Sums(int[] numbers)
		{
			int s0 = 0;
			int s1 = 0;
			for (int i = 0; i < numbers.Length; i += 2)
			{
				s0 += numbers[i];
				s1 += numbers[i + 1];
			}

			return s0 + s1;
		}

		public int SumArray4Sums(int[] numbers)
		{
			int sum = 0;
			int sum1 = 0;
			int sum2 = 0;
			int sum3 = 0;
			for (int i = 0; i < numbers.Length; i += 4)
			{
				sum += numbers[i];
				sum1 += numbers[i + 1];
				sum2 += numbers[i + 2];
				sum3 += numbers[i + 3];
			}
			return (sum + sum1) + (sum2 + sum3);
		}

		public int SumArray8Sums(int[] numbers)
		{
			int sum0 = 0;
			int sum1 = 0;
			int sum2 = 0;
			int sum3 = 0;
			int sum4 = 0;
			int sum5 = 0;
			int sum6 = 0;
			int sum7 = 0;

			for (int i = 0; i < numbers.Length; i += 8)
			{
				sum0 += numbers[i];
				sum1 += numbers[i + 1];
				sum2 += numbers[i + 2];
				sum3 += numbers[i + 3];
				sum4 += numbers[i + 4];
				sum5 += numbers[i + 5];
				sum6 += numbers[i + 6];
				sum7 += numbers[i + 7];
			}

			return ((sum0 + sum1) + (sum2 + sum3)) + ((sum4 + sum5) + (sum6 + sum7));
		}

		public int LinqSum(int[] array)
		{
			return array.Sum();
		}
	}
}

