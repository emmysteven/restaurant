using Restaurant.Domain.Common;

namespace Restaurant.Domain.Entities;

public class Booking : AuditableEntity
{
    public int Id { get; set; }
    public int ShopId { get; set; }
}