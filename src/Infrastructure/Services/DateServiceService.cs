using System;
using Application.Common.Interfaces;

namespace Infrastructure.Services
{
    public class DateServiceService : IDateService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}