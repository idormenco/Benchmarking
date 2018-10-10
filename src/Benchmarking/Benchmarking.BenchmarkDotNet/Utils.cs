using System;

namespace Benchmarking.BenchmarkDotNet
{
	class Utils
	{
		public static T[] ShuffleCopy<T>(T[] array)
		{
			T[] newArray = new T[array.Length];
			Array.Copy(array, newArray, array.Length);
			return newArray;
		}

		public static int[] RandomIntArray(int size)
		{
			int[] arr = new int[size];
			Fill(arr);
			return arr;
		}

		public static double[] RandomDoubleArray(int size)
		{
			double[] arr = new double[size];
			Fill(arr);
			return arr;
		}

		internal static int[] FillWithPattern(int size, string benchPattern)
		{
			var regularData = new int[size];
			for (int i = 0, j = 0; i < size; i++)
			{
				regularData[i] = benchPattern[j] == '1' ? 1 : -1;
				j = (j + 1) % benchPattern.Length;
			}

			return regularData;
		}

		private static void Fill(int[] array)
		{
			Random rnd = new Random(0xBAD_BEE);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = rnd.Next();
			}
		}

		private static void Fill(double[] array)
		{
			Random rnd = new Random(0xBAD_BEE);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = rnd.NextDouble();
			}
		}

		private static void Swap<T>(T[] array, int i0, int i1)
		{
			T x = array[i0];
			array[i0] = array[i1];
			array[i1] = x;
		}

		private static void Shuffle<T>(T[] array)
		{
			Random rnd = new Random(0xBAD_BEE);
			for (int i = array.Length; i > 1; i--)
			{
				Swap(array, i - 1, rnd.Next(i));
			}

		}
	}
}
