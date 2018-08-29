using System;
using System.Runtime.Caching;

namespace Benchmarking.SharedLibrary.Caching
{
	public class GoodestCachingProvider:ICachingProvider
	{
		private static MemoryCache _cache = MemoryCache.Default;
		private static readonly CacheItemPolicy _cacheItemPolicy = new CacheItemPolicy()
		{
			AbsoluteExpiration = DateTimeOffset.MaxValue
		};

		public T GetValue<TK, T>(TK request, Func<TK, T> retrieveFunc) where T : new()
		{
			string key = request.ToString();
			T cachedValue = (T)_cache[key];
			if (cachedValue == null)
			{
				var result = retrieveFunc(request);
				_cache.Set(key, result, _cacheItemPolicy);
				return result;
			}

			return cachedValue;
		}
	}
}