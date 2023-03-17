using System.Collections.Generic;

namespace Olivia.Entites.Master;

public class Voter
{
    public int Id { get; set; }
    public required string SIN { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required string Phone { get; set; }

    public required string Address { get; set; }

    public required string Major { get; set; }

    public List<Tenant> Tenants { get; set; } = new();


}
