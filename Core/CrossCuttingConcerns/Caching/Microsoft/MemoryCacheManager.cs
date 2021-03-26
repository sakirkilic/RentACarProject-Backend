using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
	public class MemoryCacheManager : ICacheManager
	{
		IMemoryCache _mermoryCache;

		public MemoryCacheManager()
		{
			_mermoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
		}

		public void Add(string key, object value, int duration)
		{
			_mermoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
		}

		public T Get<T>(string key)
		{
			return _mermoryCache.Get<T>(key);
		}

		public object Get(string key)
		{
			return _mermoryCache.Get(key);
		}

		public bool IsAdd(string key)
		{
			return _mermoryCache.TryGetValue(key, out _);
		}

		public void Remove(string key)
		{
			_mermoryCache.Remove(key);
		}

		public void RemoveByPattern(string pattern)
		{
			var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_mermoryCache) as dynamic;
			List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

			foreach (var cacheItem in cacheEntriesCollection)
			{
				ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
				cacheCollectionValues.Add(cacheItemValue);
			}

			var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
			var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

			foreach (var key in keysToRemove)
			{
				_mermoryCache.Remove(key);
			}
		}
	}
}
