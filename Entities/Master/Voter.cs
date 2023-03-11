namespace Olivia.Entites.Master;

public class Voter
{
    public int Id { get; set; }
    public string SIN { get; set; }
    
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
    public string Phone { get; set; }

    public string Address { get; set; }

    public string Major { get; set; }

    public List<Tenant> Tenants { get; set; }


}