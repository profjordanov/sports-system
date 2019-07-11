using Jbet.Domain.Events.Base;
using Marten;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jbet.Business.Base
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IDocumentSession _session;

        public EventBus(IMediator mediator, IDocumentSession session)
        {
            _mediator = mediator;
            _session = session;
        }

        public async Task<Unit> Publish<TEvent>(Guid streamId, params TEvent[] events)
            where TEvent : IEvent
        {
            foreach (var @event in events)
            {

                _session.Events.Append(streamId, @event); // Append overload that
                                                          // takes a collection of
                                                          // events they will not be published
                await _mediator.Publish(@event);
            }

            await _session.SaveChangesAsync();
            return Unit.Value;
        }
    }
}