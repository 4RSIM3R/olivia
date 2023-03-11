using Olivia.Entites.Base;

namespace Olivia.Entites.Master;

public class Plan : BaseEntity
{

    public int Id { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public int MaxVoter { get; set; }

    public int MaxCandidate { get; set; }

    public int MaxDuration { get; set; }

}