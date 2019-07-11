using MediatR;
using System;
using System.Threading.Tasks;

namespace Jbet.Domain.Events.Base
{
    public interface IEventBus
    {
        Task<Unit> Publish<TEvent>(Guid streamId, params TEvent[] events)
            where TEvent : IEvent;
    }
}