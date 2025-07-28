using Cookaracha.Core.Entities;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookaracha.Infrastructure.DAL.Configurations;

internal sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .HasConversion(x => x.Value, x => new EntityId(x))
            .IsRequired();
        builder.Property(i => i.CreatedAt)
            .HasConversion(x => x.Value, x => new Date(x))
            .IsRequired();
        builder.Property(i => i.ModifiedAt)
            .HasConversion(x => x.Value, x => new Date(x));
        builder.Property(i => i.GroceryListId)
            .HasConversion(x => x.Value, x => new EntityId(x))
            .IsRequired();
        builder.Property(i => i.Name)
            .HasConversion(x => x.Value, x => new ItemName(x))
            .IsRequired();
        builder.Property(i => i.Quantity)
            .HasConversion(x => x.Value, x => new ItemQuantity(x))
            .IsRequired();
        builder.Property(i => i.ProductId)
            .HasConversion(x => x.Value, x => new EntityId(x))
            .IsRequired(false);
    }
}