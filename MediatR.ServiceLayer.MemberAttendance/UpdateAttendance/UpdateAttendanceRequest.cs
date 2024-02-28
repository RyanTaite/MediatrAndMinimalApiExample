using MediatR.Domain.Api;

namespace MediatR.ServiceLayer.MemberAttendance.UpdateAttendance;

// ReSharper disable once ClassNeverInstantiated.Global
public record UpdateAttendanceRequest(Guid MemberId) : IRequest<ApiResult<UpdateAttendanceResult>>;