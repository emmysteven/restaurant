using System;
using Restaurant.Application.Common.Interfaces;

namespace Restaurant.Infrastructure.Services
{
    public class DateServiceService : IDateService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}