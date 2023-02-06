using Microsoft.Extensions.DependencyInjection;
using Sat.Recruiment.Application.Common.Abstractions;
using Sat.Recruiment.Domain.Models;
using Sat.Recruiment.Infraestructure.Repository;
using Sat.Recruiment.Infraestructure.Repository.User;

namespace Sat.Recruiment.Infraestructure
{
    /// <summary>
    /// Injected dependencies for this layer
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, MemoryUnitOfWork>();
            services.AddTransient<IMemoryContext, InMemoryContext>();
            services.AddTransient<ICommandRepository<User>, UserRepositoryCommand>();
            services.AddTransient<IQueryRepository<User>, UserRepositoryQueries>();
            return services;
        }
    }
}
