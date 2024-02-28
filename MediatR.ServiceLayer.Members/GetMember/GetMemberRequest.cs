using MediatR.Domain.Api;
using MediatR.ServiceLayer.Members.Interfaces;

namespace MediatR.ServiceLayer.Members.GetMember;

// ReSharper disable once ClassNeverInstantiated.Global
public record GetMemberRequest(Guid MemberId) : IRequest<ApiResult<GetMemberResult>>;