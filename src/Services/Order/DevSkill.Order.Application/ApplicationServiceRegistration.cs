using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevSkill.Order.Application;
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }

