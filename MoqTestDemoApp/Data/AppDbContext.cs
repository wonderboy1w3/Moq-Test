using Bogus;
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
        var ids = 1;
        var faker = new Faker<User>()
            .RuleFor(u => u.Id, f => ids++)
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.LastName, f => f.Person.LastName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.Phone, f => f.Person.Phone)
            .RuleFor(u => u.CreatedAt, f => f.Date.Between(DateTime.UtcNow, DateTime.UtcNow));

        modelBuilder.Entity<User>()
            .HasData(faker.Generate(10));
    }
}
