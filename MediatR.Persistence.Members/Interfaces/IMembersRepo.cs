using MediatR.Domain.Members;

namespace MediatR.Persistence.Members.Interfaces;

public interface IMembersRepo
{
    Task<List<Member>> GetAllMembersAsync(CancellationToken cancellationToken);

    Task<bool> ToggleMembersAttendanceAsync(Guid memberId, CancellationToken cancellationToken);
}