using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace TeamHost.Infrastructure.Services;

public static class RedisCacheHelper
{
    public static async Task SetRecordAsync<T>(this IDistributedCache cache,
        string recordId,
        T data,
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? slidingExpireTime = null)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
            SlidingExpiration = slidingExpireTime
        };

        var jsonData = JsonSerializer.Serialize(data);
        await cache.SetStringAsync(recordId, jsonData, options);
    }

    public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache,
        string recordId)
    {
        var jsonData = await cache.GetStringAsync(recordId);

        if (jsonData is null)
        {
            return default(T);
        }

        return JsonSerializer.Deserialize<T>(jsonData);
    }
}