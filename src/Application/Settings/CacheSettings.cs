using System;

namespace Restaurant.Application.Settings;

public class CacheSettings
{
    public string CacheKey { get; set; }
    public TimeSpan ExpirationRelativeToNow { get; set; }
}