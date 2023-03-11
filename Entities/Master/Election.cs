using Olivia.Entites.Base;

namespace Olivia.Entites.Master;

class Election : BaseEntity
{

    public int Id { get; set; }

    public Tenant Tenant { get; set; }

    public List<Candidate> Candidates { get; set; }

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

}