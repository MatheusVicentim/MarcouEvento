using MarcouEvento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarcouEvento.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Party> Parties { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<PersonParty> PersonParties { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
