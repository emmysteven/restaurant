using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IShopRepository : IBaseRepository<Shop>
    {
        Task<bool> IsUniqueEmailAsync(string email);
        Task<bool> IsUniqueWebsiteAsync(string website);
        Task<bool> IsUniquePhoneNumberAsync(string phoneNumber);
    }
}