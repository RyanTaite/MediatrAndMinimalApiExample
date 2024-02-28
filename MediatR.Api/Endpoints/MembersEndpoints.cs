using System.Net;
using MediatR.ServiceLayer.Members.GetAllMembers;

namespace MediatR.Api.Endpoints;

public static class MembersEndpoints
{
    public static void MapMembersEndpoints(this WebApplication app)
    {
        app.MapGet("/members", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllMembersRequest());
                return result.StatusCode switch
                {
                    HttpStatusCode.OK => Results.Ok(result.Payload),
                    HttpStatusCode.NotFound => Results.NotFound(result.ErrorMessage),
                    HttpStatusCode.BadRequest => Results.BadRequest(result.ErrorMessage),
                    HttpStatusCode.InternalServerError => Results.Problem(detail: result.ErrorMessage),
                    _ => Results.StatusCode((int)result.StatusCode)
                };
            })
            // These `Produces...` statements tell OpenApi (the Swagger page) what possible results the endpoint can return
            .Produces<GetAllMembersResult>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}