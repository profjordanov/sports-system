using Jbet.Domain;
using MediatR;
using Optional;

namespace Jbet.Core.Base
{

    public interface ICommand : IRequest<Option<Unit, Error>>
    {
    }

    public interface ICommand<TResult> : IRequest<Option<TResult, Error>>
    {
    }
}