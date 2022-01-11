using Restaurant.Application.Settings;

namespace Restaurant.Application.Common.Interfaces;

public interface ICacheInvalidatorPostProcessor
{
    InvalidateCacheForQueries QueriesList { get; set; }
}