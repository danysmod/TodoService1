namespace TodoService.Identity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class ContextFactory : IDesignTimeDbContextFactory<TodoServiceIdentityContext>
    {
        public TodoServiceIdentityContext CreateDbContext(string[] args)
        {
            var connectionString = ReadDefaultConnectionString();

            var builder = new DbContextOptionsBuilder<TodoServiceIdentityContext>();
            builder.UseSqlServer(connectionString);
            return new TodoServiceIdentityContext(builder.Options);
        }

        private string ReadDefaultConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
