using System.Net;
using FluentValidation;
using MediatR.ServiceLayer.MemberAttendance.UpdateAttendance;
using MediatR.ServiceLayer.Members.GetAllMembers;
using MediatR.ServiceLayer.Members.GetMember;
using Microsoft.AspNetCore.Mvc;

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

        app.MapGet("/member/{id:guid}", async (
                IValidator<GetMemberRequest> validator,
                IMediator mediator,
                Guid id) =>
            {
                var request = new GetMemberRequest(id);

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
            .Produces<GetMemberResult>()
            .Produces<string>(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();
    }
}