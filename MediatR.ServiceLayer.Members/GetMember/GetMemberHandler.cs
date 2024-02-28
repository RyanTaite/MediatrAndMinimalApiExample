using MediatR.Domain.Api;
using MediatR.ServiceLayer.Members.Interfaces;

namespace MediatR.ServiceLayer.Members.GetMember;

// ReSharper disable once UnusedType.Global
public class GetMemberHandler : IRequestHandler<GetMemberRequest, ApiResult<GetMemberResult>>
{
    private readonly IMembersService _membersService;

    public GetMemberHandler(IMembersService membersService)
    {
        _membersService = membersService;
    }

    public async Task<ApiResult<GetMemberResult>> Handle(GetMemberRequest request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ApiResult<GetMemberResult>.RequestCancelled();
        }

        var result = new GetMemberResult();
        try
        {
            result.Member = await _membersService.GetMemberAsync(request.MemberId, cancellationToken);
        }
        catch (KeyNotFoundException keyNotFoundException)
        {
            return ApiResult<GetMemberResult>.NotFound(keyNotFoundException.Message);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            if (exception.InnerException != null)
            {
                Console.WriteLine(exception.InnerException);
            }

            return ApiResult<GetMemberResult>.InternalServerError(exception.Message);
        }

        return ApiResult<GetMemberResult>.Success(result);
    }
}