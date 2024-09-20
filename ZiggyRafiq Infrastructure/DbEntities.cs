
using Microsoft.EntityFrameworkCore;
using ZiggyRafiq.Domain.Models;

namespace ZiggyRafiq.Infrastructure;

public class DbEntities : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbEntities(DbContextOptions<DbEntities> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure domain models
        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<Order>().HasMany(o => o.Items);
        modelBuilder.Entity<Order>().OwnsOne(o => o.Customer);

        modelBuilder.Entity<OrderItem>().HasKey(oi => oi.Id);
        modelBuilder.Entity<Customer>().HasKey(c => c.Id);

        // Value object configuration
        modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
    }

}
