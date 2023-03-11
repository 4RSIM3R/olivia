using Microsoft.EntityFrameworkCore;
using Olivia.Entites.Master;

namespace Olivia.Entites.Seeder;

public class DBSeeder
{

    private readonly ModelBuilder ModelBuilder;

    public DBSeeder(ModelBuilder modelBuilder)
    {
        ModelBuilder = modelBuilder;
    }

    public void Seed()
    {
        ModelBuilder.Entity<Tenant>().HasData(
            new Tenant() { Id = 1, Name = "HMTI", Email = "hmti@polinema.ac.id" }
        );
    }
}