using Microsoft.EntityFrameworkCore;
using Olivia.Entites.Base;
using Olivia.Entites.Master;
using Olivia.Entites.Transaction;
using Olivia.Entites.Seeder;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Olivia.Entities.Master;

namespace Olivia.Entites;

public class ApplicationDbContext : DbContext
{
    private static long instanceCount;

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
        => Interlocked.Increment(ref instanceCount);

    // Transaction
    public DbSet<Subcription> Subcription { get; set; }

    public DbSet<Vote> Vote { get; set; }

    // Master
    public DbSet<Candidate> Candidate { get; set; }

    public DbSet<Election> Election { get; set; }

    public DbSet<Entities.Master.Voter> Plan { get; set; }

    public DbSet<Tenant> Tenant { get; set; }

    public DbSet<Master.Voter> Voter { get; set; }

    public override int SaveChanges()
    {
        AddTimestamp();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        AddTimestamp();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DBSeeder(modelBuilder).Seed();
    }

    public void AddTimestamp()
    {

        // get current entities
        var entities = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedAt = now;
            }
            else
            {
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }

    }
}
