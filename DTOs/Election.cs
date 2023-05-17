using Olivia.Entites.Master;
using System;
using System.Collections.Generic;

namespace Olivia.DTOs;

public sealed record ElectionDto
{
    public int Id { get; set; }

    public DateTime StartAt { get; init; }

    public DateTime EndAt { get; init; }
};

public sealed record GetElectionByIdResponse(string Message, ElectionDto Data)
    : ResponseBase<ElectionDto>(Message, Data);

public sealed record GetElectionsResponse(string Message, IEnumerable<ElectionDto> Data)
    : ResponseBase<IEnumerable<ElectionDto>>(Message, Data);