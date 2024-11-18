using AVS.DevStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AVS.DevStore.API.Configurations
{
    public static class ContextConfig
    {
        public static IServiceCollection AddPersistenceConfig(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
