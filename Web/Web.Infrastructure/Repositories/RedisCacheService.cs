using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Web.Domain.Abstractions;

namespace Web.Infrastructure.Repositories;

public class RedisCacheService : IRedisCacheService
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache) => _cache = cache;

    public async Task<T> Get<T>(string key, CancellationToken cancellationToken)
    {
        var value  = await _cache.GetStringAsync(key, cancellationToken);

        if (String.IsNullOrEmpty(value))
        {
            return default;
        }

        return JsonConvert.DeserializeObject<T>(value);
    }

    public async Task<T> Set<T>(string key, T value)
    {
        var timeOut = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24),
            SlidingExpiration = TimeSpan.FromMinutes(60)
        };

        _cache.SetString(key, JsonConvert.SerializeObject(value), timeOut);

        return value;
    }
}
