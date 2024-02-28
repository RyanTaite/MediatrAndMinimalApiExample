using MediatR.Domain.Members;

namespace MediatR.ServiceLayer.Members.GetAllMembers;

public class GetAllMembersResult
{
    public List<Member> Members { get; set; } = [];
}