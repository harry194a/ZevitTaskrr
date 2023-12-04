
namespace ZevitTask.Application.comm.Exeption;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is ServiceException serviceException)
        {
            context.Result = new ObjectResult(new ErrorResponse($"Error: {serviceException.Message}", serviceException.ErrorCode))
            {
                StatusCode = (int)HttpStatusCode.ServiceUnavailable
            };
        }
        
        else
        {
            context.Result = new ObjectResult(new ErrorResponse("An unexpected error occurred", ErrorCode.UnknownError))
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}

public class ErrorResponse
{
    public string Message { get; set; }
    public ErrorCode ErrorCode { get; set; }

    public ErrorResponse(string message, ErrorCode errorCode)
    {
        Message = message;
        ErrorCode = errorCode;
    }
}

public class ServiceException : Exception
{
    public ErrorCode ErrorCode { get; }

    public ServiceException(string message, ErrorCode errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}


public enum ErrorCode
{
    UnknownError,
    NotExist
}
