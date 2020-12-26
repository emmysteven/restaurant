using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Common.Interfaces
{
    public interface IShopRepository : IBaseRepository<Shop>
    {
        Task<bool> IsUniqueEmailAsync(string email);
        Task<bool> IsUniqueWebsiteAsync(string website);
        Task<bool> IsUniquePhoneNumberAsync(string phoneNumber);
    }
}