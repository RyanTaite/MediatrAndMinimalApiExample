using MediatR.Persistence.Members;
using MediatR.Persistence.Members.Interfaces;
using MediatR.ServiceLayer.MemberAttendance.Interfaces;

namespace MediatR.ServiceLayer.MemberAttendance;

public class MemberAttendanceService : IMemberAttendanceService
{
    private readonly IMembersRepo _membersRepo;

    public MemberAttendanceService(IMembersRepo membersRepo)
    {
        _membersRepo = membersRepo;
    }

    /// <inheritdoc/>
    public async Task<bool> ToggleAttendanceForMemberAsync(
        Guid memberId,
        CancellationToken cancellationToken)
    {
        return await _membersRepo.ToggleMembersAttendanceAsync(memberId, cancellationToken);
    }
}