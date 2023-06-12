using Microsoft.EntityFrameworkCore;
using MoqTestDemoApp.Models;

namespace MoqTestDemoApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property<DateOnly>("UpdatedAt");
    }
}
