using Example.Persistence.Members;
using Example.Persistence.Members.Interfaces;
using Example.ServiceLayer.MemberAttendance.Interfaces;

namespace Example.ServiceLayer.MemberAttendance;

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