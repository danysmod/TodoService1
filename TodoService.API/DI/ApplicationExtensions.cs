namespace API.DI
{
    using App.UseCase.Account;
    using App.UseCase.Table;
    using App.UseCase.TableTask;
    using Microsoft.Extensions.DependencyInjection;
    using TodoService.Domain;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<App.Boundaries.Table.CreateTable.IUseCase, CreateTableUseCase>();
            services.AddScoped<App.Boundaries.Table.ChangeTableTitle.IUseCase, ChangeTableTitleUseCase>();
            services.AddScoped<App.Boundaries.Table.DeleteTable.IUseCase, DeleteTableUseCase>();
            services.AddScoped<App.Boundaries.Table.GetTableDetails.IUseCase, GetTableDetailsUseCase>();

            services.AddScoped<App.Boundaries.TableTask.AddTask.IUseCase, AddTaskUseCase>();
            services.AddScoped<App.Boundaries.TableTask.ChangeTitleTask.IUseCase, ChangeTitleTaskUseCase>();
            services.AddScoped<App.Boundaries.TableTask.CompleteTask.IUseCase, CompleteTaskUseCase>();
            services.AddScoped<App.Boundaries.TableTask.DeleteTask.IUseCase, DeleteTaskUseCase>();
            services.AddScoped<TableService>();

            services.AddScoped<App.Boundaries.Account.Register.IUseCase, RegisterUseCase>();
            services.AddScoped<App.Boundaries.Account.Login.IUseCase, LoginUseCase>();
            services.AddScoped<App.Boundaries.Account.GetAccountDetails.IUseCase, GetAccountDetailsUseCase>();
            services.AddScoped<AccountService>();

            return services;
        }
    }
}
