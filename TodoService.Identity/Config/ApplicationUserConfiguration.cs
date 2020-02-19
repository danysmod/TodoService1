namespace TodoService.Identity.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TodoService.Domain;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(b => b.AccountId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new BaseEntityId(v))
                .IsRequired();
        }
    }
}
