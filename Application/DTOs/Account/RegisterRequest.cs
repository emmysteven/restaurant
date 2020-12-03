using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs.Account
{
    public class RegisterRequest
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Required] public string PhoneNumber { get; set; }

        public Roles Role { get; set; }

        [Required] [MinLength(8)] public string Password { get; set; }

        // [Required]
        // [Compare("Password")]
        // public string ConfirmPassword { get; set; }
    }
}