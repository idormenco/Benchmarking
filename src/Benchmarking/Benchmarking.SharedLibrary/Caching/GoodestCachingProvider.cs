using System;
using System.Runtime.Caching;

namespace Benchmarking.SharedLibrary.Caching
{
	public class GoodestCachingProvider : ICachingProvider
	{
		private static MemoryCache _cache = MemoryCache.Default;

		private GoodestCachingProvider()
		{

		}

		public static GoodestCachingProvider Instance => new GoodestCachingProvider();

		public T GetValue<TK, T>(TK request, Func<TK, T> retrieveFunc)
		{
			string key = request.ToString();
			T cachedValue = (T)_cache.Get(key);
			if (cachedValue == null)
			{
				var result = retrieveFunc(request);
				_cache.Set(key, result, DateTimeOffset.MaxValue);
				return result;
			}

			return cachedValue;
		}
	}
}