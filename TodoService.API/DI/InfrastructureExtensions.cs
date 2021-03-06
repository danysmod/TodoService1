﻿namespace API.DI
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TodoService.Domain;
    using TodoService.Domain.Services;
    using TodoService.Infrastructure;

    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddSQLServerPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ITableFactory, EntityFactory>();
            services.AddScoped<IAccountFactory, EntityFactory>();

            services.AddDbContext<TodoServiceContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
