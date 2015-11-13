using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using AddressImporter.Common.Interfaces;
using System.Web;
using AddressImporter.Entities;

namespace Test
{
    public class CacheProvider<TEntity> : ICacheProvider<TEntity> where TEntity : class
    {
        private static ObjectCache _cache;
        public CacheProvider()
        {
            _cache = MemoryCache.Default;
        }
         
        public TEntity Get(string key)
        {
            var cachedObject = _cache.Get(key);
            if (cachedObject == null)
                return null;
            else
            {
                return (TEntity)cachedObject;
            }
        }

        public void Add(string key, TEntity value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
