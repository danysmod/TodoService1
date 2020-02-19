namespace API.DI
{
    using API.UI.Account.Register;
    using API.UI.Table.CreateTable;
    using Microsoft.Extensions.DependencyInjection;

    public static class UIExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateTablePresenter, CreateTablePresenter>();
            services.AddScoped<App.Boundaries.Table.CreateTable.IOutputPort>(
                    x => x.GetRequiredService<CreateTablePresenter>());

            services.AddScoped<RegisterPresenter, RegisterPresenter>();
            services.AddScoped<App.Boundaries.Account.Register.IOutputPort>(
                    x => x.GetRequiredService<RegisterPresenter>());

            return services;
        }
    }
}
