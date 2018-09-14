namespace Benchmarking.SharedLibrary.Math
{
	public class BooleanCounts
	{
		public static int countConditional(bool[] f0, bool[] f1)
		{
			int cnt = 0;
			for (int j = 0; j < f0.Length; j++)
			{
				for (int i = 0; i < f0.Length; i++)
				{
					if (f0[i] && f1[j])
					{
						cnt++;
					}
				}
			}
			return cnt;
		}

		public static int countLogical(bool[] f0, bool[] f1)
		{
			int cnt = 0;
			for (int j = 0; j < f0.Length; j++)
			{
				for (int i = 0; i < f0.Length; i++)
				{
					if (f0[i] & f1[j])
					{
						cnt++;
					}
				}
			}
			return cnt;
		}
	}
}
