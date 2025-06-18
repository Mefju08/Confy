using Confy.Domain.Exceptions;
using Confy.Infrastructure.Exceptions.Models;
using Humanizer;
namespace Confy.Infrastructure.Exceptions.Mappers
{
    internal sealed class ExceptionToErrorMapper : IExceptionToErrorMapper
    {
        public Error Map(Exception exception)
        {
            switch (exception)
            {
                case ConfyException ex:
                    return new Error(GetErrorCode(ex), exception.Message);
                default:
                    return new Error("fatal_error", "Unexpected error");
            }
        }

        private static string GetErrorCode(object obj)
            => obj.GetType().Name.Underscore().ToLower().Replace("_exception", string.Empty);
    }
}
