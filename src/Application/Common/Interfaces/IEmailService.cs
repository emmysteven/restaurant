using Restaurant.Application.DTOs.Email;

namespace Restaurant.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(EmailRequest request);
}