using FullStackDemo.Infrastructure.Persistence.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackDemo.WebApi.Configurations
{
    public static class DbContextConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IGundamDbContext, GundamDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GundamDb"),
                    b => b.MigrationsAssembly("FullStackDemo.Infrastructure")
            ));
        }
    }
}
