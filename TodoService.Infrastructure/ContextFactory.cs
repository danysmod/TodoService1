namespace TodoService.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class ContextFactory : IDesignTimeDbContextFactory<TodoServiceContext>
    {
        public TodoServiceContext CreateDbContext(string[] args)
        {
            var connectionString = ReadDefaultConnectionString();

            var builder = new DbContextOptionsBuilder<TodoServiceContext>();
            builder.UseSqlServer(connectionString);
            return new TodoServiceContext(builder.Options);
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
