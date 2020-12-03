using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            Shops = new HashSet<Shop>();
            Bookings = new HashSet<Booking>();
            // IsVerified = Verified.HasValue || PasswordReset.HasValue;
        }

        public int Id { get; set; }
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
        public ICollection<Shop> Shops { get; }
        public ICollection<Booking> Bookings { get; }

        public bool OwnsToken(string token)
        {
            return RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}