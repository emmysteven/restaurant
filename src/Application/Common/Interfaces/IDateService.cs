using System;

namespace Restaurant.Application.Common.Interfaces
{
    public interface IDateService
    {
        DateTime NowUtc { get; }
    }
}