
using Confy.Infrastructure.Exceptions.Models;

namespace Confy.Infrastructure.Exceptions.Mappers
{
    internal interface IExceptionToErrorMapper
    {
        Error Map(Exception exception);
    }
}