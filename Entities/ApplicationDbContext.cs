using Microsoft.EntityFrameworkCore;
using Olivia.Entites.Base;
using Olivia.Entites.Master;
using Olivia.Entites.Transaction;
using Olivia.Entites.Seeder;

namespace Olivia.Entites;

class ApplicationDbContext : DbContext
{
    public static long InstanceCount;

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
        => Interlocked.Increment(ref InstanceCount);

    // Transaction
    public DbSet<Subcription> Subcription { get; set; }

    public DbSet<Vote> Vote { get; set; }

    // Master
    public DbSet<Candidate> Candidate { get; set; }

    public DbSet<Election> Election { get; set; }

    public DbSet<Plan> Plan { get; set; }

    public DbSet<Tenant> Tenant { get; set; }

    public DbSet<Voter> Voter { get; set; }

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
            var now = DateTime.UtcNow; // current datetime

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
