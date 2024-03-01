using Example.Domain.Members;

namespace Example.ServiceLayer.Members.Interfaces;

public interface IMembersService
{
    Task<List<Member>> GetAllMembersAsync(CancellationToken cancellationToken);
    Task<Member> GetMemberAsync(Guid memberId, CancellationToken cancellationToken);
}