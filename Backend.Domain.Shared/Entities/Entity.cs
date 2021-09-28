using System;

namespace Backend.Domain.Shared.Entities
{
    public abstract class Entity
    {
        protected Entity() => Id = Guid.NewGuid();

        public Guid Id { get; }
    }
}