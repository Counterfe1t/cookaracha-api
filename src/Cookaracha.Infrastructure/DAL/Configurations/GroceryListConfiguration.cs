using Cookaracha.Core.Entities;
using Cookaracha.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookaracha.Infrastructure.DAL.Configurations;

internal sealed class GroceryListConfiguration : IEntityTypeConfiguration<GroceryList>
{
    public void Configure(EntityTypeBuilder<GroceryList> builder)
    {
        builder.HasKey(gl => gl.Id);
        builder.Property(gl => gl.Id)
            .HasConversion(x => x.Value, x => new EntityId(x))
            .IsRequired();
        builder.Property(gl => gl.CreatedAt)
            .HasConversion(x => x.Value, x => new Date(x))
            .IsRequired();
        builder.Property(gl => gl.ModifiedAt)
            .HasConversion(x => x!.Value, x => new Date(x));
        builder.Property(gl => gl.Name)
            .HasConversion(x => x.Value, x => new GroceryListName(x))
            .IsRequired();
        builder.HasMany(gl => gl.Items)
            .WithOne()
            .HasForeignKey(i => i.GroceryListId);
    }
}