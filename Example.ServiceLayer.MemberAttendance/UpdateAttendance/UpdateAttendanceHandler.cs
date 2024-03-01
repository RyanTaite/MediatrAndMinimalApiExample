using Example.ServiceLayer.MemberAttendance.Interfaces;
using MediatR;
using Example.Domain.Api;

namespace Example.ServiceLayer.MemberAttendance.UpdateAttendance;

// ReSharper disable once UnusedType.Global
public class UpdateAttendanceHandler : IRequestHandler<UpdateAttendanceRequest, ApiResult<UpdateAttendanceResult>>
{
    private readonly IMemberAttendanceService _memberAttendanceService;

    public UpdateAttendanceHandler(IMemberAttendanceService memberAttendanceService)
    {
        _memberAttendanceService = memberAttendanceService;
    }


    public async Task<ApiResult<UpdateAttendanceResult>> Handle(UpdateAttendanceRequest request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ApiResult<UpdateAttendanceResult>.RequestCancelled();
        }

        bool isAttending;
        
        try
        {
            isAttending = await _memberAttendanceService.ToggleAttendanceForMemberAsync(
                request.MemberId,
                cancellationToken
            );
        }
        catch (KeyNotFoundException keyNotFoundException)
        {
            return ApiResult<UpdateAttendanceResult>.NotFound(keyNotFoundException.Message);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            if (exception.InnerException != null)
            {
                Console.WriteLine(exception.InnerException);
            }
            
            return ApiResult<UpdateAttendanceResult>.InternalServerError(exception.Message);
        }

        var updateAttendanceResult = new UpdateAttendanceResult
        {
            IsAttending = isAttending
        };

         return ApiResult<UpdateAttendanceResult>.Success(updateAttendanceResult);
    }
}