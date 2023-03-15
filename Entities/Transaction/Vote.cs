

using Olivia.Entites.Base;
using Olivia.Entites.Master;

namespace Olivia.Entites.Transaction;

public class Vote : BaseEntity
{

    public int Id { get; set; }

    public required Voter Voter { get; set; }

    public required Candidate Candidate { get; set; }

    public required Tenant Tenant { get; set; }
}
