using Olivia.Entites.Base;

namespace Olivia.Entities.Master;

public class Tenant : BaseEntity
{

    public int Id { get; set; }

    public required string Name { get; set; }

    public int Price { get; set; }

    public int MaxVoter { get; set; }

    public int MaxCandidate { get; set; }

    public int MaxDurationDay { get; set; }

    public int GracefulPeriodDay { get; set; }

}