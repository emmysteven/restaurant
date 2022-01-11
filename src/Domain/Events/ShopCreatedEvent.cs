using Restaurant.Domain.Common;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Events;

public class ShopCreatedEvent : DomainEvent
{
    public ShopCreatedEvent(Shop item)
    {
        Item = item;
    }
        
    public Shop Item { get; }
}