
using Olivia.Entites.Base;
using Olivia.Entites.Master;

namespace Olivia.Entites.Transaction;


public class Subcription : BaseEntity
{
    public int Id { get; set; }

    public required Plan Plan { get; set; }

    public required Tenant Tenant { get; set; }


}