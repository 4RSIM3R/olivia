namespace Olivia.Entites;

class Election{

    public int Id { get; set; }

    public DateTime  StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public Tenant Tenant { get; set; }






}