
using Olivia.Entites.Base;
using Olivia.Entites.Master;
using Olivia.Entities.Master;

namespace Olivia.Entites.Transaction;


public class Subcription : BaseEntity
{
    public int Id { get; set; }

    public required Entities.Master.Tenant Plan { get; set; }

    public required Master.Tenant Tenant { get; set; }


}