namespace API.DI.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TodoService.Identity;

    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityPersistance(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TodoServiceIdentityContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<TodoServiceIdentityContext>();

            services.AddScoped<SignInManager<ApplicationUser>>();

            return services;
        }
    }
}
