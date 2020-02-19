using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoService.Identity
{
    public class TodoServiceIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public TodoServiceIdentityContext(DbContextOptions<TodoServiceIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(TodoServiceIdentityContext).Assembly);
        }
    }
}
