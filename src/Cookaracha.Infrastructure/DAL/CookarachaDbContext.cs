using Cookaracha.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cookaracha.Infrastructure.DAL;

internal sealed class CookarachaDbContext : DbContext
{
    public required DbSet<User> Users { get; set; }
    public required DbSet<Product> Products { get; set; }
    public required DbSet<GroceryList> GroceryLists { get; set; }
    public required DbSet<Item> Items { get; set; }

    public CookarachaDbContext(DbContextOptions<CookarachaDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}