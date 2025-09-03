using Cookaracha.Core.Entities;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookaracha.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasConversion(x => x.Value, x => new EntityId(x))
            .IsRequired();
        builder.Property(u => u.CreatedAt)
            .HasConversion(x => x.Value, x => new Date(x))
            .IsRequired();
        builder.Property(u => u.ModifiedAt)
            .HasConversion(x => x!.Value, x => new Date(x));
        builder.Property(u => u.Name)
            .HasConversion(x => x.Value, x => new UserName(x))
            .IsRequired();
        builder.Property(u => u.Email)
            .HasConversion(x => x.Value, x => new Email(x))
            .IsRequired();
        builder.Property(u => u.Password)
            .HasConversion(x => x.Value, x => new Password(x))
            .IsRequired();
    }
}