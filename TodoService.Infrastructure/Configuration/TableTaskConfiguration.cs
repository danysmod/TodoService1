namespace TodoService.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using TodoService.Domain;

    public class TableTaskConfiguration : IEntityTypeConfiguration<Entities.TableTask>
    {
        public void Configure(EntityTypeBuilder<Entities.TableTask> builder)
        {
            builder.ToTable("TasksTable");

            builder.Property(b => b.Id)
                   .HasConversion(
                        v => v.ToGuid(),
                        v => new BaseEntityId(v))
                   .IsRequired();

            builder.Property(b => b.Text)
                   .HasConversion(
                        v => v.ToString(),
                        v => new TaskText(v))
                   .IsRequired();

            builder.Property(x => x.CreateDate)
                   .HasConversion(
                            v => v,
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            builder.Property(x => x.EditDate)
                   .HasConversion(
                            v => v,
                            v => DateTime.SpecifyKind((DateTime)v, DateTimeKind.Utc));

            builder.Property(x => x.TableId)
                   .HasConversion(
                        v => v.ToGuid(),
                        v => new BaseEntityId(v))
                    .IsRequired();
        }
    }
}
