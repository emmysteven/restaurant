using System.ComponentModel.DataAnnotations;

namespace Restaurant.Application.DTOs.Account;

public class ForgotPasswordRequest
{
    [Required] [EmailAddress] public string Email { get; set; }
}