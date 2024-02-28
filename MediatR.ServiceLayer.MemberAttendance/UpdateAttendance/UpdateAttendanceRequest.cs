using MediatR.Domain.Api;

namespace MediatR.ServiceLayer.MemberAttendance.UpdateAttendance;

// ReSharper disable once ClassNeverInstantiated.Global
public class UpdateAttendanceRequest : IRequest<ApiResult<UpdateAttendanceResult>>
{
    /// <summary>
    /// The GUID of the Member to update the attendance for
    /// </summary>
    public Guid MemberId { get; set; }
}