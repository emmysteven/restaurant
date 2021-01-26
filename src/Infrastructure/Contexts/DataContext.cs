using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        private readonly IDateService _date;
        private readonly ICurrentUserService _currentUser;
        
        public DataContext(DbContextOptions<DataContext> options,
            ICurrentUserService currentUser,
            IDateService date) : base(options)
        {
            _date = date;
            _currentUser = currentUser;
        }

        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _date.NowUtc;
                        // entry.Entity.CreatedBy = _currentUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _date.NowUtc;
                        entry.Entity.LastModifiedBy = _currentUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}