using Olivia.Entites.Master;
using System.Collections.Generic;

namespace Olivia.Primitives
{
    public sealed record Tenant
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public List<Voter> Voters { get; init; } = new();
    }
}
