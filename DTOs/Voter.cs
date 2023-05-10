using Olivia.Entites.Master;
using System.Collections.Generic;

namespace Olivia.DTOs;

    public sealed record VoterDto
    {
        public int Id { get; set; }
        public required string SIN { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string Major { get; set; }
        public List<Tenant> Tenants { get; set; } = new();
    }

    public sealed record GetVoterByIdResponse(string Message, VoterDto Data)
    : ResponseBase<VoterDto>(Message, Data);

    public sealed record GetVotersResponse(string Message, IEnumerable<VoterDto> Data)
        : ResponseBase<IEnumerable<VoterDto>>(Message, Data);

