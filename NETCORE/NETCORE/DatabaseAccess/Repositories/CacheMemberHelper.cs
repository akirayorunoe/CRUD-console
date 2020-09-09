using Microsoft.Extensions.Caching.Memory;
using NETCORE.DatabaseAccess.Models;
using System;
using System.Collections.Generic;

namespace NETCORE.DatabaseAccess.Repositories
{
    public class CacheMemberHelper
    {
        private IMemoryCache _cache;
        public CacheMemberHelper(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public List<Member> CacheGetAll(string key)
        {
            var cacheEntry = _cache.Get<List<Member>>(key);
            return cacheEntry;
        }

        public void CacheSet(string key, List<Member> value)
        {
            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));
            // Save data in cache.
            _cache.Set(key, value,cacheEntryOptions);
        }
    }

}
