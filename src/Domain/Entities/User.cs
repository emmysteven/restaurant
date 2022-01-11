using System;
using System.Collections.Generic;
using Restaurant.Domain.Common;
using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Entities;

public class User : AuditableEntity
{
    public User()
    {
        Shops = new HashSet<Shop>();
        Bookings = new HashSet<Booking>();
        // IsVerified = Verified.HasValue || PasswordReset.HasValue;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime? PasswordReset { get; set; }
    public string PhoneNumber { get; set; }
    public Roles Role { get; set; }

    public bool AcceptTerms { get; set; }
    public string VerificationToken { get; set; }
    public string ResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }
    public DateTime? Verified { get; set; }
    public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
    public ICollection<Shop> Shops { get; set; }
    public ICollection<Booking> Bookings { get; set; }

    public bool OwnsToken(string token)
    {
        return RefreshTokens?.Find(x => x.Token == token) != null;
    }
}