using System;
using System.Collections.Generic;

namespace Benchmarking.SharedLibrary.Caching
{
	public class GooderCachingProvider : ICachingProvider
	{
		private readonly Dictionary<string, object> _cache = new Dictionary<string, object>();

		private static GooderCachingProvider Instance => new GooderCachingProvider();

		private GooderCachingProvider()
		{
		}

		public T GetValue<TK, T>(TK request, Func<TK, T> retrieveFunc) where T : new()
		{
			var key = request.ToString();
			object chacheValue;

			if (!_cache.TryGetValue(key, out chacheValue))
			{
				var retrievedValue = retrieveFunc(request);
				_cache.Add(key, retrievedValue);
			}

			return (T)chacheValue;
		}
	}
}