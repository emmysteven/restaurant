using System.Collections.Generic;
using Restaurant.Domain.Common;

namespace Restaurant.Domain.Entities
{
    public class Shop : AuditableEntity
    {
        public Shop()
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Booking> Bookings { get; }
    }
}