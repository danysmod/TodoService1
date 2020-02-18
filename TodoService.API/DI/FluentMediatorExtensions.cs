namespace TodoService.API.DI
{
    using Microsoft.Extensions.DependencyInjection;
    using FluentMediator;
    using App.Boundaries.Table.CreateTable;

    public static class FluentMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<CreateTableInput>()
                           .PipelineAsync()
                           .Call<IUseCase>((handler, request) => handler.Execute(request));
                });

            return services;
        }
    }
}
