using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoService.Identity;

namespace API.DI.Security
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TodoServiceIdentityContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
                    {
                        opt.Password.RequireDigit = false;
                        opt.Password.RequiredLength = 6;
                        opt.Password.RequireLowercase = false;
                        opt.Password.RequireNonAlphanumeric = false;
                        opt.Password.RequireUppercase = false;

                        opt.User.RequireUniqueEmail = true;
                    })
                    .AddEntityFrameworkStores<TodoServiceIdentityContext>()
                    .AddSignInManager<SignInManager<ApplicationUser>>()
                    .AddDefaultTokenProviders();

            return services;
        }
    }
}
