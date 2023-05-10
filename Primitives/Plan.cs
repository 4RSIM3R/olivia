namespace Olivia.Primitives;

public sealed record Plan
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required int Price { get; init; }
    public required int MaxVoter { get; init; }
    public required int MaxCandidate { get; init; }
    public required int MaxDurationDay { get; init; }
    public required int GracefulPeriodDay { get; init; }
};