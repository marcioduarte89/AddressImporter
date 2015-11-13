using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using AddressImporter.Common.Interfaces;

namespace Caching
{
    public class CacheProvider: ICacheProvider
    {
        private static ObjectCache _cache;
        public CacheProvider()
        {
            _cache = MemoryCache.Default;
        }

        public T Get<T>(string key)
        {
            var cachedObject = _cache.Get(key);
            if (cachedObject == null)
                return default(T);
            return (T)cachedObject;
        }

        public void Set<T>(string key, T value)
        {
            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30.0)
            };
            _cache.Add(key, value, policy);
        }

        public void Set<T>(string key, T value, int duration)
        {
            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(duration)
            };
            _cache.Add(key, value, policy);
        }

        public void Remove(string key)
        {
             if (_cache.Contains(key))
            {
                _cache.Remove(key);
            } 
        }

        
        public IEnumerable<KeyValuePair<string, object>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
