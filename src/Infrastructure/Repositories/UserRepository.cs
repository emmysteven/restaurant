using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Contexts;

namespace Restaurant.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(DataContext context) : base(context)
        {
            _users = context.Set<User>();
        }

        public async Task<bool> IsUniqueEmailAsync(string email)
        {
            return await _users.AllAsync(p => p.Email != email);
        }

        public async Task<bool> IsUniquePhoneNumberAsync(string phoneNumber)
        {
            return await _users.AllAsync(p => p.PhoneNumber != phoneNumber);
        }
    }
}