

using Olivia.Entites.Base;
using Olivia.Entites.Master;

namespace Olivia.Entites.Transaction;

public class Vote : BaseEntity
{
    public Voter Voter { get; set; }
    public Candidate Candidate { get; set; }
    public Tenant Tenant { get; set; }
}
