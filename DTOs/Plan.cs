using System.Collections.Generic;

namespace Olivia.DTOs;

public sealed record PlanDTO(
    int Id,
    string Name
);

public sealed record GetPlanByIdResponse(string Message, PlanDTO Data) 
    : ResponseBase<PlanDTO>(Message, Data);

public sealed record GetPlansResponse(string Message, IEnumerable<PlanDTO> Data)
    : ResponseBase<IEnumerable<PlanDTO>>(Message, Data);
