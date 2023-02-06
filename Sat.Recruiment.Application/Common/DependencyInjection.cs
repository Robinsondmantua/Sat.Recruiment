using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruiment.Application.Common.Behaviors;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Services;
using Sat.Recruiment.Domain.Enums;

namespace Sat.Recruiment.Application.Common
{
    /// <summary>
    /// Injected dependencies for this layer
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddUserTypeFactory();
            return services;
        }
        private static IServiceCollection AddUserTypeFactory (this IServiceCollection services)
        {
            services.AddSingleton<NormalUserService>();
            services.AddSingleton<PremiumUserService>();
            services.AddSingleton<SuperUserService>();

            services.AddTransient<Func<UserType, IUserType>>(serviceProvider => key =>
            {
                switch(key)
                {
                    case UserType.Normal:
                        return serviceProvider.GetRequiredService<NormalUserService>();
                    case UserType.SuperUser:
                        return serviceProvider.GetRequiredService<SuperUserService>();
                    case UserType.Premium:
                        return serviceProvider.GetRequiredService<SuperUserService>();
                    default:
                        return null;
                }
            });

            return services;
        }
    }
}
