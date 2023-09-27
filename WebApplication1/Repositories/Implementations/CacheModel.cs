using Microsoft.Extensions.Caching.Memory;

namespace WebApplication1.Repositories.Implementations
{
    public static class CacheModel<T>
    {
        private static readonly IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

        public static IEnumerable<T> Get(string key)
        {
            if (memoryCache.TryGetValue(key, out IEnumerable<T> results))
                return results;
            else
                return (IEnumerable<T>)default;
        }
        public static void Set(string key, IEnumerable<T> value)
        {

            var options = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(10),
            };
            memoryCache.Set(key, value,options);
        }
        public static void Delete(string key)
        {
            memoryCache.Remove(key);
        }
    }
}
