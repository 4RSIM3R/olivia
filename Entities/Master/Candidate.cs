using Olivia.Entites.Base;

namespace Olivia.Entites.Master;

public class Candidate : BaseEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }


}