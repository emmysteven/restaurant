using System;

namespace Application.Common.Interfaces
{
    public interface IDateService
    {
        DateTime NowUtc { get; }
    }
}