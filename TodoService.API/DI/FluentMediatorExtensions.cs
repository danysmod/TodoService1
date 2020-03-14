namespace API.DI
{
    using Microsoft.Extensions.DependencyInjection;
    using FluentMediator;
    using App.Boundaries.Table.CreateTable;
    using App.Boundaries.Account.Register;
    using App.Boundaries.Account.Login;
    using App.Boundaries.TableTask.AddTask;
    using App.Boundaries.Account.GetAccountDetails;
    using App.Boundaries.Table.ChangeTableTitle;
    using App.Boundaries.Table.DeleteTable;
    using App.Boundaries.Table.GetTableDetails;
    using App.Boundaries.TableTask.ChangeTitleTask;
    using App.Boundaries.TableTask.CompleteTask;
    using App.Boundaries.TableTask.DeleteTask;

    public static class FluentMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<RegisterInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Account.Register.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<LoginInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Account.Login.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<GetAccountDetailsInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Account.GetAccountDetails.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<CreateTableInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Table.CreateTable.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<ChangeTableTitleInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Table.ChangeTableTitle.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<DeleteTableInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Table.DeleteTable.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<GetTableDetailsInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Table.GetTableDetails.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<AddTaskInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.TableTask.AddTask.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<ChangeTitleTaskInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.TableTask.ChangeTitleTask.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<CompleteTaskInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.TableTask.CompleteTask.IUseCase>(
                                (handler, request) => handler.Handle(request));

                    builder.On<DeleteTaskInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.TableTask.DeleteTask.IUseCase>(
                                (handler, request) => handler.Handle(request));
                });

            return services;
        }
    }
}
