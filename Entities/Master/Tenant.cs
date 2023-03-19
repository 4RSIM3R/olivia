namespace Olivia.Entites.Master;

using System.Collections.Generic;
using Entites.Base;

public class Tenant : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public List<Voter> Voters { get; set; } = new();
}
