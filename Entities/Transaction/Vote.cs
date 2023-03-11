namespace Olivia.Entites;

public class Vote 
{
    public Voter Voter  { get; set; }
    public int CandidateId { get; set; }
    public int VoterId { get; set; }
    public int TenantId { get; set; }
}
