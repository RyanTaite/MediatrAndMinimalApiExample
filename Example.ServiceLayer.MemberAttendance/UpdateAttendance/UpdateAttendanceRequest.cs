using MediatR;
using Example.Domain.Api;

namespace Example.ServiceLayer.MemberAttendance.UpdateAttendance;

// ReSharper disable once ClassNeverInstantiated.Global
public record UpdateAttendanceRequest(Guid MemberId) : IRequest<ApiResult<UpdateAttendanceResult>>;