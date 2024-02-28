using MediatR.Domain.Members;

namespace MediatR.ServiceLayer.MemberAttendance.Interfaces;

public interface IMemberAttendanceService
{
    /// <summary>
    /// Toggle the <see cref="Member.IsAttending"/> flag for a <see cref="Member"/>
    /// with a matching <see cref="Member.Id"/> to <see cref="memberId"/>
    /// </summary>
    /// <param name="memberId">The <see cref="Member.Id"/> of the <see cref="Member"/> we want to update</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The new state of <see cref="Member.IsAttending"/></returns>
    Task<bool> ToggleAttendanceForMemberAsync(
        Guid memberId,
        CancellationToken cancellationToken);
}