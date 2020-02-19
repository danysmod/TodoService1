namespace API.DI
{
    using App.UseCase.Account;
    using App.UseCase.Table;
    using Microsoft.Extensions.DependencyInjection;
    using TodoService.Domain;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<App.Boundaries.Table.CreateTable.IUseCase, CreateTableUseCase>();
            services.AddScoped<TableService>();

            services.AddScoped<App.Boundaries.Account.Register.IUseCase, RegisterUseCase>();
            services.AddScoped<AccountService>();

            return services;
        }
    }
}
