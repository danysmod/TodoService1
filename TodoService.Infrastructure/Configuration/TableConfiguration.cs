namespace TodoService.Infrastructure.Configuration
{
    using TodoService.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class TableConfiguration : IEntityTypeConfiguration<Entities.Table>
    {
        public void Configure(EntityTypeBuilder<Entities.Table> builder)
        {
            builder.ToTable("Tables");

            builder.Property(b => b.Id)
                   .HasConversion(
                        v => v.ToGuid(),
                        v => new BaseEntityId(v))
                   .IsRequired();

            builder.Property(b => b.Name)
                   .HasConversion(
                        v => v.ToString(),
                        v => new TableName(v))
                   .IsRequired();

            builder.Ignore(p => p.Tasks);

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
