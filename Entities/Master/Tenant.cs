namespace Olivia.Entites.Master;

using Entites.Base;

public class Tenant : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<Voter> Voters { get; set; }
}