using System;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace Jbet.Domain._Base
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    public interface IAggregate
    {
        Guid Id { get; set; }
    }
}