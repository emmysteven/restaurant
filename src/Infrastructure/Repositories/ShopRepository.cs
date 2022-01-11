using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Contexts;

namespace Restaurant.Infrastructure.Repositories;

public class ShopRepository : BaseRepository<Shop>, IShopRepository
{
    private readonly DbSet<Shop> _shops;

    public ShopRepository(DataContext context) : base(context)
    {
        _shops = context.Set<Shop>();
    }

    public async Task<bool> IsUniqueEmailAsync(string email)
    {
        return await _shops.AllAsync(p => p.Email != email);
    }

    public async Task<bool> IsUniqueWebsiteAsync(string website)
    {
        return await _shops.AllAsync(p => p.Website != website);
    }

    public async Task<bool> IsUniquePhoneNumberAsync(string phoneNumber)
    {
        return await _shops.AllAsync(p => p.PhoneNumber != phoneNumber);
    }
}