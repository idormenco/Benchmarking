using System;
using Microsoft.Extensions.Caching.Memory;


namespace Benchmarking.SharedLibrary.Caching
{
	public class GoodestCachingProvider : ICachingProvider
	{
		private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

		private GoodestCachingProvider()
		{

		}

		public static GoodestCachingProvider Instance => new GoodestCachingProvider();

		public T GetValue<TK, T>(TK request, Func<TK, T> retrieveFunc)
		{
			string key = request.ToString();
			T cachedValue = _cache.Get<T>(key);
			if (cachedValue == null)
			{
				var result = retrieveFunc(request);
				_cache.Set(key, result);
				return result;
			}

			return cachedValue;
		}
	}
}