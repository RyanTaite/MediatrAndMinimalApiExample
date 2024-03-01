using System.Net;
using FluentValidation;
using MediatR;
using Example.ServiceLayer.MemberAttendance.UpdateAttendance;

namespace Example.Api.Endpoints;

public static class AttendanceEndpoints
{
    public static void MapAttendanceEndpoints(this WebApplication app)
    {
        app.MapPut("/attendance/toggle",
                async (
                    IValidator<UpdateAttendanceRequest> validator,
                    IMediator mediator,
                    UpdateAttendanceRequest request
                ) =>
                {
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }

                    var result = await mediator.Send(request);
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
            .Produces<UpdateAttendanceResult>()
            .Produces<string>(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();
    }
}