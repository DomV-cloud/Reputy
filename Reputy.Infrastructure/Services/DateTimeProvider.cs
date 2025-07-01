using Reputy.Application.Common.Interfaces.Services;

namespace Reputy.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        DateTime IDateTimeProvider.UtcNow => DateTime.UtcNow;
    }
}
