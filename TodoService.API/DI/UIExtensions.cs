namespace API.DI
{
    using API.UI.Account;
    using API.UI.Account.GetAccountDetails;
    using API.UI.Task.AddTask;
    using API.UI.Table.CreateTable;
    using Microsoft.Extensions.DependencyInjection;
    using API.UI.Table.ChangeTableTitle;
    using API.UI.Table.DeleteTable;
    using API.UI.Table.GetTableDetails;
    using API.UI.Task.ChangeTaskTitle;
    using API.UI.Task.CompleteTask;
    using API.UI.Task.DeleteTask;

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

            services.AddScoped<LoginPresenter, LoginPresenter>();
            services.AddScoped<App.Boundaries.Account.Login.IOutputPort>(
                    x => x.GetRequiredService<LoginPresenter>());

            services.AddScoped<GetAccountDetailsPresenter, GetAccountDetailsPresenter>();
            services.AddScoped<App.Boundaries.Account.GetAccountDetails.IOutputPort>(
                    x => x.GetRequiredService<GetAccountDetailsPresenter>());

            services.AddScoped<ChangeTableTitlePresenter, ChangeTableTitlePresenter>();
            services.AddScoped<App.Boundaries.Table.ChangeTableTitle.IOutputPort>(
                    x => x.GetRequiredService<ChangeTableTitlePresenter>());

            services.AddScoped<DeleteTablePresenter, DeleteTablePresenter>();
            services.AddScoped<App.Boundaries.Table.DeleteTable.IOutputPort>(
                    x => x.GetRequiredService<DeleteTablePresenter>());

            services.AddScoped<GetTableDetailsPresenter, GetTableDetailsPresenter>();
            services.AddScoped<App.Boundaries.Table.GetTableDetails.IOutputPort>(
                    x => x.GetRequiredService<GetTableDetailsPresenter>());

            services.AddScoped<AddTaskPresenter, AddTaskPresenter>();
            services.AddScoped<App.Boundaries.TableTask.AddTask.IOutputPort>(
                    x => x.GetRequiredService<AddTaskPresenter>());

            services.AddScoped<ChangeTaskTitlePresenter, ChangeTaskTitlePresenter>();
            services.AddScoped<App.Boundaries.TableTask.ChangeTitleTask.IOutputPort>(
                    x => x.GetRequiredService<ChangeTaskTitlePresenter>());

            services.AddScoped<CompleteTaskPresenter, CompleteTaskPresenter>();
            services.AddScoped<App.Boundaries.TableTask.CompleteTask.IOutputPort>(
                    x => x.GetRequiredService<CompleteTaskPresenter>());

            services.AddScoped<DeleteTaskPresenter, DeleteTaskPresenter>();
            services.AddScoped<App.Boundaries.TableTask.DeleteTask.IOutputPort>(
                    x => x.GetRequiredService<DeleteTaskPresenter>());

            return services;
        }
    }
}
