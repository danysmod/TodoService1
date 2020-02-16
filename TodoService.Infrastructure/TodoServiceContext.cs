namespace TodoService.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class TodoServiceContext : DbContext
    {
        public TodoServiceContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Table> Tables { get; set; } = null!;

        public DbSet<TableTask> TableTasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TodoServiceContext).Assembly);
        }
    }
}
