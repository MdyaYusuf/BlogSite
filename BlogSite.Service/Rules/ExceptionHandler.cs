using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Rules;

public static class ExceptionHandler<T>
{
  public static ReturnModel<T> HandleException(Exception ex)
  {
    if (ex.GetType() == typeof(NotFoundException))
    {
      return new ReturnModel<T>()
      {
        Message = ex.Message,
        Success = false,
        StatusCode = System.Net.HttpStatusCode.NotFound
      };
    }
    if (ex.GetType() == typeof(ValidationException))
    {
      return new ReturnModel<T>()
      {
        Message = ex.Message,
        Success = false,
        StatusCode = System.Net.HttpStatusCode.BadRequest
      };
    }
    return new ReturnModel<T>()
    {
      Message = ex.Message,
      Success = false,
      StatusCode = System.Net.HttpStatusCode.InternalServerError
    };
  }
}
