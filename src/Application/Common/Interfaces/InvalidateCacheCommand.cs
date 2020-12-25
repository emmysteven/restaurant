using Application.Settings;

namespace Application.Common.Interfaces
{
    public interface ICacheInvalidatorPostProcessor
    {
       InvalidateCacheForQueries QueriesList { get; set; }
    }
}