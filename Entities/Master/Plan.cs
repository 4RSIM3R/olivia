using Olivia.Entites.Base;
using Olivia.Entites.Master;
using System.Collections.Generic;

namespace Olivia.Entities.Master;

public class Voter : BaseEntity
{

    public int Id { get; set; }

    public required string Name { get; set; }

    public int Price { get; set; }

    public int MaxVoter { get; set; }

    public int MaxCandidate { get; set; }

    public int MaxDurationDay { get; set; }

    public int GracefulPeriodDay { get; set; }
    public string SIN { get; internal set; }
    public string Email { get; internal set; }
    public string Password { get; internal set; }
    public string Phone { get; internal set; }
    public string Address { get; internal set; }
    public string Major { get; internal set; }
    public List<Tenant> Tenants { get; internal set; }
}