using Domain.Common;

namespace Domain.Entities
{
    public class Booking : AuditableEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShopId { get; set; }
    }
}