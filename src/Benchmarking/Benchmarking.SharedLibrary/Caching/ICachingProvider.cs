using System;

namespace Benchmarking.SharedLibrary.Caching
{
	public interface ICachingProvider
	{
		T GetValue<TK, T>(TK request, Func<TK, T> retrieveAction) where T : new();
	}
}