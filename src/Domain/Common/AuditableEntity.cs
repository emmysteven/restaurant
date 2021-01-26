using System;

namespace Restaurant.Domain.Common
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}