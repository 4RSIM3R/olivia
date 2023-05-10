
using Olivia.Entites.Base;
using Olivia.Entites.Master;
using Olivia.Entities.Master;

namespace Olivia.Entites.Transaction;


public class Subcription : BaseEntity
{
    public int Id { get; set; }

    public required Entities.Master.Voter Plan { get; set; }

    public required Tenant Tenant { get; set; }


}