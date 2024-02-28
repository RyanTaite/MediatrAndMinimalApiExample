using MediatR.Domain.Members;

namespace MediatR.ServiceLayer.Members.Interfaces;

public interface IMembersService
{
    Task<List<Member>> GetAllMembersAsync(CancellationToken cancellationToken);
    Task<Member> GetMemberAsync(Guid memberId, CancellationToken cancellationToken);
}