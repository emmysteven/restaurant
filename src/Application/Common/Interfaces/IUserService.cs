using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Application.Common.Wrappers;
using Restaurant.Application.DTOs.Account;

namespace Restaurant.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<Response<AuthResponse>> GetByIdAsync(int id);
        Task<IEnumerable<AuthResponse>> GetAllAsync();
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<AuthResponse> AuthenticateAsync(AuthRequest request, string ipAddress);
        Task<Response<string>> VerifyEmailAsync(int id, string token);
        Task ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<Response<string>> ResetPasswordAsync(ResetPasswordRequest request);
    }
}