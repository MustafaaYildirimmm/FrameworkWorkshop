using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;

        public void Add(string key, object data, int cacheTime = 60)
        {
            if (data == null) return;

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime) }; //AbsoluteExpiration cache'de ne kadar dursun bilgisini tutar.
            Cache.Add(new CacheItem(key, data), policy);
        }

        public void Clear()
        {
            foreach (var cache in Cache)
            {
                Remove(cache.Key); 
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(t => regex.IsMatch(t.Key)).Select(t => t.Key).ToList();

            keysToRemove.ForEach((key) =>
            {
                Remove(key);
            });
        }
    }
}
