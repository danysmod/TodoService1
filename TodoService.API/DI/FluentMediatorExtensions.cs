namespace API.DI
{
    using Microsoft.Extensions.DependencyInjection;
    using FluentMediator;
    using App.Boundaries.Table.CreateTable;
    using App.Boundaries.Account.Register;

    public static class FluentMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<CreateTableInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Table.CreateTable.IUseCase>(
                                (handler, request) => handler.Execute(request));

                    builder.On<RegisterInput>()
                           .PipelineAsync()
                           .Call<App.Boundaries.Account.Register.IUseCase>(
                                (handler, request) => handler.Execute(request));
                });

            return services;
        }
    }
}
