using NewNexum.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.DomainObjects
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        public AggregateRoot() : base() { }

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents;

        public void ClearDomainEvents() => _domainEvents?.Clear();

        public void RaiseDomainEvent(IDomainEvent @event)
        {
            _domainEvents?.Add(@event);
        }
    }
}
