﻿using DevSkill.Integration.Messages;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevSkill.Catalog.Application;
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        return services;
        }
    }

