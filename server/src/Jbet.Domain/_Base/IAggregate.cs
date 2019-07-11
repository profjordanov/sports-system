using System;

namespace Jbet.Domain._Base
{
    public interface IAggregate
    {
        Guid Id { get; set; }
    }
}