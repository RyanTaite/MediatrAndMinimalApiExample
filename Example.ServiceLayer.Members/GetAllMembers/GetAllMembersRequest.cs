using Example.Domain.Api;
using MediatR;

namespace Example.ServiceLayer.Members.GetAllMembers;

public class GetAllMembersRequest : IRequest<ApiResult<GetAllMembersResult>>;