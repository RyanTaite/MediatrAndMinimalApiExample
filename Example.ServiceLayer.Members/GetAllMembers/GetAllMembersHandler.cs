using Example.Domain.Api;
using Example.ServiceLayer.Members.Interfaces;
using MediatR;

namespace Example.ServiceLayer.Members.GetAllMembers;

// ReSharper disable once UnusedType.Global
public class GetAllMembersHandler : IRequestHandler<GetAllMembersRequest, ApiResult<GetAllMembersResult>>
{
    private readonly IMembersService _membersService;

    public GetAllMembersHandler(IMembersService membersService)
    {
        _membersService = membersService;
    }

    public async Task<ApiResult<GetAllMembersResult>> Handle(GetAllMembersRequest request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return ApiResult<GetAllMembersResult>.RequestCancelled();
        }

        var result = new GetAllMembersResult();
        try
        {
            result.Members = await _membersService.GetAllMembersAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            if (exception.InnerException != null)
            {
                Console.WriteLine(exception.InnerException);
            }
            
            return ApiResult<GetAllMembersResult>.InternalServerError(exception.Message);
        }

        return ApiResult<GetAllMembersResult>.Success(result);
    }
}