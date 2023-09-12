using RubricaUrp.Backend.Domain.UoW;
using RubricaUrp.Backend.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace RubricaUrp.Backend.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDb, Db>();
            return services;
        }
    }
}
