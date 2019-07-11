using MediatR;

namespace Jbet.Core.Base
{
    public interface IQueryHandler<in TQuery, TResponse> :
        IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}