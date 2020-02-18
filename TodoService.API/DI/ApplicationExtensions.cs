namespace TodoService.API.DI
{
    using App.Boundaries.Table.CreateTable;
    using App.UseCase.Table;
    using Microsoft.Extensions.DependencyInjection;
    using TodoService.Domain;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase, CreateTableUseCase>();
            services.AddScoped<TableService>();

            return services;
        }
    }
}
