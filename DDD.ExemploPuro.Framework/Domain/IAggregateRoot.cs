using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.ExemploPuro.Framework
{
    public interface IAggregateRoot<T>
    {
        T Id { get; }

        void Validate();
    }
}
