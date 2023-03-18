using System.Collections.Generic;

namespace Olivia.DTOs;

public sealed record PlanDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Price { get; init; }
    public int MaxVoter { get; init; }
    public int MaxCandidate { get; init; }
    public int MaxDurationDay { get; init; }
    public int GracefulPeriodDay { get; init; }
};

public sealed record GetPlanByIdResponse(string Message, PlanDto Data)
    : ResponseBase<PlanDto>(Message, Data);

public sealed record GetPlansResponse(string Message, IEnumerable<PlanDto> Data)
    : ResponseBase<IEnumerable<PlanDto>>(Message, Data);