
using Microsoft.EntityFrameworkCore;
using DevSkill.Order.Application.Contracts.Persistence;
using DevSkill.Order.Persistence;
using DevSkill.Order.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSkill.Catalog.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DevSkillDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevSkillConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;    
        }
    }
}
