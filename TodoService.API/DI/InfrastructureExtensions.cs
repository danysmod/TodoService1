namespace TodoService.API.DI
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TodoService.Domain;
    using TodoService.Infrastructure;

    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddSQLServerPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ITableFactory, EntityFactory>();

            services.AddDbContext<TodoServiceContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITableRepository, TableRepository>();

            return services;
        }
    }
}
