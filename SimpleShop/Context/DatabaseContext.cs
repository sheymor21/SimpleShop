using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SimpleShop.Context.Models;

namespace SimpleShop.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Item> Items { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasKey(x => x.ClientId);
        modelBuilder.Entity<Client>().Property(x => x.ClientId)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(Guid.NewGuid().ToString());

        modelBuilder.Entity<Client>()
            .Ignore(x => x.FullName);

        modelBuilder.Entity<Item>().HasKey(x => x.ItemId);
        modelBuilder.Entity<Item>().Property(x => x.ItemId)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(Guid.NewGuid().ToString());

        modelBuilder.Entity<Client>()
            .HasMany(x => x.Items)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId);
    }
}