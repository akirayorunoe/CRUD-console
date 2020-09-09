using Microsoft.Extensions.Caching.Memory;
using NETCORE.DatabaseAccess.Models;
using System.Collections.Generic;

namespace NETCORE.DatabaseAccess.Repositories
{
    public class CacheMemberHelper
    {
        private IMemoryCache _cache;
        public CacheMemberHelper(IMemoryCache memoryCache) {
            _cache = memoryCache;
        }

        public List<Member> CacheGetAll(string key)
        {
            var cacheEntry=_cache.Get<List<Member>>(key);
            return cacheEntry;
        }
               
        public void CacheSet(string key, List<Member> value)
            {
                // Save data in cache.
                _cache.Set(key, value);
            }
        }
    
}
