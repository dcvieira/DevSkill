using DevSkill.Application.Contracts.Persistence;
using DevSkill.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevSkill.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DevSkillDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevSkillConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;    
        }
    }
}
