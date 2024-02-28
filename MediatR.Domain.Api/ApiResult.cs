using System.Net;

namespace MediatR.Domain.Api;

public class ApiResult<T>
{
    public T Payload { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
    public string ErrorMessage { get; set; } = string.Empty;

    public static ApiResult<T> Success(T payload) => new()
    {
        Payload = payload,
        StatusCode = HttpStatusCode.OK
    };

    public static ApiResult<T> NotFound(string errorMessage = "") => new()
    {
        StatusCode = HttpStatusCode.NotFound,
        ErrorMessage = string.IsNullOrEmpty(errorMessage) ? string.Empty : errorMessage
    };

    public static ApiResult<T> BadRequest(string errorMessage) => new()
    {
        StatusCode = HttpStatusCode.BadRequest, 
        ErrorMessage = errorMessage
    };

    public static ApiResult<T> InternalServerError(string errorMessage) => new()
    {
        StatusCode = HttpStatusCode.InternalServerError, 
        ErrorMessage = errorMessage
    };
    
    public static ApiResult<T> RequestCancelled() => new()
    {
        StatusCode = HttpStatusCode.InternalServerError, 
        ErrorMessage = ErrorMessages.RequestCancelledMessage
    };
}