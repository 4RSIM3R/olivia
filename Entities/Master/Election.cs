using Olivia.Entites.Base;

namespace Olivia.Entites.Master;

class Election : BaseEntity
{

    public int Id { get; set; }

    public required Tenant Tenant { get; set; }

    public List<Candidate> Candidates { get; set; } = new();

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

}