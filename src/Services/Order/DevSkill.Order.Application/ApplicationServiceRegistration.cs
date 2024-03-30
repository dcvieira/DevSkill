using DevSkill.Integration.Messages;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevSkill.Order.Application;
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMessageBus, AzServiceBusMessageBus>();

        return services;
        }
    }

