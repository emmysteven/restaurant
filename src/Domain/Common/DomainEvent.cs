using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Common;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; set; }
}
public abstract class DomainEvent
{
    protected DomainEvent()
    {
    }
    public bool IsPublished { get; set; }
}