using MediatR;

namespace Jbet.Core.Base
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}