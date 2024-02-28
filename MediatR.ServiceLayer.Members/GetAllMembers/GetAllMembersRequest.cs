using MediatR.Domain.Api;

namespace MediatR.ServiceLayer.Members.GetAllMembers;

public class GetAllMembersRequest : IRequest<ApiResult<GetAllMembersResult>>;