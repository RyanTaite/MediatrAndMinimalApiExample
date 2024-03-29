using Example.Domain.Members;

namespace Example.Persistence.Members.Interfaces;

public interface IMembersRepo
{
    Task<List<Member>> GetAllMembersAsync(CancellationToken cancellationToken);

    Task<bool> ToggleMembersAttendanceAsync(Guid memberId, CancellationToken cancellationToken);
    Task<Member> GetMemberAsync(Guid memberId, CancellationToken cancellationToken);
}