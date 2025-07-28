using Cookaracha.Core.Entities;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookaracha.Infrastructure.DAL.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(x => x.Value, x => new EntityId(x))
            .IsRequired();
        builder.Property(p => p.CreatedAt)
            .HasConversion(x => x.Value, x => new Date(x))
            .IsRequired();
        builder.Property(p => p.ModifiedAt)
            .HasConversion(x => x.Value, x => new Date(x));
        builder.Property(p => p.Name)
            .HasConversion(x => x.Value, x => new ProductName(x))
            .IsRequired();
        builder.HasMany<Item>()
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId)
            .IsRequired(false);
    }
}