using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reputy.Application.Common.Interfaces;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Application.Common.Interfaces.Services;
using Reputy.Application.Services.Authentication;
using Reputy.Infrastructure.Authentication;
using Reputy.Infrastructure.Persistance;
using Reputy.Infrastructure.Persistance.Advertisement;
using Reputy.Infrastructure.Services;

namespace Reputy.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

            return services;
        }
    }
}
