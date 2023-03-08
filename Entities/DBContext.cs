using Microsoft.EntityFrameworkCore;

namespace Olivia.Entites;

class DBContext : DbContext
{
    public static long InstanceCount;

    public DBContext(DbContextOptions options)
        : base(options)
        => Interlocked.Increment(ref InstanceCount);

    public DbSet<Plan> Plan { get; set; }
    public DbSet<Subcription> Subcription { get; set; }
}