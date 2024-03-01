using Example.Domain.Api;
using MediatR;
using Example.ServiceLayer.Members.Interfaces;

namespace Example.ServiceLayer.Members.GetMember;

// ReSharper disable once ClassNeverInstantiated.Global
public record GetMemberRequest(Guid MemberId) : IRequest<ApiResult<GetMemberResult>>;