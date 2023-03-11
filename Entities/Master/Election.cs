using Olivia.Entites.Base;

namespace Olivia.Entites.Master;

class Election : BaseEntity
{

    public int Id { get; set; }

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public Tenant Tenant { get; set; }

}