namespace TodoService.Infrastructure.Configuration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TodoService.Domain;

    public class AccountConfiguration : IEntityTypeConfiguration<Entities.Account>
    {
        public void Configure(EntityTypeBuilder<Entities.Account> builder)
        {
            builder.ToTable("Accounts");

            builder.Property(b => b.Id)
                   .HasConversion(
                        v => v.ToGuid(),
                        v => new BaseEntityId(v))
                   .IsRequired();

            builder.Ignore(p => p.Tables);

            builder.Property(x => x.CreateDate)
                   .HasConversion(
                            v => v,
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder.Property(x => x.EditDate)
                   .HasConversion(
                            v => v,
                            v => DateTime.SpecifyKind((DateTime)v, DateTimeKind.Utc));
        }
    }
}
