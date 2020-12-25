using System.Threading.Tasks;
using Application.DTOs.Email;

namespace Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}