using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarking.SharedLibrary.Caching
{
	public class BadCachingProvider : ICachingProvider
	{
		private readonly List<Tuple<string, object>> _cache = new List<Tuple<string, object>>();

		public static BadCachingProvider Instance => new BadCachingProvider();

		private BadCachingProvider()
		{
		}

		public T GetValue<TK, T>(TK request, Func<TK, T> retrieveFunc) 
		{
			var key = request.ToString();
			var chachedObject = _cache.FirstOrDefault(x => x.Item1 == key);
			if (chachedObject == null)
			{
				var retrievedValue = retrieveFunc(request);
				_cache.Add(Tuple.Create<string, object>(key, retrievedValue));
				return retrievedValue;
			}

			return (T)chachedObject.Item2;
		}
	}
}
