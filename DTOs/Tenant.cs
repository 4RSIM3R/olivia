using Olivia.Entites.Master;
using System.Collections.Generic;

namespace Olivia.DTOs;

public sealed record TenantDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public List<Voter> Voters { get; init; } = new();
}

public sealed record GetTenantByIdResponse(string Message, TenantDto Data)
: ResponseBase<TenantDto>(Message, Data);

public sealed record GetTenantsResponse(string Message, IEnumerable<TenantDto> Data)
    : ResponseBase<IEnumerable<TenantDto>>(Message, Data);
