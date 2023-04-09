namespace Restaurant.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CacheAttribute : Attribute
{
    public string CacheKey;
    public int Duration;
    public TimeSpan TimeSpanForCacheInvalidation = TimeSpan.FromSeconds(60);

    public CacheAttribute()
    {
    }

    public CacheAttribute(string cacheKey)
    {
        CacheKey = cacheKey;
    }

    public CacheAttribute(int duration)
    {
        Duration = duration;
        TimeSpanForCacheInvalidation = TimeSpan.FromSeconds(duration);
    }

    public CacheAttribute(string cacheKey, int duration)
    {
        CacheKey = cacheKey;
        Duration = duration;
        TimeSpanForCacheInvalidation = TimeSpan.FromSeconds(duration);
    }
}