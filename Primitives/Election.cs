using Olivia.Entites.Master;
using System;
using System.Collections.Generic;

namespace Olivia.Primitives;

public sealed class Election
{
    public int Id { get; init; }

    public required Tenant Tenant { get; init; }

    public required List<Candidate> Candidates { get; init; } = new();

    public DateTime StartAt { get; init; }

    public DateTime EndAt { get; init; }
}
