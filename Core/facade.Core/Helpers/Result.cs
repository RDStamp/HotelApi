using Microsoft.AspNetCore.Http;

namespace facade.Core.Helpers;

public class Result<T>
    where T : class
{
    public Result(bool isSuccess, T value, string errorMessage, int statusCode)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public bool IsSuccess { get; }

    public T Value { get; }

    public string ErrorMessage { get; }

    public int StatusCode { get; }

    public static Result<T> SuccessResult(T value) => new(true, value, string.Empty, StatusCodes.Status200OK);

    public static Result<T> FailedResult(string errorMessage, int statusCode)
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        => new(false, default, errorMessage, statusCode);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}

public class Result
{
    public Result(bool isSuccess, string errorMessage, int statusCode)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }

    public bool IsSuccess { get; }

    public string ErrorMessage { get; }

    public int StatusCode { get; }

    public static Result SuccessResult() => new(true, string.Empty, StatusCodes.Status200OK);

    public static Result FailedResult(string errorMessage, int statusCode)
        => new(false, errorMessage, statusCode);
}
