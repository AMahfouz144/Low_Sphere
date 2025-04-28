using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public interface IAggregate : IEntity
    {
    }

    public interface IAggregate<T> : IEntity<T>, IAggregate
    {
    }
}
