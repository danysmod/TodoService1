using API.UI.Table.CreateTable;
using App.Boundaries.Table.CreateTable;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoService.API.DI
{
    public static class UIExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateTablePresenter, CreateTablePresenter>();
            services.AddScoped<IOutputPort>(x => x.GetRequiredService<CreateTablePresenter>());

            return services;
        }
    }
}
