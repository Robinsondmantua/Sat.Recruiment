using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruiment.Infraestructure.Repository;

namespace Sat.Recruiment.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IMemoryContext, InMemoryContext>();
            return services;
        }
    }
}
