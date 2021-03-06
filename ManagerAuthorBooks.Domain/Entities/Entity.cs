﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
