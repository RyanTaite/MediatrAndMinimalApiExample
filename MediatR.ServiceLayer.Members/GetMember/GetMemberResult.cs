using MediatR.Domain.Members;

namespace MediatR.ServiceLayer.Members.GetMember;

public class GetMemberResult
{
    public Member Member { get; set; }
}