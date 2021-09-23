using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        protected Entity()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }
    }
}
