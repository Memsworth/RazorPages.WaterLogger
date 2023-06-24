namespace WaterLogger.Domain.Models;

public class ServiceResponse
{
    public string Message { get; set; }
    public ResponseStatus Status { get; set; } = ResponseStatus.Success;
}

public class ServiceResponse<T> : ServiceResponse
{
    public T Data { get; set; }
}